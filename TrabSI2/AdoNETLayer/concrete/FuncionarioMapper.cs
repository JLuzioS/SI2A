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
    class FuncionarioMapper :AbstracMapper<Funcionarios, int, List<Funcionarios>>, IMapper<Funcionarios, int?, List<Funcionarios>>
    {

        public FuncionarioMapper(IContext ctx) : base(ctx) { }

        string Table => "Funcionarios";

        protected override string DeleteCommandText
        {
            get
            {
                return $"delete from {this.Table} where id=@id";
            }
        }

        protected override string InsertCommandText
        {
            get
            {
                return $"INSERT INTO {this.Table} values(@cc,@nif, " +
                        "@nome, @dtNascimento, @morada, @codigoPostal, @localidade, @profissao" +
                        ", @telefone, @telemovel);";
            }
        }

        protected override string SelectAllCommandText
        {
            get
            {
                return $"select * from {this.Table}";
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
                return $"update {this.Table} set cc=@cc, nif=@nif, nome=@nome" +
                    ", dtNascimento=@dtNascimento, morada=@morada, codigoPostal=@codigoPostal," +
                    " localidade=@localidade, profissao=@profissao, telefone=@telefone, telemovel=@telemovel" +
                    " where studentNumber=@id";
            }
        }
        public override Funcionarios Create(Funcionarios entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                context.EnlistTransaction();

                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = InsertCommandText;
                    cmd.CommandType = InsertCommandType;
                    InsertParameters(cmd, entity);
                    cmd.ExecuteNonQuery();
                    entity = UpdateEntityID(cmd, entity);
                }


                ts.Complete();
                return entity;

            }

        }

        public List<Funcionarios> GetAllFuncionarios()
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
        protected override void DeleteParameters(IDbCommand cmd, Funcionarios entity)
        {
            SqlParameter p1 = new SqlParameter("@id", entity.id);
            cmd.Parameters.Add(p1);
        }

        protected override Funcionarios UpdateEntityID(IDbCommand cmd, Funcionarios funcionario)
        {
            var param = cmd.Parameters["@id"] as SqlParameter;
            funcionario.id = int.Parse(param.Value.ToString());
            return funcionario;
        }

        protected override void InsertParameters(IDbCommand cmd, Funcionarios entity)
        {
            UpdateParameters(cmd, entity);
        }

        protected override void UpdateParameters(IDbCommand cmd, Funcionarios entity)
        {
            SqlParameter p = new SqlParameter("@cc", entity.cc);
            SqlParameter p1 = new SqlParameter("@nif", entity.nif);
            SqlParameter p2 = new SqlParameter("@nome", entity.cc);
            SqlParameter p3 = new SqlParameter("@dtNascimento", entity.nif);
            SqlParameter p4 = new SqlParameter("@morada", entity.cc);
            SqlParameter p5 = new SqlParameter("@codigoPostal", entity.nif);
            SqlParameter p6 = new SqlParameter("@localidade", entity.cc);
            SqlParameter p7 = new SqlParameter("@profissao", entity.nif);
            SqlParameter p8 = new SqlParameter("@telefone", entity.nif);
            SqlParameter p9 = new SqlParameter("@telemovel", entity.nif);

            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.Parameters.Add(p8);
            cmd.Parameters.Add(p9);
        }

        protected override void SelectParameters(IDbCommand cmd, int id)
        {
            SqlParameter p = new SqlParameter("@id", id);
            cmd.Parameters.Add(p);
        }

        protected override Funcionarios Map(IDataRecord record)
        {
            Funcionarios funcionario = new Funcionarios();
            funcionario.id = record.GetInt32(0);
            funcionario.cc = record.GetValue(1) is DBNull ? null : record.GetString(1);
            funcionario.nif = record.GetValue(2) is DBNull ? null : record.GetString(2);
            funcionario.nome = record.GetString(3);
            funcionario.dtNascimento = record.GetDateTime(4);
            funcionario.morada = record.GetString(5);
            funcionario.codigoPostal = record.GetString(6);
            funcionario.localidade = record.GetString(7);
            funcionario.profissao = record.GetInt32(8);
            funcionario.telefone = record.GetValue(9) is DBNull ? null : record.GetString(9);
            funcionario.telemovel = record.GetValue(10) is DBNull ? null : record.GetString(10);

            return funcionario;
        }

        public Funcionarios Read(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
