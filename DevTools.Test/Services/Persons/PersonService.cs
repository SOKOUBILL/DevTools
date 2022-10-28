using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DevTools.Test.Services.Persons
{
    public class PersonService<T>: FileStorage<T> where T : BaseModel
    {
        public PersonService(string storageDirectory, string name) 
            : base(storageDirectory, name) { }
    }
}
