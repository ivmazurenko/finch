FROM postgres:latest 
ENV POSTGRES_DB mock_database
ENV POSTGRES_USER sa
ENV POSTGRES_PASSWORD sa_pass_111

COPY mock_database_postgre.sql /docker-entrypoint-initdb.d/
