begin
	
	print('Testes alinea d')
	begin tran
		exec insertFuncionario
			@cc = '000000000-ZZZ',
			@nif = null,
			@nome = 'Funcionário Z',
			@dtNascimento = '1973-12-31',
			@morada = 'Morada Z',
			@codigoPostal = '6712-345',
			@localidade = 'Localidade Z',
			@profissao = 4,
			@telefone = '200000000',
			@telemovel = null
		if exists (select * from Funcionarios where cc = '000000000-ZZZ')
			print('teste sobre insertFuncionario - OK')
		else
			print('teste sobre insertFuncionario - NOK')

		declare @id_ INT
		select @id_ = id from Funcionarios where cc = '000000000-ZZZ'
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
			@telemovel = ''
		if exists (select * from Funcionarios where id = @id_ and cc = '999999999-ZZZ')
			print('teste sobre updateFuncionario - OK')
		else
			print('teste sobre updateFuncionario - NOK')
				
		begin TRY
			begin tran
				exec updateFuncionario
				    @id = '',
					@cc = '999999999-ZZZ',
					@nif = '',
					@nome = '',
					@dtNascimento = '',
					@morada = '',
					@codigoPostal = '',
					@localidade = '',
					@profissao = '',
					@telefone = '299999999',
					@telemovel = ''
				print('teste sobre updateFuncionario - NOK')
			rollback;
		end TRY
		begin CATCH
			if (error_message() = 'ID do Funcionario não pode ser nulo')
				print('teste sobre updateFuncionario - OK')
			else
				print('teste sobre updateFuncionario - NOK')
		end CATCH

		exec deleteFuncionario @id = @id_
		if not exists (select * from Funcionarios where id = @id_)
			print('teste sobre deleteFuncionario - OK')
		else
			print('teste sobre deleteFuncionario - NOK')
	rollback;

	print('Testes alinea e')
	begin tran
		if exists (select dbo.obtainCodigoDeEquipaLivre(2))
			print('teste sobre obtainCodigoDeEquipaLivre - OK')
		else
			print('teste sobre obtainCodigoDeEquipaLivre - NOK')
	rollback
	
	print('Testes alinea f')
	begin tran
		exec p_CriaInter
			@competencias = 2,
			@activo = 12,
			@vlMonetario = 475.00,
			@dtInicio = '2021-10-01',
			@perMeses = 0
		if exists (select * from Intervencoes
				   where competencias = 2 and estado = 'Por Atribuir' and activo = 12 and vlMonetario = 475.00 and dtInicio = '2021-10-01' and perMeses = 0)
			print('teste sobre p_CriaInter - OK')
		else
			print('teste sobre p_CriaInter - NOK')
	rollback
	
	begin TRY
		begin tran
			exec p_CriaInter
				@competencias = 2,
				@activo = 12,
				@vlMonetario = 475.00,
				@dtInicio = '2019-10-01',
				@perMeses = 0
			print('teste sobre p_CriaInter - NOK.')
		rollback
	end TRY
	begin CATCH
		if (error_message() = 'Data de inicio da intervenção é inferior à data de acquisição do Activo')
			print('teste sobre p_CriaInter - OK')
		else
			print('teste sobre p_CriaInter - NOK')
	end CATCH
	
	print('Testes alinea g')
	begin tran
		exec insertEquipa
			@localizacao = 'Localização Equipa XPTO',
			@numElementos = 3
		if exists (select * from Equipas
				   where localizacao = 'Localização Equipa XPTO' and numElementos = 3)
			print('teste sobre insertEquipa - OK')
		else
			print('teste sobre insertEquipa - NOK')
	rollback
	
	begin TRY
		begin tran
			exec insertEquipa
				@localizacao = '',
				@numElementos = 3
			print('teste sobre insertEquipa - NOK')
		rollback
	end TRY
	begin CATCH
		if (error_message() = 'Localização não pode ser nulo')
			print('teste sobre insertEquipa - OK')
		else
			print('teste sobre insertEquipa - NOK')
	end CATCH
	
	begin TRY
		begin tran
			exec insertEquipa
				@localizacao = 'Localização Equipa XPTO',
				@numElementos = 1
			print('teste sobre insertEquipa - NOK')
		rollback
	end TRY
	begin CATCH
		if (error_message() = 'numElementos tem que ser pelo menos 2')
			print('teste sobre insertEquipa - OK')
		else
			print('teste sobre insertEquipa - NOK')
	end CATCH
	
	print('Testes alinea h')
	begin tran
		exec insertFuncionariosEquipa
			@funcionario = 9,
			@equipa = 4,
			@dtEntrada = '2021-12-01'
		if exists (select * from FuncionariosEquipas
				   where funcionario = 9 and equipa = 4 and dtEntrada = '2021-12-01')
			print('teste sobre insertFuncionariosEquipa - OK')
		else
			print('teste sobre insertFuncionariosEquipa - NOK')
	
		exec deleteFuncionariosEquipa
			@funcionario = 9,
			@equipa = 4,
			@dtSaida = null
		if exists (select * from FuncionariosEquipas
				   where funcionario = 9 and equipa = 4 and dtSaida IS NOT NULL)
			print('teste sobre deleteFuncionariosEquipa - OK')
		else
			print('teste sobre deleteFuncionariosEquipa - NOK')
	rollback
	
	print('Testes alinea h(2)')
	begin tran
		exec insertFuncionariosCompetencias
			@funcionario = 2,
			@competencia = 2
		if exists (select * from FuncionariosCompetencias
				   where funcionario = 2 and competencia = 2)
			print('teste sobre insertFuncionariosCompetencias - OK')
		else
			print('teste sobre insertFuncionariosCompetencias - NOK')
			
		exec deleteFuncionariosCompetencias
			@funcionario = 2,
			@competencia = 2
		if not exists (select * from FuncionariosCompetencias
				   where funcionario = 2 and competencia = 2)
			print('teste sobre deleteFuncionariosCompetencias - OK')
		else
			print('teste sobre deleteFuncionariosCompetencias - NOK')
	rollback
	
	begin TRY
		begin tran
			exec deleteFuncionariosCompetencias
				@funcionario = 1,
				@competencia = 2
			print('teste sobre deleteFuncionariosCompetencias - NOK')
		rollback
	end TRY
	begin CATCH
		if (error_message() = 'Competência do funcionário em uso numa intervenção')
			print('teste sobre deleteFuncionariosCompetencias - OK')
		else
			print('teste sobre deleteFuncionariosCompetencias - NOK')
	end CATCH

	print('Testes alinea i')
	begin tran
		if exists (select * from listAllIntervencoesFromDate('2021'))
			print('teste sobre listAllIntervencoesFromDate - OK')
		else
			print('teste sobre listAllIntervencoesFromDate - NOK')
	rollback
	
	begin tran
		if not exists (select * from listAllIntervencoesFromDate('1900'))
			print('teste sobre listAllIntervencoesFromDate - OK')
		else
			print('teste sobre listAllIntervencoesFromDate - NOK')
	rollback
	
	print('Testes alinea j')
	begin tran
		exec updateIntervencaoState
			@id = 1,
			@estado = 'Concluído'
		if exists (select * from Intervencoes
				   where id = 1 and estado = 'Concluído')
			print('teste sobre updateIntervencaoState - OK')
		else
			print('teste sobre updateIntervencaoState - NOK')
	rollback
	
	begin TRY
		begin tran
			exec updateIntervencaoState
				@id = 1,
				@estado = ''
			print('teste sobre updateIntervencaoState - NOK')
		rollback
	end TRY
	begin CATCH
		if (error_message() = 'Estado igual ao existente ou nulo')
			print('teste sobre updateIntervencaoState - OK')
		else
			print('teste sobre updateIntervencaoState - NOK')
	end CATCH

	print('Testes alinea k')
	begin tran
		if exists (select * from ResumoIntervencoes)
			print('teste sobre ResumoIntervencoes - OK')
		else
			print('teste sobre ResumoIntervencoes - NOK')
	rollback
	
	begin tran
		update ResumoIntervencoes set estadoIntervencoes = 'Concluído' where id = 1
		if exists (select * from ResumoIntervencoes
		           where estadoIntervencoes = 'Concluído'
		           and id = 1)
			print('teste sobre ResumoIntervencoes - OK')
		else
			print('teste sobre ResumoIntervencoes - NOK')
	rollback
	
	begin tran
		update ResumoIntervencoes set estadoIntervencoes = 'Concluído'
		if not exists (select * from ResumoIntervencoes
		               where estadoIntervencoes != 'Concluído')
			print('teste sobre ResumoIntervencoes - OK')
		else
			print('teste sobre ResumoIntervencoes - NOK')
	rollback

end