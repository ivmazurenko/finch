CREATE TABLE tb_user (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100)
);

INSERT INTO tb_user (name) VALUES ('John'), ('Jane');