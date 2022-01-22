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
    class IntervencoesMapper : AbstracMapper<Intervencoes, int, List<Intervencoes>>
    {

        public IntervencoesMapper(IContext ctx) : base(ctx) { }

        protected override string DeleteCommandText
        {
            get
            {
                return "delete from Intervencoes where id=@id";
            }
        }

        protected override string InsertCommandText
        {
            get
            {
                return "INSERT INTO Intervencoes values(@competencias, " +
                        "@estado, @activo, @vlMonetario, @dtInicio, null, @perMeses); SELECT SCOPE_IDENTITY();";
            }
        }

        protected override string SelectAllCommandText
        {
            get
            {
                return "select * from Intervencoes";
            }
        }

        protected override string SelectCommandText
        {
            get
            {
                return String.Format("{0} where id = @id", SelectAllCommandText);
            }
        }

        protected override string UpdateCommandText
        {
            get
            {
                return "update Intervencoes set competencias=@competencias, estado=@estado" +
                    ", activo=@activo, vlMonetario=@vlMonetario, dtInicio=@dtInicio," +
                    " dtFim=@dtFim, perMeses=@perMeses where id=@id";
            }
        }

        protected override void DeleteParameters(IDbCommand cmd, Intervencoes entity)
        {
            SqlParameter p1 = new SqlParameter("@id", entity.id);
            cmd.Parameters.Add(p1);
        }

        protected override Intervencoes UpdateEntityID(IDbCommand cmd, Intervencoes funcionario)
        {
            var param = cmd.Parameters["@id"] as SqlParameter;
            funcionario.id = int.Parse(param.Value.ToString());
            return funcionario;
        }

        protected override void InsertParameters(IDbCommand cmd, Intervencoes entity)
        {
            SqlParameter p1 = new SqlParameter("@competencias", entity.competencias);
            SqlParameter p2 = new SqlParameter("@estado", entity.estado);
            SqlParameter p3 = new SqlParameter("@activo", entity.activo);
            SqlParameter p4 = new SqlParameter("@vlMonetario", entity.vlMonetario);
            SqlParameter p5 = new SqlParameter("@dtInicio", entity.dtInicio);
            SqlParameter p7 = new SqlParameter("@perMeses", entity.perMeses);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p7);
        }

        internal int CreateWithProcedure(Intervencoes intervencoes)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (IDbCommand cmd = context.createCommand())
                {
                    int id = 0;
                    cmd.CommandText = "p_CriaInter";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@competencias", intervencoes.competencias));
                    cmd.Parameters.Add(new SqlParameter("@activo", intervencoes.activo));
                    cmd.Parameters.Add(new SqlParameter("@vlMonetario", intervencoes.vlMonetario));
                    cmd.Parameters.Add(new SqlParameter("@dtInicio", intervencoes.dtInicio));
                    cmd.Parameters.Add(new SqlParameter("@perMeses", intervencoes.perMeses));

                    SqlParameter p1 = new SqlParameter("@id", id);
                    p1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p1);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        var a = int.Parse(p1.SqlValue.ToString());
                        ts.Complete();
                        return a;
                    } catch (Exception)
                    {
                        return -1;
                    }
                    
                }
                
                
            }
            
        }

        protected override void UpdateParameters(IDbCommand cmd, Intervencoes entity)
        {
            SqlParameter p = new SqlParameter("@id", entity.id);
            SqlParameter p1;
            if (entity.dtFim == null)
            {
                p1 = new SqlParameter("@dtFim", DBNull.Value);
            }
            else
            {
                p1 = new SqlParameter("@dtFim", entity.dtFim);
            }

            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);
            InsertParameters(cmd, entity);
        }

        protected override void SelectParameters(IDbCommand cmd, int id)
        {
            SqlParameter p = new SqlParameter("@id", id);
            cmd.Parameters.Add(p);
        }

        protected override Intervencoes Map(IDataRecord record)
        {
            Intervencoes intervencoes = new Intervencoes();
            intervencoes.id = record.GetInt32(0);
            intervencoes.competencias = record.GetInt32(1);
            intervencoes.estado = record.GetString(2);
            intervencoes.activo = record.GetInt32(3);
            intervencoes.vlMonetario = record.GetDecimal(4);
            intervencoes.dtInicio = record.GetDateTime(5);
            intervencoes.dtFim = record.GetDateTime(6);
            intervencoes.perMeses = record.GetInt32(7);
            return intervencoes;
        }

        public override Intervencoes Create(Intervencoes entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = InsertCommandText;
                    cmd.CommandType = InsertCommandType;
                    InsertParameters(cmd, entity);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) throw new Exception("Id was not returned.");
                        SqlParameter p = new SqlParameter("@id", reader.GetValue(0));
                        cmd.Parameters.Add(p);
                    }
                    Intervencoes ent = UpdateEntityID(cmd, entity);
                    cmd.Parameters.Clear();
                    ts.Complete();
                    return ent;
                }
            }
               
        }

        public bool UpdateIntervencaoState(Intervencoes intervencoes)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = "updateIntervencaoState";
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter p1 = new SqlParameter("@id", intervencoes.id);
                    SqlParameter p2 = new SqlParameter("@estado", intervencoes.estado);

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        ts.Complete();
                        return true;
                    } catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public List<listAllIntervencoesFromDate_Result> GetALLIntervYear(string anoIntervencao)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = "select * from dbo.listAllIntervencoesFromDate(@data)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@data", anoIntervencao));
                    using (var query = cmd.ExecuteReader())
                    {
                        List<listAllIntervencoesFromDate_Result> list = new List<listAllIntervencoesFromDate_Result>();
                        while (query.Read())
                        {
                            listAllIntervencoesFromDate_Result intervencao = new listAllIntervencoesFromDate_Result();
                            intervencao.id = (int)query["id"];
                            intervencao.descricao = (string)query["descricao"];
                            list.Add(intervencao);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
