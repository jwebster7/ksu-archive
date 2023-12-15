use WideWorldImporters

/* Question 1 */
SELECT
	YEAR(O.OrderDate) AS [OrderYear], 
	CC.CustomerCategoryName AS [CustomerCategoryName],
	COUNT(DISTINCT (C.CustomerID)) AS [CustomerCount], 
	COUNT(DISTINCT (O.OrderID)) AS [OrderCount],
	ISNULL(SUM(OL.Quantity * OL.UnitPrice), 0.00) AS [Sales],
	ISNULL(SUM(OL.Quantity * OL.UnitPrice), 0.00)/ COUNT(DISTINCT (O.CustomerID)) AS [AverageSalesPerCustomer]
FROM Sales.Orders AS O
	INNER JOIN Sales.Customers AS C ON C.CustomerID = O.CustomerID
	INNER JOIN Sales.CustomerCategories AS CC ON CC.CustomerCategoryID = C.CustomerCategoryID
	INNER JOIN Sales.OrderLines AS OL ON OL.OrderID = O.OrderID
GROUP BY YEAR(O.OrderDate), CC.CustomerCategoryName
ORDER BY OrderYear, CC.CustomerCategoryName

/* Question 2 */
SELECT 
	C.CustomerID, C.CustomerName, 
	SUM(CASE WHEN YEAR(O.OrderDate) = 2014 THEN OL1.Quantity * OL1.UnitPrice ELSE 0 END) AS [2014Sales],
	SUM(CASE WHEN YEAR(O.OrderDate) = 2015 THEN OL1.Quantity * OL1.UnitPrice ELSE 0 END) AS [2015Sales],
	SUM(OL1.Quantity * OL1.UnitPrice) AS [TotalSales]
FROM Sales.Customers AS C
	INNER JOIN Sales.Orders AS O ON O.CustomerID = C.CustomerID AND O.OrderDate BETWEEN '2014-01-01' AND '2015-12-31'
	INNER JOIN Sales.OrderLines AS OL1 ON OL1.OrderID = O.OrderID
--WHERE YEAR(O.OrderDate) = 2014 OR YEAR(O.Orderdate) = 2015
GROUP BY C.CustomerID, C.CustomerName 
ORDER BY TotalSales DESC, CustomerID ASC

/* Question 3 */
SELECT
	S.SupplierID,
	S.SupplierName,
	COUNT(O.OrderID) AS [OrderCount],
	ISNULL(SUM(OL.Quantity * OL.UnitPrice), 0.00) AS [Sales]
FROM Sales.Orders AS O
	INNER JOIN Sales.OrderLines as OL on OL.OrderID = O.OrderID AND YEAR(O.OrderDate) = 2015
	INNER JOIN Warehouse.StockItems AS SI on SI.StockItemID = OL.StockItemID
	RIGHT JOIN Purchasing.Suppliers AS S ON S.SupplierID = SI.SupplierID
GROUP BY S.SupplierID, S.SupplierName
ORDER BY Sales DESC, OrderCount DESC, S.SupplierName
