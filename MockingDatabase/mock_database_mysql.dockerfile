FROM mysql:latest 
ENV MYSQL_DATABASE mock_database
ENV MYSQL_ROOT_PASSWORD vEryL111ngOassw1e!

COPY mock_database_mysql.sql /docker-entrypoint-initdb.d/