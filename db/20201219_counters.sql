alter table pharmaco_order add price decimal (6,2) 
alter table pharmaco_order_item add [source] int 
alter table pharmaco_order_item add price decimal (6,2) 

create table pharmaco_order_item_source
(
id int not null,
name varchar (50)
constraint PK_pharmaco_order_item_source primary key (id)
)

insert into pharmaco_order_item_source values (1, 'direct search')
insert into pharmaco_order_item_source values (2, 'marketing')
insert into pharmaco_order_item_source values (3, 'category')
insert into pharmaco_order_item_source values (4, 'main window')


create table pharmaco_log
(
id int identity (1,1) not null,
[date] datetime constraint DF_pharmaco_log_date default (getdate()),
[type] int not null,
additional_data varchar (1000)
constraint PK_pharmaco_log primary key (id)
)

create table pharmaco_log_type
(
id int not null,
name varchar (100)
constraint PK_pharmaco_log_type primary key (id)
)

insert into  pharmaco_log_type values   (1, 'screensaver closed')
insert into  pharmaco_log_type values   (2, 'searched') -- additional data môe by vyh¾adávanı reazec
insert into  pharmaco_log_type values   (3, 'marketing clicked') -- additional data môe by id alebo názov akcie
insert into  pharmaco_log_type values   (4, 'item removed from shopping cart ') -- additional data môe by vyh¾adávanı reazec
insert into  pharmaco_log_type values   (5, 'shopping cart cancelled') -- additional data môe by vyh¾adávanı reazec
