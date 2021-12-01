-- D
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
        INSERT INTO Funcionarios VALUES (@cc, @nif, @nome_completo, @data_de_nascimento, @morada, @codigo_postal, @localidade, @profissao, @telefone, @telemovel)
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

CREATE PROCEDURE deleteFuncionario @id INT
AS
BEGIN
    if @id IS NOT NULL
    BEGIN
        DELETE FROM Funcionarios where id = @id
    END
END;
GO

-- E
CREATE FUNCTION obtainCodigoDeEquipaLivre (@descricao VARCHAR(256) NOT NULL)
    RETURNS INT
        AS
            BEGIN

            DECLARE @competenciasID INT

            SELECT @competenciasID = id FROM Competencias WHERE (descricao = @descricao)

            SELECT funcionario FROM FuncionariosCompetencias WHERE @competenciasID = competencia

            SELECT equipa FROM IntervencoesEquipas GROUP BY equipa HAVING COUNT(*) < 3 
            

            RETURN @a

            END
go

-- F
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

            INSERT INTO Intervencoes VALUES (@descricao, @estado, @activo, @valor_monetario, @data_inicio, NULL)
            
            END
        ELSE
            BEGIN
            RAISERROR('Data de inicio da intervenção é inferior à data de acquisição do Activo', 10, 0)
            END
    END
GO 


--G
CREATE PROCEDURE insertEquipa @localizacao VARCHAR(256)
AS
    BEGIN

        IF (NULLIF(@localizacao, '') IS NULL)
            RAISERROR ('Localização can''t be null', 10, 0)
        INSERT INTO Equipas VALUES (@localizacao, 0)
        
    END
GO