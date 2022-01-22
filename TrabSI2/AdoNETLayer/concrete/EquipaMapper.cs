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
    class EquipasMapper : AbstracMapper<Equipas, int, List<Equipas>>
    {
        public EquipasMapper(IContext ctx) : base(ctx) { }

        string Table => "Equipas";

        protected override string SelectAllCommandText => $"select * from {this.Table}";

        protected override string SelectCommandText => String.Format("{0} where id = @id", SelectAllCommandText);

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
            equipa.localizacao= record.GetString(1);
            equipa.numElementos= record.GetInt32(2);
            return equipa;
        }

        protected override void SelectParameters(IDbCommand command, int k)
        {
            SqlParameter p = new SqlParameter("@id", k);
            command.Parameters.Add(p);
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

        public Equipas AddFuncionario(Equipas equipa, Funcionarios funcionario)
        {
            //insertFuncionariosEquipa @funcionario INT, @equipa INT, @dtEntrada DATE
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = "insertFuncionariosEquipa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@funcionario", funcionario.id));
                    cmd.Parameters.Add(new SqlParameter("@equipa", equipa.id));
                    cmd.Parameters.Add(new SqlParameter("@dtEntrada", DateTime.Now));
                    cmd.ExecuteNonQuery();
                }
                ts.Complete();
            }
            return equipa;
        }

        
        public Equipas DeleteFuncionario(Equipas equipa, Funcionarios funcionario)
        {
            // deleteFuncionariosEquipa @funcionario INT, @equipa INT, @dtSaida DATE AS
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = "deleteFuncionariosEquipa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@funcionario", funcionario.id));
                    cmd.Parameters.Add(new SqlParameter("@equipa", equipa.id));
                    cmd.Parameters.Add(new SqlParameter("@dtSaida", DateTime.Now));
                    cmd.ExecuteNonQuery();
                }
                ts.Complete();
            }
            return equipa;
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
                        int result = query.Read() ? query.GetInt32(0) : 0;
                        ts.Complete();
                        return result;
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
