using BGC.School.Application.EnumType;
using BGC.School.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.EntityFramework.Data
{
    public class DbInit
    {
        public static void Init(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Students.Any())
            {
                var students = new Student[]{
                new Student { Name="bugc", EnrollDate = DateTime.Now},
                new Student { Name="xyj", EnrollDate = DateTime.Now},
                new Student { Name="wee", EnrollDate = DateTime.Now}
            };
                foreach (var s in students)
                {
                    context.Students.Add(s);
                }
            }

            if (!context.Teachers.Any())
            {
                var t1 = new Teacher { Name = "test", EnrollDate = DateTime.Now };
                var t2 = new Teacher { Name = "test", EnrollDate = DateTime.Now };
                context.Teachers.Add(t1);
                context.Teachers.Add(t2);

                if (!context.Department.Any())
                {
                    var d1 = new Department { Name = "test", TeacherId =t1.Id};
                    var d2 = new Department { Name = "test", TeacherId =t2.Id};
                    context.Department.Add(d1);
                    context.Department.Add(d2);
                }
            }

                if (!context.Courses.Any())
            {
                var courses = new Course[] {
                new Course{  Title="数学", Credits=80,DepartmentId=1},
                new Course{  Title="语文", Credits=60,DepartmentId=1},
                new Course{  Title="物理", Credits=40,DepartmentId=1}
            };
                foreach (var c in courses)
                {
                    context.Courses.Add(c);
                }
            }

            context.SaveChanges();

            var enrollments = new Enrollment[] {
                new Enrollment{ StudentId=1,CourseId=1,Grade=CourseGrade.A},
                new Enrollment{ StudentId=2,CourseId=2,Grade=CourseGrade.B},
                new Enrollment{ StudentId=3,CourseId=3,Grade=CourseGrade.C}
            };
            foreach (var e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
