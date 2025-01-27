-- Initial table for products table from scraped data

DROP TABLE IF EXISTS products CASCADE;

CREATE TABLE products (
 id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
 code TEXT UNIQUE NOT NULL,
 product_name TEXT NOT NULL,
 custom_text TEXT,
 weight TEXT,
 warning TEXT,
 ingredients TEXT,
 product_contains TEXT[],
 product_does_not_contain TEXT[]
);

COPY products (product_name, custom_text, weight, warning, code ,ingredients, product_contains, product_does_not_contain) FROM '/tmp/csvs/products.csv'
WITH (FORMAT csv, HEADER true);