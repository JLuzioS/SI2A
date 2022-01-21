using AdoNETLayer.dal;
using AdoNETLayer.mapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace AdoNETLayer.concrete
{
    class CompetenciaMapper : AbstracMapper<Competencias, int, List<Competencias>>
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

            return competencia;
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


    }
}
