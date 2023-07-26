using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_LinQ_Demo
{
    public class Management
    {
        DataTable dataTable = new DataTable();
        //UC-2
        public void TopRecord(List<ProductReview> products)
        {
            var record = (from product in products orderby product.Review descending select product).Take(3);
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-------------------------------");
            foreach (var prod in record)
            {
                Console.WriteLine(prod.ProductID + "  " + prod.UserID + "  " + prod.Rating + "  " + prod.Review + "  " + prod.IsLike);

            }
            var result = products.OrderByDescending(x => x.Rating).Take(3);
            Console.WriteLine("Using lambda");
            Console.WriteLine("-------------------------------");
            foreach (var prod in result)
            {
                Console.WriteLine(prod.ProductID + "  " + prod.UserID + "  " + prod.Rating + "  " + prod.Review + "  " + prod.IsLike);

            }


        }
        //UC-3
        public void ProductRating(List<ProductReview> products)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Using lambda");
            Console.WriteLine("-------------------------------");
            var result = products.Where(x => x.Rating > 3 && (x.ProductID == 1 || x.ProductID == 4 || x.ProductID == 9));
            Display(result);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-------------------------------");
            var record = from product in products where (product.ProductID == 1 || product.ProductID == 4 || product.ProductID == 9) && product.Rating > 3 select product;
            foreach (var prod in record)
            {
                Console.WriteLine(prod.ProductID + "  " + prod.UserID + "  " + prod.Rating + "  " + prod.Review + "  " + prod.IsLike);

            }

        }
        public void Display(IEnumerable<ProductReview> satya)
        {
            foreach (var prod in satya)
            {
                Console.WriteLine(prod.ProductID + "  " + prod.UserID + "  " + prod.Rating + "  " + prod.Review + "  " + prod.IsLike);

            }

        }
        //UC-4 - Retrieve count of review present for each productID
        public void CountProduct(List<ProductReview> products)
        {
            var record = products.GroupBy(x => x.ProductID).Select(x => new { ProductId = x.Key, Count = x.Count() });
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-----------------------------");
            foreach (var prod in record)
            {
                Console.WriteLine(prod.ProductId + "  " + prod.Count);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-----------------------------");
            var result = products.GroupBy(x => x.ProductID);
            foreach (var product in result)
            {
                Console.WriteLine(product.Key + " " + product.Count());
            }

        }
        //UC-5
        public void ProductId_Review(List<ProductReview> products)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-----------------------------");
            var result = products.Select(x => new { x.ProductID, x.Review });

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductID + "  " + product.Review);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-----------------------------");
            var record = from product in products select new { product.ProductID, product.Review };
            foreach (var product in record)
            {
                Console.WriteLine(product.ProductID + "  " + product.Review);
            }

        }
        //UC-6
        public void SkipTop_Record(List<ProductReview> products)
        {
            var records = (from product in products select product).Skip(5);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-----------------------------");
            foreach (var prod in records)
            {
                Console.WriteLine(prod.ProductID + "  " + prod.UserID + "  " + prod.Rating + "  " + prod.Review + "  " + prod.IsLike);
            }
            // Display(records);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-----------------------------");
            var result = products.OrderByDescending(x => x.Rating).Skip(5);
            Display(result);

        }
        //UC-7 - Retrieve only productId and review from the list for all records using LINQ select operator.
        public void ProductId_ReviewUsing_Select(List<ProductReview> products)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-----------------------------");
            var result = products.Select(x => new { x.ProductID, x.Review });

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductID + "  " + product.Review);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-----------------------------");
            var record = from product in products select new { product.ProductID, product.Review };
            foreach (var product in record)
            {
                Console.WriteLine(product.ProductID + "  " + product.Review);
            }
        }
        //UC-8
        public void AddToDataTable(List<ProductReview> product)
        {
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Rating", typeof(int));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("IsLike", typeof(bool));

           
            foreach (var data in product)
            {
                dataTable.Rows.Add(data.ProductID, data.UserID, data.Rating, data.Review, data.IsLike);

            }

        }
        //UC-9
        public void RetriveDataFrom_DataTable()
        {
            
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-------------------------------------");
            var ser = from p in dataTable.AsEnumerable()
                      where (bool)p["IsLike"] == Convert.ToBoolean(true)
                      select p;
            foreach (var emp in ser)
            {
                Console.WriteLine("ProductID ={0} , UserID = {1} , Rating = {2} , Review = {3} ,IsLike = {4} ", emp["ProductID"], emp["UserID"], emp["Rating"], emp["Review"], emp["IsLike"]);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-------------------------------------");
            var result = dataTable.AsEnumerable().Where(x => (bool)x["IsLike"]==Convert.ToBoolean(true));
            foreach (var emp in result)
            {
                Console.WriteLine("ProductID ={0} , UserID = {1} , Rating = {2} , Review = {3} ,IsLike = {4} ", emp["ProductID"], emp["UserID"], emp["Rating"], emp["Review"], emp["IsLike"]);
            }

        }
        public void Display()
        {
            //Display certain Column
            Console.WriteLine("-------------------------------------");

            foreach (DataRow rows in dataTable.Rows)
            {
                Console.WriteLine("ProductID = {0} ", rows["ProductID"]);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------------------------------------");
            foreach (DataRow emp in dataTable.Rows)
            {
                Console.WriteLine("ProductID ={0} , UserID = {1} , Rating = {2} , Review = {3} ,IsLike = {4} ", emp["ProductID"], emp["UserID"], emp["Rating"], emp["Review"], emp["IsLike"]);
            }

        }
        //UC-10
        public void Average_Rating()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-------------------------------------");
            var result = from product in dataTable.AsEnumerable() where product["Review"].Equals("Average") select product;
            foreach (var emp in result)
            {
                Console.WriteLine("ProductID ={0}, Rating = {1} ", emp["ProductID"], emp["Rating"]);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-------------------------------------");
            var value = dataTable.AsEnumerable().Where(x => x["Review"].Equals("Average"));
            foreach (var emp in value)
            {
                Console.WriteLine("ProductID ={0}, Rating = {1} ", emp["ProductID"], emp["Rating"]);
            }
        }
        //UC11
        public void Review_Nice()
        {

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-------------------------------------");
            var result = from product in dataTable.AsEnumerable() where product["Review"].Equals("Nice") select product;
            foreach (var emp in result)
            {
                Console.WriteLine("ProductID ={0} , UserID = {1} , Rating = {2} , Review = {3} ,IsLike = {4} ", emp["ProductID"], emp["UserID"], emp["Rating"], emp["Review"], emp["IsLike"]);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-------------------------------------");
            var val = dataTable.AsEnumerable().Where(x => x["Review"].Equals("Nice"));
            foreach (var emp in val)
            {
                Console.WriteLine("ProductID ={0} , UserID = {1} , Rating = {2} , Review = {3} ,IsLike = {4} ", emp["ProductID"], emp["UserID"], emp["Rating"], emp["Review"], emp["IsLike"]);
            }
        }
        //UC12
        public void  ProductID_RatingOrderBy()
        {
          
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using LinQ");
            Console.WriteLine("-------------------------------------");
            var result = from product in dataTable.AsEnumerable() orderby product["Rating"] where product["ProductID"].Equals(10) select product;
            foreach (var emp in result)
            {
                Console.WriteLine("ProductID ={0} , UserID = {1} , Rating = {2} , Review = {3} ,IsLike = {4} ", emp["ProductID"], emp["UserID"], emp["Rating"], emp["Review"], emp["IsLike"]);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Using Lambda");
            Console.WriteLine("-------------------------------------");
            var val = dataTable.AsEnumerable().OrderBy(x => x["Rating"]).Where(x => x["ProductID"].Equals(10));
            foreach (var emp in val)
            {
                Console.WriteLine("ProductID ={0} , UserID = {1} , Rating = {2} , Review = {3} ,IsLike = {4} ", emp["ProductID"], emp["UserID"], emp["Rating"], emp["Review"], emp["IsLike"]);
            }
        }
    }
}
