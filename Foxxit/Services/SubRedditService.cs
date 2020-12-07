using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services
{
    public class SubRedditService
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

        public async Task<SubReddit> GetByIdAsync(long id)
        {
            return await SubRedditRepository.GetByIdAsync(id);
        }

        public void Add(SubReddit obj)
        {
            SubRedditRepository.AddAsync(obj);
        }

        public void Update(SubReddit obj)
        {
            SubRedditRepository.Update(obj);
        }

        public void Delete(SubReddit obj)
        {
            SubRedditRepository.Delete(obj);
        }

        public void Save()
        {
            SubRedditRepository.SaveAsync();
        }
    }
}