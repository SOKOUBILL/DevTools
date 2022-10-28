using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools
{
    public interface IConvert
    {
        string[,] GetMultiDimArrayFrom<T>(ICollection<T> list);
        string[,] GetMultiDimArrayFrom<T>(ICollection<T> list, ICollection<string> excludeProps);
        string[,] GetMultiDimArrayFrom(IDictionary<string, IEnumerable<string>> datas);
    }
}
