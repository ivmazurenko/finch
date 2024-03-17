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
