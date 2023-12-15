Use WideWorldImporters;

/* Problem 1 */
SELECT
	O.OrderID,
	O.OrderDate,
	CustomerID,
	SUM (OL.Quantity * OL.UnitPrice) AS [OrderTotal]
FROM Sales.Orders AS O
	INNER JOIN Sales.OrderLines AS OL ON O.OrderID = OL.OrderID
		AND O.OrderDate BETWEEN '2016-01-01' AND '2016-01-31'
WHERE O.CustomerID IN
(
	SELECT
		C.CustomerID
	FROM Sales.CustomerCategories AS CC
		INNER JOIN Sales.Customers AS C ON C.CustomerCategoryID = CC.CustomerCategoryID
	WHERE CC.CustomerCategoryName = 'Computer Store'
)
GROUP BY O.OrderID, O.OrderDate, O.CustomerID
ORDER BY OrderTotal DESC, OrderID ASC

/* Problem 2 */
SELECT 
	PS.SupplierID,
	PS.SupplierName,
	AC.CityName AS [City],
	ASP.StateProvinceCode AS [State],
	PS.PostalPostalCode AS [PostalCode]
FROM Purchasing.Suppliers AS PS
	INNER JOIN Purchasing.SupplierCategories AS PSC ON PS.SupplierCategoryID = PSC.SupplierCategoryID
	INNER JOIN Application.Cities AS AC ON AC.CityID = PS.PostalCityID
	INNER JOIN Application.StateProvinces AS ASP ON ASP.StateProvinceID = AC.StateProvinceID
WHERE PSC.SupplierCategoryName = 'Novelty Goods Supplier' AND PS.SupplierID NOT IN
(
	SELECT WSI.SupplierID
	FROM Warehouse.StockItems AS WSI
	WHERE WSI.SupplierID = PS.SupplierID
)
ORDER BY PS.SupplierName ASC

/* Problem 3 */
SELECT
	O.OrderID,
	O.OrderDate,
	SUM (OL.Quantity * OL.UnitPrice) AS [OrderTotal],
	(
		SELECT
			-- This is where the problems are
			DATEDIFF(DAY, MAX(O2.OrderDate), O.OrderDate)
		FROM Sales.Orders AS O2
		WHERE O.OrderID > O2.OrderID
			AND O2.CustomerID = 90
	) AS DaysSincePreviousOrder

FROM Sales.Orders AS O
	INNER JOIN Sales.OrderLines AS OL ON O.OrderID = OL.OrderID
WHERE O.CustomerID = 90
GROUP BY O.OrderID, O.OrderDate
ORDER BY O.OrderID ASC
	
/* Problem 4 */
SELECT
	C.CustomerID, C.CustomerName, DT.OrderCount, DT.Sales
FROM Sales.Customers AS C
	INNER JOIN 
	(
		SELECT 
			O.CustomerID, COUNT(DISTINCT (O.OrderID)) AS OrderCount, 
			SUM(OL.Quantity * OL.UnitPrice) AS Sales
		FROM Sales.Orders AS O
			INNER JOIN Sales.OrderLines AS OL ON O.OrderID = OL.OrderID
		WHERE YEAR(O.OrderDate) = 2015
		GROUP BY O.CustomerID
	) AS DT on C.CustomerID = DT.CustomerID
ORDER BY DT.Sales DESC, CustomerID;

/* Problem 5 */
WITH Orders2015 (CustomerID, OrderCount, Sales) AS 
(
		SELECT 
			O.CustomerID, COUNT(DISTINCT (O.OrderID)) AS OrderCount, 
			SUM(OL.Quantity * OL.UnitPrice) AS Sales
		FROM Sales.Orders AS O
			INNER JOIN Sales.OrderLines AS OL ON O.OrderID = OL.OrderID
		WHERE YEAR(O.OrderDate) = 2015
		GROUP BY O.CustomerID
)
SELECT
	C.CustomerID, C.CustomerName, CT.OrderCount, CT.Sales
FROM Sales.Customers AS C
	INNER JOIN Orders2015 AS CT ON C.CustomerID = CT.CustomerID
ORDER BY CT.Sales DESC, CustomerID