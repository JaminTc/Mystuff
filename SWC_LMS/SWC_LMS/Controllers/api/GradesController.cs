using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Util;
using SWC_LMS.Models.Api;

namespace SWC_LMS.Controllers.api
{
    public class GradesController : ApiController
    {
        SWC_LMSEntities db = new SWC_LMSEntities();
        public int Post(int id)
        {
            var passPoint = from  a in db.Assignments 
                where a.AssignmentId == id
                select a.PossiblePoints.ToString();
            int numb = 0;
            var tryThis = int.TryParse(passPoint.FirstOrDefault(), out numb );
            return numb;
        }

        public GetGrades Post(GradeIds grades)
        {   
            decimal thisPercent = 0;
            GetGrades grade = new GetGrades();
            if (grades.Percent != null)
            {
                var percent =
                    (db.FindGradePercent(grades.AssignmentId, grades.PointsEarned, grades.UserId)
                        .FirstOrDefault()
                        .ToString());
                var tryThis = decimal.TryParse(percent, out thisPercent);
            }
            else
            {
                var percent =
                    (db.AssignGradePercent(grades.AssignmentId, grades.PointsEarned, grades.UserId)
                        .FirstOrDefault()
                        .ToString());
                var tryThis = decimal.TryParse(percent, out thisPercent);
            }
            grade.Precentage = thisPercent;
            return grade;
        }
    }
}
