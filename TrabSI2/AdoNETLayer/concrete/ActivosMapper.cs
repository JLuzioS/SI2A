using AdoNETLayer.dal;
using AdoNETLayer.mapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace AdoNETLayer.concrete
{
    class ActivosMapper : AbstracMapper<Activos, int, List<Activos>>
    {
        public ActivosMapper(IContext ctx) : base(ctx) { }

        string Table => "Activos";

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
            activos.marca = record.GetValue(4) is DBNull ? null : record.GetString(4);
            activos.modelo = record.GetValue(5) is DBNull ? null : record.GetString(5);
            activos.localizacao = record.GetValue(6) is DBNull ? null : record.GetString(6);
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

        public Activos Read(int? id)
        {
            throw new NotImplementedException();
        }

    }
}
