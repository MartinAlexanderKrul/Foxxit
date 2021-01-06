using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class VoteController : Controller
    {
        public VoteController(IVoteService voteService)
        {
            VoteService = voteService;
        }

        public IVoteService VoteService { get; set; }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote(int voteType, int postId)
        {
            
        }
    }
}
