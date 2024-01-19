using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;

namespace Hephaestus
{
    public class BaseSettings
    {
        [SynthesisSettingName("The keyword your crafting furniture uses")]
        public IFormLinkGetter<IKeywordGetter> BenchKeyword { get; set; } =
            FormLinkGetter<IKeywordGetter>.Null;

        [SynthesisSettingName("The name of the crafting furniture")]
        public string ObjBenchName { get; set; } = string.Empty;

        [SynthesisSettingName("The name of the process")]
        public string ProcessName { get; set; } = string.Empty;

        [SynthesisSettingName("The name of the schematic item")]
        public string SchematicTypeName { get; set; } = string.Empty;
    }

    public class MaterialWhitelist
    {
        [SynthesisSettingName("The name of the material")]
        public string Name { get; set; } = string.Empty;

        [SynthesisSettingName("The material ingot")]
        public IFormLinkGetter<IItemGetter> Ingot { get; set; } = FormLinkGetter<IItemGetter>.Null;

        [SynthesisSettingName("The perk required to craft")]
        public IFormLinkGetter<IPerkGetter> PerkReq { get; set; } =
            FormLinkGetter<IPerkGetter>.Null;

        [SynthesisSettingName("Relevant keywords")]
        public List<IFormLinkGetter<IKeywordGetter>> Keywords { get; set; } = new();
    }

    public class PartData
    {
        [SynthesisSettingName("The keyword to look for that defines the item class")]
        public string Name { get; set; } = string.Empty;

        [SynthesisSettingName("The part's size (going from 1 to 3)")]
        public int Size { get; set; } = 1;

        [SynthesisSettingName("The part's crafting bench")]
        public IFormLinkGetter<IKeywordGetter> Bench { get; set; } =
            Skyrim.Keyword.CraftingSmithingForge;
    }

    public class PartList
    {
        [SynthesisSettingName("The keyword to look for that defines the item class")]
        public List<IFormLinkGetter<IKeywordGetter>> Keywords { get; set; } = new();

        [SynthesisSettingName(
            "The list of parts that apply to this item and their size (going from 1 to 3)"
        )]
        public List<PartData> List { get; set; } = new();
    }

    public class Settings
    {
        // [SynthesisSettingName("Drop chance % (out of 100)")]
        // [SynthesisDescription("Goes from 0 to 100, it affects how likely schematics are to drop")]
        // [SynthesisTooltip("Goes from 0 to 100, it affects how likely schematics are to drop")]
        // public int DropChance { get; set; } = 1;

        // [SynthesisSettingName("Tempering requires the schematic too")]
        // [SynthesisDescription("Makes it so you need the schematic to temper items too")]
        // [SynthesisTooltip("Makes it so you need the schematic to temper items too")]
        // public bool TemperReqSchematic { get; set; } = true;

        [SynthesisSettingName("Hide schematics, fragments, etc. once learned")]
        [SynthesisDescription(
            "Hides the added items per part/item once knowledge of that part/item is achieved"
        )]
        [SynthesisTooltip(
            "Hides the added items per part/item once knowledge of that part/item is achieved"
        )]
        public bool HideOnceUnlocked { get; set; } = true;

        [SynthesisSettingName("Blacklist items")]
        public List<IFormLinkGetter<IItemGetter>> ItemBlacklist { get; set; } = new();

        [SynthesisSettingName("Basic items")]
        [SynthesisDescription("List of items that don't also need a design schematic")]
        [SynthesisTooltip("List of items that don't also need a design schematic")]
        public List<IFormLinkGetter<IItemGetter>> BasicItems { get; set; } = new();

        [SynthesisSettingName("Add schematics to merchants?")]
        public bool DistributeVendors { get; set; } = true;

        [SynthesisSettingName("Add schematics to blacksmiths?")]
        public bool DistributeBlacksmiths { get; set; } = true;

