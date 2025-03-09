using FileSource.EndPoints.Handlers;
using MediatR;
using System;

namespace FileSource.EndPoints.Commands.Licenses.Delete
{
    public class DeleteLicenseCommand : IRequest<BaseResponse>
    {
        public Guid LicenseId { get; set; }
    }
}
