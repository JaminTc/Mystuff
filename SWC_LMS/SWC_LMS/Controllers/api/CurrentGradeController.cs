using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SWC_LMS.Models.Api;

namespace SWC_LMS.Controllers.api
{
    public class CurrentGradeController : ApiController
    {
        SWC_LMSEntities db = new SWC_LMSEntities();
        public string Post(int id)
        {
            string grade = (db.GetThisCurrentGrade(id).FirstOrDefault());
            return grade;
        }
    }
}
