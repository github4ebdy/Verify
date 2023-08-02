using System.Net;

namespace Common.Utility
{
    public class HttpResponseCode
    {
        public static int HttpStatusCode_Ok
        {
            get => (int)HttpStatusCode.OK;
        }

        public static int HttpStatusCode_BadRequest
        {
            get => (int)HttpStatusCode.BadRequest;
        }

        public static int HttpStatusCode_Created
        {
            get => (int)HttpStatusCode.Created;
        }

        public static int HttpStatusCode_InternalServerError
        {
            get => (int)HttpStatusCode.InternalServerError;
        }


        public static int HttpStatusCode_ValidationError
        {
            get => 422;
        }

        public static int HttpStatusCode_NotFound
        {
            get => 404;
        }

        public static int HttpStatusCode_Unauthorised
        {
            get => 401;
        }
    }
}