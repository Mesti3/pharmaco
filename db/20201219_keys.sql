

alter table category add constraint  PK_category primary key (id)
alter table category add constraint  PK_category_parent_category foreign key (parent_category_id)  references category(id)
