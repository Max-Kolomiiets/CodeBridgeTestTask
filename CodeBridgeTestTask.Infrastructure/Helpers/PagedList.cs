using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.DAL.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int? PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList(List<T> items, int count, int pageNumber, int? pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int? pageSize)
        {
            var count = source.Count();
            if (pageSize != null)
            {
                var items =
                     await source.Skip((pageNumber - 1) * pageSize.Value)
                     .Take(pageSize.Value).ToListAsync();
                return new PagedList<T>(items, count, pageNumber, pageSize.Value);
            }
            return new PagedList<T>(await source.ToListAsync(), count, pageNumber, count);
        }
    }
}
