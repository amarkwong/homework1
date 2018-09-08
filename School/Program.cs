using System;

namespace School
{
    class MainClass
    {
        static School school;
        //Main Menu
        public static void studentMenu()
        {
            bool inputIsValid2 = false;
            while (!inputIsValid2)
            {
                Console.Clear();
                Console.WriteLine("STUDENT MANAGEMENT MENU");
                Console.WriteLine("1.Add a student");
                Console.WriteLine("2.Enroll a student to a course");
                Console.WriteLine("3.Remove a student from a course");
                Console.WriteLine("4.Update a student's grade of a course");
                Console.WriteLine("5.Print the GPA");
                Console.WriteLine("6.Print student fee receipt");
                Console.WriteLine("7.Return to previous menu");
                Console.WriteLine("Please choose the number to select a function");
                int choice = InputValidation.checkChoice(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addStudentMenu();
                        break;
                    case 2:
                        enrollStudentMenu();
                        break;
                    case 3:
                        removeStudentMenu();
                        break;
                    case 4:
                        updateStudentGradeMenu();
                        break;
                    case 5:
                        printStudentGPAMenu();
                        break;
                    case 6:
                        generateStudentFeeMenu();
                        break;
                    case 7:
                        //go back to previous menu
                        inputIsValid2 = true;
                        break;
                    default:
                        inputIsValid2 = false;
                        break;
                }
            }

        }
        public static void courseMenu()
        {
            bool inputIsValid2 = false;
            while (!inputIsValid2)
            {
                Console.Clear();
                Console.WriteLine("COURSE MANAGEMENT MENU");
                Console.WriteLine("1.Add a course");
                Console.WriteLine("2.Remove a course");
                Console.WriteLine("3.Show a course detail");
                Console.WriteLine("4.Update a course detail");
                Console.WriteLine("5.Print all course overview");
                Console.WriteLine("6.Return to previous menu");
                Console.WriteLine("Please choose the number to select a function");
                int choice = InputValidation.checkChoice(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addCourseMenu();
                        inputIsValid2 = true;
                        break;
                    case 2:
                        removeCourseMenu();
                        inputIsValid2 = true;
                        break;
                    case 3:
                        showCourseMenu();
                        inputIsValid2 = true;
                        break;
                    case 4:
                        updateCourseMenu();
                        break;
                    case 5:
                        printAllCourseMenu();
                        break;
                    case 6:
                        inputIsValid2 = true;
                        break;
                    default:
                        break;
                }
            }
        }



