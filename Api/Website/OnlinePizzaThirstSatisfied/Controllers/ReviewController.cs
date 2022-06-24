using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaThirstSatisfied.Data;
using OnlinePizzaThirstSatisfied.Models;
using OnlinePizzaThirstSatisfied;

namespace OnlinePizzaThirstSatisfied.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public ReviewController(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllReview()
        {
            var review = await _pizzaDbContext.UserReviews.ToListAsync();
            return Ok(review);
        }

        [HttpGet]
        [Route("UserReviews")]

        public async Task<IActionResult> GetReviewByUserName(string Username)
        {
            var review = await _pizzaDbContext.UserReviews.FirstOrDefaultAsync(x => x.UserName == Username);


            return Ok(review);
        }

        [HttpPost]
        //add a pizza
        public async Task<IActionResult> AddReview(UserReviews ur)
        {
            await _pizzaDbContext.UserReviews.AddAsync(ur);
            await _pizzaDbContext.SaveChangesAsync();
            var review = await _pizzaDbContext.UserReviews.ToListAsync();

            return Ok(review);
        }

        [HttpPost("{Id:int}")]
        //update the review by id
        public async Task<IActionResult> UpdateById([FromRoute] int Id, [FromBody] UserReviews ur)
        {
            var review = await _pizzaDbContext.UserReviews.FirstOrDefaultAsync(x => x.Id == Id);

            if (review != null)
            {
                review.pName = ur.pName;
                review.UserName = ur.UserName;
                review.Ratings = ur.Ratings;

                await _pizzaDbContext.SaveChangesAsync();
                return Ok(review);
            }
            else
            {
                return BadRequest("Review not found");
            }
        }
            [HttpPost("{UserName}")]
            //update the review by UserName
            public async Task<IActionResult> UpdateByUserName([FromRoute] string UserName, [FromBody] UserReviews ur)
            {
                var review = await _pizzaDbContext.UserReviews.FirstOrDefaultAsync(x => x.UserName == UserName);

                if (review != null)
                {
                    review.pName = ur.pName;
                    review.UserName = ur.UserName;
                    review.Ratings = ur.Ratings;

                    await _pizzaDbContext.SaveChangesAsync();
                    return Ok(review);
                }
                else
                {
                    return BadRequest("Review not found");
                }



            }
            [HttpDelete]
        [Route(("{Id:int}"))]
        public async Task<IActionResult> DeleteById(int Id)
        {
            var review = await _pizzaDbContext.UserReviews.FirstOrDefaultAsync(x => x.Id == Id);

            _pizzaDbContext.UserReviews.Remove(review);
            await _pizzaDbContext.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpDelete]
        [Route("{UserName}")]
        public async Task<IActionResult> DeleteByUserName(string UserName)
        {
            var review = await _pizzaDbContext.UserReviews.FirstOrDefaultAsync(x => x.UserName == UserName);

            _pizzaDbContext.UserReviews.Remove(review);
            await _pizzaDbContext.SaveChangesAsync();
            return Ok("Deleted");
        }

    }
}
