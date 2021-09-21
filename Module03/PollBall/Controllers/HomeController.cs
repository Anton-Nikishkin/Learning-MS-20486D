using Microsoft.AspNetCore.Mvc;

using PollBall.Services;

using System;
using System.Text;

namespace PollBall.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPollResultsService _pollResults;

        public HomeController(IPollResultsService pollResults)
        {
            _pollResults = pollResults ?? throw new System.ArgumentNullException(nameof(pollResults));
        }

        public IActionResult Index()
        {
            if (Request.Query.ContainsKey("submitted"))
            {
                var results = new StringBuilder();
                var voteList = _pollResults.GetVoteResult();
                foreach (var vote in voteList)
                {
                    results.Append($"Game name: {vote.Key}. Votes: {vote.Value}{Environment.NewLine}");
                }
                return Content(results.ToString());
            } else
            {
                return Redirect("poll-questions.html");
            }
        }
    }
}
