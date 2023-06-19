using MediatR;
using Microsoft.EntityFrameworkCore;
using crud_cqrs_pattern_mediatr.Commands;
using crud_cqrs_pattern_mediatr.Data;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Handlers;

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Cliente>
{
    public Task<Cliente> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        using var context = new AppDbContextWrite();

        var cliente = context.Clientes.Find(request.Id) ?? throw new InvalidOperationException("Cliente não encontrado!");

        context.Entry(cliente).State = EntityState.Deleted;
        context.SaveChanges();

        return Task.FromResult(cliente);
    }
}
