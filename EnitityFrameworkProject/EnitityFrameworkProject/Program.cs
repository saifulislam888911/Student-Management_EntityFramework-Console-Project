using EnitityFrameworkProject;





ApplicationDbContext context = new ApplicationDbContext();



/* .................... Operation : Insert .................... */
#region Insert to the table (Hard-code)

//Student student = new Student();
//student.Name = "Mr. AAA";
//student.Cgpa = 4.00;
//student.DateOfBirth = new DateTime(2000, 01, 13);

//context.CollegeStudents.Add(student);


//context.CollegeStudents.Add(new Student 
//{ 
//    Name = "Mr. BBB",
//    Cgpa = 3.9,
//    DateOfBirth = new DateTime(2000, 12, 01)
//});


//context.CollegeStudents.Add(new Student
//{ 
//    Name = "Mr. CCC",
//    Cgpa = 3.89,
//    DateOfBirth = new DateTime(2000, 12, 13)
//});


//context.CollegeStudents.Add(new Student
//{
//    Name = "Mr. D"
//});



//context.SaveChanges();

//Console.WriteLine("Insert Successful...");

#endregion



/* .................... Operation : Fetch (Display Full Table) .................... */
#region Operation : Select (Fetch Data) 

Console.WriteLine("Display Full Table:");

List<Student> students = context.CollegeStudents.ToList();

foreach (var student in students)
{
    Console.WriteLine($"ID : {student.Id} , Name : {student.Name} , CGPA : {student.Cgpa} , DateOfBirth : {student.DateOfBirth} , Address : {student.Address} .");
}
Console.Write("\n");



/* .................... Operation : Fetch (Specific Data) .................... */

Console.WriteLine("Select Operation: Fetch (Specific Data): ToList()");

List<Student> students1 = context.CollegeStudents.Where(x => x.Cgpa >= 3.90).ToList();

foreach (var student in students1)
{
    Console.WriteLine($"ID : {student.Id} , Name : {student.Name} , CGPA : {student.Cgpa} , DateOfBirth : {student.DateOfBirth} , Address : {student.Address} .");
}
Console.Write("\n");


List<Student> students11 = context.CollegeStudents.Where(x => x.Cgpa <= 3.90 && x.DateOfBirth > new DateTime(2000, 01, 01)).ToList();

foreach (var student in students11)
{
    Console.WriteLine($"ID : {student.Id} , Name : {student.Name} , CGPA : {student.Cgpa} , DateOfBirth : {student.DateOfBirth} , Address : {student.Address} .");
}
Console.Write("\n");



Console.WriteLine("Select Operation: Fetch (Specific Data): First()");

try
{
    Student students2 = context.CollegeStudents.Where(x => x.Cgpa >= 3.90).First();

    Console.WriteLine($"ID : {students2.Id} , Name : {students2.Name} , CGPA : {students2.Cgpa} , DateOfBirth : {students2.DateOfBirth} , Address : {students2.Address} .");

    if (students2.Address == "" || students2.Address == null)
    {   
        students2.Address = "Mirpur";

        context.SaveChanges();

        Console.WriteLine("Update Successful...");

        Console.WriteLine($" After Edit :\n ID : {students2.Id} , Name : {students2.Name} , CGPA : {students2.Cgpa} , DateOfBirth : {students2.DateOfBirth} , Address : {students2.Address} .");
    }
}
catch(Exception e)
{
    Console.WriteLine("For First() : " + e.Message);
}
Console.Write("\n");



Console.WriteLine("Select Operation: Fetch (Specific Data): FirstOrDefault()");

Student? students3 = context.CollegeStudents.Where(x => x.Cgpa >= 3.90).FirstOrDefault();

Console.WriteLine($"ID : {students3.Id} , Name : {students3.Name} , CGPA : {students3.Cgpa} , DateOfBirth : {students3.DateOfBirth} , Address : {students3.Address} .");

Console.Write("\n");



Console.WriteLine("Select Operation: Fetch (Specific Data): Single()");

try
{
    Student students4 = context.CollegeStudents.Where(x => x.Cgpa >= 3.90).Single();

    Console.WriteLine($"ID : {students4.Id} , Name : {students4.Name} , CGPA : {students4.Cgpa} , DateOfBirth : {students4.DateOfBirth} , Address : {students4.Address}  .");
}
catch(Exception e)
{
    Console.WriteLine("For Single() : " + e.Message);
}
Console.Write("\n");



Console.WriteLine("Select Operation: Fetch (Specific Data): SingleOrDefault()");

try
{
    Student? students5 = context.CollegeStudents.Where(x => x.Cgpa >= 3.90).SingleOrDefault();

    Console.WriteLine($"ID : {students5.Id} , Name : {students5.Name} , CGPA : {students5.Cgpa} , DateOfBirth : {students5.DateOfBirth} , Address : {students5.Address}  .");
}
catch (Exception e)
{
    Console.WriteLine("For SingleOrDefault() : " + e.Message);
}
Console.Write("\n");

#endregion



/* .................... Operation : Delete .................... */

Student? sd1 = context.CollegeStudents.Where(x => x.Id == 1).FirstOrDefault();

if(sd1 != null)
{
    context.CollegeStudents.Remove(sd1);

    context.SaveChanges();

    Console.WriteLine("Delete Successful...");
}

