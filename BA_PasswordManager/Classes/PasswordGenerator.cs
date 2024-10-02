using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_PasswordManager.Classes
{
    internal static class PasswordGenerator
    {
        static Random rnd = new Random();
        static string allowSymbol = "1234567890qwertyuiop[]lkjhgfdsazxcvbnmQWERTYUIOPASDFGHJKL:ZXCVBNM";
        static string otherSymbol = "!@#$%^&*()_+";

        public static string generatePassword(int passSize)
        {
            string password = "";
            bool symbolType;
            for(int i = 0;  i < passSize; i++)
            {
                if(rnd.Next(10) > 2)
                    symbolType = true;
                else
                    symbolType = false;

                if (symbolType)
                    password += allowSymbol[rnd.Next(allowSymbol.Length)];
                else
                    password += otherSymbol[rnd.Next(otherSymbol.Length)];

            }

            return password;
        }
    }
}
