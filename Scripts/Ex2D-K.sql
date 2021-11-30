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

CREATE PROCEDURE updateFuncionario (
    @id INT,
    @cc VARCHAR(13) = NULL,
    @nif VARCHAR(12) = NULL,
    @nome_completo VARCHAR(256) = NULL,
    @data_de_nascimento DATE = NULL,
    @morada VARCHAR(256) = NULL,
    @codigo_postal VARCHAR(8) = NULL,
    @localidade VARCHAR(256) = NULL,
    @profissao VARCHAR(256) = NULL,
    @telefone INT = NULL,
    @telemovel INT = NULL)
AS   
BEGIN
    IF (NULLIF(@id, '') IS NULL)
        RAISERROR ('Funcionario ID can''t be null', 10, 0)
    SET @cc = NULLIF(@cc, '')
    SET @nif = NULLIF(@nif, '')
    SET @nome_completo = NULLIF(@nome_completo, '') 
    SET @data_de_nascimento = NULLIF(@data_de_nascimento, '') 
    SET @morada = NULLIF(@morada, '')
    SET @codigo_postal = NULLIF(@codigo_postal, '')
    SET @localidade = NULLIF(@localidade, '')
    SET @profissao = NULLIF(@profissao, '') 
    SET @telefone = NULLIF(@telefone, '')
    SET @telemovel = NULLIF(@telemovel, '') 

    UPDATE Funcionarios 
	SET cc = ISNULL(@cc, cc), 
		nif = ISNULL(@nif, nif),
		nome_completo = ISNULL(@nome_completo, nome_completo),
		data_de_nascimento = ISNULL(@data_de_nascimento, data_de_nascimento),
		morada = ISNULL(@morada, morada),
		codigo_postal = ISNULL(@codigo_postal, codigo_postal),
		localidade = ISNULL(@localidade, localidade),
		profissao = ISNULL(@profissao, profissao), 
		telefone = ISNULL(@telefone, telefone),
		telemovel = ISNULL(@telemovel, telemovel) 
    WHERE id = @id;
END;

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


