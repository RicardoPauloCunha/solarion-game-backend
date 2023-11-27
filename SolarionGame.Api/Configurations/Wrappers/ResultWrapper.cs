using System.Net;

namespace SolarionGame.Api.Configurations.Wrappers
{
    public class ResultWrapper
    {
        public string Message { get; private set; }
        public HttpStatusCode ResponseStatus { get; private set; }
        public object Result { get; private set; }
        public List<string> Errors { get; private set; }

        public ResultWrapper(string message, HttpStatusCode responseStatus)
        {
            Message = message;
            ResponseStatus = responseStatus;
        }

        public ResultWrapper(string message, HttpStatusCode responseStatus, List<string> errors) : this(message, responseStatus)
        {
            Errors = errors;
        }

        public ResultWrapper(string message, HttpStatusCode responseStatus, object result) : this(message, responseStatus)
        {
            Result = result;
        }

        public static ResultWrapper GenerateMessage(string message, HttpStatusCode responseStatus)
        {
            return new ResultWrapper(message, responseStatus);
        }

        public static ResultWrapper GenerateMessage(string message, HttpStatusCode responseStatus, List<string> errors)
        {
            return new ResultWrapper(message, responseStatus, errors);
        }

        public static ResultWrapper GenerateResult(string message, HttpStatusCode responseStatus, object result)
        {
            return new ResultWrapper(message, responseStatus, result);
        }

        public int GetStatusCode()
        {
            return (int)ResponseStatus;
        }

        public bool IsSuccess()
        {
            bool success = ResponseStatus == HttpStatusCode.OK || ResponseStatus == HttpStatusCode.Created;

            return success;
        }
    }
}
