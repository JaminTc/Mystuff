using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models;
using SWC_LMS.Models.Api;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Controllers.api
{
    public class DeleteController : ApiController
    {
        TeacherOperations _opp = new TeacherOperations();

        public List<GetStudentsInCourse_Result> Post(IdValues ids)
        {
            ids.IsDeleted = 1;
            List<GetStudentsInCourse_Result> roster = _opp.UpdateRoster(ids);
            return roster;
        }
    }
}