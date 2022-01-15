using System;
using System.Collections.Generic;

namespace AdoNET.dal
{
    interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Func<T, bool> criteria);
    }
}
