CREATE TABLE Profissoes (
    id INT IDENTITY NOT NULL,
    descricao VARCHAR(256) NOT NULL,

    PRIMARY KEY (id)
)

CREATE TABLE Funcionarios (
    id INT IDENTITY NOT NULL,
    cc VARCHAR(13),
    nif VARCHAR(12),
    nome VARCHAR(256) NOT NULL,
    dtNascimento DATE NOT NULL,
    morada VARCHAR(256) NOT NULL,
    codigoPostal CHAR(8) NOT NULL,
    localidade VARCHAR(256) NOT NULL,
    profissao INT NOT NULL,
    telefone VARCHAR(9),
    telemovel VARCHAR(9),

    PRIMARY KEY (id),
    CONSTRAINT valid_id CHECK (cc IS NOT NULL OR nif IS NOT NULL),
    CONSTRAINT valid_cc CHECK (cc LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[A-Z0-9a-z][A-Z0-9a-z][A-Z0-9a-z]%'),
    CONSTRAINT valid_nif CHECK (nif LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%'),
    CONSTRAINT valid_dtNascimento CHECK (dtNascimento < GETDATE()),
    CONSTRAINT valid_codigoPostal CHECK (codigoPostal LIKE '%[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]%'),
    CONSTRAINT valid_tel CHECK (telefone IS NOT NULL OR telemovel IS NOT NULL),
    CONSTRAINT valid_telefone CHECK (telefone LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%'),
    CONSTRAINT valid_telemovel CHECK (telemovel LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%'),
    CONSTRAINT fk_Funcionarios_Profissoes FOREIGN KEY (profissao) REFERENCES Profissoes(id)
)
CREATE UNIQUE INDEX Funcionarios_unique_cc ON Funcionarios(cc) WHERE cc IS NOT NULL;
CREATE UNIQUE INDEX Funcionarios_unique_nif ON Funcionarios(nif) WHERE nif IS NOT NULL;

CREATE TABLE Competencias (
    id INT IDENTITY NOT NULL,
    descricao VARCHAR(256) NOT NULL,

    PRIMARY KEY (id)
)

CREATE TABLE FuncionariosCompetencias (
    funcionario INT,
    competencia INT,

    PRIMARY KEY (funcionario, competencia),
    CONSTRAINT fk_FuncionariosCompetencias_Funcionarios FOREIGN KEY (funcionario) REFERENCES Funcionarios(id),
    CONSTRAINT fk_FuncionariosCompetencias_Competencias FOREIGN KEY (competencia) REFERENCES Competencias(id)
)

CREATE TABLE Equipas (
    id INT IDENTITY NOT NULL,
    localizacao VARCHAR(256) NOT NULL,
    numElementos INT NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT valid_numElementos CHECK (numElementos >= 2)
)

CREATE TABLE FuncionariosEquipas (
    funcionario INT NOT NULL,
    equipa INT NOT NULL,
    dtEntrada DATE NOT NULL,
    dtSaida DATE,

    PRIMARY KEY (funcionario, equipa),
    CONSTRAINT valid_dtSaida CHECK (dtSaida IS NULL OR dtEntrada < dtSaida),
    CONSTRAINT fk_FuncionariosEquipas_Funcionarios FOREIGN KEY (funcionario) REFERENCES Funcionarios(id),
    CONSTRAINT fk_FuncionariosEquipas_Equipas FOREIGN KEY (equipa) REFERENCES Equipas(id)
)

CREATE TABLE TiposActivos (
    id INT IDENTITY NOT NULL,
    descricao VARCHAR (256),

    PRIMARY KEY (id)
)

CREATE TABLE Activos (
    id INT IDENTITY NOT NULL,
    nome VARCHAR(256) NOT NULL,
    dtAaquisicao DATE NOT NULL,
    estado TINYINT NOT NULL , -- 0 desactivado | 1 operacional
    marca VARCHAR(256),
    modelo VARCHAR(256),
    localizacao VARCHAR(256) NOT NULL,
    funcionario INT NOT NULL,
    tipo INT NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT estado CHECK (estado = 0 or estado = 1),
    CONSTRAINT fk_Activos_Funcionarios FOREIGN KEY (funcionario) REFERENCES Funcionarios(id),
    CONSTRAINT fk_Activos_TiposActivos FOREIGN KEY (tipo) REFERENCES TiposActivos(id)
)

CREATE TABLE ActivosCompostos (
    activo_pai INT NOT NULL,
    activo_filho INT NOT NULL,

    PRIMARY KEY (activo_pai, activo_filho),
    CONSTRAINT fk_ActivosCompostos_ActivosPai FOREIGN KEY (activo_pai) REFERENCES Activos(id),
    CONSTRAINT fk_ActivosCompostos_ActivosFilho FOREIGN KEY (activo_filho) REFERENCES Activos(id)
)

CREATE TABLE PrecosActivos (
    activo INT NOT NULL,
    dtAtualizacao DATE NOT NULL,
    preco DECIMAL(9,2) NOT NULL,

    PRIMARY KEY (activo, dtAtualizacao),
    CONSTRAINT valid_preco CHECK (preco > 0),
    CONSTRAINT fk_PrecosActivos_Activos FOREIGN KEY (activo) REFERENCES Activos(id)
)

CREATE TABLE Intervencoes (
    id INT IDENTITY NOT NULL,
    competencias INT NOT NULL,
    estado VARCHAR(12) NOT NULL,
    activo INT NOT NULL,
    vlMonetario DECIMAL(9,2) NOT NULL,
    dtInicio DATE NOT NULL,
    dtFim DATE,
    perMeses INT NOT NULL

    PRIMARY KEY (id),
    CONSTRAINT valid_estado CHECK (estado IN ('Por Atribuir', 'Em Análise', 'Em Execução', 'Concluído')),
    CONSTRAINT valid_vlMonetario CHECK (vlMonetario > 0),
    CONSTRAINT valid_dtFim CHECK (dtFim IS NULL OR dtInicio < dtFim),
    CONSTRAINT valid_perMeses CHECK (perMeses >= 0),
    CONSTRAINT fk_Intervencoes_Activos FOREIGN KEY (activo) REFERENCES Activos(id),
    CONSTRAINT fk_Intervencoes_Competencias FOREIGN KEY (competencias) REFERENCES Competencias(id)
)

CREATE TABLE IntervencoesEquipas (
    equipa INT NOT NULL,
    intervencao INT NOT NULL,
    dtAtribuicao DATE NOT NULL,
    dtDispensa DATE,
    
    PRIMARY KEY (equipa, intervencao),
    CONSTRAINT valid_dtDispensa CHECK (dtDispensa IS NULL OR dtAtribuicao < dtDispensa),
    CONSTRAINT fk_IntervencoesEquipas_Equipas FOREIGN KEY (equipa) REFERENCES Equipas(id),
    CONSTRAINT fk_IntervencoesEquipas_Intervencoes FOREIGN KEY (intervencao) REFERENCES Intervencoes(id)
)
