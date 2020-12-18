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

        IEnumerable<SubReddit> Filter(Func<SubReddit, bool> condition);

        Task<SubReddit> GetByIdAsync(long id);
        Task<bool> IsExisting(string name);
        IEnumerable<SubReddit> GetUnApproved();

        void Save();

        void Update(SubReddit entity);
    }
}