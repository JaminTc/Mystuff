using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWC_LMS.Models;
using SWC_LMS.Models.Views;
using SWC_LMS.Repositories;
using IUser = Microsoft.AspNet.Identity.IUser;

namespace SWC_LMS.BusinessLogic
{
    public class UserOperations
    {
        private IUsers _repo = new UserDbRepo();

        public void LogIn(LmsUserViewRegistration user)
        {
            _repo.LogIn(user);
        }


        public List<LmsUser> GetAll()
        {
            List<LmsUser> userList = _repo.GetAll();
            return (userList);
        }

        public LmsUser GetById(int id)
        {
            LmsUser user = _repo.GetById(id);
            return (user);
        }

        public List<GradeLevel> GetAllGrades()
        {
            return (_repo.GetGradeLevel());
        }

        public List<string> GetUsersRoles(int id)
        {
            return _repo.GetUsersRoles(id);
        }

        public int GetUserIdByEmail(string email)
        {
            return _repo.GetUserIdByEmail(email);
        }
    }
}