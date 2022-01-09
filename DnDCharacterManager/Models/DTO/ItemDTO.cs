using Newtonsoft.Json;

namespace DnDCharacterManager.Models.DTO
{
    public class ItemDTO
    {
        public int Value { get; set; }
        public string Name { get; set; } = "";
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool Tradeable { get; set; }

    }
}