using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker
{
    public class User: IAssignable
    {
        private int _uid;
        private int _experience;
        public string Name { get; private set; }
        public string Surname { get; private set; }
        //public string Nickname {get; private set;}
        public string Rank { get=> Utils.GetRankByExp(_experience); }
        public string Fullname { get => $"{Name} {Surname}"; }
        public int UID { get => _uid; set { _uid = value; } }
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
            if (newSurname.Length < 3 || newSurname.Length > 40)
            {
                return false;
            }
            Surname = char.ToUpper(newSurname[0]) + newSurname.Substring(1);
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
            _experience = experience;
        }
        


    }
}
