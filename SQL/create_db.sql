CREATE TABLE table_goods (
    good_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    amount INTEGER NOT NULL,
    price REAL NOT NULL
);

CREATE TABLE table_users(
    user_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    full_name TEXT NOT NULL
);

CREATE TABLE table_sales (
    sale_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    date TEXT NOT NULL,
    user_id INTEGER NOT NULL,
    good_id INTEGER NOT NULL,
    FOREIGN KEY (user_id) REFERENCES table_users(user_id) 
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    FOREIGN KEY (good_id) REFERENCES table_goods(good_id) 
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

INSERT INTO table_users(full_name)
VALUES ('User 1'),
       ('User 2'),
       ('User 3'),
       ('User 4'),
       ('User 5');
INSERT INTO table_goods(name, amount, price)
VALUES ('Product 1', 10, 20.5),
       ('Product 2', 1, 100),
       ('Product 3', 99, 9.99);
INSERT INTO table_sales(date, user_id, good_id)
VALUES ('2024-02-19', 1, 1),
       ('2024-03-20', 3, 2);

SELECT table_sales.sale_id AS id,
       date,
       table_users.full_name AS full_name,
       table_goods.name AS good_name
FROM table_sales
    JOIN table_goods ON table_sales.good_id = table_goods.good_id
    JOIN table_users ON table_sales.user_id = table_users.user_id;