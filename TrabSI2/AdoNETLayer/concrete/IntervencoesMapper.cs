using AdoNETLayer.dal;
using AdoNETLayer.mapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                        "@estado, @activo, @vlMonetario, @dtInicio, @dtFim, @perMeses);";
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
                return "update Intervencoes set id=@id competencias=@competencias, estado=@estado" +
                    ", activo=@activo, vlMonetario=@vlMonetario, dtInicio=@dtInicio," +
                    " dtFim=@dtFim, perMeses=@perMeses where studentNumber=@id";
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
            UpdateParameters(cmd, entity);
        }

        protected override void UpdateParameters(IDbCommand cmd, Intervencoes entity)
        {
            SqlParameter p = new SqlParameter("@id", entity.id);
            SqlParameter p1 = new SqlParameter("@competencias", entity.competencias);
            SqlParameter p2 = new SqlParameter("@estado", entity.estado);
            SqlParameter p3 = new SqlParameter("@activo", entity.activo);
            SqlParameter p4 = new SqlParameter("@vlMonetario", entity.vlMonetario);
            SqlParameter p5 = new SqlParameter("@dtInicio", entity.dtInicio);
            SqlParameter p6 = new SqlParameter("@dtFim", entity.dtFim);
            SqlParameter p7 = new SqlParameter("@perMeses", entity.perMeses);

            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
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

        public Intervencoes Read(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
