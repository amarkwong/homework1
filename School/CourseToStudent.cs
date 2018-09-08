using System;
namespace School
{
    public class CourseToStudent
    {
        public Student student;
        public Course course;
        //maybe private next
        public int grade;

        public CourseToStudent(Student student,Course course)
        {
            this.student = student;
            this.course = course;
        }
        public CourseToStudent(Student student, Course course, int grade)
        {
            this.student = student;
            this.course = course;
            this.grade = grade;
        }
        public int getGrade()
        {
            return this.grade;
        }
        public void setGrade(int g)
        {
            this.grade = g;
        }
    }
}
