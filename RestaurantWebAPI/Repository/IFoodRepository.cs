using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFood();
        Task<Food> GetFoodById(int foodId);
        Task<Food> AddFood(Food food);
        Task<Food> UpdateFood(Food food);
        Task DeleteFood(int foodId);
    }
}
