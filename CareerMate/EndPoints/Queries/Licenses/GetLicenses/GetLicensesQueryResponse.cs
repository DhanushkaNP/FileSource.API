using FileSource.EndPoints.Handlers;
using FileSource.Models.Entities.Licenses;
using System.Collections.Generic;

namespace FileSource.EndPoints.Queries.Licenses.GetLicenses
{
    public class GetLicensesQueryResponse : BaseResponse
    {
        public GetLicensesQueryResponse() : base(200)
        {
        }

        public List<License> Items { get; set; }
    }
}
