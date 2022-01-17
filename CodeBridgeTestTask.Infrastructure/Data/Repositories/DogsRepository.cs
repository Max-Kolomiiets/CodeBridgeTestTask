using CodeBridgeTestTask.Core.Entities;
using CodeBridgeTestTask.DAL.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.Infrastructure.Data.Repositories
{
    public class DogsRepository : IDogsRepository
    {
        private AppDbContext _ctx;
        public DogsRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddDogAsync(Dog dog)
        {
            if (dog != null)
            {
                await _ctx.Dogs.AddAsync(dog);
            }
        }

        public async Task<bool> IsExists(string name)
        {
            return await _ctx.Dogs.AnyAsync(p => p.Name == name);
        }

        public async Task<Dog> GetDogAsync(int id)
        {
            return await _ctx.Dogs.FindAsync(id);
        }

        public async Task<PagedList<Dog>> GetDogsAsync(SortingParams sortingParams, PagingParams pagingParams)
        {
            IQueryable<Dog> dogs = _ctx.Dogs;

            if (sortingParams?.Attribute != null)
                dogs = sortBy(dogs, sortingParams.Attribute, sortingParams.Order);

            return await PagedList<Dog>.ToPagedList(dogs, pagingParams.PageNumber, pagingParams?.PageSize);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }

        private IQueryable<Dog> sortBy(IQueryable<Dog> dogs, string attribute, string order)
        {
            switch (attribute)
            {
                case "name":
                    if (order == "asc")
                        dogs = dogs.OrderBy(p => p.Name);
                    else if (order == "desc")
                        dogs = dogs.OrderByDescending(p => p.Name);
                    break;
                case "color":
                    if (order == "asc")
                        dogs = dogs.OrderBy(p => p.Color);
                    else if (order == "desc")
                        dogs = dogs.OrderByDescending(p => p.Color);
                    break;

                case "tail_length":
                    if (order == "asc")
                        dogs = dogs.OrderBy(p => p.TailLength);
                    else if (order == "desc")
                        dogs = dogs.OrderByDescending(p => p.TailLength);
                    break;

                case "weight":
                    if (order == "asc")
                        dogs = dogs.OrderBy(p => p.Weight);
                    else if (order == "desc")
                        dogs = dogs.OrderByDescending(p => p.Weight);
                    break;
            }
            return dogs;
        }
    }
}
