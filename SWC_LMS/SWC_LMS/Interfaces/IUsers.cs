using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SWC_LMS.Models;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Repositories
{
    interface IUsers
    {
        void LogIn(LmsUserViewRegistration user);
        List<LmsUser> GetAll();
        LmsUser GetById(int id); 
        List<GradeLevel> GetGradeLevel();
        List<string> GetUsersRoles(int id);//used by login
        int GetUserIdByEmail(string email);//used by login
    }
}
