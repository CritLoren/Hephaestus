using System.Collections;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;

namespace Hephaestus
{
    public class BaseSettings
    {
        [SynthesisSettingName("The name of the crafting furniture")]
        public string BenchName { get; set; } = string.Empty;

        [SynthesisSettingName("Is this a workbench that sharpens/tempers items?")]
        public bool doesTemperOnly { get; set; } = false;

        [SynthesisSettingName("The name of the process")]
        public string ProcessName { get; set; } = string.Empty;

        [SynthesisSettingName("The name of the schematic item")]
        public string SchematicTypeName { get; set; } = string.Empty;

        [SynthesisSettingName("Menu item")]
        public IFormLinkGetter<IStaticGetter> BenchMenuStatic { get; set; } =
            Skyrim.Static.BlacksmithAnvilStatic;
    }

    public class MaterialWhitelistData
    {
        [SynthesisSettingName("The material ingot")]
        public IFormLinkGetter<IItemGetter> Ingot { get; set; } = Skyrim.MiscItem.Leather01;

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

        [SynthesisSettingName("Give smithing exp")]
        public bool giveSmithingExp { get; set; } = false;

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
        public Dictionary<FormLink<IKeywordGetter>, BaseSettings> BenchSettings { get; set; } =
            new()
            {
                {
                    Skyrim.Keyword.CraftingSmithingForge,
                    new BaseSettings()
                    {
                        BenchName = "Forge",
                        ProcessName = "shape",
                        SchematicTypeName = "Schematic"
                    }
                },
                {
                    Skyrim.Keyword.CraftingSmithingSharpeningWheel,
                    new BaseSettings()
                    {
                        BenchName = "Sharpening Wheel",
                        ProcessName = "sharpen",
                        SchematicTypeName = "Schematic",
                        doesTemperOnly = true,
                    }
                },
                {
                    Skyrim.Keyword.CraftingSmithingArmorTable,
                    new BaseSettings()
                    {
                        BenchName = "Armor Table",
                        ProcessName = "temper",
                        SchematicTypeName = "Schematic",
                        doesTemperOnly = true,
                    }
                },
                {
                    Skyrim.Keyword.CraftingTanningRack,
                    new BaseSettings()
                    {
                        BenchName = "Tanning Rack",
                        ProcessName = "stitch",
                        SchematicTypeName = "Pattern"
                    }
                },
                {
                    Skyrim.Keyword.CraftingCookpot,
                    new BaseSettings()
                    {
                        BenchName = "Cooking Pot",
                        ProcessName = "cook",
                        SchematicTypeName = "Recipe"
                    }
                }
            };

