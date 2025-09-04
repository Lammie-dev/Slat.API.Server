using Slat.API.Server.DataModels;

namespace Slat.API.Server.Services
{
    public class LecturrerService
    {
        private readonly ApplicationDbContext context;
        public LecturrerService(ApplicationDbContext context)
        {
            this.context = context;
        }
     
        public OperationResult CreatedLecturer(LecturerCredentials lecturerCredentials)
        {
            var createLecturer = new LecturerDataModel
            {
                id = Guid.NewGuid(),
                FirstName = lecturerCredentials.FirstName,
                LastName = lecturerCredentials.LastName,
                Email = lecturerCredentials.Email,
                PhoneNumber = lecturerCredentials.PhoneNumber,
                DateCreated = DateTime.Now

            };
            context.Lecturer.Add(createLecturer);
          
            context.SaveChanges();

            return new OperationResult
            {
                Result = createLecturer
            };

        }

        public OperationResult GetLecturer(Guid id)

        { 
            var LecturerId = context.Lecturer.FirstOrDefault( l => l.id == id);
            if ( LecturerId == null )
            {
                return new OperationResult
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"Lecturer {id} can't be found. Check the ID and try again"
                };
            }
            return new OperationResult
            {
                Result = LecturerId
            };

        }

        public OperationResult AllLecturer ()
        {
            var GetAllLecturer = context.Lecturer.ToList();
          

            return new OperationResult
            {
                Result = GetAllLecturer
            };
        }


        public OperationResult RemoveLecturer(Guid id)
        {
            var lecturer = context.Lecturer.Find(id);
            if (lecturer == null)
            {
                return new OperationResult
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Lecturer can not be found"
                };
            }

            context.Lecturer.Remove(lecturer);
            context.SaveChanges();

            return new OperationResult
            {
                StatusCode = StatusCodes.Status200OK,
                Result = "Lecturer removed successfully."
                
            };
        }

        public OperationResult UpdateLecturer(Guid id, LecturerCredentials updatedLecturer)
        {
            var lecturer = context.Lecturer.Find(id);
            if (lecturer == null)
            {
                return new OperationResult
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Lecturer can not be found"
                };
            }

          
            lecturer.FirstName = updatedLecturer.FirstName;
            lecturer.LastName = updatedLecturer.LastName;
            lecturer.Email = updatedLecturer.Email;
            lecturer.PhoneNumber = updatedLecturer.PhoneNumber;


            context.SaveChanges();

            return new OperationResult
            {
                StatusCode = StatusCodes.Status200OK,
                Result = "Lecturer updated successfully."
            };
        }



    }
}
