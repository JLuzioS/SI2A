using AdoNETLayer.dal;
using AdoNETLayer.mapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdoNETLayer.concrete
{
    class ActivosMapper : AbstracMapper<Activos, int, List<Activos>>, IMapper<Activos, int?, List<Activos>>
    {
        public ActivosMapper(IContext ctx) : base(ctx) { }

        string Table => "Competencias";

        protected override string SelectAllCommandText => $"select * from {this.Table}";

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, Activos e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand command, Activos e)
        {
            throw new NotImplementedException();
        }

        protected override Activos Map(IDataRecord record)
        {
            Activos activos = new Activos();
            activos.id = record.GetInt32(0);
            activos.nome = record.GetString(1);
            activos.dtAaquisicao = record.GetDateTime(2);
            activos.estado = record.GetByte(3);
            activos.marca = record.GetString(4);
            activos.modelo= record.GetString(5);
            activos.localizacao = record.GetString(6);
            activos.funcionario = record.GetInt32(7);
            activos.tipo = record.GetInt32(8);
            return activos;
        }

        protected override void SelectParameters(IDbCommand command, int k)
        {
            throw new NotImplementedException();
        }

        protected override Activos UpdateEntityID(IDbCommand cmd, Activos e)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateParameters(IDbCommand command, Activos e)
        {
            throw new NotImplementedException();
        }

        public List<Activos> GetAllCompetencias()
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (var query = ExecuteReader(SelectAllCommandText, null))
                {
                    var result = MapAll(query);
                    ts.Complete();
                    return result;
                }
            }
        }

        public Activos Read(int? id)
        {
            throw new NotImplementedException();
        }

    }
}