        [SynthesisSettingName("Material Whitelist")]
        public Dictionary<string, MaterialWhitelistData> MaterialWhitelist { get; set; } =
            new()
            {
                {
                    "Wood",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.Firewood01,
                        Keywords = new() { Skyrim.Keyword.WeapMaterialWood }
                    }
                },
                {
                    "Cloth",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.Leather01,
                        Keywords = new() { Skyrim.Keyword.ArmorClothing }
                    }
                },
                {
                    "Hide",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.Leather01,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialHide, }
                    }
                },
                {
                    "Leather",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.Leather01,
                        Keywords = new()
                        {
                            Skyrim.Keyword.ArmorMaterialLeather,
                            Skyrim.Keyword.ArmorDarkBrotherhood,
                            Skyrim.Keyword.ArmorNightingale,
                            Dawnguard.Keyword.DLC1ArmorMaterialVampire
                        }
                    }
                },
                {
                    "Iron",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotIron,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialIron,
                            Skyrim.Keyword.ArmorMaterialIron
                        }
                    }
                },
                {
                    "Iron Banded",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotCorundum,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialIronBanded, }
                    }
                },
                {
                    "Studded",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotIron,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialStudded, }
                    }
                },
                {
                    "Scaled",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotCorundum,
                        PerkReq = Skyrim.Perk.AdvancedArmors,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialScaled, }
                    }
                },
                {
                    "Draugr",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotIron,
                        Keywords = new() { Skyrim.Keyword.WeapMaterialDraugr }
                    }
                },
                {
                    "Honed Draugr",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotIron,
                        Keywords = new() { Skyrim.Keyword.WeapMaterialDraugrHoned }
                    }
                },
                {
                    "Imperial",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotSteel,
                        PerkReq = Skyrim.Perk.SteelSmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialImperial,
                            Skyrim.Keyword.ArmorMaterialImperialLight,
                        }
                    }
                },
                {
                    "Imperial Studded",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotSteel,
                        PerkReq = Skyrim.Perk.SteelSmithing,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialImperialStudded, }
                    }
                },
                {
                    "Heavy Imperial",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotSteel,
                        PerkReq = Skyrim.Perk.SteelSmithing,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialImperialHeavy, }
                    }
                },
                {
                    "Steel",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotSteel,
                        PerkReq = Skyrim.Perk.SteelSmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialSteel,
                            Skyrim.Keyword.ArmorMaterialSteel,
                            Update.Keyword.ArmorMaterialBlades,
                            Dawnguard.Keyword.DLC1ArmorMaterialDawnguard
                        }
                    }
                },
                {
                    "Steel Plate",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotCorundum,
                        PerkReq = Skyrim.Perk.SteelSmithing,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialSteelPlate, }
                    }
                },
                {
                    "Orcish",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotOrichalcum,
                        PerkReq = Skyrim.Perk.OrcishSmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialOrcish,
                            Skyrim.Keyword.ArmorMaterialOrcish,
                        }
                    }
                },
                {
                    "Dwemer",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotDwarven,
                        PerkReq = Skyrim.Perk.OrcishSmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialDwarven,
                            Skyrim.Keyword.ArmorMaterialDwarven,
                        }
                    }
                },
                {
                    "Elven",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotQuicksilver,
                        PerkReq = Skyrim.Perk.ElvenSmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialElven,
                            Skyrim.Keyword.ArmorMaterialElven,
                        }
                    }
                },
                {
                    "Elven Gilded",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotQuicksilver,
                        PerkReq = Skyrim.Perk.ElvenSmithing,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialElvenGilded }
                    }
                },
                {
                    "Falmer",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.ChaurusChitin,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialFalmer,
                            Update.Keyword.ArmorMaterialFalmer,
                            Dawnguard.Keyword.DLC1ArmorMaterielFalmerHeavy,
                            Dawnguard.Keyword.DLC1ArmorMaterielFalmerHeavyOriginal
                        }
                    }
                },
                {
                    "Falmer Hardened",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.ChaurusChitin,
                        Keywords = new() { Dawnguard.Keyword.DLC1ArmorMaterialFalmerHardened }
                    }
                },
                {
                    "Honed Falmer",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.ChaurusChitin,
                        Keywords = new() { Skyrim.Keyword.WeapMaterialFalmerHoned, }
                    }
                },
                {
                    "Glass",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotMalachite,
                        PerkReq = Skyrim.Perk.GlassSmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialGlass,
                            Skyrim.Keyword.ArmorMaterialGlass,
                        }
                    }
                },
                {
                    "Ebony",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotEbony,
                        PerkReq = Skyrim.Perk.EbonySmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialEbony,
                            Skyrim.Keyword.ArmorMaterialEbony
                        }
                    }
                },
                {
                    "Daedric",
                    new()
                    {
                        Ingot = Skyrim.Ingredient.DaedraHeart,
                        PerkReq = Skyrim.Perk.DaedricSmithing,
                        Keywords = new()
                        {
                            Skyrim.Keyword.WeapMaterialDaedric,
                            Skyrim.Keyword.ArmorMaterialDaedric
                        }
                    }
                },
                {
                    "Dragonscale",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.DragonScales,
                        PerkReq = Skyrim.Perk.DragonArmor,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialDragonscale },
                    }
                },
                {
                    "Dragonplate",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.DragonBone,
                        PerkReq = Skyrim.Perk.DragonArmor,
                        Keywords = new() { Skyrim.Keyword.ArmorMaterialDragonplate }
                    }
                },
                {
                    "Dragonbone",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.DragonBone,
                        PerkReq = Skyrim.Perk.DragonArmor,
                        Keywords = new() { Dawnguard.Keyword.DLC1WeapMaterialDragonbone }
                    }
                },
                {
                    "Stalhrim",
                    new()
                    {
                        Ingot = Dragonborn.MiscItem.DLC2OreStalhrim,
                        Keywords = new()
                        {
                            Dragonborn.Keyword.DLC2WeaponMaterialStalhrim,
                            Dragonborn.Keyword.DLC2ArmorMaterialStalhrimLight,
                            Dragonborn.Keyword.DLC2ArmorMaterialStalhrimHeavy
                        }
                    }
                },
                {
                    "Nordic",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.IngotQuicksilver,
                        PerkReq = Skyrim.Perk.AdvancedArmors,
                        Keywords = new()
                        {
                            Dragonborn.Keyword.DLC2WeaponMaterialNordic,
                            Dragonborn.Keyword.DLC2ArmorMaterialNordicLight,
                            Dragonborn.Keyword.DLC2ArmorMaterialNordicHeavy,
                        }
                    }
                },
                {
                    "Chitin",
                    new()
                    {
                        Ingot = Dragonborn.MiscItem.DLC2ChitinPlate,
                        PerkReq = Skyrim.Perk.ElvenSmithing,
                        Keywords = new()
                        {
                            Dragonborn.Keyword.DLC2ArmorMaterialChitinLight,
                            Dragonborn.Keyword.DLC2ArmorMaterialChitinHeavy
                        }
                    }
                },
                {
                    "Bonemold",
                    new()
                    {
                        Ingot = Skyrim.Ingredient.BoneMeal,
                        PerkReq = Skyrim.Perk.SteelSmithing,
                        Keywords = new()
                        {
                            Dragonborn.Keyword.DLC2ArmorMaterialBonemoldLight,
                            Dragonborn.Keyword.DLC2ArmorMaterialBonemoldHeavy,
                        }
                    }
                },
                {
                    "Gold",
                    new() { Ingot = Skyrim.MiscItem.IngotGold, }
                },
                {
                    "Silver",
                    new()
                    {
                        Ingot = Skyrim.MiscItem.ingotSilver,
                        Keywords = new() { Skyrim.Keyword.WeapMaterialSilver }
                    }
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
                        new() { Name = "Bowstring", },
                        new() { Name = "Limb", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.WeapTypeWarAxe, },
                    List =
                    {
                        new() { Name = "Pommel" },
                        new() { Name = "One Handed Handle" },
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
                        new() { Name = "One Handed Handle", },
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
                        new() { Name = "One Handed Handle", },
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
                        new() { Name = "One Handed Handle", },
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
                        new() { Name = "Two Handed Handle", },
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
                        new() { Name = "Two Handed Handle", },
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
                        new() { Name = "Two Handed Handle", },
                        new() { Name = "Long Shaft", Size = 2 },
                        new() { Name = "Great Hammer Head", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ClothingHead, },
                    List =
                    {
                        new() { Name = "Hat Inner Lining", },
                        new() { Name = "Hat Stitching Pattern", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorHelmet, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new() { Name = "Helmet Inner Padding", },
                        new() { Name = "Light Helmet", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorHelmet, Skyrim.Keyword.ArmorHeavy },
                    List =
                    {
                        new() { Name = "Helmet Inner Padding", },
                        new() { Name = "Heavy Helmet", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ClothingBody },
                    List =
                    {
                        new() { Name = "Clothes Inner Lining", },
                        new() { Name = "Chest Stitching Pattern", },
                        new() { Name = "Arm Stitching Pattern", },
                        new() { Name = "Trousers Stitching Pattern", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorCuirass, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new() { Name = "Cuirass Inner Padding", },
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
                        new() { Name = "Cuirass Inner Padding", },
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
                        new() { Name = "Glove Inner Lining", },
                        new() { Name = "Glove Stitching Pattern", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorGauntlets, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new() { Name = "Gauntlet Inner Padding", },
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
                        new() { Name = "Gauntlet Inner Padding", },
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
                        new() { Name = "Shoe Inner Lining", },
                        new() { Name = "Shoe Stitching Pattern", },
                    }
                },
                new PartList()
                {
                    Keywords = new() { Skyrim.Keyword.ArmorBoots, Skyrim.Keyword.ArmorLight },
                    List =
                    {
                        new() { Name = "Sabaton Inner Padding", },
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
                        new() { Name = "Sabaton Inner Padding", },
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
                        new() { Name = "Shield Trim" },
                        new() { Name = "Shield Handle", },
                        new() { Name = "Shield Face", },
                    }
                },
            };
    }
}
