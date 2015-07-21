using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models.Api;

namespace SWC_LMS.Controllers.api
{
    public class AddController : ApiController
    {
        TeacherOperations _oop = new TeacherOperations();
        public List<GetStudentsInCourse_Result> Add(IdValues ids)
        {
            ids.IsDeleted = 0;
            List<GetStudentsInCourse_Result> roster = _oop.AddToRoster(ids);
            return roster;
        }
    }
}