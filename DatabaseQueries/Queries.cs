namespace Database
{
    public class Queries
	{
		// Write a query that will produce a reverse-sorted list (alphabetically by name) of customers (first and last names) whose last name begins with the letter 'S'
		string query1 =
			@"
				SELECT LastName
						,FirstName
				FROM Customer
				WHERE LastName LIKE 'S%'
				ORDER BY LastName DESC, FirstName DESC;
			";

		// Write a SQL query that will show the total value of all orders each customer has placed in the past six months. 
		// Any customer wihtout any orders should show a $0 value.
		string query2 =
			@"
			  SELECT LastName
					,FirstName
					,cust.ID AS Customer_ID
					,SUM(ordline.Total) AS Total_Orders_Amount
			  FROM Customer AS cust
			  LEFT JOIN[Order] AS ord
				ON ord.CustomerID = Cust.ID
			  LEFT JOIN (SELECT ISNULL(Cost, 0) * ISNULL(Quantity, 0) AS Total
							,ID as OrderID
						 FROM OrderLine) AS ordline
				ON ord.ID = ordline.OrderID
			  WHERE ord.OrderDate <= GETDATE()
				AND ord.OrderDate >= DATEADD(month, -6, GETDATE())
			  GROUP BY Customer_ID
			";

		// Amend the query from the previous question to only show those customers who have a total order value of more than $100 and less that $500
		// in the past six months.
		string query3 =
			@"
			  SELECT LastName
					,FirstName
					,cust.ID AS Customer_ID
					,SUM(ordline.Total) as CustomerTotal
			  FROM Customer AS cust
			  LEFT JOIN [Order] AS ord
				ON ord.CustomerID = Cust.ID
			  LEFT JOIN (SELECT ISNULL(Cost, 0) * ISNULL(Quantity, 0) as Total
						      , OrdID as OrderID
						 FROM OrderLine) AS ordline
				ON ord.ID = ordline.OrderID
			  WHERE ord.OrderDate <= GETDATE()
				AND ord.OrderDate >= DATEADD(month, -6, GETDATE())
				AND ordline.Total > 100.00
				AND ordline.Total < 500.00
			  GROUP BY Customer_ID
			";
	}
}
