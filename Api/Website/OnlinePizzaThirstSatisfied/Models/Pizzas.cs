using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaThirstSatisfied.Models
{
    public class Pizzas

    {
       
        [Required(ErrorMessage ="Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage ="PizzaName is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Size is required")]


        public string Description { get; set; }
        [Required(ErrorMessage = "Size is required")]

        public string Size  { get; set; }

        [Required(ErrorMessage ="Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage ="Price is required")]
        public int price { get; set; }
        [Required(ErrorMessage = "stock is required")]
        public int stockAvailable { get; set; }








    }
}
