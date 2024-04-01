#!/bin/bash

database_file="mock_database_sqlite.db"
sql_script="mock_database_sqlite.sql"

if [ -f "$database_file" ]; then
    echo "Removing previous database file: $database_file"
    rm "$database_file"
fi

echo "Creating new database: $database_file"
sqlite3 "$database_file" < "$sql_script"

echo "Database created successfully."
