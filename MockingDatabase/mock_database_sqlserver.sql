use
mock_database;

CREATE TABLE tb_user
(
    id   int PRIMARY KEY IDENTITY,
    name VARCHAR(100)
);

INSERT INTO tb_user (name)
VALUES ('John'),
       ('Jane');



CREATE TABLE tb_value_varchar100
(
    value VARCHAR(100) not null
);

INSERT INTO tb_value_varchar100 (value)
VALUES ('John'),
       ('Jane');



CREATE TABLE tb_value_bit
(
    value bit not null
);

INSERT INTO tb_value_bit (value)
VALUES (0),
       (1);


CREATE TABLE tb_value_bit_nullable
(
    value bit,
);

INSERT INTO tb_value_bit_nullable (value)
VALUES (null),
       (1),
       (0);


CREATE TABLE tb_different_integer_nullable
(
    value_smallint smallint,
    value_integer  integer,
    value_bigint   bigint
);

INSERT INTO tb_different_integer_nullable (value_smallint, value_integer, value_bigint)
VALUES (NULL, 2, 4),
       (1, NULL, 4),
       (1, 2, NULL),
       (0, 0, 0);
