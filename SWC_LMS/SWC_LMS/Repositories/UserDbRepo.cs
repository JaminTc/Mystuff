using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using SWC_LMS.Models;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Repositories
{
    public class UserDbRepo : IUsers
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SWC_LMSEntities db = new SWC_LMSEntities();

        public void LogIn(LmsUserViewRegistration user)
        {
            byte? gradeLevelId = null;
            if (user.GradeLevelId != null)
            {
                gradeLevelId = Convert.ToByte(user.GradeLevelId);
            }
          
            ObjectParameter userId = new ObjectParameter("userId", typeof (int));
            db.LmsUserInsert(user.GuidId, user.FirstName, user.LastName, user.Email, gradeLevelId, user.SuggestedRole,
                userId);
        }

        public List<LmsUser> GetAll()
        {
            return db.LmsUserGetAll().ToList();
        }

        public LmsUser GetById(int id)
        {
            return GetAll().FirstOrDefault(m => m.UserId == id);
        }

        public List<GradeLevel> GetGradeLevel()
        {
            return db.GradeLevelSelectAll().ToList();
        }

        public List<string> GetUsersRoles(int id)
        {
            var roles = db.LmsUserSelectRoleNames(id);
            var userRoles = roles.TakeWhile(n => n != null);
            return userRoles.ToList();
        }

        public int GetUserIdByEmail(string email)
        {
            var id = db.GetUserIdByEmail(email).FirstOrDefault();
            return id.GetValueOrDefault();
        }
    }
}