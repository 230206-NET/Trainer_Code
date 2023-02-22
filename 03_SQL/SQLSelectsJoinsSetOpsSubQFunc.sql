select * from artist;

select * from artist where [Name] = 'Green Day'

select * from artist where ArtistId < 150;

-- Get me all artist where their name ends in a certain string
select * from artist where [Name] like '%i'

-- Get me all artists where their name STARTS with a certain string
select * from artist where [Name] like 'B%'

-- Get me all artists where their name contains a certain string
select * from artist where [Name] like '%ie%';

-- limit the result set to a certain number using 'top' keyword
select top 5 * from artist where [Name] like '%ie%';

-- SELECT columns (which column(s) do i want in my result set)
-- FROM dataset 
-- WHERE condition (filter by this condition)
-- GROUP BY column(s) (comes in handy if you're using aggregate functions)
-- HAVING condition (further filter after group by)
-- ORDER BY column(s) (order the data set in a certain way)

-- How do I get a list of customers who live in 'Canada' and ordered by their Lastname?
select * from customer where country = 'Canada' order by LastName;

select * from employee;

-- we use joins to bring related data scattered across many tables back together
-- inner join, left join, right join, full outer join
-- join two tables on a COMMON column

select * from Invoice;
select * from InvoiceLine;
select * from Track;
-- I.InvoiceId, InvoiceDate, Total, Track.[Name] as TrackName, Composer
select * from Invoice as I
LEFT JOIN InvoiceLine ON I.InvoiceId = InvoiceLine.InvoiceId
JOIN Track ON InvoiceLine.TrackId = Track.TrackId;

-- Modify the above query to display customer name(first and/or last) of the invoice as well as genre information
-- ordered by Composer's last name

select Customer.FirstName,Customer.LastName, Genre.GenreId, Genre.Name, I.InvoiceId, InvoiceDate, Total, Track.[Name] as TrackName, Composer from Invoice as I
JOIN InvoiceLine ON I.InvoiceId = InvoiceLine.InvoiceId
JOIN Track ON InvoiceLine.TrackId = Track.TrackId
JOIN Customer ON I.CustomerId = Customer.CustomerId
JOIN Genre ON Genre.GenreId = Track.GenreId 
order by Track.Composer

select * from InvoiceLine JOIN Track on InvoiceLine.TrackId = Track.TrackId where Track.TrackId = 22;

-- Set operators operates on multiple SELECT statements
Select CustomerId as Id, FirstName, LastName, City, State, Country FROM Customer
Union All
Select EmployeeId as Id, FirstName, LastName, City, State, Country FROM Employee;
-- Union
-- Union All (gives you the duplicates)
-- Intersect
-- Except

-- Subqueries
-- Nested Queries
-- Where and From clause

-- If we wanted to search for invoice lines that have a certain track by its name,
SELECT * FROM InvoiceLine join Track on InvoiceLine.TrackId = Track.TrackId where Track.Name = 'Overdose'

SELECT * FROM InvoiceLine where TrackId = (Select TrackId from Track where Track.Name = 'Overdose')

-- Select * from Invoice where CustomerId = (Select CustomerId from Customer where Name = '');

Select * From (Select * From Customer Where Country = 'USA') as USACustomer where USACustomer.FirstName like '%a%';

-- Functions : predefined collection of sql queries
-- Built In functions
    -- Scalar
        -- any function that returns a single value
        -- Lower(), Upper(), getdate()
    -- Aggregate
        -- They work on multiple rows and return a single value
        -- Count(), Avg(), Sum()
-- Group By and Having clauses when using Aggregate functions
    -- group by is used when you use aggregate functions in select statements
    -- use having clause when you want to filter the result set further after group by

Select Count(FirstName) as NumCustomer, Country from Customer group by country order by NumCustomer desc;

Select Count(FirstName) as NumCustomer, Country from Customer where FirstName like '%a%' group by country having Count(FirstName) > 1 order by NumCustomer desc;

-- Write a query that counts how many sales a certain track has made, group them by track name and order them also by their track name
select top 5 Name, count(Name) as NumSales, sum(InvoiceLine.UnitPrice) as Sum from Track right join InvoiceLine ON Track.TrackId = InvoiceLine.TrackId
group by Name
order by Sum desc;

SELECT count(Quantity) as Sales, [Name] from InvoiceLine, Track where InvoiceLine.TrackId = Track.TrackId group by Track.Name order by Track.Name

-- write a query that gives you total revenue for each track