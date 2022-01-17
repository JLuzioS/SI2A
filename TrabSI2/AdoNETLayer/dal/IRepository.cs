using System;
using System.Collections.Generic;

namespace AdoNETLayer.dal
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Func<T, bool> criteria);
    }
}
