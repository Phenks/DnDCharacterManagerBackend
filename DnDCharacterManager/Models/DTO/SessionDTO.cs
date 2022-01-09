namespace DnDCharacterManager.Models.DTO
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int  MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public bool Active { get; set; }
        /// <summary>
        /// Id of the user that created the session
        /// </summary>
        public int CreatorId { get; set; }
    }
}
