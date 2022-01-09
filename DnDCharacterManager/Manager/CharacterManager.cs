using DnDCharacterManager.Models.DTO;
using DnDCharacterManager.Util;

namespace DnDCharacterManager.Manager
{
    public static class CharacterManager
    {
        public static Character CreateCharacter(Character character,UserDTO player)
        {
            using (var db = new DnDContext())
            {
                db.AddRange(character.Items);
                db.Add(character.Currency);

                character.Classes = character.Classes.Select(c => CreateOrGetCharClass(c.Name,db)).ToList();


                var dbCharacter = db.Add(character).Entity;
                db.SaveChanges();
                dbCharacter.Player = player;
                db.Update(dbCharacter);
                db.SaveChanges();
                return dbCharacter;
            }

        }
        private static CharacterClass CreateOrGetCharClass(string className,DnDContext db)
        {
            var charClass = db.Classes.FirstOrDefault(c => c.Name == className);
            if (charClass != default)
            {
                return charClass;
            }
            var dbClass = db.Classes.Add(new CharacterClass() { Name = className }).Entity;
            db.SaveChanges();
            return dbClass;
        } 
    }
}
