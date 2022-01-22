-- D
CREATE OR ALTER PROCEDURE insertFuncionario
							@cc VARCHAR(13),
                            @nif VARCHAR(12), 
                            @nome VARCHAR(256), 
                            @dtNascimento DATE, 
                            @morada VARCHAR(256), 
                            @codigoPostal VARCHAR(8), 
                            @localidade VARCHAR(256), 
                            @profissao INT, 
                            @telefone VARCHAR(9), 
                            @telemovel VARCHAR(9) AS
	BEGIN
        INSERT INTO Funcionarios(cc, nif, nome, dtNascimento, morada, codigoPostal, localidade, profissao, telefone, telemovel) VALUES 
        (@cc, @nif, @nome, @dtNascimento, @morada, @codigoPostal, @localidade, @profissao, @telefone, @telemovel)
    END
GO

CREATE OR ALTER PROCEDURE updateFuncionario
							@id INT,
                            @cc VARCHAR(13) = NULL,
                            @nif VARCHAR(12) = NULL,
                            @nome VARCHAR(256) = NULL,
                            @dtNascimento DATE = NULL,
                            @morada VARCHAR(256) = NULL,
                            @codigoPostal VARCHAR(8) = NULL,
                            @localidade VARCHAR(256) = NULL,
                            @profissao INT = NULL,
                            @telefone VARCHAR(9) = NULL,
                            @telemovel VARCHAR(9) = NULL AS
	BEGIN
		BEGIN TRY
			IF (NULLIF(@id, '') IS NULL)
				RAISERROR ('ID do Funcionario não pode ser nulo', 16, 0)
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
		END TRY
		BEGIN CATCH
			THROW
		END CATCH
	END
GO

CREATE OR ALTER PROCEDURE deleteFuncionario @id INT AS
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
		RETURN (SELECT TOP 1 E.id FROM equipas AS E
		        LEFT JOIN IntervencoesEquipas AS IE ON IE.equipa = E.id
		        WHERE EXISTS (
		        	SELECT equipa FROM FuncionariosEquipas AS FE
		            INNER JOIN Funcionarios AS F ON F.id = FE.funcionario 
		            INNER JOIN FuncionariosCompetencias AS FC ON FE.funcionario = FC.funcionario
		            WHERE FE.equipa = E.id 
		            AND FC.competencia = @descricao
		            AND FE.dtSaida IS NULL
		        ) 
		        AND IE.dtDispensa IS NULL 
		        GROUP BY E.id 
		        HAVING COUNT(*) < 3
		        ORDER BY MIN(IE.dtAtribuicao) )
	END
GO

-- F
CREATE OR ALTER PROCEDURE p_CriaInter
							@competencias INT,
                            @activo INT,
                            @vlMonetario DECIMAL(9,2),
                            @dtInicio DATE,
                            @perMeses INT,
							@id INT OUTPUT AS
	BEGIN
		BEGIN TRY
			DECLARE @dtAaquisicao DATE
			SELECT @dtAaquisicao = dtAaquisicao FROM Activos where @activo = id
			
			IF @dtInicio > @dtAaquisicao
				BEGIN
					INSERT INTO Intervencoes(competencias, estado, activo, vlMonetario , dtInicio, dtFim, perMeses) VALUES
					(@competencias, 'Por Atribuir', @activo, @vlMonetario, @dtInicio, NULL, @perMeses)
					SELECT @id = SCOPE_IDENTITY();
				END
			ELSE
				BEGIN
					RAISERROR('Data de inicio da intervenção é inferior à data de acquisição do Activo', 16, 0)
				END
		END TRY
		BEGIN CATCH
			THROW
		END CATCH
	END
GO 

-- G
CREATE OR ALTER PROCEDURE insertEquipa
							@localizacao VARCHAR(256),
							@numElementos INT,
							@id INT OUTPUT AS
    BEGIN
		BEGIN TRY
        IF (NULLIF(@localizacao, '') IS NULL)
            RAISERROR ('Localização não pode ser nulo', 16, 0)
        IF (NULLIF(@numElementos, 0) < 2)
            RAISERROR ('numElementos tem que ser pelo menos 2', 16, 0)
        INSERT INTO Equipas(localizacao, numElementos) VALUES
        (@localizacao, @numElementos)
		SELECT @id = SCOPE_IDENTITY();
		END TRY
		BEGIN CATCH
			THROW
		END CATCH
    END
