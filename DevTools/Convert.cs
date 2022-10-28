using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DevTools
{
    public partial class Design : IConvert
    {
        public string[,] GetMultiDimArrayFrom<T>(ICollection<T> list)
        {
           
            List<T> liste = new List<T>();
            liste= list.ToList();
            var nom = typeof(T).GetProperties();
            int row = liste.Count() + 1;
            int column = nom.Count();
            string[,] getMultiDimArrayFrom = new string[row,column];

           for(int j=0; j< column; j++)
            {
                Console.WriteLine(nom[j].Name);
            }
            for (int i=0; i<row; i++)
            {
                if (i == 0)
                {
                    for(int j=0; j< column; j++)
                    {
                        string p = nom[j].Name;
                        getMultiDimArrayFrom[i, j] = $"{p}";
                    }
                }

                else
                {
                    for (int j = 0; j < column; j++)
                    {
                        string nameofproperty = nom[j].Name;
                        var d = GetType().GetProperty(nameofproperty);
                        var s = d ?? nom[j].GetValue(liste[i - 1]) ;
                        getMultiDimArrayFrom[i, j] = $"{s}";
                    }
                }
            }
            return getMultiDimArrayFrom;
        }

        public string[,] GetMultiDimArrayFrom<T>(ICollection<T> list, ICollection<string> excludeProps)
        {
           
            List<T> liste = new List<T>();
            liste = list.ToList();
            List<string> liste2 = new List<string>();
            liste2 = excludeProps.ToList();
            var nom = typeof(T).GetProperties();
            int row = liste.Count() + 1;
            int column = nom.Count();
            int nbr_exclus = excludeProps.Count();
            string[,] getMultiDimArrayFrom = new string[row, column];

            for (int i = 0; i < row; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < column; j++)
                    {
                        string p = nom[j].Name;
                        bool decision = false;

                        for (int k = 0; k < nbr_exclus; k++)
                        {
                            if (p == liste2[k])
                            {
                                decision = true;
                            }
                        }

                        if (!decision)
                        {
                            getMultiDimArrayFrom[i, j] = $"{p}";
                        }

                    }
                }

                else
                {
                    for (int j = 0; j < column; j++)
                    {
                        string nameofproperty = nom[j].Name;
                        bool decision = false;

                        for(int k = 0; k < nbr_exclus; k++)
                        {
                            if (nameofproperty == liste2[k])
                            {
                                decision = true;
                            }
                        }

                        if (!decision)
                        {
                            var d = GetType().GetProperty(nameofproperty);
                            var s = d ?? nom[j].GetValue(liste[i - 1]);
                            getMultiDimArrayFrom[i, j] = $"{s}";
                        }
                        
                    }
                }
            }
            return getMultiDimArrayFrom;
        }

        public string[,] GetMultiDimArrayFrom(IDictionary<string, IEnumerable<string>> datas)
        {

            throw new NotImplementedException();
        }
    }
}
