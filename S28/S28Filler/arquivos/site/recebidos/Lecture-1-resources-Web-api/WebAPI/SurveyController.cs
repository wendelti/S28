using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI 
{
    public static class Voting
    {
        public static Dictionary<string, int> Votes = new Dictionary<string, int>();
    }

    public class vmVote
    {
        public string vote;
    }


    public class SurveyController : DnnApiController
    {

        [HttpGet]
        [AllowAnonymous]
        public string Get()
        {
            return "Hello World";
        }

        [HttpPost]
        [AllowAnonymous]
        public string Vote(vmVote sendersVote)
        {
            if (!Voting.Votes.ContainsKey(sendersVote.vote))
                Voting.Votes.Add(sendersVote.vote, 0);

            Voting.Votes[sendersVote.vote]++;

            var votingResults = from v in Voting.Votes
                                select new { Equipment = v.Key, Votes = v.Value };

            return Newtonsoft.Json.JsonConvert.SerializeObject(votingResults.ToArray());
        }
    }
}
