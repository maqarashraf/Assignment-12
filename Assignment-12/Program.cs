namespace Assignment_12
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using global::ASSLINQ;
    using System.Linq;

    namespace ASSLINQ
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // =========================================================
                // LINQ - Element Operators
                // =========================================================

                // ================= QUESTION 1 =================
                // Get the first Product out of Stock

                var q1 = ListGenerators.ProductList
                    .First(p => p.UnitsInStock == 0);

                Console.WriteLine("Element Operators - Q1");
                Console.WriteLine(q1);


                // ================= QUESTION 2 =================
                // Return the first product whose Price > 1000,
                // otherwise return null

                var q2 = ListGenerators.ProductList    

                    .FirstOrDefault(p => p.UnitPrice > 1000);

                Console.WriteLine("\nElement Operators - Q2");
                Console.WriteLine(q2);


                // ================= QUESTION 3 =================
                // Retrieve the second number greater than 5

                int[] Arr1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                var q3 = Arr1
                    .Where(n => n > 5)
                    .Skip(1)
                    .First();

                Console.WriteLine("\nElement Operators - Q3");
                Console.WriteLine(q3);


                // =========================================================
                // LINQ - Aggregate Operators
                // =========================================================

                // ================= QUESTION 1 =================
                // Get the number of odd numbers in the array

                int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                int q4 = Arr2.Count(n => n % 2 != 0);

                Console.WriteLine("\nAggregate Operators - Q1");
                Console.WriteLine(q4);


                // ================= QUESTION 2 =================
                // Return a list of customers and how many orders each has

                var q5 = ListGenerators.CustomerList
                    .Select(c => new
                    {
                        CustomerName = c.CustomerName,
                        OrdersCount = c.Orders.Count()
                    });

                Console.WriteLine("\nAggregate Operators - Q2");

                foreach (var item in q5)
                {
                    Console.WriteLine(
                        $"{item.CustomerName} -> {item.OrdersCount}");
                }


                // ================= QUESTION 3 =================
                // Return a list of categories and how many products each has

                var q6 = ListGenerators.ProductList
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        ProductsCount = g.Count()
                    });

                Console.WriteLine("\nAggregate Operators - Q3");

                foreach (var item in q6)
                {
                    Console.WriteLine(
                        $"{item.Category} -> {item.ProductsCount}");
                }


                // ================= QUESTION 4 =================
                // Get the total of the numbers in an array

                int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                int q7 = Arr3.Sum();

                Console.WriteLine("\nAggregate Operators - Q4");
                Console.WriteLine(q7);


                // ================= QUESTION 5 =================
                // Get the total number of characters
                // in dictionary_english.txt

                string[] words = File.ReadAllLines("dictionary_english.txt");

                int q8 = words.Sum(w => w.Length);

                Console.WriteLine("\nAggregate Operators - Q5");
                Console.WriteLine(q8);


                // ================= QUESTION 6 =================
                // Get the length of the shortest word

                int q9 = words.Min(w => w.Length);

                Console.WriteLine("\nAggregate Operators - Q6");
                Console.WriteLine(q9);


                // ================= QUESTION 7 =================
                // Get the length of the longest word

                int q10 = words.Max(w => w.Length);

                Console.WriteLine("\nAggregate Operators - Q7");
                Console.WriteLine(q10);


                // ================= QUESTION 8 =================
                // Get the average length of the words

                double q11 = words.Average(w => w.Length);

                Console.WriteLine("\nAggregate Operators - Q8");
                Console.WriteLine(q11);


                // ================= QUESTION 9 =================
                // Get the total units in stock for each product category

                var q12 = ListGenerators.ProductList
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        TotalUnits = g.Sum(p => p.UnitsInStock)
                    });

                Console.WriteLine("\nAggregate Operators - Q9");

                foreach (var item in q12)
                {
                    Console.WriteLine(
                        $"{item.Category} -> {item.TotalUnits}");
                }


                // ================= QUESTION 10 =================
                // Get the cheapest price among each category's products

                var q13 = ListGenerators.ProductList
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        CheapestPrice = g.Min(p => p.UnitPrice)
                    });

                Console.WriteLine("\nAggregate Operators - Q10");

                foreach (var item in q13)
                {
                    Console.WriteLine(
                        $"{item.Category} -> {item.CheapestPrice}");
                }


                // ================= QUESTION 11 =================
                // Get the products with the lowest price in each category
                // Use LET

                var q14 =
                    from p in ListGenerators.ProductList
                    group p by p.Category into g
                    let minPrice = g.Min(p => p.UnitPrice)
                    from p in g
                    where p.UnitPrice == minPrice
                    select new
                    {
                        Category = g.Key,
                        ProductName = p.ProductName,
                        Price = p.UnitPrice
                    };

                Console.WriteLine("\nAggregate Operators - Q11");

                foreach (var item in q14)
                {
                    Console.WriteLine(
                        $"{item.Category} -> {item.ProductName} -> {item.Price}");
                }


                // ================= QUESTION 12 =================
                // Get the highest price among each category's products

                var q15 = ListGenerators.ProductList
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        HighestPrice = g.Max(p => p.UnitPrice)
                    });

                Console.WriteLine("\nAggregate Operators - Q12");

                foreach (var item in q15)
                {
                    Console.WriteLine(
                        $"{item.Category} -> {item.HighestPrice}");
                }


                // ================= QUESTION 13 =================
                // Get the products with the highest price in each category

                var q16 =
                    from p in ListGenerators.ProductList
                    group p by p.Category into g
                    let maxPrice = g.Max(p => p.UnitPrice)
                    from p in g
                    where p.UnitPrice == maxPrice
                    select new
                    {
                        Category = g.Key,
                        ProductName = p.ProductName,
                        Price = p.UnitPrice
                    };

                Console.WriteLine("\nAggregate Operators - Q13");

                foreach (var item in q16)
                {
                    Console.WriteLine(
                        $"{item.Category} -> {item.ProductName} -> {item.Price}");
                }


                // ================= QUESTION 14 =================
                // Get the average price of each category's products

                var q17 = ListGenerators.ProductList
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        AveragePrice = g.Average(p => p.UnitPrice)
                    });

                Console.WriteLine("\nAggregate Operators - Q14");

                foreach (var item in q17)
                {
                    Console.WriteLine(
                        $"{item.Category} -> {item.AveragePrice:F2}");
                }


                // =========================================================
                // LINQ - Set Operators
                // =========================================================

                // ================= QUESTION 1 =================
                // Find the unique Category names from Product List

                var q18 = ListGenerators.ProductList
                    .Select(p => p.Category)
                    .Distinct();

                Console.WriteLine("\nSet Operators - Q1");

                foreach (var category in q18)
                {
                    Console.WriteLine(category);
                }


                // ================= QUESTION 2 =================
                // Unique first letter from product and customer names

                var productLetters = ListGenerators.ProductList
                    .Select(p => p.ProductName[0]);

                var customerLetters = ListGenerators.CustomerList
                    .Select(c => c.CustomerName[0]);

                var q19 = productLetters
                    .Union(customerLetters);

                Console.WriteLine("\nSet Operators - Q2");

                foreach (var letter in q19)
                {
                    Console.WriteLine(letter);
                }


                // ================= QUESTION 3 =================
                // Common first letter from product and customer names

                var q20 = productLetters
                    .Intersect(customerLetters);

                Console.WriteLine("\nSet Operators - Q3");

                foreach (var letter in q20)
                {
                    Console.WriteLine(letter);
                }


                // ================= QUESTION 4 =================
                // First letters of product names that are not
                // first letters of customer names

                var q21 = productLetters
                    .Except(customerLetters);

                Console.WriteLine("\nSet Operators - Q4");

                foreach (var letter in q21)
                {
                    Console.WriteLine(letter);
                }


                // ================= QUESTION 5 =================
                // Last Three Characters in each name of all customers
                // and products, including duplicates

                var productNames = ListGenerators.ProductList
                    .Select(p => p.ProductName);

                var customerNames = ListGenerators.CustomerList
                    .Select(c => c.CustomerName);

                var q22 = productNames
                    .Concat(customerNames)
                    .Select(name =>
                        name.Substring(name.Length - 3));

                Console.WriteLine("\nSet Operators - Q5");

                foreach (var item in q22)
                {
                    Console.WriteLine(item);
                }


                // =========================================================
                // LINQ - Partitioning Operators
                // =========================================================

                // ================= QUESTION 1 =================
                // Get the first 3 orders from customers in Washington

                var q23 = ListGenerators.CustomerList
                    .Where(c => c.City == "Washington")
                    .SelectMany(c => c.Orders)
                    .Take(3);

                Console.WriteLine("\nPartitioning Operators - Q1");

                foreach (var order in q23)
                {
                    Console.WriteLine(order);
                }


                // ================= QUESTION 2 =================
                // Get all but the first 2 orders from customers in Washington

                var q24 = ListGenerators.CustomerList
                    .Where(c => c.City == "Washington")
                    .SelectMany(c => c.Orders)
                    .Skip(2);

                Console.WriteLine("\nPartitioning Operators - Q2");

                foreach (var order in q24)
                {
                    Console.WriteLine(order);
                }


                // ================= QUESTION 3 =================
                // Return elements from beginning until a number
                // is less than its position

                int[] numbers1 =
                {
                5, 4, 1, 3, 9, 8, 6, 7, 2, 0
            };

                var q25 = numbers1
                    .TakeWhile((number, index) => number >= index);

                Console.WriteLine("\nPartitioning Operators - Q3");

                foreach (var number in q25)
                {
                    Console.WriteLine(number);
                }


                // ================= QUESTION 4 =================
                // Get elements starting from the first element
                // divisible by 3

                int[] numbers2 =
                {
                5, 4, 1, 3, 9, 8, 6, 7, 2, 0
            };

                var q26 = numbers2
                    .SkipWhile(number => number % 3 != 0);

                Console.WriteLine("\nPartitioning Operators - Q4");

                foreach (var number in q26)
                {
                    Console.WriteLine(number);
                }


                // ================= QUESTION 5 =================
                // Get elements starting from the first element
                // less than its position

                int[] numbers3 =
                {
                5, 4, 1, 3, 9, 8, 6, 7, 2, 0
            };

                var q27 = numbers3
                    .SkipWhile((number, index) => number >= index);

                Console.WriteLine("\nPartitioning Operators - Q5");

                foreach (var number in q27)
                {
                    Console.WriteLine(number);
                }


                // =========================================================
                // LINQ - Quantifiers
                // =========================================================

                // ================= QUESTION 1 =================
                // Determine if any words contain the substring "ei"

                bool q28 = words.Any(w => w.Contains("ei"));

                Console.WriteLine("\nQuantifiers - Q1");
                Console.WriteLine(q28);


                // ================= QUESTION 2 =================
                // Return grouped products only for categories
                // that have at least one product out of stock

                var q29 = ListGenerators.ProductList
                    .GroupBy(p => p.Category)
                    .Where(g => g.Any(p => p.UnitsInStock == 0));

                Console.WriteLine("\nQuantifiers - Q2");

                foreach (var group in q29)
                {
                    Console.WriteLine($"Category: {group.Key}");

                    foreach (var product in group)
                    {
                        Console.WriteLine(product.ProductName);
                    }

                    Console.WriteLine();
                }


                // ================= QUESTION 3 =================
                // Return grouped products only for categories
                // that have all products in stock

                var q30 = ListGenerators.ProductList
                    .GroupBy(p => p.Category)
                    .Where(g => g.All(p => p.UnitsInStock > 0));

                Console.WriteLine("\nQuantifiers - Q3");

                foreach (var group in q30)
                {
                    Console.WriteLine($"Category: {group.Key}");

                    foreach (var product in group)
                    {
                        Console.WriteLine(product.ProductName);
                    }

                    Console.WriteLine();
                }


                // =========================================================
                // LINQ - Grouping Operators
                // =========================================================

                // ================= QUESTION 1 =================
                // Group numbers by their remainder when divided by 5

                List<int> numbers = new List<int>
            {
                0, 1, 2, 3, 4,
                5, 6, 7, 8, 9,
                10, 11, 12, 13, 14, 15
            };

                var q31 = numbers
                    .GroupBy(n => n % 5);

                Console.WriteLine("\nGrouping Operators - Q1");

                foreach (var group in q31)
                {
                    Console.WriteLine(
                        $"Remainder {group.Key}:");

                    foreach (var number in group)
                    {
                        Console.WriteLine(number);
                    }

                    Console.WriteLine();
                }


                // ================= QUESTION 2 =================
                // Group dictionary words by their first letter

                var q32 = words
                    .GroupBy(w => w[0]);

                Console.WriteLine("\nGrouping Operators - Q2");

                foreach (var group in q32)
                {
                    Console.WriteLine(
                        $"Letter: {group.Key}");

                    foreach (var word in group)
                    {
                        Console.WriteLine(word);
                    }

                    Console.WriteLine();
                }


                // ================= QUESTION 3 =================
                // Group words with a custom comparer
                // Words that consist of the same characters together

                string[] Arr4 =
                {
                "from",
                "salt",
                "earn",
                "last",
                "near",
                "form"
            };

                var q33 = Arr4
                    .GroupBy(word => word, new CustomComparer());

                Console.WriteLine("\nGrouping Operators - Q3");

                foreach (var group in q33)
                {
                    Console.WriteLine(
                        string.Join(" , ", group));
                }


                Console.WriteLine("\n\n===== Assignment Finished =====");

                Console.ReadKey();
            }
        }


        // =========================================================
        // Custom Comparer
        // Used in Grouping Operators - Question 3
        // =========================================================

        class CustomComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                if (x == null || y == null)
                {
                    return x == y;
                }

                return string.Concat(
                    x.OrderBy(c => c))
                    ==
                    string.Concat(
                        y.OrderBy(c => c));
            }


            public int GetHashCode(string obj)
            {
                return string.Concat(
                    obj.OrderBy(c => c)
                ).GetHashCode();
            }
        }
    }

}
