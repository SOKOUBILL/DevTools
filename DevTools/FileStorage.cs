using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DevTools
{ 
    public class FileStorage<T> where T : BaseModel
    {
        #region(properties)
        private string fileLocation;
        private List<T> list=new List<T>();
        #endregion
        
        #region(constructor)
        public FileStorage(string storageDirectory)
        {
           var fileName = $"{typeof(T).Name}.json";

            fileLocation = Path.Combine(storageDirectory, fileName);
            FileStream fStream = null;
            if(!Directory.Exists(storageDirectory))
                Directory.CreateDirectory(storageDirectory);

            if(!File.Exists(fileLocation))
                fStream = File.Create(fileLocation);

            fStream?.Close();
            Deserialize();
        }

        public FileStorage(string storageDirectory, string fileName)
        {
            fileLocation = Path.Combine(storageDirectory, fileName);
            FileStream fStream = null;
            if (!File.Exists(fileName))
                File.Create(fileName);
            if (!Directory.Exists(storageDirectory))
                Directory.CreateDirectory(storageDirectory);

            if (!File.Exists(fileLocation))
                fStream = File.Create(fileLocation);

            fStream?.Close();
            Deserialize();
        }

        public FileStorage( ) { }

        #endregion

        #region(public methods)

        /// <summary>
        /// Ajouter une donnee et retourne la donnee ajoute
        /// </summary>
        /// <returns></returns>
        public T Create(T data)
        {
            if(data == null)
                throw new ArgumentNullException("data: is not reference as instance " +
                    "of an object");
            data.CreateAt = DateTime.Now;
            data.Id = (list.LastOrDefault()?.Id ?? 0) + 1;
            list.Add(data);
            Serialize();
            return data;
        }


        /// <summary>
        /// Modifie les proprites d'une donnee et retourne la nouvelle
        /// donnee
        /// </summary>
        /// <returns></returns>
        public T Update(int id , T data)
        {
            
            try
            {
                if (data == null)
                    throw new ArgumentNullException("data: is not reference as instance " +
                        "of an object");
                var result = list.FirstOrDefault(x => x.Id == id);
                if (result == null)
                    throw new ArgumentNullException("Entity not found");
                var index = list.IndexOf(result);
                list[index] = data;
                Serialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return data;
        }


        /// <summary>
        /// supprime une donnee et return true si elle a ete supprime 
        /// et false dans le cas ccontraire
        /// </summary>
        /// <returns></returns>
        public bool Delete(int id )
        {
            bool decision = false;
            try
            {
                var result = list.FirstOrDefault(x => x.Id == id);
                if (result == null)
                    throw new ArgumentNullException("Cette personne  n'existe " +
                        "pas !");
                decision = list.Remove(result);
                Serialize();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            if (decision)
                return true;
            return false;
        }


        /// <summary>
        /// retourne la liste des donnees contenues dans la base de données  
        /// </summary>
        /// <returns></returns>
        public ICollection<T> GetAll(int? skip = null, int? take = null) =>
            list.Skip(skip ?? 0).Take(take ?? list.Count).ToList();


        #endregion


        #region(private methods)

        private void Deserialize()
        {
            var json=File.ReadAllText(fileLocation);
            list =JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
         private void Serialize()
        {
            try
            {
                var jsonData= JsonConvert.SerializeObject(list);
                File.WriteAllText(fileLocation, jsonData);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        #endregion
    }
}
