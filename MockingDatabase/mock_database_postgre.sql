CREATE TABLE tb_user
(
    id   SERIAL PRIMARY KEY,
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
VALUES (B'0'),
       (B'1');


CREATE TABLE tb_value_bit_nullable
(
    value bit
);

INSERT INTO tb_value_bit_nullable (value)
VALUES (NULL),
       (B'1'),
       (B'0');


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
