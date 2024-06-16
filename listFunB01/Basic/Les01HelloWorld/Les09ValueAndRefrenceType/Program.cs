/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");*/

namespace Les09ValueAndRefrenceType
{
    class Student
    {
        public string StudentName { get; set; }
    }

    public class Program
    {
        /**
         * trong truong hop nay bien x la bien tham tri, nen gia tri cua bien x chi nam o trong ham, chu khong co anh huong ra ben ngoai
         */
        public static void Change(int x)
        {
            x = 200;
            Console.WriteLine(x);
        }

         static void ChangeReference(Student st2)
        {
            st2.StudentName = "Jack";
        }

        public static void Main(string[] args)
        {
           /* int i = 100;
            Console.WriteLine(i);
            Change(i);
            Console.WriteLine(i);*/

            Student student = new Student();
            student.StudentName = "Bill";

            ChangeReference(student);

            Console.WriteLine(student.StudentName);
            Console.ReadLine();
        }
    }
}
