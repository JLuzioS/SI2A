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
    class IntervencoesEquipasMapper : AbstracMapper<IntervencoesEquipas, int, List<IntervencoesEquipas>>
    {
        public IntervencoesEquipasMapper(IContext ctx) : base(ctx) { }
        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => "insert into IntervencoesEquipas values (@equipa, @intervencao, @dtAtribuicao, null)";

        protected override void DeleteParameters(IDbCommand command, IntervencoesEquipas e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand cmd, IntervencoesEquipas entity)
        {
            SqlParameter p1 = new SqlParameter("@equipa", entity.equipa);
            SqlParameter p2 = new SqlParameter("@intervencao", entity.intervencao);
            SqlParameter p3 = new SqlParameter("@dtAtribuicao", entity.dtAtribuicao);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
        }

        protected override IntervencoesEquipas Map(IDataRecord record)
        {
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int k)
        {
            throw new NotImplementedException();
        }

        protected override IntervencoesEquipas UpdateEntityID(IDbCommand cmd, IntervencoesEquipas e)
        {
            throw new NotImplementedException();
        }

        public bool AddEquipaToIntervencao(IntervencoesEquipas entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = InsertCommandText;
                    cmd.CommandType = InsertCommandType;
                    InsertParameters(cmd, entity);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    ts.Complete();
                    return true;
                }
            }
        }

        protected override void UpdateParameters(IDbCommand cmd, IntervencoesEquipas entity)
        {
            throw new NotImplementedException();
        }
    }
}
