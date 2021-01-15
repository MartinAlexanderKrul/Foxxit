using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services.Interfaces;
using System.Threading.Tasks;
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

        [HttpPost("{value}/{postBaseId}")]
        public async Task<IActionResult> Vote([FromRoute]int value, [FromRoute]int postBaseId)
        {
            var currentUser = await GetActiveUserAsync();
            var existingVote = VoteService.GetVoteValue(currentUser.Id, postBaseId);

            if (existingVote == 0 || existingVote != value)
            {
                VoteService.AddNewVote(currentUser.Id, postBaseId, value);
            }

            var model = new PostBase() { CurrentVoteValue = existingVote/*, Count = votesCount*/ };

            return View("_VotesPartial", model);
        }

        //[HttpGet("votesInfo")]
        //public async Task<IActionResult> VotesInfo(int postBaseId)
        //{
        //    var currentUser = await GetActiveUserAsync();
        //    var voteValue = VoteService.GetVoteValue(currentUser.Id, postBaseId);
        //    //var votesCount = VoteService.GetVotesCount(postBaseId);

        //    var model = new PostBase() { CurrentVoteValue = voteValue/*, Count = votesCount*/ };

        //    return View("_VotesPartial", model);
        //}
    }
}
