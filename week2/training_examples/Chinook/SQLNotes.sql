-- SQL Notes

USE MyDatabase;

-- Comments in SQL are noted with a "--"
/*
    multi-line comments are also supported
*/

-- DDL - Data Definition - Creating and modifying the structure of the data/tables/db
-- DQL - Data Query - Retreiving the data in interesting ways
-- DML - Data Manipulation - Creating and modifying the data inside the established structure
-- DCL - Data Control - Access control and server administration

/*
    DQL
    - SELECT - sorting, filtering and gathering data from tables within the database - Select ALWAYS returns tables
    - 
*/

SELECT 2; -- SELECT always returns a table
SELECT 2 + 2; -- the server can be pretty powerful
SELECT SYSUTCDATETIME(); -- can respond to requests with computation or calculation
SELECT 'this is a string';

SELECT * FROM [MyDatabase].[dbo].[Artist];

-- gather all of the entries from the Customer table, from the dbo schema, from the db MyDatabase

SELECT * FROM [MyDatabase].[dbo].[Customer];

-- gather ferer columns from the Customer Table
-- don't use *, use specific column names

SELECT FirstName, LastName FROM [MyDatabase].[dbo].[Customer];

-- Use WHERE to filter the response

SELECT FirstName, LastName FROM [MyDatabase].[dbo].[Customer] WHERE LastName = 'Smith';
SELECT FirstName, LastName FROM [MyDatabase].[dbo].[Customer] WHERE Country = 'Canada' AND City = 'Vancouver';

