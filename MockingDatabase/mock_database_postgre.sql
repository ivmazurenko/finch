create table tb_user
(
    id   SERIAL primary key,
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
values (B'0'),
       (B'1');



create table tb_value_bit_nullable
(
    value bit
);
insert into tb_value_bit_nullable (value)
values (null),
       (B'1'),
       (B'0');


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
    value NUMERIC(3, 2) not null
);
insert into tb_value_numeric (value)
values (1.05),
       (1.99);



create table tb_value_numeric_nullable
(
    value NUMERIC(3, 2)
);
insert into tb_value_numeric_nullable (value)
values (null),
       (1.22);
