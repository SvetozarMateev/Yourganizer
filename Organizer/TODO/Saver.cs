using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Contracts;
using TODO.Models;

namespace TODO
{
    public static class Saver
    {
        public static void SaveUsernamesAndPasswords(string usernames, string password)
        {
            using (StreamWriter writer = new StreamWriter("../../../../Database/DatabaseOfUsernames.txt", true))
            {
                writer.Write(usernames);
                writer.WriteLine($" {password}");
            }
        }
        public static void CreateUserFile(IUser user)
        {
            using (StreamWriter writer = new StreamWriter($"../../../../Database/{user.Username}_UserDatabase.txt"))
            {
                writer.WriteLine(user.FormatUserInfoForDB());
            }
        }
    }
}
