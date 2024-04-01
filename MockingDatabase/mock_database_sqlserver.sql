create
database mock_database
go

use
mock_database;

create table tb_user
(
    id   int primary key identity,
    name VARCHAR(100)
);

insert into tb_user (name)
values ('John'),
       ('Jane');



create table tb_value_varchar100
(
    value VARCHAR(100) not null
);

insert into tb_value_varchar100 (value)
values ('John'),
       ('Jane');



create table tb_value_bit
(
    value bit not null
);

insert into tb_value_bit (value)
values (0),
       (1);


create table tb_value_bit_nullable
(
    value bit,
);

insert into tb_value_bit_nullable (value)
values (null),
       (1),
       (0);


create table tb_different_integer_nullable
(
    value_smallint smallint,
    value_integer  integer,
    value_bigint   bigint
);

insert into tb_different_integer_nullable (value_smallint, value_integer, value_bigint)
values (null, 2, 4),
       (1, null, 4),
       (1, 2, null),
       (0, 0, 0);





create table tb_value_numeric
(
    value NUMERIC(3, 2)
);
insert into tb_value_numeric (value)
values (1.05),
       (1.99);
