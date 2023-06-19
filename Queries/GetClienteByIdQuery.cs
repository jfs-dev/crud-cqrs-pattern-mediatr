using MediatR;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Queries;

public class GetClienteByIdQuery : IRequest<Cliente>
{
    public int Id { get; set; }
}
