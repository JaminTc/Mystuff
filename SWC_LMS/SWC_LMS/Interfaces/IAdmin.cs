using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_LMS.Models;

namespace SWC_LMS.Repositories
{
    interface IAdmin
    {
        IQueryable<LmsUser> QueryForList();
        void AssignRoles(string GuidId, string roleId);
        void RemoveRoles(string GuidId, string roleId);
        void LmsUserToAspNetUser(string guid, int userid);
        string GetGUidByEmail(string email);
        void Edit(LmsUserViewRegistration user);
    }
}
