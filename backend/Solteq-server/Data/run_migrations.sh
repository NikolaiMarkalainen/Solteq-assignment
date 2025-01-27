#Manually run through all migrations

DB_HOST="127.0.0.1"
DB_PORT="5432" 
DB_NAME="solteq"
DB_USER="nikolai"
export PGPASSWORD="password"

MIGRATIONS_FOLDER="./migrations"

for migration_file in $MIGRATIONS_FOLDER/*.pgsql; do
    echo "Running migration: $migration_file"
    psql -h $DB_HOST -U $DB_USER -d $DB_NAME -p $DB_PORT -f $migration_file 
    if [ $? -eq 0 ]; then
        echo "Migration $migration_file completed successfully."
    else
        echo "Error in migration $migration_file."
        exit 1  
    fi
done

echo "All migrations applied successfully."