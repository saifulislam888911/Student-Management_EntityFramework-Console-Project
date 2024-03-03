using EnitityFrameworkProject;





//Student student = new Student();
//student.Name = "Mr. AAA";
//student.Cgpa = 4.00;
//student.DateOfBirth = new DateTime(2000, 01, 13);

ApplicationDbContext context = new ApplicationDbContext();



/* .................... Operation : Insert .................... */
#region Insert to the table (Hard-code)

/* [Note: "Student"class's object "student" properties' value will be added in
          "DbSet<Student> CollegeStudents" generic class's property.]
*/
//context.CollegeStudents.Add(student);



/* [Note: In "DbSet<Student> CollegeStudents" generic class's property, 
          we call "Add" method and in the parameter we  
          directly creating "Student"class's object 
          and directly provide the value to the properties.]
*/
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





/* [Note: * "context.SaveChanges()" method is used for write-operation. 
          * After writing all the codes for adding,editing,deleting data in database, 
            this method is written once at the end to execute all the crud codes & SaveChanges for write-operation.]
*/
//context.SaveChanges();

#endregion



/* .................... Operation : Fetch (Display Full Table) .................... */
#region Operation : Select (Fetch Data) 

Console.WriteLine("Display Full Table:");

/* [Note: * "ToList()" will fetch full data of the table.
          * "Student" Entity Class is passed as Generic Parameter in "List<Student>" type Collection class,
            "List<Student> students" variable's datatype is "List<Student>" type,
            full table the will be stored in "students".]
*/
List<Student> students = context.CollegeStudents.ToList();

foreach (var student in students)
{
    Console.WriteLine($"ID : {student.Id} , Name : {student.Name} , CGPA : {student.Cgpa} , DateOfBirth : {student.DateOfBirth} , Address : {student.Address} .");
}
Console.Write("\n");



/* .................... Operation : Fetch (Specific Data) .................... */

Console.WriteLine("Select Operation: Fetch (Specific Data): ToList()");

/* [Note: * "Where(x => x.Cgpa >= 3.90)" lamda method, Linq Query.
          * "ToList()":fetched data will be converted into List.
          * "ToList()" is used For Fetching more than 1 data.]
*/
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
    /* [Note: * "First()" will select the 1st matched Data from Table.
          * If there is no data//null , it will show error. 
          * Data Type : Entity Class "Student" Data Type variable "students2".]
    */
    Student students2 = context.CollegeStudents.Where(x => x.Cgpa >= 3.90).First();

    Console.WriteLine($"ID : {students2.Id} , Name : {students2.Name} , CGPA : {students2.Cgpa} , DateOfBirth : {students2.DateOfBirth} , Address : {students2.Address} .");

    if (students2.Address == "" || students2.Address == null)
    {   
        students2.Address = "Mirpur";

        context.SaveChanges();

        Console.WriteLine($" After Edit :\n ID : {students2.Id} , Name : {students2.Name} , CGPA : {students2.Cgpa} , DateOfBirth : {students2.DateOfBirth} , Address : {students2.Address} .");
    }
}
catch(Exception e)
{
    Console.WriteLine("For First() : " + e.Message);
}
Console.Write("\n");



Console.WriteLine("Select Operation: Fetch (Specific Data): FirstOrDefault()");

/* [Note: * "FirstOrDefault()" will select the 1st matched Data from Table.
          * If there is no data//null , it will not show error.
            it will return default value//null.
          * "Student?" data type should be declared nullable"?".]
*/
Student? students3 = context.CollegeStudents.Where(x => x.Cgpa >= 3.90).FirstOrDefault();

Console.WriteLine($"ID : {students3.Id} , Name : {students3.Name} , CGPA : {students3.Cgpa} , DateOfBirth : {students3.DateOfBirth} , Address : {students3.Address} .");

Console.Write("\n");



Console.WriteLine("Select Operation: Fetch (Specific Data): Single()");

try
{
    /* [Note: * "Single()" will select the 1st matched and only single Data from Table.
          * If there is no data//null Or More than 1 result,
            it will show error.]
    */
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
    /* [Note: * "SingleOrDefault()" will select the 1st matched and only single Data from Table.
          * If there is More than 1 result//Data,
            it will show error.
          * If there is no data//null , it will not show error.
            it will return default value//null.
          * "Student?" data type should be declared nullable"?".]
    */
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

