﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using SWC_LMS.Models.Api;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Repositories
{
    public class TeacherRepoDb : ITeacher
    {
        SWC_LMSEntities db = new SWC_LMSEntities();
        public List<GetTeachersCourseInfo_Result> GetTeachersCourseInfo(int id)
        {
            var course = db.GetTeachersCourseInfo(id);
            return course.ToList();
        }

        public List<GetStudentsInCourse_Result> GetStudentsInCourse(int courseId)
        {
            var roster = db.GetStudentsInCourse(courseId);
            return roster.ToList();
        }

        public Course ThisCourseInfo(int id)
        {
            return db.GetThisCourse(id).FirstOrDefault();
        }

        public List<Subject> GetAllSubjects()
        {
            return db.GetAllSubjects().ToList();
        }

        public void AddNewCourse(TeacherViewModel course)
        {
            var startDate = DateTime.Parse(course.StartDate);
            var endDate = DateTime.Parse(course.EndDate);
            Byte gradeLevel = Convert.ToByte(course.GradeLevel);
            db.AddNewCourse(course.UserId, course.SubjectId, course.CourseName, course.CourseDescription, gradeLevel, course.IsArchived, startDate, endDate);
        }

        public void EditCourse(TeacherViewModel course)
        {
            var startDate = DateTime.Parse(course.StartDate);
            var endDate = DateTime.Parse(course.EndDate);
            Byte gradeLevel = Convert.ToByte(course.GradeLevel);
            db.AlterCourse(course.CourseId, course.SubjectId, course.CourseName, course.CourseDescription,
                gradeLevel, course.IsArchived, startDate, endDate);
        }

        public void AddAssingment(AssignmentViewModel assignment)
        {
            var dueDate = DateTime.Parse(assignment.DueDate); 
            db.AddNewAssignment(assignment.CourseId, assignment.AssignmentName, assignment.PossiblePoints,
                dueDate, assignment.AssignmentDescription);
        }

        public IQueryable<LmsUser> QueryForList()
        {
            return db.LmsUserGetAll().AsQueryable();
        }

        public IQueryable<GetTeachersCourseInfo_Result> QueryForArchivedClasses(int id)
        {
            return db.GetTeachersCourseInfo(id).AsQueryable();
        }

        public List<GetStudentsInCourse_Result> UpdateRoster(IdValues ids)
        {
            db.UpdateRoster(ids.StudentId, ids.CourseId, ids.IsDeleted);
            var roster = db.GetStudentsInCourse(ids.CourseId);
            return roster.ToList();
        }

        public List<GetStudentsInCourse_Result> AddToRoster(IdValues ids)
        {
            db.AddToRoster(ids.CourseId, ids.StudentId, ids.IsDeleted);
            var roster = db.GetStudentsInCourse(ids.CourseId);
            return roster.ToList();
        }

        public List<GradeBookViewModel> GradeBook(int id)
        {

            return (from c in db.Courses
                join r in db.Rosters on c.CourseId equals r.CourseId
                join u in db.LmsUsers on r.UserId equals u.UserId
                join a in db.Assignments on c.CourseId equals a.CourseId
                where c.CourseId == id
                group r by new {r.UserId,u.FirstName,u.LastName,r.CurrentGrade, r.Course,r.RosterId,}
                into g
                select new GradeBookViewModel
                {
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    UserId = g.Key.UserId,
                    Grade = g.Key.CurrentGrade,
                    Assignments = g.FirstOrDefault().RosterAssignments.ToList()
                }).ToList();
               
        }

    }
}