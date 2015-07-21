using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWC_LMS.Models.Views;
using SWC_LMS.Repositories;

namespace SWC_LMS.BusinessLogic
{
    public class PStudnetOperations
    {
        private IPStudent _repo = new PStudentRepoDb();

        public List<ParentViewModel> GetParentsChildren(int id)
        {
            List<ParentViewModel> parentsChildrenList = _repo.GetParentsChildren(id);
            return parentsChildrenList;
        }

        public List<GetCoursesForStudent_Result> GetCoursesForStudent(int id)
        {
            var courses = _repo.GetCoursesForStudent(id);
            return courses;
        }

        public List<GetAssignmentGrades_Result> GetAssignmentGrades(int rosterId)
        {
            var assignments = _repo.GetAssignmentGrades(rosterId);
            return assignments;
        }
    }
}