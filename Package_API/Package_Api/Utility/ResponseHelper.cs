using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Package_Api.Utility
{
    public static class ResponseHelper
    {
        // Method to handle database connection or unexpected errors
        public static ActionResult HandleDatabaseError(Exception ex)
        {
            if (ex is SqlException)
            {
                return new ObjectResult("Database connection error.")
                {
                    StatusCode = 500
                };
            }

            return new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = 500
            };
        }
        public static ActionResult HandleNoResult()
        {
            return new ObjectResult("No Results on these searchcriterias");
        }
    }
}
