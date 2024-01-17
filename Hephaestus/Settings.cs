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
        [SynthesisSettingName("The material keyword")]
        public IFormLinkGetter<IKeywordGetter> Keyword { get; set; } =
            FormLinkGetter<IKeywordGetter>.Null;

        [SynthesisSettingName("The name of the material")]
        public string Name { get; set; } = string.Empty;

        [SynthesisSettingName("The material ingot")]
        public IFormLinkGetter<IItemGetter> Ingot { get; set; } = FormLinkGetter<IItemGetter>.Null;

        [SynthesisSettingName("The perk required to craft")]
        public IFormLinkGetter<IPerkGetter> PerkReq { get; set; } =
            FormLinkGetter<IPerkGetter>.Null;
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
        public IFormLinkGetter<IKeywordGetter> Keyword { get; set; } =
            FormLinkGetter<IKeywordGetter>.Null;

        [SynthesisSettingName(
            "The list of parts that apply to this item and their size (going from 1 to 3)"
        )]
        public List<PartData> List { get; set; } = new();
    }

    public class Settings
    {
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
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialWood,
                    Name = "Wood",
                    Ingot = Skyrim.MiscItem.Firewood01
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialIron,
                    Name = "Iron",
                    Ingot = Skyrim.MiscItem.IngotIron
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialDraugr,
                    Name = "Draugr",
                    Ingot = Skyrim.MiscItem.IngotIron
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialDraugrHoned,
                    Name = "Honed Draugr",
                    Ingot = Skyrim.MiscItem.IngotIron
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialImperial,
                    Name = "Imperial",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialSteel,
                    Name = "Steel",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialSilver,
                    Name = "Silver",
                    Ingot = Skyrim.MiscItem.ingotSilver
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialOrcish,
                    Name = "Orcish",
                    Ingot = Skyrim.MiscItem.IngotOrichalcum,
                    PerkReq = Skyrim.Perk.OrcishSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialDwarven,
                    Name = "Dwemer",
                    Ingot = Skyrim.MiscItem.IngotOrichalcum,
                    PerkReq = Skyrim.Perk.OrcishSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialElven,
                    Name = "Elven",
                    Ingot = Skyrim.MiscItem.IngotQuicksilver,
                    PerkReq = Skyrim.Perk.ElvenSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialFalmer,
                    Name = "Falmer",
                    Ingot = Skyrim.MiscItem.ChaurusChitin
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialFalmerHoned,
                    Name = "Honed Falmer",
                    Ingot = Skyrim.MiscItem.ChaurusChitin
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialGlass,
                    Name = "Glass",
                    Ingot = Skyrim.MiscItem.IngotMalachite,
                    PerkReq = Skyrim.Perk.GlassSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialEbony,
                    Name = "Ebony",
                    Ingot = Skyrim.MiscItem.IngotEbony,
                    PerkReq = Skyrim.Perk.EbonySmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.WeapMaterialDaedric,
                    Name = "Daedric",
                    Ingot = Skyrim.Ingredient.DaedraHeart,
                    PerkReq = Skyrim.Perk.DaedricSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialHide,
                    Name = "Hide",
                    Ingot = Skyrim.MiscItem.Leather01
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialLeather,
                    Name = "Leather",
                    Ingot = Skyrim.MiscItem.Leather01
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialIron,
                    Name = "Iron",
                    Ingot = Skyrim.MiscItem.IngotIron
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialIronBanded,
                    Name = "Iron Banded",
                    Ingot = Skyrim.MiscItem.IngotCorundum
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialStudded,
                    Name = "Studded",
                    Ingot = Skyrim.MiscItem.IngotIron
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialScaled,
                    Name = "Scaled",
                    Ingot = Skyrim.MiscItem.IngotCorundum,
                    PerkReq = Skyrim.Perk.AdvancedArmors
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialSteel,
                    Name = "Steel",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialImperialLight,
                    Name = "Imperial",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialImperialStudded,
                    Name = "Imperial Studded",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialImperialHeavy,
                    Name = "Heavy Imperial",
                    Ingot = Skyrim.MiscItem.IngotSteel,
                    PerkReq = Skyrim.Perk.SteelSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialSteelPlate,
                    Name = "Steel Plate",
                    Ingot = Skyrim.MiscItem.IngotCorundum,
                    PerkReq = Skyrim.Perk.SteelSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialOrcish,
                    Name = "Orcish",
                    Ingot = Skyrim.MiscItem.IngotOrichalcum,
                    PerkReq = Skyrim.Perk.OrcishSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialDwarven,
                    Name = "Dwemer",
                    Ingot = Skyrim.MiscItem.IngotOrichalcum,
                    PerkReq = Skyrim.Perk.OrcishSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialElven,
                    Name = "Elven",
                    Ingot = Skyrim.MiscItem.IngotQuicksilver,
                    PerkReq = Skyrim.Perk.ElvenSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialElvenGilded,
                    Name = "Elven Gilded",
                    Ingot = Skyrim.MiscItem.IngotQuicksilver,
                    PerkReq = Skyrim.Perk.ElvenSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialGlass,
                    Name = "Glass",
                    Ingot = Skyrim.MiscItem.IngotMalachite,
                    PerkReq = Skyrim.Perk.GlassSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialEbony,
                    Name = "Ebony",
                    Ingot = Skyrim.MiscItem.IngotEbony,
                    PerkReq = Skyrim.Perk.EbonySmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialDaedric,
                    Name = "Daedric",
                    Ingot = Skyrim.Ingredient.DaedraHeart,
                    PerkReq = Skyrim.Perk.DaedricSmithing
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialDragonscale,
                    Name = "Dragonscale",
                    Ingot = Skyrim.MiscItem.DragonScales,
                    PerkReq = Skyrim.Perk.DragonArmor
                },
                new MaterialWhitelist()
                {
                    Keyword = Skyrim.Keyword.ArmorMaterialDragonplate,
                    Name = "Dragonplate",
                    Ingot = Skyrim.MiscItem.DragonBone,
                    PerkReq = Skyrim.Perk.DragonArmor
                }
            };

        [SynthesisSettingName("Part List")]
        public List<PartList> PartList { get; set; } =
            new()
            {
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeBow,
                    List =
                    {
                        new PartData() { Name = "Grip" },
                        new PartData()
                        {
                            Name = "Bowstring",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Limb", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeWarAxe,
                    List =
                    {
                        new PartData() { Name = "Pommel" },
                        new PartData()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Standard Shaft" },
                        new PartData() { Name = "Axe Head" }
                    }
                },
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeMace,
                    List =
                    {
                        new PartData() { Name = "Pommel" },
                        new PartData()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Standard Shaft" },
                        new PartData() { Name = "Mace Head" }
                    }
                },
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeSword,
                    List =
                    {
                        new PartData() { Name = "Pommel" },
                        new PartData()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Guard" },
                        new PartData() { Name = "Standard Blade", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeDagger,
                    List =
                    {
                        new PartData() { Name = "Pommel" },
                        new PartData()
                        {
                            Name = "One Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Guard" },
                        new PartData() { Name = "Short Blade" }
                    }
                },
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeGreatsword,
                    List =
                    {
                        new PartData() { Name = "Pommel" },
                        new PartData()
                        {
                            Name = "Two Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Guard" },
                        new PartData() { Name = "Great Blade", Size = 3 }
                    }
                },
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeBattleaxe,
                    List =
                    {
                        new PartData() { Name = "Pommel" },
                        new PartData()
                        {
                            Name = "Two Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Long Shaft", Size = 2 },
                        new PartData() { Name = "Great Axe Blade", Size = 2 }
                    }
                },
                new PartList()
                {
                    Keyword = Skyrim.Keyword.WeapTypeWarhammer,
                    List =
                    {
                        new PartData() { Name = "Pommel" },
                        new PartData()
                        {
                            Name = "Two Handed Handle",
                            Bench = Skyrim.Keyword.CraftingTanningRack
                        },
                        new PartData() { Name = "Long Shaft", Size = 2 },
                        new PartData() { Name = "Great Hammer Blade", Size = 2 }
                    }
                },
            };

        [SynthesisSettingName("Drop chance % (out of 100)")]
        [SynthesisDescription("Goes from 0 to 100, it affects how likely schematics are to drop")]
        [SynthesisTooltip("Goes from 0 to 100, it affects how likely schematics are to drop")]
        public int DropChance { get; set; } = 1;

        [SynthesisSettingName("Tempering requires the schematic too")]
        [SynthesisDescription("Makes it so you need the schematic to temper items too")]
        [SynthesisTooltip("Makes it so you need the schematic to temper items too")]
        public bool TemperReqSchematic { get; set; } = true;

        [SynthesisSettingName("Use smelter to break down items")]
        [SynthesisTooltip("Otherwise you'll get exp for every item breakdown")]
        public bool UseSmelter { get; set; } = true;

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

        [SynthesisSettingName("Add custom lists to distribute schematics to")]
        [SynthesisTooltip(
            "Keep in mind that any leveled list that is used as an outfit by NPCs may cause issues with some instances of said NPCs being naked."
        )]
        public List<IFormLinkGetter<ILeveledItemGetter>> LVLIWhitelist { get; set; } = new();

        [SynthesisSettingName("Add names to pool of crafters")]
        [SynthesisDescription(
            "Any name added here is added to the pool of names that get used when generating the looted schematics"
        )]
        [SynthesisTooltip(
            "Any name added here is added to the pool of names that get used when generating the looted schematics"
        )]
        public List<string> LovedOnesName { get; set; } = new();

        [SynthesisSettingName("(Debug) Show patched item info")]
        public bool ShowDebugLogs { get; set; } = true;
    }
}
