using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaThirstSatisfied.Data;
using OnlinePizzaThirstSatisfied.Models;
using OnlinePizzaThirstSatisfied;

namespace OnlinePizzaThirstSatisfied.Controllers

{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public PizzasController(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var pizzas = await _pizzaDbContext.Pizzas.ToListAsync();
            return Ok(pizzas);
        }
        /*
       [HttpGet("{Id}")]
        //get pizza by id

       public async Task<IActionResult> GetById(int Id)
        {
          var pizza = await _pizzaDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == Id);

            return Ok(pizza);
        }

        */



        [HttpGet]
        [Route("Pizzas")]

        public async Task<IActionResult> GetByName(string name)
        {
            var pizza = await _pizzaDbContext.Pizzas.FirstOrDefaultAsync(x => x.Name == name);

            return Ok(pizza);
        }

        [HttpPost]
        //add a pizza
        public async Task<IActionResult> AddPizza(Pizzas p)
        {
            await _pizzaDbContext.Pizzas.AddAsync(p);
            await _pizzaDbContext.SaveChangesAsync();
            var pizzas = await _pizzaDbContext.Pizzas.ToListAsync();

            return Ok(pizzas);
        }

        [HttpPost("{Id:int}")]
        public async Task<IActionResult> UpdateById([FromRoute] int Id,[FromBody]Pizzas e)
        {
            var pizza = await _pizzaDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == Id);

            if (pizza != null)
            {
                pizza.Name = e.Name;
                pizza.Size = e.Size;
                pizza.Description = e.Description;
                pizza.Type = e.Type;
                pizza.price = e.price;
                pizza.stockAvailable = e.stockAvailable;
                await _pizzaDbContext.SaveChangesAsync();
                return Ok(pizza);
            }
            else
            {
                return BadRequest("Pizza not found");
            }

            
        }


        [HttpDelete]
        [Route(("{Id:int}"))]
        public async Task<IActionResult> DeleteById(int Id)
        {
            var pizza = await _pizzaDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == Id);

            _pizzaDbContext.Pizzas.Remove(pizza);
            await _pizzaDbContext.SaveChangesAsync();
            return Ok("Deleted");
        }
























    }
}