        [SynthesisSettingName(
            "Add schematics to special loot (special chests, boss chests, etc.)?"
        )]
        public bool DistributeSpecial { get; set; } = true;

        // [SynthesisSettingName("Allow artifacts to be broken down")]
        // [SynthesisDescription(
        //     "Let the patcher create breakdown recipe of the item into the relevant parts"
        // )]
        // [SynthesisTooltip(
        //     "Let the patcher create breakdown recipe of the item into the relevant parts"
        // )]
        // public bool AlsoBreakdownArtifacts { get; set; } = false;

        [SynthesisSettingName("Add custom lists to distribute schematics to")]
        [SynthesisTooltip(
            "Keep in mind that any leveled list that is used as an outfit by NPCs may cause issues with some instances of said NPCs being naked."
        )]
        public List<IFormLinkGetter<ILeveledItemGetter>> LVLIWhitelist { get; set; } = new();

        // [SynthesisSettingName("Add names to pool of crafters")]
        // [SynthesisDescription(
        //     "Any name added here is added to the pool of names that get used when generating the looted schematics"
        // )]
        // [SynthesisTooltip(
        //     "Any name added here is added to the pool of names that get used when generating the looted schematics"
        // )]
        // public List<string> LovedOnesName { get; set; } = new();

        [SynthesisSettingName("(Debug) Show patched item info")]
        public bool ShowDebugLogs { get; set; } = true;

        [SynthesisSettingName("Hide item crafting knowledge from Active Effects")]
        public bool HideKnowledgeUI { get; set; } = false;

        [SynthesisSettingName("Crafting furniture settings")]
        public List<BaseSettings> BenchSettings { get; set; } =
            new()
            {
                new BaseSettings()
                {
                    BenchKeyword = Skyrim.Keyword.CraftingSmithingForge,
                    ObjBenchName = "Forge",
                    ProcessName = "shape",
                    SchematicTypeName = "Schematic"
                },
                new BaseSettings()
                {
                    BenchKeyword = Skyrim.Keyword.CraftingSmithingSharpeningWheel,
                    ObjBenchName = "Sharpening Wheel",
                    ProcessName = "sharpen",
                    SchematicTypeName = "Schematic"
                },
                new BaseSettings()
                {
                    BenchKeyword = Skyrim.Keyword.CraftingSmithingArmorTable,
                    ObjBenchName = "Armor Table",
                    ProcessName = "temper",
                    SchematicTypeName = "Schematic"
                },
                new BaseSettings()
                {
                    BenchKeyword = Skyrim.Keyword.CraftingTanningRack,
                    ObjBenchName = "Tanning Rack",
                    ProcessName = "stitch",
                    SchematicTypeName = "Pattern"
                },
                new BaseSettings()
                {
                    BenchKeyword = Skyrim.Keyword.CraftingCookpot,
                    ObjBenchName = "Cooking Pot",
                    ProcessName = "cook",
                    SchematicTypeName = "Recipe"
                }
            };

