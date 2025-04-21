SET PGCLIENTENCODING=utf-8
set PGPASSWORD=postgres
psql -h localhost -p 5432 -U postgres -d shop_database -f scripts\drop_tables.sql

pause