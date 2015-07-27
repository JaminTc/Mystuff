using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWC_LMS.Models.Api;
using SWC_LMS.Models.Views;
using SWC_LMS.Repositories;

namespace SWC_LMS.BusinessLogic
{
    public class TeacherOperations 
    {
        ITeacher _repo = new TeacherRepoDb();

        public List<GetTeachersCourseInfo_Result> GetTeachersCourseInfo(int id)
        {
            List<GetTeachersCourseInfo_Result> courseInfo = _repo.GetTeachersCourseInfo(id);
            return courseInfo;
        }

        public Course GetThisCourse(int id)
        {
           return _repo.ThisCourseInfo(id);
        }

        public List<Subject> GetAllSubjects()
        {
            return _repo.GetAllSubjects();
        }

        public void AddNewCourse(TeacherViewModel course)
        {
            _repo.AddNewCourse(course);
        }

        public List<RosterViewModel> GetStudentsInCourse(int courseId)
        {
            List<GetStudentsInCourse_Result> repoRoster = _repo.GetStudentsInCourse(courseId);
            List<RosterViewModel> roster = new List<RosterViewModel>();
            
            foreach (var students in repoRoster)
            {
                RosterViewModel student = new RosterViewModel
                {
                    FirstName = students.FirstName,
                    LastName = students.LastName,
                    Email = students.Email,
                    CourseName = students.CourseName,
                    GradeLevel = students.GradeLevel,
                    StudentId = students.StudentId
                };
                roster.Add(student);
            }
            return roster;
        }
        public void EditCourse(TeacherViewModel course)
        {
            _repo.EditCourse(course);
        }

        public void AddAssignment(AssignmentViewModel assignment)
        {
            _repo.AddAssingment(assignment);
        }

        public IQueryable<LmsUser> QueryForSearch()
        {
            IQueryable<LmsUser> userList = _repo.QueryForList();
            return (userList);
        }

        public List<GetStudentsInCourse_Result> UpdateRoster(IdValues ids)
        {
            List<GetStudentsInCourse_Result> roster = _repo.UpdateRoster(ids);
            return roster;
        }

        public IQueryable<GetTeachersCourseInfo_Result> QueryForArchivedClasses(int id)
        {
            IQueryable<GetTeachersCourseInfo_Result> courseInfo = _repo.QueryForArchivedClasses(id);
            return courseInfo;
        }
        
        public List<GetStudentsInCourse_Result> AddToRoster(IdValues ids)
        {
           return (_repo.AddToRoster(ids));
        }

        public List<GradeBookViewModel> Gradebook(int id)
        {
            return (_repo.GradeBook(id));
        } 
    }
}
           