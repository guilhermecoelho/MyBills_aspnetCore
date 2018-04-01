
namespace MyBills.API.Helper
{
    public class Constants
    {
        public enum HttpStatusCode : long
        {
            BadRequest = 400,
            NotFound = 404,
            InternalServerError = 500,
            Ok = 200
        }
    }
}
