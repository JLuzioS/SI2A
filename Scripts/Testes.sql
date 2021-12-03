select * from Profissoes p;
select * from Funcionarios f;
select * from Competencias c;
select * from FuncionariosCompetencias fc;
select * from Equipas e;
select * from FuncionariosEquipas fe;
select * from TiposActivos ta;
select * from Activos a;
select * from ActivosCompostos ac;
select * from PrecosActivos pa;
select * from Intervencoes i;
select * from IntervencoesEquipas ie;

exec insertFuncionario
	@cc = '000000000-ZZZ',
	@nif = null,
	@nome = 'Funcion�rio Z',
	@dtNascimento = '1973-12-31',
	@morada = 'Morada Z',
	@codigoPostal = '6712-345',
	@localidade = 'Localidade Z',
	@profissao = 4,
	@telefone = '200000000',
	@telemovel = null;
select top 1 f.* from Funcionarios f order by f.id desc;

DECLARE @id_ INT
select top 1 @id_ = f.id from Funcionarios f order by f.id desc;
exec updateFuncionario
    @id = @id_,
	@cc = '999999999-ZZZ',
	@nif = '',
	@nome = '',
	@dtNascimento = '',
	@morada = '',
	@codigoPostal = '',
	@localidade = '',
	@profissao = '',
	@telefone = '299999999',
	@telemovel = '';
select top 1 f.* from Funcionarios f order by f.id desc;

DECLARE @id_ INT
select @id_ = f.id from Funcionarios f where f.cc = '999999999-ZZZ';
exec deleteFuncionario @id = @id_;
select top 1 f.* from Funcionarios f order by f.id desc;

select dbo.obtainCodigoDeEquipaLivre(2);

exec p_CriaInter
	@competencias = 2,
	@estado = 'Por Atribuir',
	@activo = 12,
	@vlMonetario = 475.00,
	@dtInicio = '2021-10-01',
	@perMeses = 0;
select top 1 i.* from Intervencoes i order by i.id desc;

exec insertEquipa
	@localizacao = 'Localiza��o Equipa XPTO',
	@numElementos = 3;
select top 1 e.* from Equipas e order by e.id desc;

exec insertFuncionariosEquipa
	@funcionario = 9,
	@equipa = 4,
	@dtEntrada = '2021-12-01';
select fe.* from FuncionariosEquipas fe where fe.funcionario = 9 and fe.equipa = 4;

exec deleteFuncionariosEquipa
	@funcionario = 9,
	@equipa = 4,
	@dtSaida = null;
select fe.* from FuncionariosEquipas fe where fe.funcionario = 9 and fe.equipa = 4;

SELECT * FROM dbo.listAllIntervencoesFromDate('2021')