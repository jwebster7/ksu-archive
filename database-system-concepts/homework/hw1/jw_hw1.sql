/* Question 1 */
SELECT 
	MONTH(O.OrderDate) AS [Month],
	COUNT(DISTINCT(O.CustomerID)) AS [CustomerCount],
	COUNT(MONTH(O.OrderID)) AS [OrderCount]
FROM Sales.Orders AS O
WHERE O.OrderDate BETWEEN '2015-01-01' AND '2015-12-31'
GROUP BY MONTH(O.OrderDate)
ORDER BY [Month] ASC

/* Question 2 */
SELECT 
	O.CustomerID AS [CustomerID],
	COUNT(O.OrderID) AS [OrderCount],
	MIN(O.OrderDate) AS [FirstOrderDate],
	MAX(O.OrderDate) AS [LastOrderDate],
	CASE
		WHEN COUNT(O.OrderID) < 25 THEN N'Few Orders'
		WHEN COUNT(O.OrderID) < 100 AND COUNT(O.OrderID) >= 25 THEN N'Growing Customer'
		WHEN COUNT(O.OrderID) >= 100 THEN N'Large Customer'
	END AS CustomerCategory
FROM Sales.Orders O
GROUP BY O.CustomerID
ORDER BY O.CustomerID ASC

/* Question 3 */
DECLARE
	@FirstOrderDate DATE = '2015-01-01',
	@LastOrderDate DATE = '2015-02-01',
	@PageSize INT = 100,
	@Page INT = 1;

SELECT
	O.OrderID,
	O.OrderDate,
	O.CustomerID,
	O.SalespersonPersonID
FROM Sales.Orders AS O
WHERE O.OrderDate BETWEEN @FirstOrderDate AND @LastOrderDate
ORDER BY O.OrderID ASC
OFFSET ((@Page - 1) * @PageSize) ROWS
FETCH NEXT @PageSize ROWS ONLY
