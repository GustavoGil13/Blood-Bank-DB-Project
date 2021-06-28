Create proc del_pessoa @CC_pessoa int 
as
	declare @id int
	begin transaction
		begin try
			if exists(select * from Funcionario where CC_Funcionario=@CC_pessoa)
				delete Funcionario where CC_Funcionario=@CC_pessoa
			if exists(select * from Doador where CC_Doador=@CC_pessoa)
				select @id = ID_Doador from Doador where CC_Doador=@CC_pessoa
				update Recipiente_Sangue set ID_Doador_RS=null where ID_Doador_RS=@id
				delete Doador where CC_Doador=@CC_pessoa
			if exists(select * from Paciente where CC_Paciente=@CC_pessoa)
				select @id = ID_Paciente from Paciente where CC_Paciente=@CC_pessoa
				update Recipiente_Sangue set ID_Paciente_RS=null where ID_Paciente_RS=@id
				delete Paciente where CC_Paciente=@CC_pessoa
			if exists(select * from Tipo_Sangue_Pessoa where CC_Pessoa_TP=@CC_pessoa)
				delete Tipo_Sangue_Pessoa where CC_Pessoa_TP=@CC_pessoa
			if exists(select * from Especifica_Medicamentos where CC_Pessoa_EM=@CC_pessoa)
				delete Especifica_Medicamentos where CC_Pessoa_EM=@CC_pessoa
			if exists(select * from Descreve_Patologias where CC_Pessoa_DP=@CC_pessoa)
				delete Descreve_Patologias where CC_Pessoa_DP=@CC_pessoa
			if exists(select * from Ficha_Clinica where CC_Pessoa=@CC_pessoa)
				delete Ficha_Clinica where CC_Pessoa=@CC_pessoa
			if exists(select * from Pessoa where CC=@CC_pessoa)
				delete Pessoa where CC=@CC_pessoa
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

Create proc InsertDoador @CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int, @ID_doador int, @ID_ficha int, @tipo_sangue varchar(3), @banco varchar(256)
as
	begin transaction
		begin try
			insert into Pessoa values (@CC,@nome,@apelido,@morada,@idade,@telemovel);
			insert into Doador values (@CC, @ID_doador,@banco);
			insert into Ficha_Clinica values (@ID_ficha, @CC);
			insert into Tipo_Sangue_Pessoa values (@tipo_sangue, @ID_ficha, @CC);
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

Create proc InsertFuncionario @CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int, @ID_Func int ,@salario smallmoney, @banco varchar(256)
as
	begin transaction
		begin try
			insert into Pessoa values (@CC,@nome,@apelido,@morada,@idade,@telemovel);
			insert into Funcionario values (@ID_Func, @CC, @salario, @banco);
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

Create proc InsertGestor @CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int, @ID_Func int ,@salario smallmoney, @banco varchar(256)
as
	begin transaction
		begin try
			insert into Pessoa values (@CC,@nome,@apelido,@morada,@idade,@telemovel);
			insert into Funcionario values (@ID_Func, @CC, @salario, @banco);
			update Banco_Sangue set ID_gestor=@ID_Func where nome=@banco;
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

Create proc InsertPaciente @CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int, @ID_paciente int, @ID_ficha int, @tipo_sangue varchar(3), @doencas varchar(2048), @medicamentos varchar(2048), @banco varchar(256)
as
	begin transaction
		begin try
			insert into Pessoa values (@CC,@nome,@apelido,@morada,@idade,@telemovel);
			insert into Paciente values (@CC, @ID_paciente,@banco);
			insert into Ficha_Clinica values (@ID_ficha, @CC);
			insert into Tipo_Sangue_Pessoa values (@tipo_sangue, @ID_ficha, @CC);
			-- colocar doenças
			if @doencas <> ''
			begin
				declare @doenca as varchar(256)
				declare C cursor fast_forward
				for select * from string_split(@doencas, ',')
				open C
				fetch C into @doenca

				while @@FETCH_STATUS = 0
					begin
						insert into Descreve_Patologias values (@doenca, @ID_ficha, @CC);
						fetch C into @doenca
					end

				Close C;
				deallocate C;
			end
			-- colocar medicamentos
			if @medicamentos <> ''
			begin
				declare @medicamento as varchar(256)
				declare C cursor fast_forward
				for select * from string_split(@medicamentos, ',')
				open C
				fetch C into @medicamento

				while @@FETCH_STATUS = 0
					begin
						insert into Especifica_Medicamentos values (@medicamento, @ID_ficha, @CC);
						fetch C into @medicamento
					end

				Close C;
				deallocate C;
			end
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

create proc InsertCliente @no_cliente int, @NIF int, @nome varchar(256), @tipo_cliente varchar(32)
as
	insert into Cliente values (@no_cliente, @NIF, @nome, @tipo_cliente)
Go


Create proc InsertEncomenda @no_cliente int, @numero_encomenda int, @data_encomenda date, @quantidade_recipientes int, @tipo_sangue varchar(3), @banco varchar(256)
as
	begin transaction
		begin try
			insert into Encomendas values (@numero_encomenda, @quantidade_recipientes, @tipo_sangue)
			insert into Faz values (@numero_encomenda, @no_cliente, @data_encomenda)
			insert into Fornece values (@banco, @numero_encomenda, null)
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

create proc InsertBanco @nome varchar(256), @morada varchar(256)
as
	insert into Banco_Sangue values (@nome, @morada, null)
Go

