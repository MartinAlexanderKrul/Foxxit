using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
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
        public async Task<IActionResult> Vote(int value, int postBaseId)
        {
            var currentUser = GetActiveUserAsync();
            var existingVote = VoteService.GetVoteValue(currentUser.Id, postBaseId);

            if (existingVote == 0 || existingVote != value)
            {
                VoteService.AddNewVote(currentUser.Id, postBaseId, value);
            }

            return await VotesInfo(postBaseId);
        }

        [HttpGet("votesInfo")]
        public async Task<IActionResult> VotesInfo(int postBaseId)
        {
            var currentUser = await GetActiveUserAsync();
            var voteValue = VoteService.GetVoteValue(currentUser.Id, postBaseId);
            var votesCount = VoteService.GetVotesCount(postBaseId);

            var model = new VoteViewModel() { Value = voteValue, Count = votesCount };

            return View(model);
        }
    }
}
