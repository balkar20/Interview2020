using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DisneyPrincessApp
{
    interface IRepository<T, N> where T : class
    {
        void AddElement(T item);
        void DeleteElement(N atr);
        T GetElement(N atr);
        void UpdateElement(T item);
    }
}
