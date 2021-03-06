﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SWC_LMS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SWC_LMSEntities : DbContext
    {
        public SWC_LMSEntities()
            : base("name=SWC_LMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<GradeLevel> GradeLevels { get; set; }
        public virtual DbSet<LmsUser> LmsUsers { get; set; }
        public virtual DbSet<Roster> Rosters { get; set; }
        public virtual DbSet<RosterAssignment> RosterAssignments { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
    
        public virtual ObjectResult<GetAssignmentGrades_Result> GetAssignmentGrades(Nullable<int> rosterId)
        {
            var rosterIdParameter = rosterId.HasValue ?
                new ObjectParameter("RosterId", rosterId) :
                new ObjectParameter("RosterId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAssignmentGrades_Result>("GetAssignmentGrades", rosterIdParameter);
        }
    
        public virtual ObjectResult<GetAssignmentsInCourse_Result> GetAssignmentsInCourse(Nullable<int> courseId)
        {
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAssignmentsInCourse_Result>("GetAssignmentsInCourse", courseIdParameter);
        }
    
        public virtual ObjectResult<GetRosterAssignments_Result> GetRosterAssignments(Nullable<int> rosterId)
        {
            var rosterIdParameter = rosterId.HasValue ?
                new ObjectParameter("RosterId", rosterId) :
                new ObjectParameter("RosterId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRosterAssignments_Result>("GetRosterAssignments", rosterIdParameter);
        }
    
        public virtual ObjectResult<GetStudentAndRosterId_Result> GetStudentAndRosterId(Nullable<int> courseId)
        {
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentAndRosterId_Result>("GetStudentAndRosterId", courseIdParameter);
        }
    
        public virtual ObjectResult<GetStudentsInCourse_Result> GetStudentsInCourse(Nullable<int> courseId)
        {
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentsInCourse_Result>("GetStudentsInCourse", courseIdParameter);
        }
    
        public virtual ObjectResult<GradeLevel> GradeLevelSelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GradeLevel>("GradeLevelSelectAll");
        }
    
        public virtual ObjectResult<GradeLevel> GradeLevelSelectAll(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GradeLevel>("GradeLevelSelectAll", mergeOption);
        }
    
        public virtual int LmsUserInsert(string id, string firstName, string lastName, string email, Nullable<byte> gradeLevelId, string suggestedRole, ObjectParameter userId)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var gradeLevelIdParameter = gradeLevelId.HasValue ?
                new ObjectParameter("GradeLevelId", gradeLevelId) :
                new ObjectParameter("GradeLevelId", typeof(byte));
    
            var suggestedRoleParameter = suggestedRole != null ?
                new ObjectParameter("SuggestedRole", suggestedRole) :
                new ObjectParameter("SuggestedRole", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LmsUserInsert", idParameter, firstNameParameter, lastNameParameter, emailParameter, gradeLevelIdParameter, suggestedRoleParameter, userId);
        }
    
        public virtual ObjectResult<LmsUserSelectByAspNetId_Result> LmsUserSelectByAspNetId(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LmsUserSelectByAspNetId_Result>("LmsUserSelectByAspNetId", idParameter);
        }
    
        public virtual ObjectResult<LmsUserSelectByUserId_Result> LmsUserSelectByUserId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LmsUserSelectByUserId_Result>("LmsUserSelectByUserId", userIdParameter);
        }
    
        public virtual ObjectResult<string> LmsUserSelectRoleNames(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("LmsUserSelectRoleNames", userIdParameter);
        }
    
        public virtual ObjectResult<LmsUserSelectUnassigned_Result> LmsUserSelectUnassigned()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LmsUserSelectUnassigned_Result>("LmsUserSelectUnassigned");
        }
    
        public virtual int UpdateAssignmentGrade(Nullable<int> rosterAssignmentId, Nullable<decimal> pointsEarned, Nullable<decimal> percentage, Nullable<int> gradeLetter)
        {
            var rosterAssignmentIdParameter = rosterAssignmentId.HasValue ?
                new ObjectParameter("RosterAssignmentId", rosterAssignmentId) :
                new ObjectParameter("RosterAssignmentId", typeof(int));
    
            var pointsEarnedParameter = pointsEarned.HasValue ?
                new ObjectParameter("PointsEarned", pointsEarned) :
                new ObjectParameter("PointsEarned", typeof(decimal));
    
            var percentageParameter = percentage.HasValue ?
                new ObjectParameter("Percentage", percentage) :
                new ObjectParameter("Percentage", typeof(decimal));
    
            var gradeLetterParameter = gradeLetter.HasValue ?
                new ObjectParameter("GradeLetter", gradeLetter) :
                new ObjectParameter("GradeLetter", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateAssignmentGrade", rosterAssignmentIdParameter, pointsEarnedParameter, percentageParameter, gradeLetterParameter);
        }
    
        public virtual int UpdateRosterCurrentGrade(Nullable<int> rosterAssignmentId)
        {
            var rosterAssignmentIdParameter = rosterAssignmentId.HasValue ?
                new ObjectParameter("RosterAssignmentId", rosterAssignmentId) :
                new ObjectParameter("RosterAssignmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateRosterCurrentGrade", rosterAssignmentIdParameter);
        }
    
        public virtual ObjectResult<AspNetRole> GetAllRoles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AspNetRole>("GetAllRoles");
        }
    
        public virtual ObjectResult<AspNetRole> GetAllRoles(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AspNetRole>("GetAllRoles", mergeOption);
        }
    
        public virtual ObjectResult<LmsUser> LmsUserGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LmsUser>("LmsUserGetAll");
        }
    
        public virtual ObjectResult<LmsUser> LmsUserGetAll(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LmsUser>("LmsUserGetAll", mergeOption);
        }
    
        public virtual ObjectResult<Nullable<int>> GetUserIdByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetUserIdByEmail", emailParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<int>> ParentsChildren(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ParentsChildren", userIdParameter);
        }
    
        public virtual ObjectResult<ChildrensInfo_Result> ChildrensInfo(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ChildrensInfo_Result>("ChildrensInfo", userIdParameter);
        }
    
        public virtual int LmsUserEdit(Nullable<int> userId, string guidId, string firstName, string lastName, Nullable<byte> gradeLevelId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var guidIdParameter = guidId != null ?
                new ObjectParameter("GuidId", guidId) :
                new ObjectParameter("GuidId", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var gradeLevelIdParameter = gradeLevelId.HasValue ?
                new ObjectParameter("GradeLevelId", gradeLevelId) :
                new ObjectParameter("GradeLevelId", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LmsUserEdit", userIdParameter, guidIdParameter, firstNameParameter, lastNameParameter, gradeLevelIdParameter);
        }
    
        public virtual int AssignUserRole(string userID, string roleID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            var roleIDParameter = roleID != null ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AssignUserRole", userIDParameter, roleIDParameter);
        }
    
        public virtual int RemoveUserRole(string userId, string roleId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var roleIdParameter = roleId != null ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveUserRole", userIdParameter, roleIdParameter);
        }
    
        public virtual ObjectResult<string> GetGUidByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetGUidByEmail", emailParameter);
        }
    
        public virtual int Lms_UsertoASPNETUser(string id, Nullable<int> userId)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Lms_UsertoASPNETUser", idParameter, userIdParameter);
        }
    
        public virtual ObjectResult<Course> GetThisCourse(Nullable<int> courseId)
        {
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Course>("GetThisCourse", courseIdParameter);
        }
    
        public virtual ObjectResult<Course> GetThisCourse(Nullable<int> courseId, MergeOption mergeOption)
        {
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Course>("GetThisCourse", mergeOption, courseIdParameter);
        }
    
        public virtual ObjectResult<Subject> GetAllSubjects()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Subject>("GetAllSubjects");
        }
    
        public virtual ObjectResult<Subject> GetAllSubjects(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Subject>("GetAllSubjects", mergeOption);
        }
    
        public virtual int AddNewCourse(Nullable<int> userId, Nullable<int> subjectId, string courseName, string courseDescription, Nullable<byte> gradeLevel, Nullable<bool> isArchived, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var subjectIdParameter = subjectId.HasValue ?
                new ObjectParameter("SubjectId", subjectId) :
                new ObjectParameter("SubjectId", typeof(int));
    
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            var courseDescriptionParameter = courseDescription != null ?
                new ObjectParameter("CourseDescription", courseDescription) :
                new ObjectParameter("CourseDescription", typeof(string));
    
            var gradeLevelParameter = gradeLevel.HasValue ?
                new ObjectParameter("GradeLevel", gradeLevel) :
                new ObjectParameter("GradeLevel", typeof(byte));
    
            var isArchivedParameter = isArchived.HasValue ?
                new ObjectParameter("IsArchived", isArchived) :
                new ObjectParameter("IsArchived", typeof(bool));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewCourse", userIdParameter, subjectIdParameter, courseNameParameter, courseDescriptionParameter, gradeLevelParameter, isArchivedParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<GetCoursesForStudent_Result> GetCoursesForStudent(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCoursesForStudent_Result>("GetCoursesForStudent", userIdParameter);
        }
    
        public virtual int UpdateRoster(Nullable<int> studentId, Nullable<int> courseId, Nullable<int> isDeleted)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(int));
    
            var isDeletedParameter = isDeleted.HasValue ?
                new ObjectParameter("IsDeleted", isDeleted) :
                new ObjectParameter("IsDeleted", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateRoster", studentIdParameter, courseIdParameter, isDeletedParameter);
        }
    
        public virtual int AddToRoster(Nullable<int> courseId, Nullable<int> userId, Nullable<int> isDeleted)
        {
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("courseId", courseId) :
                new ObjectParameter("courseId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var isDeletedParameter = isDeleted.HasValue ?
                new ObjectParameter("isDeleted", isDeleted) :
                new ObjectParameter("isDeleted", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddToRoster", courseIdParameter, userIdParameter, isDeletedParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> AssignGradePercent(Nullable<int> assignmentId, Nullable<decimal> pointsEarned, Nullable<int> userId)
        {
            var assignmentIdParameter = assignmentId.HasValue ?
                new ObjectParameter("AssignmentId", assignmentId) :
                new ObjectParameter("AssignmentId", typeof(int));
    
            var pointsEarnedParameter = pointsEarned.HasValue ?
                new ObjectParameter("PointsEarned", pointsEarned) :
                new ObjectParameter("PointsEarned", typeof(decimal));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("AssignGradePercent", assignmentIdParameter, pointsEarnedParameter, userIdParameter);
        }
    
        public virtual int AddNewAssignment(Nullable<int> courseID, string assingmentName, Nullable<int> possiblePoints, Nullable<System.DateTime> dueDate, string assingmentDescription)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("CourseID", courseID) :
                new ObjectParameter("CourseID", typeof(int));
    
            var assingmentNameParameter = assingmentName != null ?
                new ObjectParameter("AssingmentName", assingmentName) :
                new ObjectParameter("AssingmentName", typeof(string));
    
            var possiblePointsParameter = possiblePoints.HasValue ?
                new ObjectParameter("PossiblePoints", possiblePoints) :
                new ObjectParameter("PossiblePoints", typeof(int));
    
            var dueDateParameter = dueDate.HasValue ?
                new ObjectParameter("DueDate", dueDate) :
                new ObjectParameter("DueDate", typeof(System.DateTime));
    
            var assingmentDescriptionParameter = assingmentDescription != null ?
                new ObjectParameter("AssingmentDescription", assingmentDescription) :
                new ObjectParameter("AssingmentDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewAssignment", courseIDParameter, assingmentNameParameter, possiblePointsParameter, dueDateParameter, assingmentDescriptionParameter);
        }
    
        public virtual ObjectResult<string> GetThisCurrentGrade(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetThisCurrentGrade", userIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> FindGradePercent(Nullable<int> assignmentId, Nullable<decimal> pointsEarned, Nullable<int> userId)
        {
            var assignmentIdParameter = assignmentId.HasValue ?
                new ObjectParameter("AssignmentId", assignmentId) :
                new ObjectParameter("AssignmentId", typeof(int));
    
            var pointsEarnedParameter = pointsEarned.HasValue ?
                new ObjectParameter("PointsEarned", pointsEarned) :
                new ObjectParameter("PointsEarned", typeof(decimal));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("FindGradePercent", assignmentIdParameter, pointsEarnedParameter, userIdParameter);
        }
    
        public virtual ObjectResult<GetTeachersCourseInfo_Result> GetTeachersCourseInfo(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTeachersCourseInfo_Result>("GetTeachersCourseInfo", userIdParameter);
        }
    
        public virtual int AlterCourse(Nullable<int> courseId, Nullable<int> subjectId, string courseName, string courseDescription, Nullable<byte> gradeLevel, Nullable<bool> isArchived, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var courseIdParameter = courseId.HasValue ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(int));
    
            var subjectIdParameter = subjectId.HasValue ?
                new ObjectParameter("SubjectId", subjectId) :
                new ObjectParameter("SubjectId", typeof(int));
    
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            var courseDescriptionParameter = courseDescription != null ?
                new ObjectParameter("CourseDescription", courseDescription) :
                new ObjectParameter("CourseDescription", typeof(string));
    
            var gradeLevelParameter = gradeLevel.HasValue ?
                new ObjectParameter("GradeLevel", gradeLevel) :
                new ObjectParameter("GradeLevel", typeof(byte));
    
            var isArchivedParameter = isArchived.HasValue ?
                new ObjectParameter("IsArchived", isArchived) :
                new ObjectParameter("IsArchived", typeof(bool));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlterCourse", courseIdParameter, subjectIdParameter, courseNameParameter, courseDescriptionParameter, gradeLevelParameter, isArchivedParameter, startDateParameter, endDateParameter);
        }
    }
}
