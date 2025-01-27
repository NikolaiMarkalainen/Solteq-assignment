-- Initial table for products table from scraped data

DROP TABLE IF EXISTS products;

CREATE TABLE products (
 id SERIAL PRIMARY KEY,
 product_name TEXT NOT NULL,
 custom_text TEXT,
 weight TEXT,
 warning TEXT,
 code TEXT,
 ingredients TEXT,
 nutritional_details JSON,
 product_contains TEXT[],
 product_does_not_contain TEXT[]
);

COPY products (product_name, custom_text, weight, warning, code ,ingredients, nutritional_details, product_contains, product_does_not_contain) FROM '/tmp/csvs/products.csv'
WITH (FORMAT csv, HEADER true);