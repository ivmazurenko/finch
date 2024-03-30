FROM mcr.microsoft.com/mssql/server:latest
ENV ACCEPT_EULA=Y

# The SA_PASSWORD environment variable is deprecated. Please use MSSQL_SA_PASSWORD instead.
ENV MSSQL_SA_PASSWORD=vEryL111ngOassw1e! 
COPY ./mock_database_sqlserver.sql ./
COPY ./mock_database_sqlserver.sh ./
EXPOSE 1433

ENTRYPOINT /bin/bash ./mock_database_sqlserver.sh & /opt/mssql/bin/sqlservr
