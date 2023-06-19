using MediatR;
using crud_cqrs_pattern_mediatr.Data;
using crud_cqrs_pattern_mediatr.Models;
using crud_cqrs_pattern_mediatr.Queries;

namespace crud_cqrs_pattern_mediatr.Handlers;

public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, IEnumerable<Cliente>>
{
    public Task<IEnumerable<Cliente>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
    {
        using var context = new AppDbContextRead();
        
        return Task.FromResult<IEnumerable<Cliente>>(context.Clientes.ToList());
    }
}
