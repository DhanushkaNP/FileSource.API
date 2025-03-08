using FileSource.Abstractions.Enums;
using FileSource.EndPoints.Handlers;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FileSource.EndPoints.Commands.Licenses.Create
{
    public class CreateLicenseCommand : IRequest<BaseResponse>
    {
        [Required(ErrorMessage = "License key required", AllowEmptyStrings = false)]
        public LicenseTypes Type { get; set; }

        [Required(ErrorMessage = "Daily limit required")]
        public int DailyLimit { get; set; }

        [Required(ErrorMessage = "Valid days required")]
        public int ValidDays { get; set; }
    }
}
