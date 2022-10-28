using System;
using DevTools.Test.Services.Persons;
using DevTools.Test.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.Test.Services.Teachers
{
    public class TeacherService : PersonService<Teacher> 
    {
        public TeacherService(string directory, string name) 
            : base(directory,typeof(Teacher).Name) { }

        public Teacher Add()
        {
            bool isvalide;
            double salaire;

            Console.WriteLine($"Entrer le nom de l'enseignant :");
            string name = Console.ReadLine();
            Console.WriteLine($"Entrer son prenom :");
            string prenom = Console.ReadLine();
            Console.WriteLine($"Entrer sa date de naissance suivant cette ordre(année/mois/jour): ");
            string datet = Console.ReadLine();
            DateTime dateNaissance = DateTime.Parse(datet);

            do
            {
                Console.WriteLine($"Entrer son salaire :");
                string value = Console.ReadLine();
                isvalide = double.TryParse(value, out salaire);
            } while (isvalide == false);

            Console.WriteLine($"Entrer sa date de prise de fonction suivant cette ordre(année/mois/jour): ");
            string datet2 = Console.ReadLine();
            DateTime datePriseFonction = DateTime.Parse(datet2);

            Teacher teacher = new Teacher(name, prenom, dateNaissance, salaire, datePriseFonction);
            return teacher;
        }

    }
}
