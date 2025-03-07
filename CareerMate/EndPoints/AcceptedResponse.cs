using Microsoft.AspNetCore.Http;

namespace CareerMate.EndPoints.Handlers
{
    public class AcceptedResponse : BaseResponse
    {
        public AcceptedResponse(string id)
            : base(StatusCodes.Status202Accepted)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
