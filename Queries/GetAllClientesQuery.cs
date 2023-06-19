using MediatR;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Queries;

public class GetAllClientesQuery : IRequest<IEnumerable<Cliente>>
{
}
