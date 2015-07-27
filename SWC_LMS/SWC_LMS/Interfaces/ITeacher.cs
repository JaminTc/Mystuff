using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_LMS.Models.Api;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Repositories
{
    interface ITeacher
    {
        List<GetTeachersCourseInfo_Result> GetTeachersCourseInfo(int id);
        Course ThisCourseInfo(int id);
        List<Subject> GetAllSubjects();
        void AddNewCourse(TeacherViewModel course);
        void EditCourse(TeacherViewModel course);
        void AddAssingment(AssignmentViewModel assignment);
        List<GetStudentsInCourse_Result> GetStudentsInCourse(int courseId);
        IQueryable<LmsUser> QueryForList();
        List<GetStudentsInCourse_Result> UpdateRoster(IdValues ids);
        List<GetStudentsInCourse_Result> AddToRoster(IdValues ids);
        IQueryable<GetTeachersCourseInfo_Result> QueryForArchivedClasses(int id);
        List<GradeBookViewModel> GradeBook(int id);
    }
}
