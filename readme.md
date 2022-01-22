10 é vitoria

L51NG3.passwd88

public int obtainCodigoDeEquipaLivre(int descricao)
        {
            var value = Database.SqlQuery<int>("select dbo.obtainCodigoDeEquipaLivre(@descricao) equipaId", new System.Data.SqlClient.SqlParameter("@descricao", descricao)).Single();
            return value;
        }
