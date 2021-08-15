using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    public interface IPrinter
    {/// <summary>
    /// интерфейс вывода информации
    /// </summary>
    /// <param name="text"></param>
        void Print(string text);
    }
}
