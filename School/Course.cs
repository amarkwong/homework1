using System;
namespace School
{
    public class Course
    {
        public int maxStudent = 6;
        public int credit = 2;
        public String courseName;

        public Course(String name)
        {
            this.courseName = name;
            this.credit = 2;
            this.maxStudent = 6;
        }
        public Course(String name, int max, int credit)
        {
            this.courseName = name;
            this.maxStudent = max;
            this.credit = credit;
        }
        public Course(String name, int max)
        {
            this.courseName = name;
            this.maxStudent = max;
            this.credit = 2;
        }
        public Course(int credit, String name)
        {
            this.credit = credit;
            this.courseName = name;
            this.maxStudent = 6;
        }
        public void setCredit(int credit)
        {
            this.credit = credit;
        }
        public void setMaxStudent(int maxStudent)
        {
            this.maxStudent= maxStudent;
        }
        public int getCredit()
        {
            return this.credit;

        }
        public int getMaxStudent()
        {
            return this.maxStudent;
        }
    }
}
