using System;
using System.Data.SqlClient;

namespace AdoNETLayer.dal
{
    public interface IContext : IDisposable
    {
        void Open();
        SqlCommand createCommand();
        void EnlistTransaction();
    }
}
