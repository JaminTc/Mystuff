using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models;
using SWC_LMS.Models.Api;

namespace SWC_LMS.Controllers.api
{
    public class TeacherController : ApiController 
    {
        AdminOperations _opp1 = new AdminOperations();
        TeacherOperations _opp3 = new TeacherOperations();

        public IEnumerable<TeacherViewResultsModel> Post(RosterSearch user)
        {
                byte? gradeLevelId;
                if (user.GradeLevelId != null)
                {
                    gradeLevelId = Convert.ToByte(user.GradeLevelId);
                }
                else
                {
                    gradeLevelId = null;
                }
                IQueryable<LmsUser> userList = _opp1.QueryForSearch();
                if (user.LastName != null || user.GradeLevelId != null)
                    {
                    if (user.LastName != null)
                    {
                        userList = userList.Where(x => x.LastName == user.LastName);
                    }
                    if (user.GradeLevelId != null)
                    {
                        userList = userList.Where(x => x.GradeLevelId.Equals(gradeLevelId));
                    }
                    var matchToSearch = from x in userList
                        select
                            new TeacherViewResultsModel
                            {
                                LastName = x.LastName,
                                FirstName = x.FirstName,
                                GradeLevelName = x.GradeLevel.GradeLevelName,
                                UserId = x.UserId
                            };
                    return matchToSearch;
                    }
                return null;
        }

        public IEnumerable<GetTeachersCourseInfo_Result> Get(int id)
        {
            IQueryable<GetTeachersCourseInfo_Result> classList = _opp3.QueryForArchivedClasses(id);
            classList = classList.Where(x => x.IsArchived);

            var matchToSearch = from x in classList
                                select new GetTeachersCourseInfo_Result { CourseName = x.CourseName, CourseId = x.CourseId };

            return matchToSearch;
        }
    }
}