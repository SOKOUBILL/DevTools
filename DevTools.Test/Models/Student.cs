using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.Test.Models
{
    public class Student : Person
    {
        /// <summary>
        ///prend et retourne le matricule d'un etudiant
        /// </summary>
        public string Matricule { get; set; }


        /// <summary>
        /// constructeur 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prenom"></param>
        /// <param name="dateNaissance"></param>
        /// <param name="matricule"></param>
        public Student(string name, string prenom, DateTime dateNaissance, string matricule)
            : base(name, prenom, dateNaissance)
        {
            Matricule = matricule;
        }

        /// <summary>
        /// constructeur vide 
        /// </summary>
        public Student() { }

        public override string ToString()
        {
            return $" hello i am StudentService. mon nom est {Name} , mon prenom est {Prenom}" +
                $" et mon matricule est  {Matricule}.";
        }
    }
}
