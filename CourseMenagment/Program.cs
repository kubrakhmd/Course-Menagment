


using CourseManagement;
using CourseMenagment;
CourseService courseservise=new CourseService();

string answer;
do
{


Console.WriteLine("1.Yeni qrup yaradin\n2.Qruplarin siyahisini gosterin\n3.Qrup uzerinde deyisiklik edin\n4.Qrupdaki telebelerin tipini gosterin\n5.Butun telebelerin siyahisini gosterin\n6.Telebe yarat\n\n\n\n 0.Exit");
   answer = Console.ReadLine();
    switch (answer)
    {
        case ("1"):
            courseservise.CreateGroup();
            Console.WriteLine("Grup yarandi");

            break;
        case ("2"):
            courseservise.DisplayGroup();
                    break;
            break;
        case ("3"):
            courseservise.EditGroup();
            break;
        case ("4"):
            courseservise.DisplayStudentsInGroup();
            break;
        case ("5"):
            courseservise.DisplayAllStudents();
            break;
        case ("6"):
            courseservise.CreateStudent();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Yanlish deyer");
            break;
    }
}
while (answer != "0");
