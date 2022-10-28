using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.Test.Models
{
    public class Teacher : Person
    {
        /// <summary>
        ///prend et retourne le salaire d'un enseignant
        /// </summary>
        public double Salaire { get; set; }

        /// <summary>
        ///prend et retourne la date de prise de fonction d'un enseignant
        /// </summary>
        public DateTime DatePriseFonction { get; set; }

        /// <summary>
        /// constructeur vide
        /// </summary>
        public Teacher() { }


        /// <summary>
        /// constructeur 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prenom"></param>
        /// <param name="dateNaissance"></param>
        /// <param name="salaire"></param>
        /// <param name="datePriseFonction"></param>
        public Teacher(string name, string prenom, DateTime dateNaissance,
            double salaire, DateTime datePriseFonction)
            : base(name, prenom, dateNaissance)
        {
            Salaire = salaire;
            DatePriseFonction = datePriseFonction;
        }

    }
}
