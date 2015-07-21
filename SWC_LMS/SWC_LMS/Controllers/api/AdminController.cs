using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Controllers.api
{
    public class AdminController : ApiController
    {
        AdminOperations _opp = new AdminOperations();

        public IEnumerable<SearchResultView> Post(Search user)
        {
            IQueryable<LmsUser> userList = _opp.QueryForSearch();
            if (user.FirstName != null)
            {
                userList = userList.Where(x => x.Id != null && x.FirstName.StartsWith(user.FirstName));
                 
            }
            if (user.LastName != null)
            {
                userList = userList.Where(x => x.Id != null && x.LastName.StartsWith(user.LastName));
            }
            if (user.Email != null)
            {
                userList = userList.Where(x => x.Id != null && x.Email.StartsWith(user.Email));
            } 
            if (user.Role != "null")
            {
                userList = userList.Where(x => x.SuggestedRole == user.Role && x.Id != null);
            }

            var matchToSearch = from x in userList
                                select new SearchResultView{FirstName = x.FirstName,LastName = x.LastName,Email = x.Email,Role = x.SuggestedRole,Id = x.UserId };

            return matchToSearch;
        }
    }
}
