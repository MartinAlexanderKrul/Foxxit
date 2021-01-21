using Foxxit.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.DTO
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items, int count, int currentPage, int pageSize, SortMethod sortMethod)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            SortMethod = sortMethod;

            this.AddRange(items);
        }

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public SortMethod SortMethod { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return CurrentPage > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return CurrentPage < TotalPages;
            }
        }

        // the following async method is used instead of a constructor which cannot run async code
        public static async Task<PaginatedList<T>> CreateAsync(IEnumerable<T> source, int currentPage, SortMethod sortMethod)
        {
            int pageSize = 10;
            var count = source.Count();
            var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, currentPage, pageSize, sortMethod);
        }
    }
}