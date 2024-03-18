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
