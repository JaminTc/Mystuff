using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWC_LMS.Models;
using SWC_LMS.Repositories;

namespace SWC_LMS.BusinessLogic
{
    public class AdminOperations
    {
        IAdmin _repo = new AdminRepoDb();

        public void Edit(LmsUserViewRegistration user)
        {
            _repo.Edit(user);
        }

        public IQueryable<LmsUser> QueryForSearch()
        {
            IQueryable<LmsUser> userList = _repo.QueryForList();
            return (userList);
        }

        public void AssignRole(string GuidId, string roleId)
        {
            _repo.AssignRoles(GuidId, roleId);
        }
        public void RemoveRole(string Id, string roleId)
        {
            _repo.RemoveRoles(Id, roleId);
        }

        public void LmsUserToAspNetUser(string guid, int userId)
        {
            _repo.LmsUserToAspNetUser(guid, userId);
        }

        public string GetGuidByEmail(string email)
        {
            var guid = _repo.GetGUidByEmail(email);
            return guid;
        }
    }
}