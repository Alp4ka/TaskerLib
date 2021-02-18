using System;

namespace Tasker
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Experience { get; set; }
        //public string Nickname {get; private set;}
        public string Rank { get=> Utils.GetRankByExp(Experience); }
        public string Fullname { get => $"{Name} {Surname}"; }
        //public int UID { get => _uid; set { _uid = value; } }
        public bool SetName(string newName)
        {
            if(newName.Length < 2 || newName.Length > 30)
            {
                return false;
            }
            Name = char.ToUpper(newName[0]) + newName.Substring(1);
            return true;
        }
        public bool SetSurname(string newSurname)
        {
            if (newSurname.Length < 2 || newSurname.Length > 40)
            {
                return false;
            }
            Surname = char.ToUpper(newSurname[0]) + newSurname.Substring(1);
            return true;
        }
        public static bool CheckName(string name)
        {
            if (name.Length < 2 || name.Length > 30)
            {
                return false;
            }
            return true;
        }
        public static bool CheckSurname(string name)
        {
            if (name.Length < 2 || name.Length > 40)
            {
                return false;
            }
            return true;
        }
        public User(string name, string surname, int experience = 0)
        {
            if (!SetName(name))
            {
                throw new ArgumentException($"Wrong length of name!");
            }
            if (!SetSurname(surname))
            {
                throw new ArgumentException($"Wrong length of surname!");
            }
            Experience = experience;
        }
        public override string ToString()
        {
            return $"[User] {Fullname}. Rank: {Rank} with {Experience} exp.";
        }

    }
}
