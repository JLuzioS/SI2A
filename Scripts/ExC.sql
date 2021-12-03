insert into Profissoes (descricao) values
('Profissão 1'),
('Profissão 2'),
('Profissão 3'),
('Gerente');

insert into Funcionarios (cc, nif, nome, dtNascimento, morada, codigoPostal, localidade, profissao, telefone, telemovel) values
('123456789-ABC', null, 'Funcionário 1', '1973-01-01', 'Morada 1', '1234-567', 'Localidade 1', 1, '212345678', null),
('234567891-ABC', null, 'Funcionário 2', '1973-02-02', 'Morada 2', '2345-671', 'Localidade 2', 2, '223456781', null),
('345678912-ABC', null, 'Funcionário 3', '1973-03-03', 'Morada 3', '3456-712', 'Localidade 3', 3, '234567812', null),
('456789123-ABC', null, 'Funcionário 4', '1973-04-04', 'Morada 4', '4567-123', 'Localidade 4', 1, '245678123', null),
('567891234-ABC', null, 'Funcionário 5', '1973-05-05', 'Morada 5', '5671-234', 'Localidade 5', 2, '256781234', null),
(null, '123456789', 'Funcionário 6', '1973-06-06', 'Morada 6', '6712-345', 'Localidade 6', 3, null, '912345678'),
(null, '234567891', 'Funcionário 7', '1973-07-07', 'Morada 7', '7123-456', 'Localidade 7', 1, null, '923456781'),
(null, '345678912', 'Funcionário 8', '1973-08-08', 'Morada 8', '1234-567', 'Localidade 8', 1, null, '934567812'),
('111111111-ABC', null, 'Funcionário A', '1973-08-08', 'Morada A', '1234-567', 'Localidade A', 4, '211111111', null),
('222222222-ABC', null, 'Funcionário B', '1973-09-09', 'Morada B', '2345-671', 'Localidade B', 4, '222222222', null),
('333333333-ABC', null, 'Funcionário C', '1973-10-10', 'Morada C', '3456-712', 'Localidade C', 4, '233333333', null),
('444444444-ABC', null, 'Funcionário D', '1973-11-11', 'Morada D', '4567-123', 'Localidade D', 4, '244444444', null),
('555555555-ABC', null, 'Funcionário E', '1973-12-12', 'Morada E', '5671-234', 'Localidade E', 4, '255555555', null),
('666666666-ABC', null, 'Funcionário F', '1973-12-31', 'Morada F', '6712-345', 'Localidade F', 4, '266666666', null);

insert into Competencias (descricao) values
('Competencia 1'),
('Competencia 2'),
('Competencia 3'),
('Competencia 4');

insert into FuncionariosCompetencias (funcionario, competencia) values
(1, 1),
(1, 2),
(2, 3),
(3, 1),
(4, 2),
(5, 3),
(6, 1),
(7, 2),
(8, 4);

insert into Equipas (localizacao, numElementos) values
('Localização Equipa 1', 2),
('Localização Equipa 2', 3),
('Localização Equipa 3', 2),
('Localização Equipa 4', 2);

insert into FuncionariosEquipas (funcionario, equipa, dtEntrada, dtSaida) values
(1, 1, '2021-01-01', null),
(2, 1, '2021-01-01', null),
(3, 2, '2021-01-01', null),
(4, 2, '2021-01-01', null),
(5, 2, '2021-01-01', null),
(6, 3, '2021-01-01', null),
(7, 3, '2021-01-01', null);

insert into TiposActivos (descricao) values
('Tipo Activo 1'),
('Tipo Activo 2'),
('Tipo Activo 3');

insert into Activos (nome, dtAaquisicao, estado, marca, modelo, localizacao, funcionario, tipo) values
('Activo 1 Composto', '2021-01-01', 1, null, null, 'Localização Activo 1', 9, 1),
('Activo 1 A', '2021-01-01', 1, 'Marca A', 'Modelo A', 'Localização Activo 1', 10, 1),
('Activo 1 B', '2021-01-01', 1, 'Marca B', 'Modelo B', 'Localização Activo 1', 11, 1),
('Activo 1 C', '2021-01-01', 1, 'Marca C', 'Modelo C', 'Localização Activo 1', 12, 1),
('Activo 5', '2021-02-02', 1, 'Marca 5', 'Modelo 5', 'Localização Activo 5', 9, 2),
('Activo 6', '2021-03-03', 1, 'Marca 6', 'Modelo 6', 'Localização Activo 6', 10, 3),
('Activo 7', '2021-04-04', 0, 'Marca 7', 'Modelo 7', 'Localização Activo 7', 11, 2),
('Activo 8', '2021-05-05', 1, 'Marca 8', 'Modelo 8', 'Localização Activo 8', 12, 3),
('Activo 9', '2021-02-02', 1, 'Marca 9', 'Modelo 9', 'Localização Activo 9', 9, 2),
('Activo 10', '2021-03-03', 1, 'Marca 10', 'Modelo 10', 'Localização Activo 10', 10, 3),
('Activo 11', '2021-04-04', 1, 'Marca 11', 'Modelo 11', 'Localização Activo 11', 11, 2),
('Activo 12', '2021-05-05', 1, 'Marca 12', 'Modelo 12', 'Localização Activo 12', 12, 3);

insert into ActivosCompostos (activo_pai, activo_filho) values
(1, 2),
(1, 3),
(1, 4);

insert into PrecosActivos (activo, dtAtualizacao, preco) values
(1, '2021-01-01', 1000.00),
(2, '2021-01-01', 500.00),
(3, '2021-01-01', 250.75),
(4, '2021-01-01', 249.25),
(5, '2021-02-02', 1750.00),
(6, '2021-03-03', 320.00),
(7, '2021-04-04', 1.50),
(8, '2021-05-05', 899.99),
(9, '2021-06-06', 1750.00),
(10, '2021-07-07', 1320.00),
(11, '2021-08-08', 890.50),
(12, '2021-09-09', 975.00);

insert into Intervencoes (competencias, estado, activo, vlMonetario, dtInicio, dtFim, perMeses) values
(1, 'Por Atribuir', 1, 550.00, '2022-01-01', null, 0),
(2, 'Em Execução', 5, 900.00, '2021-02-02', null, 6),
(3, 'Em Análise', 6, 250.00, '2021-03-03', null, 6),
(2, 'Concluído', 7, 5.00, '2021-04-04', '2021-04-25', 0),
(4, 'Por Atribuir', 7, 450.00, '2021-04-04', null, 6),
(2, 'Em Execução', 8, 900.00, '2021-05-05', null, 6),
(2, 'Em Execução', 9, 1000.00, '2021-02-02', null, 6),
(3, 'Em Execução', 10, 900.00, '2021-03-03', null, 6),
(1, 'Em Execução', 11, 300.00, '2021-04-04', null, 6),
(2, 'Em Execução', 12, 400.00, '2021-05-05', null, 6);

insert into IntervencoesEquipas (equipa, intervencao, dtAtribuicao, dtDispensa) values
(1, 2, '2021-02-15', null),
(2, 3, '2021-03-15', null),
(1, 4, '2021-04-15', '2021-04-25'),
(3, 4, '2021-04-15', null),
(1, 6, '2021-05-15', null),
(1, 7, '2021-02-15', null),
(3, 8, '2021-03-10', null),
(2, 9, '2021-04-15', null),
(2, 10, '2021-05-15', '2021-05-25');
