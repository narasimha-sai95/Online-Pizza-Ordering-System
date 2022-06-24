using System.ComponentModel.DataAnnotations;
using OnlinePizzaThirstSatisfied.Data;
namespace OnlinePizzaThirstSatisfied.Models
{
    public class UserReviews
    {
        
        public int Id { get; set; }
        
        public string UserName {get; set;} 
        public string pName { get; set; } 

        public int Ratings { get; set; }


       

    }
}
