ALTER TABLE FuncionariosCompetencias DROP CONSTRAINT fk_FuncionariosCompetencias_funcionario, fk_FuncionariosCompetencias_comptencia
ALTER TABLE MembrosEquipas DROP CONSTRAINT fk_MembrosEquipas_equipas,fk_MembrosEquipas_funcionario, fk_MembrosEquipas_competencias
ALTER TABLE Activos DROP CONSTRAINT fk_Activos_gestores, fk_PrecosActivos_activo, fk_Activos_tipoactivo
ALTER TABLE Intervencoes DROP CONSTRAINT fk_Intervencoes_activo, fk_Intervencoes_descricao, fk_Intervencoes_estado, fk_Intervencoes_data
ALTER TABLE IntervencoesEquipas DROP CONSTRAINT fk_IntervencoesEquipas_equipas, fk_IntervencoesEquipas_intervencoes
ALTER TABLE ActivosCompostos DROP CONSTRAINT fk_MembrosEquipas_activoPai, fk_MembrosEquipas_activoFilho


DROP TABLE IF EXISTS Funcionarios
DROP TABLE IF EXISTS  FuncionariosCompetencias 
DROP TABLE IF EXISTS  Equipas
DROP TABLE IF EXISTS  TipoActivo
DROP TABLE IF EXISTS  Competencias
DROP TABLE IF EXISTS  MembrosEquipas 
DROP TABLE IF EXISTS  Activos
DROP TABLE IF EXISTS  PrecosActivos 
DROP TABLE IF EXISTS  EstadosIntervencoes
DROP TABLE IF EXISTS  Intervencoes
DROP TABLE IF EXISTS  IntervencoesEquipas 