Create proc Fornecimento @banco varchar(256), @numero_encomenda int, @data_fornecimento date
as
	declare @ts varchar(3), @n int, @conta int
	begin transaction
			begin try
				select @ts = tipo_sangue_encomenda from Encomendas where no_encomenda=@numero_encomenda
				select @n = quantidade_recipientes from Encomendas where no_encomenda=@numero_encomenda

				select top (@n) @conta = count(codigo_associado)
				from Recipiente_Sangue join Tipo_Sangue_Recipiente on codigo_associado=codigo_associado_RS
				where RS_BS_nome=@banco and data_utilizacao is null and tipo_sangue_RS=@ts

				if @n = @conta
					begin
						update Fornece set data_fornecimento=@data_fornecimento where nome_BS=@banco and no_encomenda_F=@numero_encomenda

						declare @codigo as int
						declare C cursor fast_forward
						for select codigo_associado
							from Recipiente_Sangue join Tipo_Sangue_Recipiente on codigo_associado=codigo_associado_RS
							where RS_BS_nome=@banco and data_utilizacao is null and tipo_sangue_RS=@ts

						open C
						fetch C into @codigo

						while @@FETCH_STATUS = 0
							begin
								delete Tipo_Sangue_Recipiente where codigo_associado_RS=@codigo
								delete Recipiente_Sangue where codigo_associado=@codigo
								fetch C into @codigo
							end
						Close C;
						deallocate C;
					end
				commit
			end try
	begin catch
		rollback transaction
	end catch
Go

Create proc EditDoador @CC_antigo int, @CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int, @tipo_sangue varchar(3) 
as
	begin transaction
		begin try
		update Pessoa set CC=@CC, nome=@nome, apelido=@apelido, morada=@morada, idade=@idade, telemovel=@telemovel where CC=@CC_antigo
		update Tipo_Sangue_Pessoa set Tipo_Sangue_Pessoa=@tipo_sangue where CC_Pessoa_TP=@CC
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

Create proc EditFuncionario @CC_antigo int, @CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int,@salario smallmoney
as
	begin transaction
		begin try
			update Pessoa set CC=@CC, nome=@nome, apelido=@apelido, morada=@morada, idade=@idade, telemovel=@telemovel where CC=@CC_antigo
			update Funcionario set salario=@salario where CC_Funcionario=@CC
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

Create proc EditGestor @CC_antigo int,@CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int, @ID_Func int ,@salario smallmoney, @banco varchar(256)
as
	begin transaction
		begin try
			update Pessoa set CC=@CC, nome=@nome, apelido=@apelido, morada=@morada, idade=@idade, telemovel=@telemovel where CC=@CC_antigo
			update Funcionario set salario=@salario where CC_Funcionario=@CC
			update Banco_Sangue set ID_gestor=@ID_Func where nome=@banco;
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

Create proc EditPaciente @CC_antigo int, @CC int, @nome varchar(256), @apelido varchar(256), @morada varchar(256), @idade tinyint, @telemovel int, @ID_ficha int, @tipo_sangue varchar(3), @doencas varchar(2048), @medicamentos varchar(2048) 
as
	begin transaction
		begin try
			update Pessoa set CC=@CC, nome=@nome, apelido=@apelido, morada=@morada, idade=@idade, telemovel=@telemovel where CC=@CC_antigo
			update Tipo_Sangue_Pessoa set Tipo_Sangue_Pessoa=@tipo_sangue where CC_Pessoa_TP=@CC
			-- eliminar doenças e medicamentos
			if exists(select * from Especifica_Medicamentos where CC_Pessoa_EM=@CC)
				delete Especifica_Medicamentos where CC_Pessoa_EM=@CC
			if exists(select * from Descreve_Patologias where CC_Pessoa_DP=@CC)
				delete Descreve_Patologias where CC_Pessoa_DP=@CC
			-- colocar doenças
			if @doencas <> ''
			begin
				declare @doenca as varchar(256)

				declare C cursor fast_forward
				for select * from string_split(@doencas, ',')
				open C
				fetch C into @doenca

				while @@FETCH_STATUS = 0
					begin
						insert into Descreve_Patologias values (@doenca, @ID_ficha, @CC);
						fetch C into @doenca
					end

				Close C;
				deallocate C;
			end
			-- colocar medicamentos
			if @medicamentos <> ''
			begin
				declare @medicamento as varchar(256)

				declare C cursor fast_forward
				for select * from string_split(@medicamentos, ',')
				open C
				fetch C into @medicamento

				while @@FETCH_STATUS = 0
					begin
						insert into Especifica_Medicamentos values (@medicamento, @ID_ficha, @CC);
						fetch C into @medicamento
					end

				Close C;
				deallocate C;
			end
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

create proc MakeDonation @codigo int, @id_doador int, @data_doacao date, @tipo_sangue varchar(3), @banco varchar(256)
as
	begin transaction
		begin try
			insert into Recipiente_Sangue (codigo_associado, ID_Doador_RS, data_doa_sangue, RS_BS_nome) values (@codigo, @id_doador, @data_doacao, @banco)
			insert into Tipo_Sangue_Recipiente values (@codigo, @tipo_sangue)
			commit
		end try
	begin catch
		rollback transaction
	end catch
GO

create proc ArmazenarRecipiente @codigo int, @data_armazenar date
as
	update Recipiente_Sangue set data_armazenamento_RS=@data_armazenar where codigo_associado=@codigo
GO

create proc AtribuirRecipiente @codigo int, @id_paciente int, @data_recebe date
as
	update Recipiente_Sangue set ID_Paciente_RS=@id_paciente, data_utilizacao=@data_recebe where codigo_associado=@codigo
GO

create proc GetStock @banco varchar(256)
as
	select tipo_sangue_RS, count(tipo_sangue_RS) as stock
	from (select tipo_sangue_RS
		from Recipiente_Sangue join Tipo_Sangue_Recipiente on codigo_associado=codigo_associado_RS
		where RS_BS_nome=@banco and data_utilizacao is null) as temp
	group by tipo_sangue_RS
GO