        [SynthesisSettingName("Material Whitelist")]
        public List<MaterialWhitelist> MaterialWhitelist { get; set; } =
            new()
            {
                new()
                {
                    Name = "Wood",
                    Ingot = Skyrim.MiscItem.Firewood01,
                    Keywords = new() { Skyrim.Keyword.WeapMaterialWood }
                },
                new MaterialWhitelist()
                {
                    Name = "Cloth",
                    Ingot = Skyrim.MiscItem.Leather01,
                    Keywords = new() { Skyrim.Keyword.ArmorClothing }
                },
                new MaterialWhitelist()
                {
                    Name = "Hide",
                    Ingot = Skyrim.MiscItem.Leather01,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialHide, }
                },
                new MaterialWhitelist()
                {
                    Name = "Leather",
                    Ingot = Skyrim.MiscItem.Leather01,
                    Keywords = new()
                    {
                        Skyrim.Keyword.ArmorMaterialLeather,
                        Skyrim.Keyword.ArmorDarkBrotherhood,
                        Skyrim.Keyword.ArmorNightingale,
                        Dawnguard.Keyword.DLC1ArmorMaterialVampire
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Iron",
                    Ingot = Skyrim.MiscItem.IngotIron,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialIron,
                        Skyrim.Keyword.ArmorMaterialIron
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Iron Banded",
                    Ingot = Skyrim.MiscItem.IngotCorundum,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialIronBanded, }
                },
                new MaterialWhitelist()
                {
                    Name = "Studded",
                    Ingot = Skyrim.MiscItem.IngotIron,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialStudded, }
                },
                new MaterialWhitelist()
                {
                    Name = "Scaled",
                    Ingot = Skyrim.MiscItem.IngotCorundum,
                    PerkReq = Skyrim.Perk.AdvancedArmors,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialScaled, }
                },
                new MaterialWhitelist()
                {
                    Name = "Draugr",
                    Ingot = Skyrim.MiscItem.IngotIron,
                    Keywords = new() { Skyrim.Keyword.WeapMaterialDraugr }
                },
                new MaterialWhitelist()
                {
                    Name = "Honed Draugr",
                    Ingot = Skyrim.MiscItem.IngotIron,
                    Keywords = new() { Skyrim.Keyword.WeapMaterialDraugrHoned }
                },
                new MaterialWhitelist()
                {
                    Name = "Imperial",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialImperial,
                        Skyrim.Keyword.ArmorMaterialImperialLight,
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Imperial Studded",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialImperialStudded, }
                },
                new MaterialWhitelist()
                {
                    Name = "Heavy Imperial",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialImperialHeavy, }
                },
                new MaterialWhitelist()
                {
                    Name = "Steel",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialSteel,
                        Skyrim.Keyword.ArmorMaterialSteel,
                        Update.Keyword.ArmorMaterialBlades,
                        Dawnguard.Keyword.DLC1ArmorMaterialDawnguard
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Steel Plate",
                    Ingot = Skyrim.MiscItem.IngotCorundum,
                    PerkReq = Skyrim.Perk.SteelSmithing,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialSteelPlate, }
                },
                new MaterialWhitelist()
                {
                    Name = "Orcish",
                    Ingot = Skyrim.MiscItem.IngotOrichalcum,
                    PerkReq = Skyrim.Perk.OrcishSmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialOrcish,
                        Skyrim.Keyword.ArmorMaterialOrcish,
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Dwemer",
                    Ingot = Skyrim.MiscItem.IngotDwarven,
                    PerkReq = Skyrim.Perk.OrcishSmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialDwarven,
                        Skyrim.Keyword.ArmorMaterialDwarven,
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Elven",
                    Ingot = Skyrim.MiscItem.IngotQuicksilver,
                    PerkReq = Skyrim.Perk.ElvenSmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialElven,
                        Skyrim.Keyword.ArmorMaterialElven,
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Elven Gilded",
                    Ingot = Skyrim.MiscItem.IngotQuicksilver,
                    PerkReq = Skyrim.Perk.ElvenSmithing,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialElvenGilded }
                },
                new MaterialWhitelist()
                {
                    Name = "Falmer",
                    Ingot = Skyrim.MiscItem.ChaurusChitin,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialFalmer,
                        Update.Keyword.ArmorMaterialFalmer,
                        Dawnguard.Keyword.DLC1ArmorMaterielFalmerHeavy,
                        Dawnguard.Keyword.DLC1ArmorMaterielFalmerHeavyOriginal
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Falmer Hardened",
                    Ingot = Skyrim.MiscItem.ChaurusChitin,
                    Keywords = new() { Dawnguard.Keyword.DLC1ArmorMaterialFalmerHardened }
                },
                new MaterialWhitelist()
                {
                    Name = "Honed Falmer",
                    Ingot = Skyrim.MiscItem.ChaurusChitin,
                    Keywords = new() { Skyrim.Keyword.WeapMaterialFalmerHoned, }
                },
                new MaterialWhitelist()
                {
                    Name = "Glass",
                    Ingot = Skyrim.MiscItem.IngotMalachite,
                    PerkReq = Skyrim.Perk.GlassSmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialGlass,
                        Skyrim.Keyword.ArmorMaterialGlass,
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Ebony",
                    Ingot = Skyrim.MiscItem.IngotEbony,
                    PerkReq = Skyrim.Perk.EbonySmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialEbony,
                        Skyrim.Keyword.ArmorMaterialEbony
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Daedric",
                    Ingot = Skyrim.Ingredient.DaedraHeart,
                    PerkReq = Skyrim.Perk.DaedricSmithing,
                    Keywords = new()
                    {
                        Skyrim.Keyword.WeapMaterialDaedric,
                        Skyrim.Keyword.ArmorMaterialDaedric
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Dragonscale",
                    Ingot = Skyrim.MiscItem.DragonScales,
                    PerkReq = Skyrim.Perk.DragonArmor,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialDragonscale },
                },
                new MaterialWhitelist()
                {
                    Name = "Dragonplate",
                    Ingot = Skyrim.MiscItem.DragonBone,
                    PerkReq = Skyrim.Perk.DragonArmor,
                    Keywords = new() { Skyrim.Keyword.ArmorMaterialDragonplate }
                },
                new MaterialWhitelist()
                {
                    Name = "Dragonbone",
                    Ingot = Skyrim.MiscItem.DragonBone,
                    PerkReq = Skyrim.Perk.DragonArmor,
                    Keywords = new() { Dawnguard.Keyword.DLC1WeapMaterialDragonbone }
                },
                new MaterialWhitelist()
                {
                    Name = "Stalhrim",
                    Ingot = Dragonborn.MiscItem.DLC2OreStalhrim,
                    Keywords = new()
                    {
                        Dragonborn.Keyword.DLC2WeaponMaterialStalhrim,
                        Dragonborn.Keyword.DLC2ArmorMaterialStalhrimLight,
                        Dragonborn.Keyword.DLC2ArmorMaterialStalhrimHeavy
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Nordic",
                    Ingot = Skyrim.MiscItem.IngotQuicksilver,
                    PerkReq = Skyrim.Perk.AdvancedArmors,
                    Keywords = new()
                    {
                        Dragonborn.Keyword.DLC2WeaponMaterialNordic,
                        Dragonborn.Keyword.DLC2ArmorMaterialNordicLight,
                        Dragonborn.Keyword.DLC2ArmorMaterialNordicHeavy,
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Chitin",
                    Ingot = Dragonborn.MiscItem.DLC2ChitinPlate,
                    PerkReq = Skyrim.Perk.ElvenSmithing,
                    Keywords = new()
                    {
                        Dragonborn.Keyword.DLC2ArmorMaterialChitinLight,
                        Dragonborn.Keyword.DLC2ArmorMaterialChitinHeavy
                    }
                },
                new MaterialWhitelist()
                {
                    Name = "Bonemold",
                    Ingot = Skyrim.Ingredient.BoneMeal,
                    PerkReq = Skyrim.Perk.SteelSmithing,
                    Keywords = new()
                    {
                        Dragonborn.Keyword.DLC2ArmorMaterialBonemoldLight,
                        Dragonborn.Keyword.DLC2ArmorMaterialBonemoldHeavy,
                    }
                },
                new MaterialWhitelist() { Name = "Gold", Ingot = Skyrim.MiscItem.IngotGold, },
                new MaterialWhitelist()
                {
                    Name = "Silver",
                    Ingot = Skyrim.MiscItem.ingotSilver,
                    Keywords = new() { Skyrim.Keyword.WeapMaterialSilver }
                },
            };

        [SynthesisSettingName("Part List")]
        public List<PartList> PartList { get; set; } =
            new()
            {
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeBow, },
                    List =
                    {
                        new() { Name = "Grip" },
                        new() { Name = "Bowstring", Bench = Skyrim.Keyword.CraftingTanningRack },
                        new() { Name = "Limb", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeWarAxe, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Standard Shaft" },
                        new() { Name = "Axe Head" }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeMace, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Standard Shaft" },
                        new() { Name = "Mace Head" }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeSword, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Guard" },
                        new() { Name = "Standard Blade", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeDagger, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Guard" },
                        new() { Name = "Short Blade" }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeGreatsword, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new()
                        {
                            Name = "Two Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Guard" },
                        new() { Name = "Great Blade", Size = 3 }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeBattleaxe, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new()
                        {
                            Name = "Two Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Long Shaft", Size = 2 },
                        new() { Name = "Great Axe Blade", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeWarhammer, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new()
                        {
                            Name = "Two Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Long Shaft", Size = 2 },
                        new() { Name = "Great Hammer Blade", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ClothingHead, },
                    List =
                    {
                        new()
                        {
                            Name = "Hat Inner Lining",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new()
                        {
                            Name = "Hat Stitching Pattern",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorHelmet, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new()
                        {
                            Name = "Helmet Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Light Helmet", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorHelmet, Skyrim.Keyword.ArmorHeavy },
                    List =
                    {
                        new()
                        {
                            Name = "Helmet Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Heavy Helmet", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ClothingBody },
                    List =
                    {
                        new()
                        {
                            Name = "Clothes Inner Lining",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new()
                        {
                            Name = "Chest Stitching Pattern",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new()
                        {
                            Name = "Arm Stitching Pattern",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new()
                        {
                            Name = "Trousers Stitching Pattern",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorCuirass, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new()
                        {
                            Name = "Cuirass Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Light Breastplate", },
                        new() { Name = "Light Pauldron", },
                        new() { Name = "Tasset", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorCuirass, Skyrim.Keyword.ArmorHeavy },
                    List =
                    {
                        new()
                        {
                            Name = "Cuirass Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Heavy Breastplate", },
                        new() { Name = "Heavy Pauldron", },
                        new() { Name = "Tasset", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ClothingHands },
                    List =
                    {
                        new()
                        {
                            Name = "Glove Inner Lining",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new()
                        {
                            Name = "Glove Stitching Pattern",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorGauntlets, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new()
                        {
                            Name = "Gauntlet Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Light Vambrace", },
                        new() { Name = "Light Rerebrace", },
                        new() { Name = "Light Gauntlet", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorGauntlets, Skyrim.Keyword.ArmorHeavy },
                    List =
                    {
                        new()
                        {
                            Name = "Gauntlet Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Heavy Vambrace", },
                        new() { Name = "Heavy Rerebrace", },
                        new() { Name = "Heavy Gauntlet", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ClothingFeet },
                    List =
                    {
                        new()
                        {
                            Name = "Boot Inner Lining",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new()
                        {
                            Name = "Boot Stitching Pattern",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorBoots, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new()
                        {
                            Name = "Sabaton Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Greaves", },
                        new() { Name = "Poleyns", },
                        new() { Name = "Light Sabaton", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorBoots, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new()
                        {
                            Name = "Sabaton Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Light Greaves", },
                        new() { Name = "Light Poleyns", },
                        new() { Name = "Light Sabaton", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorBoots, Skyrim.Keyword.ArmorHeavy },
                    List =
                    {
                        new()
                        {
                            Name = "Sabaton Inner Padding",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new() { Name = "Heavy Greaves", },
                        new() { Name = "Heavy Poleyns", },
                        new() { Name = "Heavy Sabaton", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorShield },
                    List =
                    {
                        new() { Name = "Shield Trim", Bench = Skyrim.Keyword.CraftingTanningRack },
                        new() { Name = "Shield Handle", },
                        new() { Name = "Shield Face", },
                    }
                },
            };
    }
}
