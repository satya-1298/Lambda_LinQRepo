using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_LinQ_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();

            List<ProductReview> list = new List<ProductReview>()
            {
                new ProductReview(){ ProductID = 1,UserID = 1, Rating=5, Review="Average",IsLike=true},
                new ProductReview(){ ProductID = 2,UserID = 2, Rating=6, Review="Average",IsLike=true},
                new ProductReview(){ ProductID = 3,UserID = 3, Rating=3, Review="Bad",IsLike=false},
                new ProductReview(){ ProductID = 4,UserID = 4, Rating=8, Review="Good",IsLike=true},
                new ProductReview(){ ProductID = 5,UserID = 5, Rating=2, Review="Bad",IsLike=false},
                new ProductReview(){ ProductID = 6,UserID = 6, Rating=1, Review="Bad",IsLike=false},
                new ProductReview(){ ProductID = 7,UserID = 7, Rating=10, Review="VeryGood",IsLike=true},
                new ProductReview(){ ProductID = 8,UserID = 8, Rating=7, Review="Nice",IsLike=true},
                new ProductReview(){ ProductID = 9,UserID = 9, Rating=5, Review="Average",IsLike=false},
                new ProductReview(){ ProductID = 10,UserID = 10, Rating=4, Review="Average",IsLike=false},
                new ProductReview(){ ProductID = 11,UserID = 11, Rating=9, Review="Good",IsLike=true},
                new ProductReview(){ ProductID = 12,UserID = 12, Rating=1, Review="Bad",IsLike=false},
                new ProductReview(){ ProductID = 1,UserID = 13, Rating=3, Review="Bad",IsLike=false},
                new ProductReview(){ ProductID = 14,UserID = 14, Rating=9, Review="Good",IsLike=true},
                new ProductReview(){ ProductID = 15,UserID = 15, Rating=6, Review="Nice",IsLike=true},
                new ProductReview(){ ProductID = 16,UserID = 16, Rating=10, Review="VeryGood",IsLike=false},
                new ProductReview(){ ProductID = 17,UserID = 17, Rating=4, Review="Bad",IsLike=true},
                new ProductReview(){ ProductID = 18,UserID = 18, Rating=6, Review="Nice",IsLike=false},
                new ProductReview(){ ProductID = 19,UserID = 19, Rating=8, Review="Good",IsLike=false},
                new ProductReview(){ ProductID = 20,UserID = 20, Rating=2, Review="Bad",IsLike=true},
                new ProductReview(){ ProductID = 21,UserID = 21, Rating=1, Review="Bad",IsLike=false},
                new ProductReview(){ ProductID = 6,UserID = 22, Rating=9, Review="Good",IsLike=true},
                new ProductReview(){ ProductID = 4,UserID = 23, Rating=5, Review="Average",IsLike=false},
                new ProductReview(){ ProductID = 17,UserID = 24, Rating=10, Review="VeryGood",IsLike=false},
                new ProductReview(){ ProductID = 6,UserID = 25, Rating=6, Review="Nice",IsLike=false},

            };
            while (true)
            {
                Console.WriteLine("1-Top three ratings");
                Console.WriteLine("2-Top three Ratings by product Id");
                Console.WriteLine("Choose a option");
                int op=Convert.ToInt32(Console.ReadLine());
                switch(op) 
                {
                    case 1:
                        management.TopRecord(list);
                        break;
                    case 2:
                        management.ProductRating(list); 
                        break;

                }
            }



        }
    }
}
