using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Abp.Domain.Uow;
using Foxxit.Attributes.RoleServices;
using Foxxit.Enums;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Foxxit.Controllers
{
    [Authorize]
    public class FoxxitController : MainController
    {
        private const int PageSize = 10;

        public FoxxitController(IVoteService voteService, IUserSubRedditService userSubRedditService, IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager, ISearchService searchService, IPostService postService, ISubRedditService subRedditService, ICommentService commentService, IImageService imageService)
            : base(userManager, signInManager)
        {
            SearchService = searchService;
            PostService = postService;
            SubRedditService = subRedditService;
            CommentService = commentService;
            UserService = userService;
            VoteService = voteService;
            UserSubRedditService = userSubRedditService;
            ImageService = imageService;
        }

        public ISearchService SearchService { get; set; }
        public IPostService PostService { get; set; }
        public ISubRedditService SubRedditService { get; set; }
        public ICommentService CommentService { get; set; }
        public IUserService UserService { get; set; }
        public IUserSubRedditService UserSubRedditService { get; set; }
        public IImageService ImageService { get; set; }
        public IVoteService VoteService { get; set; }

        [HttpGet("/vote/{value}/{postBaseId}")]
        public async Task<VotesInfo> Vote(int value, long postBaseId)
        {
            var currentUser = await GetActiveUserAsync();
            var existingVote = VoteService.GetVote(currentUser.Id, postBaseId);

            if (existingVote is null)
            {
                existingVote = await VoteService.AddNewVote(currentUser.Id, postBaseId, value);
                await VoteService.SaveAsync();
                await VoteService.EnsureOneVote(existingVote);
            }
            else if (existingVote.Value == value)
            {
                VoteService.Delete(existingVote);
                await VoteService.SaveAsync();
                existingVote.Value = 0;
            }
            else
            {
                existingVote.Value = value;
                VoteService.Update(existingVote);
                await VoteService.SaveAsync();
            }

            var commentModel = await CommentService.GetByIdInclude(postBaseId);
            var postModel = await PostService.GetByIdIncludeCommentsAndUserAsync(postBaseId);

            if (commentModel is not null)
            {
                var dto = new VotesInfo { Karma = commentModel.Karma, CurrentVote = existingVote.Value };
                return dto;
            }
            else
            {
                var dto = new VotesInfo { Karma = postModel.Karma, CurrentVote = existingVote.Value };
                return dto;
            }
        }

        [HttpGet("")]
        [HttpGet("index")]
        public async Task<IActionResult> Index(SortMethod sortMethod)
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();
            var posts = PostService.Sort(sortMethod, null);
            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                Posts = posts,
                SortMethod = sortMethod,
                SubReddits = subReddits,
                PostViewModel = new PostViewModel(currentUser, false),
            };

            return View("Index", model);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string category, string keyword)
        {
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                Posts = await PostService.GetAllIncludeCommentsAndUserAsync(),
                SubReddits = await SubRedditService.GetAllIncludeUserAndMembers(),
                SearchReturnModel = SearchService.Search(category, keyword),
            };

            return View("Search", model);
        }

        [HttpGet("paginationSample")]
        public async Task<IActionResult> PaginationSample(int? pageNum)
        {
            var posts = await PostService.GetAllIncludeCommentsAndUserAsync();
            return View(await PaginatedList<Post>.CreateAsync(posts, pageNum ?? 1));
        }

        [HttpGet("subreddit")]
        public async Task<IActionResult> SubReddit(SortMethod sortMethod, long subRedditId)
        {
            var currentUser = await GetActiveUserAsync();
            var currentSubReddit = await SubRedditService.GetbyIdIncludeUserAndMembers(subRedditId);
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();
            var posts = PostService.Sort(sortMethod, subRedditId);

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                CurrentSubReddit = currentSubReddit,
                Posts = posts,
                SortMethod = sortMethod,
                SubReddits = subReddits,
            };

            return View("SubReddit", model);
        }

        [HttpGet("expanded-subreddit")]
        public async Task<IActionResult> ExpandSubReddit(SortMethod sortMethod, long subRedditId)
        {
            var currentUser = await GetActiveUserAsync();
            var currentSubReddit = await SubRedditService.GetbyIdIncludeUserAndMembers(subRedditId);
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();
            var posts = PostService.Sort(sortMethod, subRedditId);

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                CurrentSubReddit = currentSubReddit,
                Posts = posts,
                SortMethod = sortMethod,
                SubReddits = subReddits,
            };

            return View("ExpandedSubReddit", model);
        }

        [HttpGet("subreddit/new")]
        public async Task<IActionResult> CreateSubreddit()
        {
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                SubReddits = await SubRedditService.GetAllIncludeUserAndMembers()
            };

            return View("CreateSubreddit", model);
        }

        [HttpPost("subreddit/new")]
        public async Task<IActionResult> CreateSubreddit(string name, string about)
        {
            var list = await SubRedditService.GetAllAsync();
            if (!list.Any(s => s.Name.Equals(name)))
            {
                var currentUser = await GetActiveUserAsync();
                var subreddit = new SubReddit(name, about, currentUser.Id);
                await SubRedditService.AddAsync(subreddit);
                await SubRedditService.SaveAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "SubReddit with this name already exists.");
            }

            return View("Index");
        }

        // [AuthorizedRoles(Enums.UserRole.Admin)]
        [HttpGet("subreddit/approve")]
        public async Task<IActionResult> ApproveSubreddit()
        {
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                SubReddits = await SubRedditService.GetAllIncludeUserAndMembers()
            };

            return View("SubredditsToApprove", model);
        }

        // [AuthorizedRoles(Enums.UserRole.Admin)]
        [HttpPost("subreddit/approve")]
        public async Task<IActionResult> ApproveSubreddit(long id, bool isApproved)
        {
            var subRedditToChange = await SubRedditService.GetByIdAsync(id);
            subRedditToChange.IsApproved = isApproved;
            SubRedditService.Update(subRedditToChange);
            await SubRedditService.SaveAsync();

            return RedirectToAction("ApproveSubreddit");
        }

        [HttpGet("/Post/New")]
        public async Task<IActionResult> NewPost(int subRedditId)
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();
            var currentSubReddit = await SubRedditService.GetbyIdIncludeUserAndMembers(subRedditId);

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits,
                CurrentSubReddit = currentSubReddit
            };

            return View("CreatePost", model);
        }

        [HttpPost("/Post/Create")]
        public async Task<IActionResult> CreatePost(string title, string url, string text, long subRedditId, IFormFile file)
        {
            var imageUrl = file != null ? "https://" + Request.Host + $"/image/imagestore/{await ImageService.SaveImageAsync(file)}" : null;

            var user = await GetActiveUserAsync();
            var subReddit = await SubRedditService.GetByIdAsync(subRedditId);
            var post = new Post(title, text, url, imageUrl, subReddit, user);

            await PostService.AddAsync(post);
            await PostService.SaveAsync();

            return Redirect($"/Post/{post.Id}");
        }

        [HttpGet("/Post/{postId}")]
        public async Task<IActionResult> ViewPost(long postId)
        {
            var currentUser = await GetActiveUserAsync();
            var post = await PostService.GetByIdIncludeCommentsAndUserAsync(postId);
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();

            var postViewModel = new PostViewModel(currentUser, post, true);

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits,
                PostViewModel = postViewModel,
            };

            return View("Post", model);
        }

        [HttpGet("loadComments")]
        public async Task<IActionResult> LoadComments(long postId)
        {
            var model = await PostService.GetByIdAsync(postId);
            return PartialView("_CommentViewPartial", model);
        }

        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment(string text, long postId)
        {
            var user = await GetActiveUserAsync();
            var post = await PostService.GetByIdAsync(postId);

            var comment = new Comment(text, user, post);

            await CommentService.AddAsync(comment);
            await CommentService.SaveAsync();

            return Redirect($"Post/{postId}");
        }

        [HttpPost("addSubComment")]
        public async Task<IActionResult> AddSubComment(string text, long postId, long originalCommentId)
        {
            var user = await GetActiveUserAsync();

            var originalComment = await CommentService.GetByIdAsync(originalCommentId);
            var comment = new Comment() { OriginalCommentId = originalCommentId, Text = text, User = user };

            originalComment.Comments.Add(comment);

            CommentService.Update(originalComment);
            await CommentService.SaveAsync();

            return Redirect($"Post/{postId}");
        }

        [HttpGet("comment/reply/{id}")]
        public async Task<IActionResult> ShowReply(long id)
        {
            var comment = await CommentService.GetByIdInclude(id);
            return View("_AddSubCommentViewPartial", comment);
        }

        [HttpGet("SubReddit/Join")]
        public async Task<IActionResult> Join(long subRedditId)
        {
            var user = await GetActiveUserAsync();
            var subReddit = await SubRedditService.GetByIdAsync(subRedditId);

            subReddit.Members.Add(new UserSubReddit() { SubReddit = subReddit, User = user });
            SubRedditService.Update(subReddit);
            await SubRedditService.SaveAsync();

            return Redirect($"/SubReddit?subRedditId={subRedditId}");
        }

        [HttpGet("SubReddit/Unfollow")]
        public async Task<IActionResult> Unfollow(long subRedditId)
        {
            var user = await GetActiveUserAsync();
            await UserSubRedditService.Delete(subRedditId, user.Id);

            return Redirect($"/SubReddit?subRedditId={subRedditId}");
        }

        [HttpGet("passwordchange")]
        public async Task<IActionResult> PasswordChange()
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits,
            };

            return View("AccountPasswordChange", model);
        }

        [HttpPost("passwordchange")]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel model)
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();

            var mainModel = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits,
                PasswordChangeViewModel = model,
            };

            if (!ModelState.IsValid)
            {
                return View("AccountPasswordChange", mainModel);
            }

            var user = await GetActiveUserAsync();
            var changePasswordResult = await UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (changePasswordResult.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (user.PasswordHash is not null)
                {
                    ModelState.AddModelError(string.Empty, "Server side denied the password change!");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Foxxit has no permission to change you password! Try to contact your external login provider.");
                }
            }

            return View("AccountPasswordChange", mainModel);
        }

        [HttpGet("usernamechange")]
        public async Task<IActionResult> UsernameChange()
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits,
            };

            return View("AccountUsernameChange", model);
        }

        [HttpPost("usernamechange")]
        public async Task<IActionResult> UsernameChange(UsernameChangeViewModel model)
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllIncludeUserAndMembers();

            var mainModel = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits,
                UsernameChangeViewModel = model,
            };

            if (!ModelState.IsValid)
            {
                return View("AccountUsernameChange", mainModel);
            }

            var existingUserName = await UserManager.FindByNameAsync(model.NewUserName);

            if (existingUserName is null)
            {
                var user = await GetActiveUserAsync();
                await UserService.UpdateUsernameAsync(user, model.NewUserName);
            }
            else
            {
                ModelState.AddModelError("NewUserName", "Username is already taken!");
            }

            return RedirectToAction("Index", "Foxxit");
        }
    }
}