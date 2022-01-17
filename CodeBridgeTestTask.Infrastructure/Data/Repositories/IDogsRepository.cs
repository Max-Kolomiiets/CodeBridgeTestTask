﻿using CodeBridgeTestTask.Core.Entities;
using CodeBridgeTestTask.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.Infrastructure.Data.Repositories
{
    public interface IDogsRepository
    {
        Task<IList<Dog>> GetDogsAsync(SortingParams sortingParams, PagingParams pagingParams);
        Task<Dog> GetDogAsync(int id);
        Task AddDogAsync(Dog dog);
        Task<int> SaveChangesAsync();
    }
}