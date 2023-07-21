using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_LinQ_Demo
{
    //lambda expression is used to create anonymous function ,expression and body member
    //It's a short block of code that accepts parameter and return a value
    //Use => - is a lambda operator which is used for all the lambda expressions.

    //LinQ- It's a language Integrated Query 
    //It is used for filtering ,sorting ,grouping
    //Mainly it is used for fetching the data from Xml document, database and collections
    public class ProductReview
    {
        //ProductID, UserID, Rating, Review and isLike fields
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }  
        public bool IsLike { get; set; }
    }
}
