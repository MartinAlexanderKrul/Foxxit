using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class VoteController : MainController
    {
        public VoteController(UserManager<User> userManager, SignInManager<User> signInManager, IVoteService voteService)
            : base(userManager, signInManager)
        {
            VoteService = voteService;
        }

        public IVoteService VoteService { get; set; }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote(int voteType, int postBaseId)
        {
            var currentUser = GetActiveUserAsync();
            var vote = new Vote() { Value = voteType, PostBaseId = postBaseId, OwnerId = currentUser.Id };

            var existingVotes = VoteService.GetVoteValue(currentUser.Id, postBaseId);

            if (existingVotes == 0 || existingVotes != voteType)
            {
                await VoteService.AddAsync(vote);
                await VoteService.SaveAsync();
            }

            return RedirectToAction();
        }
    }
}
