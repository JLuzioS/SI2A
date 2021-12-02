-- D
CREATE OR ALTER PROCEDURE insertFuncionario ( 
									@cc VARCHAR(13),
                                    @nif VARCHAR(12), 
                                    @nome VARCHAR(256), 
                                    @dtNascimento DATE, 
                                    @morada VARCHAR(256), 
                                    @codigoPostal VARCHAR(8), 
                                    @localidade VARCHAR(256), 
                                    @profissao VARCHAR(256), 
                                    @telefone VARCHAR(9), 
                                    @telemovel VARCHAR(9) ) AS
	BEGIN
        INSERT INTO Funcionarios(cc, nif, nome, dtNascimento, morada, codigoPostal, localidade, profissao, telefone, telemovel) VALUES 
        (@cc, @nif, @nome, @dtNascimento, @morada, @codigoPostal, @localidade, @profissao, @telefone, @telemovel)
    END
GO

CREATE OR ALTER PROCEDURE updateFuncionario (
									@id INT,
                                    @cc VARCHAR(13) = NULL,
                                    @nif VARCHAR(12) = NULL,
                                    @nome VARCHAR(256) = NULL,
                                    @dtNascimento DATE = NULL,
                                    @morada VARCHAR(256) = NULL,
                                    @codigoPostal VARCHAR(8) = NULL,
                                    @localidade VARCHAR(256) = NULL,
                                    @profissao VARCHAR(256) = NULL,
                                    @telefone VARCHAR(9) = NULL,
                                    @telemovel VARCHAR(9) = NULL ) AS
	BEGIN
	    IF (NULLIF(@id, '') IS NULL)
	        RAISERROR ('Funcionario ID can''t be null', 10, 0)
	    SET @cc = NULLIF(@cc, '')
	    SET @nif = NULLIF(@nif, '')
	    SET @nome = NULLIF(@nome, '') 
	    SET @dtNascimento = NULLIF(@dtNascimento, '') 
	    SET @morada = NULLIF(@morada, '')
	    SET @codigoPostal = NULLIF(@codigoPostal, '')
	    SET @localidade = NULLIF(@localidade, '')
	    SET @profissao = NULLIF(@profissao, '') 
	    SET @telefone = NULLIF(@telefone, '')
	    SET @telemovel = NULLIF(@telemovel, '') 
	
	    UPDATE Funcionarios 
		SET cc = ISNULL(@cc, cc), 
			nif = ISNULL(@nif, nif),
			nome = ISNULL(@nome, nome),
			dtNascimento = ISNULL(@dtNascimento, dtNascimento),
			morada = ISNULL(@morada, morada),
			codigoPostal = ISNULL(@codigoPostal, codigoPostal),
			localidade = ISNULL(@localidade, localidade),
			profissao = ISNULL(@profissao, profissao), 
			telefone = ISNULL(@telefone, telefone),
			telemovel = ISNULL(@telemovel, telemovel) 
	    WHERE id = @id;
	END;
GO

CREATE OR ALTER PROCEDURE deleteFuncionario ( @id INT ) AS
	BEGIN
	    if @id IS NOT NULL
	    BEGIN
	        DELETE FROM Funcionarios where id = @id
	    END
	END;
GO

-- E
CREATE OR ALTER FUNCTION obtainCodigoDeEquipaLivre ( @descricao INT ) RETURNS INT AS
	BEGIN
		RETURN (SELECT TOP 1 equipas.id FROM equipas 
		        LEFT JOIN IntervencoesEquipas AS IE ON equipas.id = IE.equipa
		        WHERE EXISTS (
		        	SELECT equipa FROM FuncionariosEquipas AS FE
		            INNER JOIN Funcionarios AS F ON F.id = FE.funcionario 
		            INNER JOIN FuncionariosCompetencias AS FC ON FE.funcionario = FC.funcionario
		            WHERE FE.equipa = equipas.id 
		            AND FC.competencia = @descricao 
		            AND FE.dtSaida IS NULL
		        ) 
		        AND IE.dtDispensa IS NULL 
		        GROUP BY equipas.id 
		        HAVING COUNT(*) < 3
		        ORDER BY IE.dtAtribuicao )
	END
GO

-- F
CREATE OR ALTER PROCEDURE p_CriaInter (
								@competencias INT,
                                @estado INT,
                                @activo INT,
                                @vlMonetario DECIMAL(9,2),
                                @dtInicio DATE,
                                @perMeses INT ) AS
	BEGIN
        DECLARE @dtAaquisicao DATE
        SELECT @dtAaquisicao = dtAaquisicao FROM Activos where @activo = id
        
        IF @dtInicio > @dtAaquisicao
            BEGIN
            	INSERT INTO Intervencoes(competencias, estado, activo, vlMonetario , dtInicio, dtFim, perMeses) VALUES
            	(@competencias, @estado, @activo, @vlMonetario, @dtInicio, NULL, @perMeses)
            END
        ELSE
            BEGIN
            	RAISERROR('Data de inicio da intervenção é inferior á data de acquisição do Activo', 10, 0)
            END
	END
GO 

-- G
CREATE OR ALTER PROCEDURE insertEquipa (
							@localizacao VARCHAR(256),
							@numElementos INT ) AS
    BEGIN
        IF (NULLIF(@localizacao, '') IS NULL)
            RAISERROR ('Localização can''t be null', 10, 0)
        IF (NULLIF(@numElementos, 0) < 2)
            RAISERROR ('numElementos must be at least 2', 10, 0)
        INSERT INTO Equipas(localizacao, numElementos) VALUES
        (@localizacao, @numElementos)
    END
GO