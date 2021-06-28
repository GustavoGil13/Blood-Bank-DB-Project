drop table Faz;
drop table Fornece;
drop table Tipo_Sangue_Recipiente;
drop table Tipo_Sangue_Pessoa;
drop table Recipiente_Sangue;
drop table Paciente;
drop table Doador;
drop table Descreve_Patologias;
drop table Patologias;
drop table Cliente;
drop table Encomendas;
alter table Funcionario
	drop constraint func
drop table Banco_Sangue
drop table Especifica_Medicamentos
drop table Ficha_Clinica
drop table Funcionario
drop table Medicamentos
drop table Pessoa
drop procedure del_pessoa
drop procedure InsertDoador
drop procedure InsertFuncionario
drop procedure InsertGestor
drop procedure InsertPaciente
drop procedure EditDoador
drop procedure EditFuncionario
drop procedure EditGestor
drop procedure EditPaciente
drop procedure MakeDonation
drop procedure ArmazenarRecipiente
drop procedure AtribuirRecipiente
drop procedure InsertCliente
drop procedure InsertEncomenda
drop procedure Fornecimento
drop procedure GetStock
drop procedure InsertBanco
GO

create table Pessoa (
	CC int not null primary key check (CC >= 10000000 and CC <= 99999999),
	nome varchar(256) not null,
	apelido varchar(256) not null,
	morada varchar(256),
	idade tinyint not null,
	telemovel int not null check (telemovel >= 910000000 and telemovel <= 969999999)
);
GO

create table Ficha_Clinica (
	ID_Ficha int not null,
	CC_Pessoa int not null references Pessoa(CC) on update cascade,
	primary key (CC_Pessoa, ID_Ficha)
);
GO

create table Medicamentos (
	nome_medicamento varchar(256) not null primary key
);
GO

create table Patologias (
	nome_patologia varchar(256) not null primary key
);
GO

create table Descreve_Patologias (
	nome_DP varchar(256) not null references Patologias(nome_patologia),
	ID_Ficha_DP int not null,
	CC_Pessoa_DP int not null,
	primary key(ID_Ficha_DP, CC_Pessoa_DP, nome_DP),
	foreign key (CC_Pessoa_DP, ID_Ficha_DP) references Ficha_Clinica(CC_Pessoa, ID_Ficha) on update cascade
);
GO

create table Especifica_Medicamentos (
	nome_EM varchar(256) not null references Medicamentos(nome_medicamento),
	ID_Ficha_EM int not null,
	CC_Pessoa_EM int not null,
	primary key(ID_Ficha_EM, CC_Pessoa_EM, nome_EM),
	foreign key (CC_Pessoa_EM, ID_Ficha_EM) references Ficha_Clinica(CC_Pessoa, ID_Ficha) on update cascade
);
GO

create table Tipo_Sangue_Pessoa (
	Tipo_Sangue_Pessoa char(3) not null,
	ID_Ficha_SP int not null,
	CC_Pessoa_TP int not null,
	primary key(ID_Ficha_SP,CC_Pessoa_TP,Tipo_Sangue_Pessoa),
	foreign key (CC_Pessoa_TP, ID_Ficha_SP) references Ficha_Clinica(CC_Pessoa, ID_Ficha) on update cascade
);
GO

create table Paciente (
	CC_Paciente int not null unique references Pessoa(CC) on update cascade,
	ID_Paciente int not null  primary key,
	nome_bs_p varchar(256)
);
Go

create table Doador (
	CC_Doador int not null unique references Pessoa(CC) on update cascade,
	ID_Doador int not null  primary key,
	nome_bs_d varchar(256)
);
GO

create table Funcionario (
	ID_Funcionario int not null  primary key,
	CC_Funcionario int not null unique references Pessoa(CC) on update cascade,
	salario smallmoney check (salario >= 0) default 0,
	Funcionario_BS_nome varchar(256)
);
GO

create table Recipiente_Sangue (
	codigo_associado int not null  primary key,
	data_armazenamento_RS date,
	ID_Paciente_RS int references Paciente(ID_Paciente),
	data_utilizacao date,
	ID_Doador_RS int references Doador(ID_Doador),
	data_doa_sangue date not null,
	RS_BS_nome varchar(256)
);
GO

create table Tipo_Sangue_Recipiente (
	codigo_associado_RS int not null references Recipiente_Sangue(codigo_associado),
	tipo_sangue_RS char(3) not null,
	primary key(codigo_associado_RS, tipo_sangue_RS)
);
GO

create table Banco_Sangue (
	nome varchar(256) not null primary key,
	morada varchar(256),
	ID_gestor int references Funcionario(ID_Funcionario) on delete set null on update cascade
);
GO

create table Encomendas (
	no_encomenda int not null  primary key,
	quantidade_recipientes int not null,
	tipo_sangue_encomenda char(3) not null
);
GO

create table Fornece (
	nome_BS varchar(256) not null references Banco_Sangue(nome) on update cascade,
	no_encomenda_F int not null references Encomendas(no_encomenda) on update cascade,
	data_fornecimento date, -- pode ser null pq ainda n forneceu
	primary key(nome_BS,no_encomenda_F)
);
GO

create table Cliente (
	no_cliente int not null  primary key,
	NIF int not null unique check (NIF >= 100000000 and NIF <= 999999999),
	nome_cliente varchar(256) not null,
	tipo_cliente varchar(32)
);
GO

create table Faz (
	no_encomendas_faz int not null references Encomendas(no_encomenda) on update cascade,
	no_cliente_faz int not null references Cliente(no_cliente) on update cascade,
	data_encomenda date not null,
	primary key(no_encomendas_faz, no_cliente_faz)
);
GO

alter table Funcionario
	add constraint func foreign key (Funcionario_BS_nome) references Banco_Sangue(nome);
Go

alter table Recipiente_Sangue
	add constraint rs foreign key (RS_BS_nome) references Banco_Sangue(nome);
Go

alter table Paciente
	add constraint pac foreign key (nome_bs_p) references Banco_Sangue(nome);
Go

alter table Doador
	add constraint dor foreign key (nome_bs_d) references Banco_Sangue(nome);
Go