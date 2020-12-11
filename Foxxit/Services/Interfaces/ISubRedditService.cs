using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Services
{
    public interface ISubRedditService
    {
        void Add(SubReddit entity);

        void Delete(SubReddit entity);

        Task<IEnumerable<SubReddit>> GetAllAsync();

        Task<IEnumerable<SubReddit>> Filter(Func<SubReddit, bool> condition);

        Task<SubReddit> GetByIdAsync(long id);

        void Save();

        void Update(SubReddit entity);
    }
}