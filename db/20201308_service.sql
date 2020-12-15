alter table pharmaco_order_item add [name] nvarchar(1000) null;
alter table pharmaco_order add [user] varchar(50) null;


--alter table pharmaco_order_item drop column  [name]
update oi 
set oi.name = m.name
from pharmaco_order_item oi, medicine m
where oi.medicine_id = m.id

delete from [pharmaco_db_access] where name = 'select_all_orders'
insert into [pharmaco_db_access] values ('select_all_orders', 'select o.tag as tag, o.[state] as state , o.created as created, o.id as id, o.[user] as [user],
oi.quantity as quantity, oi.[name] as name
from pharmaco_order o
join pharmaco_order_item oi on oi.order_id=o.id
where created between @param1 and @param2  ')


		create table pharmaco_order_state (
		id int not null constraint PK_pharmaco_order_state primary key ,
		name nvarchar (50)
		);
		insert into pharmaco_order_state values (1, 'created')
		insert into pharmaco_order_state values (2, 'seen')
		insert into pharmaco_order_state values (3, 'processing')
		insert into pharmaco_order_state values (4, 'sold')
		insert into pharmaco_order_state values (5, 'cancelled')

