#!/bin/bash

# Variables
PASSWORD="${MSSQL_SA_PASSWORD}"
SQL_SCRIPT_PATH="/init/instnwnd.sql"

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to start
echo "Waiting for SQL Server to start..."
sleep 15

# Check if the SQL script exists
if [ ! -f "${SQL_SCRIPT_PATH}" ]; then
  echo "Error: SQL script not found at ${SQL_SCRIPT_PATH}."
  exit 1
fi

# Execute the SQL script
echo "Running SQL script: ${SQL_SCRIPT_PATH}"
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "${PASSWORD}" -i "${SQL_SCRIPT_PATH}" -C

# Check the result of sqlcmd
if [ $? -eq 0 ]; then
  echo "SQL script executed successfully."
else
  echo "Error: Failed to execute SQL script."
  exit 1
fi

wait
