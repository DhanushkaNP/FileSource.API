using FileSource.Abstractions.Models.Queries;
using FileSource.EndPoints.Handlers;
using MediatR;

namespace FileSource.EndPoints.Queries.Licenses.GetLicenses
{
    public class GetLicensesQuery : PagedQuery, IRequest<BaseResponse>
    {
    }
}
