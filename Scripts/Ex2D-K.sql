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


