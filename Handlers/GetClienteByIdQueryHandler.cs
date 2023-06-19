using MediatR;
using crud_cqrs_pattern_mediatr.Data;
using crud_cqrs_pattern_mediatr.Models;
using crud_cqrs_pattern_mediatr.Queries;

namespace crud_cqrs_pattern_mediatr.Handlers;

public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
{
    public Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        using var context = new AppDbContextRead();

        var cliente = context.Clientes.Find(request.Id) ?? throw new InvalidOperationException("Cliente não encontrado!");

        return Task.FromResult(cliente);
    }
}
