using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext appDbContext;
        public FoodRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Food> AddFood(Food food)
        {
            var result = await appDbContext.Foods.AddAsync(food);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteFood(int foodId)
        {
            var result = await appDbContext.Foods
                .FirstOrDefaultAsync(e => e.Id == foodId);

            if (result != null)
            {
                appDbContext.Foods.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Food>> GetFood()
        {
            return await appDbContext.Foods.ToListAsync();
        }

        public async Task<Food> GetFoodById(int foodId)
        {
            return await appDbContext.Foods
                .FirstOrDefaultAsync(e => e.Id == foodId);
        }

        public async Task<Food> UpdateFood(Food food)
        {
            var result = await appDbContext.Foods
               .FirstOrDefaultAsync(e => e.Id == food.Id);

            if (result != null)
            {
                result.Nama = food.Nama;
                result.Harga = food.Harga;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
