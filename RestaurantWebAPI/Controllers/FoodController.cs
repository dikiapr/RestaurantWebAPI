using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.Models;
using RestaurantWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository foodRepository;

        public FoodController(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetFood()
        {
            try
            {
                return Ok(await foodRepository.GetFood());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Food>> CreateFood(Food food)
        {
            try
            {
                if (food == null)
                    return BadRequest();

                var createdFood = await foodRepository.AddFood(food);

                return CreatedAtAction(nameof(GetFood),
                    new { id = createdFood.Id }, createdFood);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new food record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Food>> UpdateFood(int id, Food food)
        {
            try
            {
                if (id != food.Id)
                    return BadRequest("Food ID mismatch");

                var foodToUpdate = await foodRepository.GetFoodById(id);

                if (foodToUpdate == null)
                {
                    return NotFound($"Food with Id = {id} not found");
                }

                return await foodRepository.UpdateFood(food);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating food record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFood(int id)
        {
            try
            {
                var foodToDelete = await foodRepository.GetFoodById(id);

                if (foodToDelete == null)
                {
                    return NotFound($"Food with Id = {id} not found");
                }

                await foodRepository.DeleteFood(id);

                return Ok($"Food with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting food record");
            }
        }
    }
}
