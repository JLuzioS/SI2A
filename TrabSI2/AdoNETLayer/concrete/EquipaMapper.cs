using AdoNETLayer.dal;
using AdoNETLayer.mapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace AdoNETLayer.concrete
{
    class EquipasMapper : AbstracMapper<Equipas, int, List<Equipas>>, IMapper<Equipas, int?, List<Equipas>>
    {
        public EquipasMapper(IContext ctx) : base(ctx) { }

        string Table => "Equipas";

        protected override string SelectAllCommandText => $"select * from {this.Table}";

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, Equipas e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand command, Equipas e)
        {
            throw new NotImplementedException();
        }

        protected override Equipas Map(IDataRecord record)
        {
            Equipas equipa = new Equipas();
            equipa.id = record.GetInt32(0);
            equipa.localizacao = record.GetString(1);
            equipa.numElementos = record.GetInt32(2);
            return equipa;
        }

        protected override void SelectParameters(IDbCommand command, int k)
        {
            throw new NotImplementedException();
        }

        protected override Equipas UpdateEntityID(IDbCommand cmd, Equipas e)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateParameters(IDbCommand command, Equipas e)
        {
            throw new NotImplementedException();
        }

        public List<Equipas> GetAllCompetencias()
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

        public Equipas Read(int? id)
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
                    using (var query = cmd.ExecuteReader())
                    {
                        if (query.Read())
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

        public void CreateEquipa(string localizacao, int numElementos)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = "insertEquipa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@localizacao", localizacao));
                    cmd.Parameters.Add(new SqlParameter("@numElementos", numElementos));
                    cmd.ExecuteNonQuery();
                }
                ts.Complete();
            }
        }
    }
}
