using AdoNET.dal;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace AdoNET.concrete
{

    class Context : IContext
    {
        private string connectionString;
        private SqlConnection con = null;

        private IFuncionarioRepository _funcionarioRepository;

        public Context(string cs)
        {
            connectionString = cs;
            _countryRepository = new FuncionarioRepository(this);
        }

        public void Open()
        {
            if (con == null)
            {
                con = new SqlConnection(connectionString);

            }
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public SqlCommand createCommand()
        {
            Open();
            SqlCommand cmd = con.CreateCommand();
            return cmd;
        }
        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }

        }

        public void EnlistTransaction()
        {
            if (con != null)
            {
                con.EnlistTransaction(Transaction.Current);
            }
        }

        public IFuncionarioRepository funcionarios
        {
            get
            {
                return _funcionariosRepository;
            }
        }


    }
    
}
