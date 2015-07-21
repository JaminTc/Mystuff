using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWC_LMS.Models;

namespace SWC_LMS.Repositories
{
    public class AdminRepoDb : IAdmin
    {
        SWC_LMSEntities db = new SWC_LMSEntities();

        public void Edit(LmsUserViewRegistration user)
        {
            byte gradeLevelId = Convert.ToByte(user.GradeLevelId);
            db.LmsUserEdit(user.UserId, user.GuidId, user.FirstName, user.LastName, gradeLevelId);
        }

        public void AssignRoles(string UserId, string roleId)
        {
            db.AssignUserRole(UserId, roleId);
        }

        public void RemoveRoles(string UserId, string roleId)
        {
            db.RemoveUserRole(UserId, roleId);
        }

        public IQueryable<LmsUser> QueryForList()
        {
            return db.LmsUserGetAll().AsQueryable();
        }

        public void LmsUserToAspNetUser(string guid, int userId)
        {
            db.Lms_UsertoASPNETUser(guid, userId);
        }

        public string GetGUidByEmail(string email)
        {
            var guid = db.GetGUidByEmail(email);
            return guid.FirstOrDefault();
        }
    }
}