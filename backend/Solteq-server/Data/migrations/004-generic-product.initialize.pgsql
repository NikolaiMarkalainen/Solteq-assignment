DROP TABLE IF EXISTS generic_products;

CREATE TABLE generic_products(
    id BIGINT,
    product_name TEXT NOT NULL,
    category TEXT NOT NULL
);

INSERT INTO generic_products (id, product_name, category)
SELECT id, product_name, category from products;