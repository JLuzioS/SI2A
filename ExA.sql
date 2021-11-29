CREATE TABLE Funcionarios (
    cc VARCHAR(12) NOT NULL,
    nif VARCHAR(12),
    nome_completo VARCHAR(256) NOT NULL,
    data_de_nascimento DATE NOT NULL,
    morada VARCHAR(256) NOT NULL,
    codigo_postal VARCHAR(8) NOT NULL,
    localidade VARCHAR(256) NOT NULL,
    profissao VARCHAR(256) NOT NULL,
    telefone INT NOT NULL,
    telemovel INT,

    PRIMARY KEY (cc),
    CONSTRAINT valid_cc CHECK (cc LIKE NULL OR cc LIKE '%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]% %_%%_%%_%'),
    CONSTRAINT valid_codigo_postal CHECK (codigo_postal LIKE '%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%-%%[^0-9]%%[^0-9]%%[^0-9]%'),
    CONSTRAINT valid_telefone CHECK (telefone LIKE '%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%'),
    CONSTRAINT valid_telemovel CHECK (telemovel LIKE NULL OR telemovel LIKE '%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%'),
    CONSTRAINT valid_nif CHECK (codigo_postal LIKE NULL OR codigo_postal LIKE '%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%%[^0-9]%')
)

CREATE TABLE Gestores (
    cc VARCHAR(12) NOT NULL,

    PRIMARY KEY (cc),
    CONSTRAINT fk_funcionario FOREIGN KEY (cc) REFERENCES Gestores(cc)
)

CREATE TABLE MembrosEquipas (
    cc VARCHAR(12) NOT NULL,

    PRIMARY KEY (cc),
    CONSTRAINT fk_funcionario FOREIGN KEY (cc) REFERENCES Gestores(cc)
)

CREATE TABLE Elementos (
    cc VARCHAR(12) NOT NULL,

    PRIMARY KEY (cc),
    CONSTRAINT fk_funcionarios FOREIGN KEY (cc) REFERENCES Funcionarios(cc)
)

CREATE TABLE Activos (
    id INT,
    nome VARCHAR(256) NOT NULL,
    data_aquisicao DATE NOT NULL,
    estado INT NOT NULL , -- 0 desactivado | 1 desactivado
    marca VARCHAR(256) NOT NULL,
    modelo VARCHAR(256) NOT NULL,
    localizacao VARCHAR(256) NOT NULL,
    gestor VARCHAR(12) NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT estado CHECK (estado = 0 or estado = 1),
    CONSTRAINT fk_gestores FOREIGN KEY (gestor) REFERENCES Gestores(cc)
)

CREATE TABLE PrecosActivos (
    id INT NOT NULL,
    [data] INT NOT NULL,
    preco FLOAT NOT NULL,

    PRIMARY KEY ([data], id),
    CONSTRAINT fk_activo FOREIGN KEY (id) REFERENCES Activos(id)
)

CREATE TABLE TiposDeActivos (
    id INT NOT NULL,
    descricao VARCHAR(256) NOT NULL,
    id_activos INT NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT fk_activo FOREIGN KEY (id_activos) REFERENCES Activos(id)
)

CREATE TABLE RegistosHistoricos (
    valor_comercial_do_Activo FLOAT,
    [data] DATE NOT NULL,
    idActivo INT NOT NULL,

    CONSTRAINT fk_activo  FOREIGN KEY (idActivo) REFERENCES Activos(id)
)

CREATE TABLE EstadosIntervencoes (
    id INT NOT NULL,
    estado VARCHAR(30) NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT valid_estado CHECK (estado LIKE 'por atribuir' OR estado LIKE 'em analise' OR estado LIKE'em execucao' OR estado LIKE 'concluido')
)

CREATE TABLE DescricoesIntervencoes (
    id INT NOT NULL,
    descricao VARCHAR(256) NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT valid_descricao CHECK (descricao LIKE 'avaria' OR descricao LIKE 'rutura' OR descricao LIKE 'inspeccao')
)

CREATE TABLE Intervencoes (
    id INT NOT NULL,
    id_descricao INT NOT NULL,
    id_estado INT NOT NULL,
    id_activos INT NOT NULL,
    valor_monetario FLOAT NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT fk_activo FOREIGN KEY (id_activos) REFERENCES Activos(id),
    CONSTRAINT fk_descricao FOREIGN KEY (id_estado) REFERENCES DescricoesIntervencoes(id),
    CONSTRAINT fk_estado FOREIGN KEY (id_descricao) REFERENCES EstadosIntervencoes(id),
)

CREATE TABLE Equipas (
    id INT NOT NULL,
    id_descricao INT NOT NULL,
    id_estado INT NOT NULL,
    id_activos INT NOT NULL,
    valor_monetario FLOAT NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT fk_activo FOREIGN KEY (id_activos) REFERENCES Activos(id),
    CONSTRAINT fk_descricao FOREIGN KEY (id_estado) REFERENCES DescricoesIntervencoes(id),
    CONSTRAINT fk_estado FOREIGN KEY (id_descricao) REFERENCES EstadosIntervencoes(id),
)
