create database F1;

use F1;
	
create table Equipe (
    id int identity (100,1) not null,
    nome varchar(30) not null,
    constraint PK_Equipe Primary Key (id),
    constraint UN_Equipe_Nome Unique (nome)
)


create table Piloto (
    id int identity (1000,1) not null,
    nome varchar(30) not null,
    constraint PK_Piloto Primary Key (id),
    constraint UN_Piloto_Nome Unique (nome)
)

create table Carro(
    id int identity (2000,10) not null,
    modelo varchar(10) not null,
    ano int not null,
    unidade int not null,
    id_equipe int not null,
    constraint PK_Carro primary key (id),
    constraint UN_Carro_01 unique (modelo, ano, unidade),
    constraint FK_Carro_Equipe foreign key (id_equipe) references Equipe(id)
)

create table PilotoCarro (
    id_piloto int not null,
    id_carro int not null,
    data_evento date not null,
    constraint PK_PilotoCarro primary key (id_piloto, id_carro, data_evento),
    constraint FK_PilotoCarro_Piloto foreign key (id_piloto) references Piloto (id),
    constraint FK_PilotoCarro_Carro foreign key (id_carro) references Carro(id)
)

