using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Repositories
{
    public class PStudentRepoDb : IPStudent
    {
        SWC_LMSEntities db = new SWC_LMSEntities();

        public List<ParentViewModel> GetParentsChildren(int id)
        {
            List<ParentViewModel> parentsChildrenList = new List<ParentViewModel>();
            var childrensId = db.ParentsChildren(id);
            foreach (var childsId in childrensId)
            {
                var childsInfo = db.ChildrensInfo(childsId).ToList();
                ParentViewModel child = new ParentViewModel
                {
                    FirstName = childsInfo.FirstOrDefault().FirstName,
                    LastName = childsInfo.FirstOrDefault().LastName,
                    UserId = childsInfo.FirstOrDefault().UserId
                };
                parentsChildrenList.Add(child);
            }
            return parentsChildrenList;
        }

        public List<GetCoursesForStudent_Result> GetCoursesForStudent(int id)
        {
            var courses = db.GetCoursesForStudent(id).ToList();
            return courses;
        }

        public List<GetAssignmentGrades_Result> GetAssignmentGrades(int rosterId)
        {
            var assignments = db.GetAssignmentGrades(rosterId).ToList();
            return assignments;
        }
    }
}