<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="menu_menu" %>

<nav class="sidebar sidebar-offcanvas" id="sidebar">
    <ul class="nav">
        <li class="nav-item">
            <a class="nav-link" href="#">
                <i class="icon-grid menu-icon"></i>
                <span class="menu-title">Dashboard</span>
            </a>
        </li>
        <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#form-elements" aria-expanded="false" aria-controls="form-elements">
                <i class="icon-columns menu-icon"></i>
                <span class="menu-title">Course</span>
                <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="form-elements">
                <ul class="nav flex-column sub-menu">
                    <li class="nav-item"><a class="nav-link" href="/AddCourse.aspx">Add Course</a></li>
                    <li class="nav-item"><a class="nav-link" href="/CourseRecord.aspx">Course Record</a></li>
                    <li class="nav-item"><a class="nav-link" href="/CourseRegistrationAdd.aspx">Course Registration</a></li>
                    <li class="nav-item"><a class="nav-link" href="/CourseRegistrationRecord.aspx">View Course Registration</a></li>
                </ul>
            </div>
        </li>
        <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#chart" aria-expanded="false" aria-controls="chart">
                <i class="icon-bar-graph menu-icon"></i>
                <span class="menu-title">Faculty</span>
                <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="chart">
                <ul class="nav flex-column sub-menu">
                    <li class="nav-item"><a class="nav-link" href="/FacultyAdd.aspx">Add Faculty</a></li>
                    <li class="nav-item"><a class="nav-link" href="/FacultyRecordAdd.aspx">View Faculty Record</a></li>
                </ul>
            </div>
        </li>
        <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#charts" aria-expanded="false" aria-controls="charts">
                <i class="icon-bar-graph menu-icon"></i>
                <span class="menu-title">Department</span>
                <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="charts">
                <ul class="nav flex-column sub-menu">
                    <li class="nav-item"><a class="nav-link" href="/DepartmentAdd.aspx">Create Department</a></li>
                    <li class="nav-item"><a class="nav-link" href="/DepartmentRecord.aspx">View Department Record</a></li>
                </ul>
            </div>
        </li>
        <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#auth" aria-expanded="false" aria-controls="auth">
                <i class="icon-head menu-icon"></i>
                <span class="menu-title">Staff</span>
                <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="auth">
                <ul class="nav flex-column sub-menu">
                    <li class="nav-item"><a class="nav-link" href="/StaffAdd.aspx">Add Staff</a></li>
                    <li class="nav-item"><a class="nav-link" href="/StaffRecord.aspx">View Staff Record</a></li>
                </ul>
                </div>
                </li>
                
            <li class ="nav-item">
                 <a class="nav-link" data-toggle="collapse" href="#auths" aria-expanded="false" aria-controls="auths">
                <i class="icon-head menu-icon"></i>
                <span class="menu-title">Student</span>
                <i class="menu-arrow"></i>
            </a>
             <div class="collapse" id="auths">
                <ul class="nav flex-column sub-menu">
                    <li class="nav-item"><a class="nav-link" href="/StudentAdd.aspx">Add Student</a></li>
                    <li class="nav-item"><a class="nav-link" href="/StudentRecord.aspx">View Student Record</a></li>
                </ul>
            </div>
                </li>
       
 
        

    </ul>
</nav>