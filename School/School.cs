using System;
using System.Collections.Generic;
using System.Linq;


namespace School
{
    public class School
    {
        public List<Student> students;
        public List<Course> courses;
        public List<CourseToStudent> courseToStudents;

        public School()
        {
            this.students = new List<Student>();
            this.courses = new List<Course>();
            this.courseToStudents= new List<CourseToStudent>();

        }
        /****************************************/
        /*      Course related methods          */
        /****************************************/
        //Add Course with overloading
        public int addCourse(String className)
        {
            Course course = new Course(className);
            courses.Add(course);
            return 0;
        }
        public int addCourse(String className,int maxStudent)
        {
            Course course = new Course(className,maxStudent);
            courses.Add(course);
            return 0;
        }
        public int addCourse(int credit,String className)
        {
            Course course = new Course(credit, className);
            courses.Add(course);
            return 0;
        }
        public int addCourse(String className, int credit,int maxStudent)
        {
            Course course = new Course(className,maxStudent,credit);
            courses.Add(course);
            return 0;

        }
        //Remove a course
        public void removeCourse(String name)
        {
            int courseIndex = courses.FindIndex(i => (i.courseName == name));
            if (courseIndex == -1)
            {
                Console.WriteLine("Course " + name + " doesn't exist");
            }
            else{
                courses.RemoveAt(courseIndex);
            }
        }
        //update a course's max student and credit
        public int updateCourse(String courseName,int credit, int maxStudent)
        {
            int courseIndex = courses.FindIndex(i => i.courseName == courseName);
            courses[courseIndex].setCredit(credit);
            courses[courseIndex].setMaxStudent(maxStudent);
            return 0;

        }
        //print short student list of a course
        public int printStudentShort(String courseName)
        {
            List<CourseToStudent> result = courseToStudents.FindAll(i => (i.course.courseName == courseName));
            foreach (CourseToStudent c2s in result)
            {
                Console.WriteLine(c2s.student.name);
            }
            return 0;
        }
        //print all course
        public int printAllCourse()
        {
            foreach (Course course in courses)
            {
                Console.WriteLine(course.courseName);
            }
            return 0;
        }
        //Show a course detail
        public void showCourseDetail(String courseName)
        {
            Console.Clear();
            int courseIndex = courses.FindIndex(i => i.courseName == courseName);
            if (courseIndex == -1)
            {
                Console.WriteLine("Course " + courseName + " doesn't exist!");
            }
            else
            {
                Console.WriteLine("Course " + courseName);
                Console.WriteLine("Credit " + courses[courseIndex].credit);
                Console.WriteLine("Max student "+ courses[courseIndex].maxStudent);
                //maybe list all the enroll student 
            }
        }
        /****************************************/
        /*      Student related methods         */
        /****************************************/

        //add student method with overloading
        public int addStudent(String name)
        {
            Student student = new Student(name);
            students.Add(student);
            return 0;
        }
        public int addStudent(String name,int creditLimit)
        {
            Student student = new Student(name,creditLimit);
            students.Add(student);
            return 0;
        }

