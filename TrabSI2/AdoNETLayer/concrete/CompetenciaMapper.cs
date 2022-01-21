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
    class CompetenciaMapper : AbstracMapper<Competencias, int, List<Competencias>>, ICompetenciasMapper
    {
        public CompetenciaMapper(IContext ctx) : base(ctx) { }

        string Table => "Competencias";

        protected override string SelectAllCommandText => $"select * from {this.Table}";

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, Competencias e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand command, Competencias e)
        {
            throw new NotImplementedException();
        }

        protected override Competencias Map(IDataRecord record)
        {
            Competencias competencia = new Competencias();
            competencia.id = record.GetInt32(0);
            competencia.descricao = record.GetString(1);

            return new CompetenciasProxy(competencia);
        }

        protected override void SelectParameters(IDbCommand command, int k)
        {
            throw new NotImplementedException();
        }

        protected override Competencias UpdateEntityID(IDbCommand cmd, Competencias e)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateParameters(IDbCommand command, Competencias e)
        {
            throw new NotImplementedException();
        }

        public List<Competencias> GetAllCompetencias()
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (var query = ExecuteReader(SelectAllCommandText, null))
                {
                    List<Competencias> result = new List<Competencias>();
                    while (query.Read())
                    {
                        result.Add(Map(query));
                    }

                    return result;
                }
            }
        }

        public Competencias Read(int? id)
        {
            throw new NotImplementedException();
        }

        public int GetFreeEquipa(int competenciaId)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = "select dbo.obtainCodigoDeEquipaLivre(@descricao)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@descricao", competenciaId));
                    var query = cmd.ExecuteReader();
                    if(query.Read())
                    {
                        return query.GetInt32(0);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