GO

-- H
CREATE OR ALTER PROCEDURE insertFuncionariosEquipa
							@funcionario INT,
							@equipa INT,
							@dtEntrada DATE AS
	BEGIN
		SET @dtEntrada = NULLIF(@dtEntrada, '')
		
		INSERT INTO FuncionariosEquipas(funcionario, equipa, dtEntrada, dtSaida) VALUES
        (@funcionario, @equipa, ISNULL(@dtEntrada, GETDATE()), null)
	END
GO 

CREATE OR ALTER PROCEDURE deleteFuncionariosEquipa
							@funcionario INT,
							@equipa INT,
							@dtSaida DATE AS
	BEGIN
		SET @dtSaida = NULLIF(@dtSaida, '')
		
		UPDATE FuncionariosEquipas 
		SET dtSaida = ISNULL(@dtSaida, GETDATE()) 
	    WHERE funcionario = @funcionario
	    AND equipa = @equipa;
	END
GO 

-- H(2)
CREATE OR ALTER PROCEDURE insertFuncionariosCompetencias
							@funcionario INT,
							@competencia INT AS
	BEGIN
		INSERT INTO FuncionariosCompetencias(funcionario, competencia) VALUES
        (@funcionario, @competencia)
	END
GO 

CREATE OR ALTER PROCEDURE deleteFuncionariosCompetencias
							@funcionario INT,
							@competencia INT AS
	BEGIN
		DECLARE @equipa INT
		DECLARE @cnt INT
		
		SELECT @equipa = equipa FROM FuncionariosEquipas
		WHERE funcionario = @funcionario
	    AND dtSaida IS NULL;
		
		SELECT @cnt = COUNT(*) FROM FuncionariosCompetencias AS FC
		WHERE FC.competencia = @competencia
		AND FC.funcionario IN (SELECT FE.funcionario FROM FuncionariosEquipas FE
                               WHERE FE.funcionario != @funcionario
                               AND FE.equipa = @equipa
                               AND FE.dtSaida IS NULL);
		
		IF @cnt > 0
            BEGIN
            	DELETE FROM FuncionariosCompetencias 
	            WHERE funcionario = @funcionario
	            AND competencia = @competencia;
            END
        ELSE
            BEGIN
            	RAISERROR('Competência do funcionário em uso numa intervenção', 16, 0)
            END
		
	END
GO 

-- I
CREATE OR ALTER FUNCTION listAllIntervencoesFromDate (@data VARCHAR(4))
	RETURNS TABLE 
		AS
		RETURN (
			SELECT I.id, C.descricao FROM  Intervencoes AS I
			INNER JOIN Competencias AS C
			ON C.id = I.competencias
			WHERE YEAR(I.dtInicio) = @data
			)
GO

-- J
CREATE OR ALTER PROCEDURE updateIntervencaoState
							@id INT,
							@estado VARCHAR (12)
	AS
	BEGIN
		BEGIN TRY
			DECLARE @estadoActual VARCHAR(12)
			SET  @estadoActual = (SELECT estado FROM Intervencoes WHERE id = @id)
		
			IF(NULLIF(@estado, '') IS NULL OR @estado = @estadoActual)
				BEGIN
					RAISERROR ('Estado igual ao existente ou nulo', 16, 1)
				END
			
			UPDATE Intervencoes 
			SET estado = @estado
			WHERE id = @id
		END TRY
		BEGIN CATCH
			THROW
		END CATCH
	END
GO

-- K
CREATE OR ALTER VIEW ResumoIntervencoes 
	AS
		SELECT ROW_NUMBER() OVER( ORDER BY I.id ) AS id, I.estado AS estadoIntervencoes, I.vlMonetario AS vlMonetarioIntervencoes, I.dtInicio AS dtInicioIntervencoes, I.dtFim AS dtFimIntervencoes, I.perMeses AS perMesesIntervencoes, 
				A.nome AS nomeActivos, A.dtAaquisicao AS dtAquisicaoActivos, A.estado AS estadoActivos , ISNULL(A.marca, 'Sem Marca') AS marcaActivos, ISNULL(A.modelo, 'Sem modelo') AS modeloActivos, A.localizacao AS localizacaoActivos, A.funcionario AS funcionarioActivos, A.tipo AS tipoActivos
			FROM Intervencoes AS I
			INNER JOIN Activos AS A 
			ON I.id = A.id
GO