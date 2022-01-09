using DnDCharacterManager.Models.Wrapper;

namespace DnDCharacterManager.Models.DTO
{
    public class Character
    {
        public int Id { get; set; }
        public int Milestones { get; set; }
        public string Name { get; set; } = "";
        public string ImageURL { get; set; } = "";
        public string Race { get; set; } = "";
        public int Level { get; set; }
        public CurrencyDTO Currency { get; set; } = new CurrencyDTO();
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
        public UserDTO? Player { get; set; }
        public int? PlayerId { get; set; }
        public string Description { get; set; }
        public List<CharacterClass> Classes { get; set; }

        public static explicit operator Character(BeyondCharacterWrapper bc)
        {
            var characterDTO = new Character()
            {
                Name = bc.data.Name,
                Race = bc.data.Race.FullName,
                Currency = bc.data.Currencies,
                Items = bc.data.Inventory.Select(x => new ItemDTO()
                {
                    Name = x.Definition.Name,
                    Quantity = x.Quantity,
                }).ToList(),
                Level = bc.data.Classes.Sum(c => c.Level),
                Milestones = 0,
                Description = "",
                Classes = bc.data.Classes.Select(c => new CharacterClass() { Name = c.Definition.Name }).ToList()
            };
            return characterDTO;
        }
    }

    public class CharacterDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public string ImageURL { get; set; } = "";
        public string Race { get; set; } = "";
        public int Level { get; set; }
        public List<string> Classes { get; set; }
        public CharacterDTO(Character character)
        {
            Id = character.Id;
            Name = character.Name;
            Race = character.Race;
            Level = character.Level;
            Classes = character.Classes.Select(c => c.Name).ToList();
        }
    }

    public class CharacterDetailDTO : CharacterDTO
    {
        public CurrencyDTO Currency { get; set; } = new CurrencyDTO();
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
        public int Milestones { get; set; }
        public string Description { get; set; }
        public CharacterDetailDTO(Character character) : base(character)
        {
            Items = character.Items;
            Currency = character.Currency;
            Description = character.Description;
            Milestones = character.Milestones;
        }
    }
}