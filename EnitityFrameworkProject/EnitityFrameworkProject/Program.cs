using EnitityFrameworkProject;





Student student = new Student();
student.Name = "Mr. AAA";
student.Cgpa = 4.00;
student.DateOfBirth = new DateTime(2000, 01, 13);

ApplicationDbContext context = new ApplicationDbContext();



/* [Note: "Student"class's object "student" properties' value will be added in
          "DbSet<Student> CollegeStudents" generic class's property.]
*/
context.CollegeStudents.Add(student);



/* [Note: In "DbSet<Student> CollegeStudents" generic class's property, 
          we call "Add" method and in the parameter we  
          directly creating "Student"class's object 
          and directly provide the value to the properties.]
*/
context.CollegeStudents.Add(new Student 
{ 
    Name = "Mr. BBB",
    Cgpa = 3.9,
    DateOfBirth = new DateTime(2000, 12, 01)
});

context.CollegeStudents.Add(new Student
{ 
    Name = "Mr. CCC",
    Cgpa = 3.89,
    DateOfBirth = new DateTime(2000, 12, 13)
});

context.CollegeStudents.Add(new Student
{
    Name = "Mr. D"
});





/* [Note: * "context.SaveChanges()" method is used for write-operation. 
          * After writing all the codes for adding,editing,deleting data in database, 
            this method is written once at the end to execute all the crud codes & SaveChanges for write-operation.]
*/
context.SaveChanges();