using Microsoft.AspNetCore.Http.HttpResults;

namespace Slat.API.Server
{
    public class StudentService
    {
        private readonly ApplicationDbContext context;

        public StudentService(ApplicationDbContext context)
        {
            this.context = context;  
        }

        public OperationResult CreateStudent(StudentCredentials studentCredentials)
        {
            var student = new StudentDataModel
            {
                Id = Guid.NewGuid(),
                FirstName = studentCredentials.FirstName,
                LastName = studentCredentials.LastName,
                MatricNumber = studentCredentials.MatricNumber,
                PhoneNumber = studentCredentials.PhoneNumber,
                Email = studentCredentials.Email,
                DateCreated = DateTime.UtcNow
            };

            context.Students.Add(student);
            context.SaveChanges();

            return new OperationResult
            {
                Result = student
               
            };
        }

        public OperationResult GetStudent(Guid id) 
        {
            var student = context.Students.FirstOrDefault(x => x.Id == id);

            if (student == null) {

                return new OperationResult
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Student Id can't be found. Please check the Id and try again."
                };
            }

            return new OperationResult
            {
                Result = student
            };
        }

        public OperationResult GetAllStudent()
        {
           var getAllStudent = context.Students.ToList();
           
            return new OperationResult { 
            Result = getAllStudent
            };

        }


        public OperationResult RemoveStudent(Guid id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return new OperationResult
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Student can not be found"
                };
            }

            context.Students.Remove(student);
            context.SaveChanges();

            return new OperationResult
            {
                StatusCode = StatusCodes.Status200OK,
                Result = "Student removed successfully."

            };
        }

        public OperationResult UpdateStudent(Guid id,StudentCredentials studentCredentials)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return new OperationResult
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Student can not be found"
                };
            }


            student.FirstName = studentCredentials.FirstName;
            student.LastName = studentCredentials.LastName;
            student.MatricNumber = studentCredentials.MatricNumber;
            student.Email = studentCredentials.Email;
            student.PhoneNumber = studentCredentials.PhoneNumber;


            context.SaveChanges();

            return new OperationResult
            {
                StatusCode = StatusCodes.Status200OK,
                Result = "Student updated successfully."
            };
        }


    }
}
