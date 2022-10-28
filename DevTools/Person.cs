using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DevTools
{
    public class Person : BaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DateNaiss { get; set; }
        public string Speudo { get; set; }

        public Person(string email, string name, DateTime dateNaiss, string speudo)
        {
            Email = email;
            Name = name;
            DateNaiss = dateNaiss;
            Speudo = speudo;
        }
    }
}
