using System;
using System.Collections.Generic;

namespace School
{
    public class Student
    {
        public String name;
        public int currentCredit;
        public int creditLimit;
        private double GPA;

        public Student(String name)
        {
            this.name = name;
        }
        public Student(String name, int creditLimit)
        {
            this.name = name;
            this.creditLimit = creditLimit;
        }
        public void setGPA(double gpa)
        {
            this.GPA = gpa;
        }
        public double getGPA()
        {
            return this.GPA;
        }
    }
}

