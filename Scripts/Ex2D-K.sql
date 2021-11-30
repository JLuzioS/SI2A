CREATE PROCEDURE insertFuncionario  @cc VARCHAR(13), 
                                    @nif VARCHAR(12), 
                                    @nome_completo VARCHAR(256), 
                                    @data_de_nascimento DATE, 
                                    @morada VARCHAR(256), 
                                    @codigo_postal VARCHAR(8), 
                                    @localidade VARCHAR(256), 
                                    @profissao VARCHAR(256), 
                                    @telefone INT, 
                                    @telemovel INT
AS
    BEGIN
        DECLARE @id AS BIGINT
        SELECT TOP 1 @id = id + 1  FROM Funcionarios ORDER BY id ASC
        INSERT INTO Funcionarios VALUES (ISNULL(@id, 1), @cc, @nif, @nome_completo, @data_de_nascimento, @morada, @codigo_postal, @localidade, @profissao, @telefone, @telemovel)
    END
GO



CREATE PROCEDURE deleteFuncionario  @id INT
AS
    BEGIN
        if @id IS NOT NULL
        BEGIN
            DELETE FROM Funcionarios where id = @id
        END
    END
GO

CREATE PROCEDURE p_CriaInter    @descricao INT,
                                @estado INT,
                                @activo INT,
                                @valor_monetario FLOAT,
                                @data_inicio DATE
AS
    BEGIN
        DECLARE @data_aquisicao DATE
        SELECT @data_aquisicao = data_aquisicao FROM Activos where @activo = id
        
        IF @data_inicio > @data_aquisicao
            BEGIN

            DECLARE @id AS BIGINT
            SELECT TOP 1 @id = id + 1  FROM Intervencoes ORDER BY id ASC
            INSERT INTO Intervencoes VALUES (ISNULL(@id, 1), @descricao, @estado, @activo, @valor_monetario, @data_inicio, NULL)
            
            END
        ELSE
            BEGIN
            PRINT 'ELSE'
            RAISERROR(15600, -1, -1, 'Data de inicio da intervenção é inferior à data de acquisição do Activo')
            END
    END

    drop PROCEDURE p_CriaInter
