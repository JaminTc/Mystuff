using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Repositories
{
    interface IPStudent
    {
        List<ParentViewModel> GetParentsChildren(int id);
        List<GetCoursesForStudent_Result> GetCoursesForStudent(int id);
        List<GetAssignmentGrades_Result> GetAssignmentGrades(int rosterId);
    }
}
