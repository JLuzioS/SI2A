using System.Data.SqlClient;

namespace AdoNET.dal
{
    interface IContext
    {
        void Open();
        SqlCommand createCommand();
        void EnlistTransaction();
    }
}
