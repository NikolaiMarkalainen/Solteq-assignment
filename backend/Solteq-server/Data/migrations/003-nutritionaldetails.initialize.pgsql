

DROP TABLE IF EXISTS nutritional_details;

CREATE TABLE nutritional_details (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    product_id TEXT REFERENCES products(code) ON DELETE CASCADE,
    calories TEXT NOT NULL,
    fat TEXT NOT NULL,
    saturated_fat TEXT NOT NULL,
    carbohydrates TEXT NOT NULL,
    sugars TEXT NOT NULL,
    polyols TEXT DEFAULT '0',
    protein TEXT NOT NULL,
    salt TEXT NOT NULL
);

COPY nutritional_details (product_id, calories, fat, saturated_fat, carbohydrates, sugars, polyols, protein, salt) FROM '/tmp/csvs/nutrition.csv'
WITH (FORMAT csv, HEADER true);

UPDATE nutritional_details
SET polyols = '0 g'
WHERE polyols IS NULL;