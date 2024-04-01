#!/bin/bash

docker-compose down -v
docker-compose up --build -d 

./mock_database_sqlite.sh