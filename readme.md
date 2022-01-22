10 é vitoria

L51NG3.passwd88

        public int obtainCodigoDeEquipaLivre(int descricao)
        {
            var value = Database.SqlQuery<int>("select ISNULL(dbo.obtainCodigoDeEquipaLivre(@descricao), -1) equipaId", new System.Data.SqlClient.SqlParameter("@descricao", descricao)).Single();
            return value;
        }
