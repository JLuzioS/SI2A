CREATE TABLE Funcionarios (
    id INT IDENTITY NOT NULL,
    cc VARCHAR(13) UNIQUE  NOT NULL,
    nif VARCHAR(12) UNIQUE,
    nome_completo VARCHAR(256) NOT NULL,
    data_de_nascimento DATE NOT NULL,
    morada VARCHAR(256) NOT NULL,
    codigo_postal VARCHAR(8) NOT NULL,
    localidade VARCHAR(256) NOT NULL,
    profissao VARCHAR(256) NOT NULL,
    telefone INT NOT NULL,
    telemovel INT,

    PRIMARY KEY (id),
    CONSTRAINT valid_cc CHECK (cc LIKE NULL OR cc LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[A-Z0-9a-z][A-Z0-9a-z][A-Z0-9a-z]%'),
    CONSTRAINT valid_codigo_postal CHECK (codigo_postal LIKE '%[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]%'),
    CONSTRAINT valid_telefone CHECK (telefone LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%'),
    CONSTRAINT valid_telemovel CHECK (telemovel LIKE NULL OR telemovel LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%'),
    CONSTRAINT valid_nif CHECK (nif LIKE NULL OR nif LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%')
)

CREATE TABLE Equipas (
    id INT IDENTITY NOT NULL,
    localizacao VARCHAR(256) NOT NULL,
    numElementos INT NOT NULL,

    PRIMARY KEY (id)
)

CREATE TABLE Gestores (
    funcionario INT NOT NULL,

    PRIMARY KEY (funcionario),
    CONSTRAINT fk_Gestores_funcionario FOREIGN KEY (funcionario) REFERENCES Funcionarios(id)
)

CREATE TABLE Competencias (
    id INT IDENTITY NOT NULL,
    descricao VARCHAR(256) NOT NULL,

    PRIMARY KEY (id)
)

CREATE TABLE MembrosEquipas (
    membro INT NOT NULL,
    equipa INT NOT NULL,
    competencias INT NOT NULL,

    PRIMARY KEY (membro, equipa),
    CONSTRAINT fk_MembrosEquipas_funcionario FOREIGN KEY (membro) REFERENCES Funcionarios(id),
    CONSTRAINT fk_MembrosEquipas_equipas FOREIGN KEY (equipa) REFERENCES Equipas(id),
    CONSTRAINT fk_MembrosEquipas_competencias FOREIGN KEY (competencias) REFERENCES Competencias(id)
)

CREATE TABLE Activos (
    id INT IDENTITY NOT NULL,
    nome VARCHAR(256) NOT NULL,
    data_aquisicao DATE NOT NULL,
    estado INT NOT NULL , -- 0 desactivado | 1 activado
    marca VARCHAR(256) NOT NULL,
    modelo VARCHAR(256) NOT NULL,
    localizacao VARCHAR(256) NOT NULL,
    gestor INT NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT estado CHECK (estado = 0 or estado = 1),
    CONSTRAINT fk_Activos_gestores FOREIGN KEY (gestor) REFERENCES Gestores(funcionario)
)

CREATE TABLE PrecosActivos (
    activo INT NOT NULL,
    [data] INT NOT NULL,
    preco FLOAT NOT NULL,

    PRIMARY KEY ([data], activo),
    CONSTRAINT fk_PrecosActivos_activo FOREIGN KEY (activo) REFERENCES Activos(id)
)

CREATE TABLE EstadosIntervencoes (
    id INT IDENTITY NOT NULL,
    estado VARCHAR(30) NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT valid_estado CHECK (estado LIKE 'Por Atribuir' OR estado LIKE 'Em Análise' OR estado LIKE 'Em Execução' OR estado LIKE 'Concluido')
)

CREATE TABLE Intervencoes (
    id INT IDENTITY NOT NULL,
    competencias INT NOT NULL,
    estado INT NOT NULL,
    activo INT NOT NULL,
    valor_monetario FLOAT NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim DATE,
    periodicidade_meses INT NOT NULL

    PRIMARY KEY (id),
    CONSTRAINT fk_Intervencoes_activo FOREIGN KEY (activo) REFERENCES Activos(id),
    CONSTRAINT fk_Intervencoes_competencias FOREIGN KEY (competencias) REFERENCES Competencias(id),
    CONSTRAINT fk_Intervencoes_estado FOREIGN KEY (estado) REFERENCES EstadosIntervencoes(id)
)

CREATE TABLE IntervencoesEquipas (
    equipa INT NOT NULL,
    intervencao INT NOT NULL,
    
    PRIMARY KEY (equipa, intervencao),
    CONSTRAINT fk_IntervencoesEquipas_equipas FOREIGN KEY (equipa) REFERENCES Equipas(id),
    CONSTRAINT fk_IntervencoesEquipas_intervencoes FOREIGN KEY (intervencao) REFERENCES Intervencoes(id)
)

