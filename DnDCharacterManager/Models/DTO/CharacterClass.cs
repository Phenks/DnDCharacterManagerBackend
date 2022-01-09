namespace DnDCharacterManager.Models.DTO
{
    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Character> Characters { get; set;}
    }
}
