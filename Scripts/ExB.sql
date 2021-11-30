ALTER TABLE Gestores DROP CONSTRAINT fk_Gestores_funcionario
ALTER TABLE MembrosEquipas DROP CONSTRAINT fk_MembrosEquipas_equipas,fk_MembrosEquipas_funcionario, fk_MembrosEquipas_competencias
ALTER TABLE Activos DROP CONSTRAINT fk_Activos_gestores, fk_PrecosActivos_activo
ALTER TABLE Intervencoes DROP CONSTRAINT fk_Intervencoes_activo, fk_Intervencoes_descricao, fk_Intervencoes_estado, fk_Intervencoes_data
ALTER TABLE IntervencoesEquipas DROP CONSTRAINT fk_IntervencoesEquipas_equipas, fk_IntervencoesEquipas_intervencoes

DROP TABLE IntervencoesEquipas
DROP TABLE Intervencoes 
DROP TABLE DescricoesIntervencoes
DROP TABLE EstadosIntervencoes
DROP TABLE PrecosActivos
DROP TABLE Activos 
DROP TABLE Membros
DROP TABLE Equipas 
DROP TABLE Competencias
DROP TABLE Gestores
DROP TABLE Equipas 
DROP TABLE Funcionarios
DROP TABLE MembrosEquipas

