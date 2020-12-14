using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services
{
    public class SubRedditService : ISubRedditService
    {
        public SubRedditService(SubRedditRepository subRedditRepository)
        {
            SubRedditRepository = subRedditRepository;
        }

        public SubRedditRepository SubRedditRepository { get; private set; }

        public async Task<IEnumerable<SubReddit>> GetAllAsync()
        {
            return await SubRedditRepository.GetAllAsync();
        }

        public IEnumerable<SubReddit> Filter(Func<SubReddit, bool> condition)
        {
            return SubRedditRepository.Filter(condition);
        }

        public async Task<SubReddit> GetByIdAsync(long id)
        {
            return await SubRedditRepository.GetByIdAsync(id);
        }

        public void Add(SubReddit entity)
        {
            SubRedditRepository.AddAsync(entity);
        }

        public void Update(SubReddit entity)
        {
            SubRedditRepository.Update(entity);
        }

        public void Delete(SubReddit entity)
        {
            SubRedditRepository.Delete(entity);
        }

        public void Save()
        {
            SubRedditRepository.SaveAsync();
        }
    }
}