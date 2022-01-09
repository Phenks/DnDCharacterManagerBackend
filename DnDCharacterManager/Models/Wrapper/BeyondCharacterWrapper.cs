using DnDCharacterManager.Models.DTO;

namespace DnDCharacterManager.Models.Wrapper
{


    public class BeyondCharacterWrapper
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public CurrencyDTO Currencies { get; set; }
        public List<ItemWrapper> Inventory { get; set; }
        public List<ClassWrapper> Classes { get; set; }
    }

    public class ClassWrapper
    {
        public int Level { get; set; }
        public ClassDetails Definition { get; set; }
    }

    public class ClassDetails
    {
        public string Name { get; set; }
    }
    public class Race
    {
        public string FullName { get; set; }
    }

    public class CurrencyWrapper
    {
        public int cp { get; set; }
        public int sp { get; set; }
        public int gp { get; set; }
        public int ep { get; set; }
        public int pp { get; set; }

    }

    public class ItemWrapper
    {
        public int Quantity { get; set; }
        public ItemData Definition { get; set; }
    }

    public class ItemData
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
    }
}