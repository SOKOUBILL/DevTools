using System;
using DevTools.Test.Services.Persons;
using DevTools.Test.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.Test.Services.Students
{
    public class StudentService : PersonService<Student> 
    {
        public StudentService(string storageDirectory, string namefile) 
            : base("dat",typeof(Student).Name) { }

        public Student Add()
        {
            Console.WriteLine($"Entrer le nom de l'etudiant :");
            string name = Console.ReadLine();
            Console.WriteLine($"Entrer son prenom :");
            string prenom = Console.ReadLine();
            Console.WriteLine($"Entrer sa date de naissance suivant cette ordre(année/mois/jour): ");
            string date = Console.ReadLine();
            DateTime dateNaissance = DateTime.Parse(date);
            Console.WriteLine($"Entrer son matricule :");
            string matricule = Console.ReadLine();
            Student student = new Student(name, prenom, dateNaissance, matricule);

            return student;
        }

        public Student Update()
        {
            Console.WriteLine(" Veiller entrer le nom de l'etudiant que vous voulez modifier ");
            string nameStudentAModifier = Console.ReadLine();
            Console.WriteLine($"\n\t\t Veiller renseigner les nouvelles informations");
            Console.WriteLine($"Entrer le nom de l'etudiant :");
            string name = Console.ReadLine();
            Console.WriteLine($"Entrer son prenom :");
            string prenom = Console.ReadLine();
            Console.WriteLine($"Entrer sa date de naissance suivant cette ordre(année/mois/jour): ");
            string date = Console.ReadLine();
            DateTime dateNaissance = DateTime.Parse(date);
            Console.WriteLine($"Entrer son matricule :");
            string matricule = Console.ReadLine();

            Student student = new Student(name, prenom, dateNaissance, matricule);
            return student;
        }


    }
}
