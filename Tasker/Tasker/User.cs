using System;

namespace Tasker
{
    public class User
    {
        // User id.
        public int ID { get; set; }
        // User name.
        public string Name { get; private set; }
        // User surname.
        public string Surname { get; private set; }
        // User experience.
        public int Experience { get; set; }
        // User rank.
        public string Rank { get=> Utils.GetRankByExp(Experience); }
        // User fullname.
        public string Fullname { get => $"{Name} {Surname}"; }

        /// <summary>
        /// Set name.
        /// </summary>
        /// <param name="newName"> String name. </param>
        /// <returns> true if correct, false otherwise. </returns>
        public bool SetName(string newName)
        {
            if(newName.Length < 2 || newName.Length > 30)
            {
                return false;
            }
            Name = char.ToUpper(newName[0]) + newName.Substring(1);
            return true;
        }
        /// <summary>
        /// Set surname.
        /// </summary>
        /// <param name="newSurname"> String surname. </param>
        /// <returns> true if correct, false otherwise. </returns>
        public bool SetSurname(string newSurname)
        {
            if (newSurname.Length < 2 || newSurname.Length > 40)
            {
                return false;
            }
            Surname = char.ToUpper(newSurname[0]) + newSurname.Substring(1);
            return true;
        }
        // Get Type.
        public string Type { get => "[User]"; }

        /// <summary>
        /// Check name.
        /// </summary>
        /// <param name="name"> String name. </param>
        /// <returns> true id correct, false otherwise. </returns>
        public static bool CheckName(string name)
        {
            if (name.Length < 2 || name.Length > 30)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check surname.
        /// </summary>
        /// <param name="name"> String name. </param>
        /// <returns> true id correct, false otherwise. </returns>
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
