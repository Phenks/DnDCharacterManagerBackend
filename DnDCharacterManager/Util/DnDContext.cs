using DnDCharacterManager.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterManager.Util
{
    public class DnDContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<ItemDTO> Items { get; set; }
        public DbSet<CurrencyDTO> Currencies { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<CharacterClass> Classes { get; set; }
        public DbSet<SessionDTO> Sessions { get; set; }


        public string DbPath { get; private set; }
        public DnDContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}dnd.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
