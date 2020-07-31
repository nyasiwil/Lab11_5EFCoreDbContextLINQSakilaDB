USE sakila;
GO
-- Cleaning up Sakila Null Values
/* In this lab, we’ll be using the ToArray() method to pull data from our database 
into an array. However, we’ll get an error when we do this if the film table has null 
values.  While we could work around this, implementing a code fix would take too much 
time, so our fix is going to be to clean up Sakila’s null values first.
Open SQL management studio and select all data from the film table.  For any records 
that have NULL values, we need to run UPDATE statements to replace the null data with 
real data.  Your fixes might be different from ours, but we’ve included the .sql script 
we used to clean our data. */

--SELECT *, ISNULL(original_language_id, 0)
--FROM film;

UPDATE film
SET original_language_id = ISNULL(original_language_id, language_id);

DROP TRIGGER IF EXISTS [film].[insert_film]

SELECT * 
FROM film;