  alter table marketing add fullscreen_banner_path nvarchar (200) null
  go

  --data
  declare @prefix varchar(300)
  set @prefix = (select left(horizontal_banner_path, len(horizontal_banner_path) - charindex('\', reverse(horizontal_banner_path) + '\')) from marketing where id = 2)
  update marketing set fullscreen_banner_path = concat(@prefix, '\', 'bioderma_full.jpg') where id = 5
    update marketing set fullscreen_banner_path = concat(@prefix, '\', 'jamieson_full.jpg') where id = 7	
	--insert into marketing ([name], active, fullscreen_banner_path) values ('xanax', 1,concat(@prefix, '\', 'xanax_full.jpg') )
	insert into marketing ([name], active, fullscreen_banner_path) values ('durex', 1,concat(@prefix, '\', 'durex_full.jpg') )
 
  select SCOPE_IDENTITY(), id
  from medicine where name like '%durex%'
  /*
  select  horizontal_banner_path* from marketing


  select left(horizontal_banner_path, 
  select len(horizontal_banner_path)  from marketing where id = 1
  */

  update pharmaco_db_access set value = 
  'select id as id, [name] as name, [description] as [description], horizontal_banner_path as horizontal_banner_path, vertical_banner_path as vertical_banner_path,fullscreen_banner_path as fullscreen_banner_path from marketing where active = 1'
  where name = 'select_marketing_sql'
