using System;

// Seth Burgett
// 9/15/22
// This program will calculate 5 homework grades, 3 Quiz grades and 2 exam grades for n students.
// Final grades are worth the sum of 50% of homework Average, 30% quiz average and 20% of exam average.
// Will calculate final letter grade.

namespace GradeCalculator
{
    class Program
    {
 
    static int NumberInput()
    {
        Console.WriteLine("How Many Students are you grading?");
        int input = Convert.ToInt32(Console.ReadLine());
        return input;
    }

    //ask for student name. Return a variable name = NameInput()
    //Loop until gives valid input.
    static string NameInput()
    {
        Console.WriteLine("Please enter Student name.");
        string input = Console.ReadLine();
        return input;
    }


    static double Homework(string name)  //Passes Homework, Quiz, and Exams through homework.
    {
        int h = 0;
        int q = 0;
        int e = 0;
        double weightedTotal = 0;

        //Passes # of assignments and named String into Grader.
        h = Grader(5, " Homework "); //maybe return a double??
        q = Grader(3, " Quiz ");
        e = Grader(2, " Exam ");
        Console.WriteLine(name + "'s " + " Homework Average: " + h);
        Console.WriteLine(name + "'s " + " Quiz Average: " + q);
        Console.WriteLine(name + "'s" + " Exam Average: " + e);
        weightedTotal = WeightApplier(h, q, e);
        Console.WriteLine(name + "'s Weighted Total: " + weightedTotal);

        return weightedTotal;
   
    }

        //Takes # of Assignments and assignment type
    static int Grader(int typeCount, string homeQuizExam) 
    {
        //Establishes some variables for the up coming loop
        int grade1 = 1;     //Counter integer. Increments until +1 until == typeCount
        int workGrade = 0;  //Initiated to read user input within loop
        int workTotal = 0;  //Initiated to sum user inputs within loop

        for (int i = 0; i < typeCount; i++)                             //Run the grade method typeCount times
        {   
            do
            {
                Console.WriteLine("Enter " + homeQuizExam + grade1);        //Prompts user, receives type string from second argument in Method(int, string)      
                workGrade = Convert.ToInt32(Console.ReadLine());            //Sets workGrade to user input.
                if (workGrade < 0 || workGrade > 100)
                {
                    Console.WriteLine("Please enter grade between 0 and 100.");
                }
            }
            while(workGrade < 0 || workGrade > 100);
            
            workTotal = workGrade + workTotal;                          //Total inputs together.
            grade1++;

        }           
            
        int workAverage = workTotal / typeCount;    // Creates average of total work
        return workAverage;                         //Saves value of workAverage
    }


    static double WeightApplier(double homeworkAverage, double quizAverage, double examAverage) //Takes each average and weights it.
    {
        double weightedTotal  = (homeworkAverage * .5) + (quizAverage * .3) + (examAverage * .2);   //weighs & sums
        return weightedTotal;                                                                       //saves value of weighted total
    }

    //Takes result of weighted total as argument and passes through if/else. Outputs result as Character.
    //Should output name. 
    static char LetterGrade(string name, double number)
    {
        char letterGrade = '0';
        if (number >= 90)
        {
            Console.WriteLine(name + " receives an " + 'A');
            letterGrade = 'A';
        }
        else if(number >= 80)
        {
            Console.WriteLine(name + "receives a "+ 'B');
            letterGrade = 'B';
        }
        else if(number >= 70)
        {
            Console.WriteLine(name + " receives a " + 'C');
             letterGrade = 'C';
        }
        else if(number >= 60)
        {
            Console.WriteLine(name + "receives a " + 'D');
             letterGrade = 'D';
        }
        else if (number < 60)
        {
            Console.WriteLine(name + " receives an " + 'F');
             letterGrade = 'F';
        }
        return letterGrade;
    }



    //Ask user for input. Plug input into Homework()
    static void Main(string[] args)
    {
        //number = number sets how many students there are to grade.
        double number = NumberInput();
        //remainder verifies a number > 1.
        //Loops as many times as user inputs for Number of Students
        int looper = 0;
            do
            {                
                do
                {
                    for(int i = 0; i < number; i++) //Loops bases on number of students entered.
                    {
                        string name = NameInput();
                        double grade = Homework(name);
                        char finalGrade = Convert.ToChar(LetterGrade(name, grade));
                        looper++;
                    }
                    
                    if (number < 1)
                    {
                        Console.WriteLine("Please enter a # greater than 0.");
                        number = NumberInput();
                    }
                }while (number >= 1 & number > looper); //Verify entry is within requirements.

            }while (looper < number);
       

    }

    
    
    }




}

