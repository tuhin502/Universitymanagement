<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeshBoard.aspx.cs" Inherits="UniversityManagementSystemWebApp.DeshBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
<div>
     <a href="Views/Department/">Views/Department/
    @Html.ActionLink("Save Department", "Save", "Department")</a>
</div>

<div>
    @Html.ActionLink(" Save Department", "DepartmentDetails", "Department")
</div>


<div>
    @Html.ActionLink(" Save Course", "Save", "Course")
</div>

<div>
    @Html.ActionLink(" Save Teacher", "Save", "Teacher")
</div>

<div>
    @Html.ActionLink(" CourseAssignToTeacher CourseAssignToTeacher", "CourseAssignToTeacher", "CourseAssignToTeacher")
</div>

<div>
    @Html.ActionLink(" ViewCourseStatistics CourseAssignToTeacher", "ViewCourseStatistics", "CourseAssignToTeacher")
</div>

<div>
    @Html.ActionLink(" Save Student", "Save", "Student")
</div>


<div>
    @Html.ActionLink(" Save ClassRoom", "Save", "ClassRoom")
</div>

<div>
    @Html.ActionLink(" Save ClassSchedule", "Save", "ClassRoom")
</div>


<div>
    @Html.ActionLink(" EnrollInCourse EnrollInCourse", "EnrollInCourse", "EnrollInCourse")
</div>


<div>
    @Html.ActionLink(" Save StudentResult", "Save", "StudentResult")
</div>

<div>
    @Html.ActionLink(" ViewResult StudentResult", "ViewResult", "StudentResult")
</div>

<div>
    @Html.ActionLink(" UnAllocate UnAllocateClassRoom", "UnAllocate", "UnAllocateClassRoom")

</div>

<div>
    <a class="btn btn-default" href="Views/Student/">Views/Student/
        @Html.ActionLink(" UnAssign UnAssignCourse", "UnAssign", "UnAssignCourse")
    </a>
   
</div>
       
    </form>
</body>
</html>
