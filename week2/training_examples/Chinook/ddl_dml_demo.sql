-- DDL and DML Demo --

CREATE DATABASE DemoDB;

USE DemoDB;

-- CREATE DATABASE BudgetDB;

-- USE BudgetDB;

-- CREATE SCHEMA TEST;

-- CREATE TABLE
CREATE TABLE DemoTable(
    demo_id int IDENTITY(1, 1) PRIMARY KEY,
    demo_name VARCHAR(255) NOT NULL,
    demo_date TIMESTAMP
);

-- ALTER TABLE, ADD COLUMN
ALTER TABLE DemoTable
ADD demo_description VARCHAR(255) NOT NULL;

-- ALTER TABLE, RENAME COLUMN
EXEC sp_rename 'dbo.DemoTable.demo_description', 'demo_newcolumn';

/*
    -- ALTER TABLE DemoTable
    -- ALTER RENAME COLUMN demo_description TO demo_newname
*/

-- Data Manipulation Language

-- Insert Values
INSERT INTO DemoTable (demo_name, demo_newcolumn) 
    VALUES ('my Value', 'testing');

INSERT INTO DemoTable (demo_name, demo_newcolumn) 
    VALUES ('second Value', 'testing some other values');

-- Update 
UPDATE DemoTable
SET demo_newcolumn = 'new testing value'
WHERE demo_id = 1;

-- Delete
DELETE FROM DemoTable
WHERE demo_id = 2;

-- Truncate
TRUNCATE TABLE DemoTable;

-- Drop Table
DROP TABLE DemoTable;

SELECT * FROM DemoTable;