        //enroll a student in a course
        public int enrollStudent(String studentName,String courseName)
        {
            int studentIndex = students.FindIndex(i => i.name == studentName);
            int courseIndex = courses.FindIndex(i => i.courseName == courseName);
            //check if the student adn course exist
            if (studentIndex == -1)
            {
                Console.WriteLine("Student " + studentName + " doesn't exist, please add the student first");
                return -1;
            }
            if (courseIndex == -1)
            {
                Console.WriteLine("Course " + courseName + " doesn't exist, please add the course first");
                return -1;
            }
            //check the credit limit
            List <CourseToStudent>result = courseToStudents.FindAll(i => (i.student.name == studentName));
            int currentCredit = result.Sum(i => i.course.credit);
            int courseCredit = courses.Find(i => (i.courseName == courseName)).credit;
            if (currentCredit + courseCredit <= students[studentIndex].creditLimit)
            {
                //check the course max student limit
                int enrolledNumber= courseToStudents.FindAll(i => (i.course.courseName == courseName)).Count;
                if (courses[courseIndex].maxStudent >= (enrolledNumber + 1))
                {
                    CourseToStudent courseToStudent = new CourseToStudent(students[studentIndex], courses[courseIndex]);
                    courseToStudents.Add(courseToStudent);
                    return 0;
                }
                else
                {
                    Console.WriteLine("Coures " +courseName + "is going to exceed its max student limit ", courses[courseIndex].maxStudent);
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("Student " + studentName + "is going to exceed his/her credit limit" , students[studentIndex].creditLimit);
                return -1;
            }
        }

        //remove a student from a course
        public int removeStudent(String studentName, String courseName)
        {
            int courseToStudentsIndex = courseToStudents.FindIndex(i => (i.course.courseName == courseName
                                                                         &&i.student.name==studentName));
            //check if the student adn course exist
           if (courseToStudentsIndex == -1)
            {
                Console.WriteLine("Student " + studentName + " didn't enrolled");
                return -1;
            }
            courseToStudents.RemoveAt(courseToStudentsIndex);
            return 0;
        }
        //print short course list of a student
        public int printCourseShort(String studentName)
        {
            List<CourseToStudent> result = courseToStudents.FindAll(i => (i.student.name == studentName));
            foreach (CourseToStudent c2s in result)
            {
                Console.WriteLine(c2s.course.courseName);
            }
            return 0;
        }

        //print student Fee
        public int printFee(String studentName)
        {
            //simple calculation 1 course for 100
            int fee= 100*courseToStudents.FindAll(i => (i.student.name == studentName)).Count;
            Console.WriteLine("Student " + studentName + "'s total fee\t{0,8:c}" , fee);
            return 0;
        }
        //print student GPA with overloading
        public int printGPA()
        {
            Console.Clear();
            Console.WriteLine("STUDENT\t GPA");
            foreach (Student student in students)
            {
                List<CourseToStudent> c2s = courseToStudents.FindAll(item => (item.student == student));
                // try and see which one is more effective
                /*
                for (int i = 0; i < result.Count;i++)
                {
                    //or just coursename== coursename, as the credit in courseToStudents might haven't been set
                    GPA += result[i].course.credit * result[i].grade;
                }
                GPA = GPA / result.Sum(i=>i.course.credit);
                */
                double GPA = (double)c2s.Sum(i => (i.course.credit * i.grade)) / (c2s.Sum(i => i.course.credit));
                student.setGPA(GPA);
                Console.WriteLine(student.name + "\t" ,GPA);
                //Maybe later a sorted version
            }
            return 0;
        }
        public int printGPA(int GPARange)
        {
            Console.Clear();
            Console.WriteLine("STUDENT\t GPA");
            foreach (Student student in students)
            {
                List<CourseToStudent> c2s = courseToStudents.FindAll(item => (item.student == student));
                // try and see which one is more effective
                /*
                for (int i = 0; i < result.Count;i++)
                {
                    //or just coursename== coursename, as the credit in courseToStudents might haven't been set
                    GPA += result[i].course.credit * result[i].grade;
                }
                GPA = GPA / result.Sum(i=>i.course.credit);
                */
                //                double GPA = c2s.Select(i => i.course.credit * i.grade).Sum() / c2s.Sum(i => i.course.credit);
                double GPA = (double)c2s.Sum(i => (i.course.credit* i.grade)) / (c2s.Sum(i => i.course.credit));
                student.setGPA(GPA);
                if (GPA >= GPARange && GPA <= GPARange + 1)
                {
                    Console.WriteLine(student.name + "\t"+ GPA);
                }
                //Maybe later a sorted version
            }
            return 0;
        }
        //update the grade
        public int updateStudentGrade(String studentName,String courseName,int grade)
        {
            int c2sIndex = courseToStudents.FindIndex(i => (i.course.courseName == courseName && i.student.name == studentName));
            courseToStudents[c2sIndex].grade = grade;
            return 0;

        }
       

        //only for seed(),on data validation here
        public int addCourseToStudents(String courseName, String studentName,int grade)
        {
            int courseIndex = courses.FindIndex(i => i.courseName == courseName);
            int studentIndex = students.FindIndex(i => i.name == studentName);
            CourseToStudent courseToStudent = new CourseToStudent(students[studentIndex], courses[courseIndex], grade);
            courseToStudents.Add(courseToStudent);
            return 0;
        }
    }
}
