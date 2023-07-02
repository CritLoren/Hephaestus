// Hephaestus.cs
// A mutagen synthesis patcher that randomizes the height of all human COBJs in a deterministic manner
// The patcher can be configured with a minimum and maximum value for each race and gender of that race

using Mutagen.Bethesda;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Aspects;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace Hephaestus
{
    public class Program
    {
        static Lazy<Settings> _settings = null!;
        public static Settings settings => _settings.Value;

        public static async Task<int> Main(string[] args)
        {
            // Run the patcher
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "Hephaestus.esp")
                .SetAutogeneratedSettings("Settings", "settings.json", out _settings)
                .Run(args);
        }

        // A method to run the patch on a given load order
        private static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            Console.WriteLine(String.Empty);
            Console.WriteLine("=================================================");
            Console.WriteLine("Building cache ...");
            Console.WriteLine("=================================================");
            Console.WriteLine(String.Empty);

            // **To Do**
            // 7. We patch the blacksmithing intro quest to give you the relevant schematics with the materials.

            Dictionary<FormKey, List<FormKey>> itemCOBJs = new();
            Dictionary<FormKey, List<FormKey>> itemLVLIs = new();
            Dictionary<FormKey, FormKey> itemBOOK = new();
            Dictionary<FormKey, Dictionary<String, FormKey>> bookLVLIs = new();
            List<FormKey> benchWhitelist =
                new()
                {
                    Skyrim.Keyword.CraftingSmithingForge.FormKey,
                    Skyrim.Keyword.CraftingCookpot.FormKey,
                    Skyrim.Keyword.CraftingTanningRack.FormKey
                };

            foreach (
                IConstructibleObjectGetter baseCOBJ in state.LoadOrder.PriorityOrder
                    .ConstructibleObject()
                    .WinningOverrides()
            )
            {
                // Sanity checks to lower processing count
                if (
                    baseCOBJ.Items == null
                    || !benchWhitelist.Contains(baseCOBJ.WorkbenchKeyword.FormKey)
                )
                    continue;
                if (
                    !baseCOBJ.CreatedObject.TryResolve(state.LinkCache, out var createdItem)
                    || createdItem is not INamedGetter createdItemName
                    || createdItem is not IWeightValueGetter createdItemValue
                )
                    continue;

                // Base lists to reference
                List<FormKey> LVLIFormList = new List<FormKey>();

                // Check if there are any LVLIs that this item is dropped in
                foreach (
                    var baseLVLI in state.LoadOrder.PriorityOrder.LeveledItem().WinningOverrides()
                )
                {
                    if (baseLVLI.Entries == null)
                        continue;
                    if (baseLVLI.Entries.Any(e => e.Data?.Reference.FormKey == createdItem.FormKey))
                    {
                        if (!itemLVLIs.ContainsKey(createdItem.FormKey))
                            itemLVLIs.Add(createdItem.FormKey, new List<FormKey>());

                        if (!itemLVLIs[createdItem.FormKey].Contains(baseLVLI.FormKey))
                            itemLVLIs[createdItem.FormKey].Add(baseLVLI.FormKey);
                    }
                }

                // if no relevant LVLIs, skip item early
                if (!itemLVLIs.ContainsKey(createdItem.FormKey))
                    continue;

                // add COBJ now since it's already passed the LVLI check
                if (!itemCOBJs.ContainsKey(createdItem.FormKey))
                    itemCOBJs.Add(createdItem.FormKey, new List<FormKey>());
                itemCOBJs[createdItem.FormKey].Add(baseCOBJ.FormKey);
            }

            Console.WriteLine(String.Empty);
            Console.WriteLine("=================================================");
            Console.WriteLine("Assigning item types and prepping things ...");
            Console.WriteLine("=================================================");
            Console.WriteLine(String.Empty);

            foreach (var createdItemFormKey in itemCOBJs.Keys)
            {
                // Pull created item
                if (
                    !state.LinkCache.TryResolve<IItemGetter>(
                        createdItemFormKey,
                        out var createdItem
                    )
                    || createdItem is not INamedGetter createdItemName
                    || createdItem is not IWeightValueGetter createdItemValue
                )
                    continue;

                if (settings.ShowDebugLogs)
                {
                    Console.WriteLine(String.Empty);
                    Console.WriteLine("=================================================");
                    Console.WriteLine(String.Empty);
                    Console.WriteLine($"Found {createdItemName.Name} ...");
                    // Console.WriteLine("It's referenced in the following COBJs:");
                    // Console.WriteLine($"{String.Join('\n', itemCOBJs[createdItem.FormKey])}");
                    // Console.WriteLine("And the following LVLIs:");
                    // Console.WriteLine($"{String.Join('\n', itemLVLIs[createdItem.FormKey])}");
                }
                else
                    Console.WriteLine($"Patching for {createdItemName.Name} ...");

                // Deterministic seed
                var random = new Random(createdItem.FormKey.ID.GetHashCode());

                // Base Object
                string? objName = createdItemName.Name;
                string? objEditorID = createdItem.EditorID;
                uint objValue = createdItemValue.Value;
                string? objType = "Misc";

                // Book variables
                Book book;
                Book bookFragment;
                var schematicBase = Skyrim.Scroll.EbonyFleshScroll.TryResolve(state.LinkCache);
                var objInvArt = new FormLinkNullable<IStaticGetter>(
                    schematicBase?.MenuDisplayObject.FormKey
                );
                Model objModel = schematicBase?.Model?.DeepCopy() ?? new Model();
                ObjectBounds objBounds =
                    schematicBase?.ObjectBounds?.DeepCopy() ?? new ObjectBounds();
                string? objBench = "Forge";
                string? processName = "crafting";
                string schematicType = "Schematic";
                string? requiredItems = String.Empty;
                string? aAn;
                if (objName?.IndexOfAny(vowels) == 0)
                    aAn = "an";
                else
                    aAn = "a";

                // Assigning item types
                switch (createdItem)
                {
                    case IWeaponGetter:
                        objType = "Weapon";
                        break;
                    case IArmorGetter armorObj:
                        var flagToCheck = armorObj.BodyTemplate;
                        if (flagToCheck == null)
                            continue;
                        switch (flagToCheck.FirstPersonFlags)
                        {
                            case BipedObjectFlag.Hands
                            or BipedObjectFlag.Feet:
                                aAn = "a pair of";
                                break;
                            case BipedObjectFlag.Amulet
                            or BipedObjectFlag.Ring:
                                objType = "Jewelry";
                                break;
                            default:
                                objType = "Armor";
                                break;
                        }
                        if (armorObj.EquipmentType.FormKey == Skyrim.EquipType.Shield.FormKey)
                        {
                            objType = "Shield";
                        }
                        break;
                }
                if (settings.ShowDebugLogs)
                {
                    Console.WriteLine(String.Empty);
                    Console.WriteLine($"Creating {objName} schematics and patching COBJs ...");
                    Console.WriteLine(String.Empty);
                }

                foreach (FormKey cobjFormKey in itemCOBJs[createdItemFormKey])
                {
                    // Define COBJ
                    if (
                        !state.LinkCache.TryResolve<IConstructibleObjectGetter>(
                            cobjFormKey,
                            out var cobj
                        )
                    )
                        continue;

                    // Set values based on bench
                    if (
                        cobj.WorkbenchKeyword.FormKey
                        == Skyrim.Keyword.CraftingSmithingForge.FormKey
                    )
                    {
                        objBench = "Forge";
                        processName = "smelting";
                    }
                    else if (
                        cobj.WorkbenchKeyword.FormKey == Skyrim.Keyword.CraftingTanningRack.FormKey
                    )
                    {
                        objBench = "Tanning Rack";
                        processName = "tanning";
                    }
                    else if (
                        cobj.WorkbenchKeyword.FormKey == Skyrim.Keyword.CraftingCookpot.FormKey
                    )
                    {
                        objBench = "Cooking Pot";
                        processName = "cooking";
                        schematicType = "Recipe";
                    }
                    ;

                    if (cobj.Items == null)
                        continue;
                    foreach (var reqItem in cobj.Items)
                    {
                        if (!reqItem.Item.Item.TryResolve(state.LinkCache, out var reqItemObj))
                            continue;
                        if (reqItemObj is not INamedGetter namedItem)
                            continue;
                        requiredItems += $"{namedItem.Name}\n";
                    }
                    ;

                    // Building the flavour text
                    string[] flavourText =
                    {
                        $"looks like the notes of a madman, though I can somewhat decypher it. It seems to detail the process of",
                        $"seems to have been teared off from someone's journal. It seems to explain the process of",
                        $"seems to have been written by an apprentice, from the looks of it it describes the process of",
                        $"goes into great detail on the steps of",
                        $"contains the secrets to",
                        $"is filled with scribbles and notes on the steps of",
                        $"still has some stains of blood on it, it describes the process of"
                    };

                    if (!itemBOOK.ContainsKey(createdItem.FormKey))
                    {
                        // Define how many times an item needs to be broken down
                        int min = 5;
                        int max = 10;
                        uint noteToSchematicRatio = (uint)
                            Math.Max(Math.Round(min + (max - min) * (float)random.NextDouble()), 1);

                        // create a new book
                        book = state.PatchMod.Books.AddNew(objEditorID);

                        // Set the book properties
                        book.EditorID = $"{objEditorID}_{schematicType}";
                        book.Name = $"{objType} {schematicType}: {objName}";
                        book.Description =
                            $"A {schematicType.ToLower()} that provides guidance on {processName} {aAn} {objName}. Without this, I won't be able to remember how to craft the item anymore.";
                        book.Value = objValue * noteToSchematicRatio;
                        book.Weight = 0.25f;
                        book.Model = objModel;
                        book.InventoryArt = objInvArt;
                        book.ObjectBounds = objBounds;
                        book.BookText =
                            $"[pagebreak]\n<p align='center'>\n\n\n{objName} {schematicType}\n\n\n\n</p>\n[pagebreak]\n<p align='left'>\nMaterials needed:\n{requiredItems}\nThis {schematicType.ToLower()} {flavourText[random.Next(flavourText.Length)]} {processName} {aAn} {objName} at a {objBench}.";
                        ;
                        book.Type = Book.BookType.NoteOrScroll;
                        book.Keywords = new Noggog.ExtendedList<IFormLinkGetter<IKeywordGetter>>();
                        book.Keywords.Add(Skyrim.Keyword.VendorItemRecipe);

                        // Add book to dict
                        itemBOOK.Add(createdItem.FormKey, book.FormKey);

                        if (settings.ShowDebugLogs)
                        {
                            Console.WriteLine($"Created {book.Name}:");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine(book.BookText);
                            Console.WriteLine("-----------------------");
                            Console.WriteLine(String.Empty);
                        }

                        // create a new book fragment
                        bookFragment = state.PatchMod.Books.AddNew(book.EditorID);
                        string? counter = "a couple";
                        switch (noteToSchematicRatio)
                        {
                            case (<= 6):
                                counter = "a small amount";
                                break;
                            case (<= 8):
                                counter = "a fair amount";
                                break;
                            case (<= 10):
                                counter = "a larger amount";
                                break;
                        }

                        // Set the fragment properties
                        bookFragment.EditorID = $"{objEditorID}_{schematicType}_Fragment";
                        bookFragment.Name = $"{schematicType} notes on {objName}";
                        bookFragment.Description =
                            $"Notes I made on the {processName} of {aAn} {objName}. Maybe if I collect {counter} of these I can then write up my own {schematicType.ToLower()}.";
                        bookFragment.Value = (uint)(
                            Math.Min(Math.Round(objValue / ((double)noteToSchematicRatio * 1.2)), 1)
                        );
                        bookFragment.Weight = 0.1f;
                        bookFragment.Model = objModel;
                        book.InventoryArt = objInvArt;
                        bookFragment.ObjectBounds = objBounds;
                        bookFragment.BookText =
                            $"After breaking down {aAn} {objName} I feel like I've grown closer to understanding the process of {processName} it. I should study more of these if I want to be able to craft {aAn} {objName} of my own.";
                        string bookEditorIDTemplate = $"{objEditorID}_{schematicType}";
                        ;
                        bookFragment.Type = Book.BookType.NoteOrScroll;
                        bookFragment.Keywords = new Noggog.ExtendedList<
                            IFormLinkGetter<IKeywordGetter>
                        >();
                        bookFragment.Keywords.Add(Skyrim.Keyword.VendorItemRecipe);

                        // Create COBJ item -> fragment
                        var itemToFragmentCOBJ = state.PatchMod.ConstructibleObjects.AddNew();

                        itemToFragmentCOBJ.EditorID = $"{objEditorID}_Breakdown_Recipe";
                        itemToFragmentCOBJ.CreatedObject =
                            new FormLinkNullable<IConstructibleGetter>(bookFragment.FormKey);

                        itemToFragmentCOBJ.Items = new Noggog.ExtendedList<ContainerEntry>();
                        itemToFragmentCOBJ.Items.Add(
                            new ContainerEntry()
                            {
                                Item = new ContainerItem()
                                {
                                    Item = new FormLink<IItemGetter>(createdItem.FormKey),
                                    Count = 1
                                },
                            }
                        );

                        // Set which place the items disassemble
                        if (
                            cobj.WorkbenchKeyword.FormKey
                            == Skyrim.Keyword.CraftingSmithingForge.FormKey
                        )
                        {
                            itemToFragmentCOBJ.WorkbenchKeyword =
                                new FormLinkNullable<IKeywordGetter>(
                                    Skyrim.Keyword.CraftingSmelter.FormKey
                                );
                        }
                        else
                        {
                            itemToFragmentCOBJ.WorkbenchKeyword =
                                new FormLinkNullable<IKeywordGetter>(cobj.WorkbenchKeyword.FormKey);
                        }
                        itemToFragmentCOBJ.CreatedObjectCount = (ushort?)
                            itemToFragmentCOBJ.Items.Count;

                        // Add conditions (so it doesn't clutter the menu)
                        GetItemCountConditionData itemToFragmentCOBJCond =
                            new GetItemCountConditionData();
                        itemToFragmentCOBJCond.ItemOrList = new FormLinkOrIndex<IItemOrListGetter>(
                            itemToFragmentCOBJCond,
                            createdItem.FormKey
                        );
                        itemToFragmentCOBJCond.ItemOrList.Link.SetTo(book);

                        itemToFragmentCOBJ.Conditions.Add(
                            new ConditionFloat()
                            {
                                ComparisonValue = 1,
                                CompareOperator = CompareOperator.GreaterThanOrEqualTo,
                                Data = itemToFragmentCOBJCond
                            }
                        );

                        // Create COBJ fragment -> book
                        var bookCOBJ = state.PatchMod.ConstructibleObjects.AddNew();

                        bookCOBJ.EditorID = $"{objEditorID}_{schematicType}_Recipe";
                        bookCOBJ.CreatedObject = new FormLinkNullable<IConstructibleGetter>(
                            book.FormKey
                        );

                        bookCOBJ.Items = new Noggog.ExtendedList<ContainerEntry>();
                        bookCOBJ.Items.Add(
                            new ContainerEntry()
                            {
                                Item = new ContainerItem()
                                {
                                    Item = new FormLink<IItemGetter>(bookFragment.FormKey),
                                    Count = (int)noteToSchematicRatio
                                },
                            }
                        );
                        bookCOBJ.WorkbenchKeyword = new FormLinkNullable<IKeywordGetter>(
                            cobj.WorkbenchKeyword.FormKey
                        );
                        bookCOBJ.CreatedObjectCount = (ushort?)bookCOBJ.Items.Count;

                        // Add conditions (so it doesn't clutter the menu)
                        GetItemCountConditionData bookCOBJCond = new GetItemCountConditionData();
                        bookCOBJCond.ItemOrList = new FormLinkOrIndex<IItemOrListGetter>(
                            bookCOBJCond,
                            bookCOBJ.FormKey
                        );
                        bookCOBJCond.ItemOrList.Link.SetTo(book);

                        bookCOBJ.Conditions.Add(
                            new ConditionFloat()
                            {
                                ComparisonValue = noteToSchematicRatio,
                                CompareOperator = CompareOperator.GreaterThanOrEqualTo,
                                Data = bookCOBJCond
                            }
                        );

                        if (settings.ShowDebugLogs)
                        {
                            Console.WriteLine($"Created {bookFragment.Name}:");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine(bookFragment.BookText);
                            Console.WriteLine("-----------------------");
                            Console.WriteLine(String.Empty);
                        }
                    }
                    else
                    {
                        // Link to existing book
                        if (
                            !state.LinkCache.TryResolve<IBookGetter>(
                                itemBOOK[createdItemFormKey],
                                out var bookLink
                            )
                        )
                            continue;

                        if (bookLink is not Book BookLinkBook)
                            continue;

                        book = BookLinkBook;
                    }

                    // Create a new COBJ record with the modified conditions
                    var modifiedCobj = state.PatchMod.ConstructibleObjects.GetOrAddAsOverride(cobj);
                    GetItemCountConditionData newCond = new GetItemCountConditionData();
                    newCond.ItemOrList = new FormLinkOrIndex<IItemOrListGetter>(
                        newCond,
                        book.FormKey
                    );
                    newCond.ItemOrList.Link.SetTo(book);

                    modifiedCobj.Conditions.Add(
                        new ConditionFloat()
                        {
                            ComparisonValue = 1,
                            CompareOperator = CompareOperator.GreaterThanOrEqualTo,
                            Data = newCond
                        }
                    );

                    if (settings.ShowDebugLogs)
                        Console.WriteLine($"    Patched {cobj.EditorID} with {book.EditorID}");
                }

                if (settings.ShowDebugLogs)
                    Console.WriteLine($"Patching LVLIs to include new schematics ...");

                foreach (FormKey lvliFormKey in itemLVLIs[createdItemFormKey])
                {
                    // Define LVLI and check if it's empty
                    if (
                        !state.LinkCache.TryResolve<ILeveledItemGetter>(
                            lvliFormKey,
                            out var leveledList
                        )
                        && leveledList?.Entries == null
                    )
                        continue;

                    // Define the LVLI to be made specifically for the schematic
                    LeveledItem schematicLVLI;

                    // basic book entry to be added to schematicLVLI
                    LeveledItemEntry bookEntry = new LeveledItemEntry()
                    {
                        Data = new LeveledItemEntryData()
                        {
                            Reference = new FormLink<IItemGetter>(itemBOOK[createdItemFormKey]),
                            Level = 1,
                            Count = 1
                        }
                    };

                    string leveledItemIDTemplate = $"{objEditorID}_{schematicType}";

                    if (!bookLVLIs.ContainsKey(itemBOOK[createdItemFormKey]))
                        bookLVLIs.Add(
                            itemBOOK[createdItemFormKey],
                            new Dictionary<String, FormKey>()
                        );

                    if (!bookLVLIs[itemBOOK[createdItemFormKey]].ContainsKey(leveledItemIDTemplate))
                    {
                        // Create leveled list for each item with a user customizable drop chance
                        schematicLVLI = state.PatchMod.LeveledItems.AddNew();
                        schematicLVLI.ChanceNone = (byte)(100 - settings.DropChance);
                        schematicLVLI.EditorID = leveledItemIDTemplate;
                        schematicLVLI.Entries = new Noggog.ExtendedList<LeveledItemEntry>();
                        schematicLVLI.Entries.Add(bookEntry);
                        bookLVLIs[itemBOOK[createdItemFormKey]].Add(
                            schematicLVLI.EditorID,
                            schematicLVLI.FormKey
                        );
                    }
                    else
                    {
                        // Link to existing book
                        if (
                            !state.LinkCache.TryResolve<ILeveledItemGetter>(
                                bookLVLIs[itemBOOK[createdItemFormKey]][leveledItemIDTemplate],
                                out var schematicLVLILink
                            )
                        )
                            continue;

                        if (schematicLVLILink is not LeveledItem schematicLVLILinkLVLI)
                            continue;

                        schematicLVLI = schematicLVLILinkLVLI;
                    }

                    if (settings.ShowDebugLogs)
                    {
                        Console.WriteLine(String.Empty);
                        Console.WriteLine(
                            $"    Injecting {schematicLVLI.EditorID} in {leveledList.EditorID}"
                        );
                    }

                    for (int i = 0; i < leveledList.Entries?.Count; i++)
                    {
                        var existingEntry = leveledList.Entries[i];
                        if (existingEntry.Data?.Reference.FormKey != createdItem.FormKey)
                            continue;

                        // Get the level of the existing entry
                        short existingLevel = existingEntry?.Data?.Level ?? 1;

                        // Create a new entry with the new item and the same level
                        LeveledItemEntry newEntry = new LeveledItemEntry()
                        {
                            Data = new LeveledItemEntryData()
                            {
                                Reference = new FormLink<IItemGetter>(schematicLVLI),
                                Level = existingLevel,
                                Count = 1
                            }
                        };

                        LeveledItem modifiedBaseLVLI =
                            state.PatchMod.LeveledItems.GetOrAddAsOverride(leveledList);

                        // Add the new entry to the leveled list
                        if (modifiedBaseLVLI.Entries == null)
                            modifiedBaseLVLI.Entries = new Noggog.ExtendedList<LeveledItemEntry>();
                        modifiedBaseLVLI.Entries.Add(newEntry);

                        if (settings.ShowDebugLogs)
                            Console.WriteLine($"        Injected at level {existingLevel};");
                    }
                }
            }

            Console.WriteLine(String.Empty);
            Console.WriteLine("=================================================");
        }
    }
}
