using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePasswordDLL
{
    public class CodePassword
    {
        public string getPassword(string p_sPassw)
        {
            string password = "";
            foreach (char a in p_sPassw)
            {
                char ch = a;
                ch--;
                password += ch;
            }
            return password;
        }
        
    }
}