        //Course Menu
        public static void addCourseMenu()
        {
            Console.Clear();
            Console.WriteLine("ADD A COURSE");
            Console.WriteLine("Please input the course name");
            String courseName = Console.ReadLine();
            //Course name check, maybe later
            Console.WriteLine("Please input the course credit");
            int courseCredit = InputValidation.checkCredit(Console.ReadLine());
            Console.WriteLine("Please input the number of max student");
            int courseMaxStudent = InputValidation.checkMaxStudent(Console.ReadLine());

            if (courseCredit == -1 && courseMaxStudent == -1)
            {
                school.addCourse(courseName);
            }
            else
            {
                if (courseMaxStudent == -1)
                {
                    school.addCourse(courseCredit, courseName);
                }
                else
                {
                    if (courseCredit == -1)
                    {
                        school.addCourse(courseName, courseMaxStudent);
                    }
                    else
                    {
                        school.addCourse(courseName, courseMaxStudent, courseCredit);
                    }
                }
            }
            Console.WriteLine("Done");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static void removeCourseMenu()
        {
            Console.Clear();
            Console.WriteLine("REMOVE A COURSE");
            Console.WriteLine("Please input the course name");
            String courseName = Console.ReadLine();
            try
            {
                school.removeCourse(courseName);
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static void showCourseMenu()
        {
            //SHOW MENU
            Console.WriteLine("SHOW A COURSE DETAIL");
            Console.WriteLine("Please input the course name");
            String courseName = Console.ReadLine();
            try
            {
                school.showCourseDetail(courseName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Done");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static void updateCourseMenu()
        {
            Console.Clear();
            Console.WriteLine("Please input the course name:");
            String courseName = Console.ReadLine();
            Console.WriteLine("Please input the course credit:");
            int credit = InputValidation.checkCredit(Console.ReadLine());
            Console.WriteLine("Please input the course max student:");
            int maxStudent = InputValidation.checkCredit(Console.ReadLine());
            school.updateCourse(courseName,credit,maxStudent);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static void printAllCourseMenu()
        {
            Console.Clear();
            school.printAllCourse();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }



        public static void addStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("ADD A STUDENT");
            Console.WriteLine("Please input the student name");
            String studentName = Console.ReadLine();
            Console.WriteLine("Please input the credit limit of the student, enter for the default value");
            int studentCreditLimit = InputValidation.checkCreditLimit(Console.ReadLine());
            if (studentCreditLimit == -1)
            {
                school.addStudent(studentName);
            }
            else
            {
                school.addStudent(studentName, studentCreditLimit);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static void generateStudentFeeMenu()
        {
            Console.Clear();
            Console.WriteLine("PRINT STUDENT FEE");
            Console.WriteLine("Please input the student name");
            String studentName = Console.ReadLine();
            school.printFee(studentName);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static void enrollStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("ENROLL A STUDENT");

            Console.WriteLine("Please input the student name");
            String studentName = Console.ReadLine();
            school.printAllCourse();
            Console.WriteLine("Which course you would like to get enrolled? please input the course name");
            String courseName = Console.ReadLine();
            school.enrollStudent(studentName, courseName);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }
        public static void removeStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("REMOVE A STUDENT");
            Console.WriteLine("Please input the student name");
            String studentName = Console.ReadLine();
            Console.WriteLine("Please input the course name");
            String courseName = Console.ReadLine();
            school.removeStudent(studentName, courseName);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }
        public static void updateStudentGradeMenu()
        {
            Console.Clear();
            Console.WriteLine("UPDATE STUDENT GRADE");
            Console.WriteLine("Please input the student name");
            String studentName = Console.ReadLine();
            school.printCourseShort(studentName);
            Console.WriteLine("Please input the course name");
            String courseName = Console.ReadLine();
            Console.WriteLine("Please input the grade");
            int grade = InputValidation.checkGrade(Console.ReadLine());
            school.updateStudentGrade(studentName, courseName,grade);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static void printStudentGPAMenu()
        {
            Console.Clear();
            Console.WriteLine("Please input the GPA range you want to check(eg.4)");
            int gPARange = InputValidation.checkGPARange(Console.ReadLine());
            if (gPARange == -1)
            {
                school.printGPA();
            }
            else
            {
                school.printGPA(gPARange);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }



        public static void Main(string[] args)
        {
            school = new School();
            seed();
            bool inputIsValid1 = false;
            while (!inputIsValid1)
            {

                //
                Console.Clear();

                Console.WriteLine("SCHOOL MANAGE SYSTEM");
                Console.WriteLine("1.Course management menu");
                Console.WriteLine("2.Student management menu");
                Console.WriteLine("3.Quit");
                Console.WriteLine("Please choose the number to select a menu");
                int choice = InputValidation.checkChoice(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        courseMenu();
                        break;
                    case 2:
                        studentMenu();
                        break;
                    case 3:
                        inputIsValid1 = true;
                        break;
                }

            }
        }
        //Data initialization
        public static void seed()
        {
            school.addCourse("FINM7401",2,10);
            school.addCourse("MATH7039",2,10);
            school.addCourse("STAT7304",2,3);
            school.addCourse("CSSE2310",2,6);
            school.addCourse("MATH7091",4,8);

            school.addStudent("Tony", 8);
            school.addStudent("Adam", 8);
            school.addStudent("Barney", 8);
            school.addStudent("Robin", 8);
            school.addStudent("Ted", 10);
            school.addStudent("Lily", 10);
            school.addStudent("Mathew", 10);
            school.addStudent("David", 12);

            school.addCourseToStudents("FINM7401", "Tony", 4);
            school.addCourseToStudents("FINM7401", "Adam", 5);
            school.addCourseToStudents("FINM7401", "Barney", 5);
            school.addCourseToStudents("FINM7401", "Robin", 6);
            school.addCourseToStudents("FINM7401", "Mathew", 6);
            school.addCourseToStudents("FINM7401", "Ted", 7);

            school.addCourseToStudents("MATH7039", "David", 5);
            school.addCourseToStudents("MATH7039", "Ted", 7);
            school.addCourseToStudents("MATH7039", "Lily", 5);
            school.addCourseToStudents("MATH7039", "Adam", 4);

            school.addCourseToStudents("MATH7091", "Mathew", 6);
            school.addCourseToStudents("MATH7091", "Robin", 7);
            school.addCourseToStudents("MATH7091", "Lily", 6);
            school.addCourseToStudents("MATH7091", "Ted", 7);
            school.addCourseToStudents("MATH7091", "Adam", 5);

            school.addCourseToStudents("CSSE2310", "Tony", 5);
            school.addCourseToStudents("CSSE2310", "Barney", 6);
            school.addCourseToStudents("CSSE2310", "Lily", 6);
            school.addCourseToStudents("CSSE2310", "Ted", 7);
            school.addCourseToStudents("CSSE2310", "Robin", 6);

            school.addCourseToStudents("STAT7304", "David", 3);
            school.addCourseToStudents("STAT7304", "Ted", 7);
            school.addCourseToStudents("STAT7304", "Mathew", 6);
        }

    }
}


