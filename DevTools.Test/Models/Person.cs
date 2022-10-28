using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.Test.Models
{
    public abstract class Person : BaseModel
    {
        

        /// <summary>
        /// prend et retourne le nom d'une personne
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///prend et retourne le prenom d'une personne
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// prend et retourne la date de naissnce  d'une personne
        /// </summary>
        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// retourne l'age d'une personne
        /// </summary>
        /// <returns></returns>
        public int Age
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - DateNaissance;
                double hour = timeSpan.TotalHours;
                double year = hour / 24 / 365;
                return (int)year;
            }
        }


        /// <summary>
        /// constructeur vide
        /// </summary>
        public Person() { }

        /// <summary>
        /// constructeur 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prenom"></param>
        /// <param name="dateNaissance"></param>
        public Person(string name, string prenom, DateTime dateNaissance)
        {
            Name = name;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }

    }
}
