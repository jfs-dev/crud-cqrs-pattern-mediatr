using MediatR;
using Microsoft.EntityFrameworkCore;
using crud_cqrs_pattern_mediatr.Commands;
using crud_cqrs_pattern_mediatr.Data;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern.Handlers;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Cliente>
{
    public Task<Cliente> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        using var context = new AppDbContextWrite();

        var cliente = context.Clientes.Find(request.Id) ?? throw new InvalidOperationException("Cliente não encontrado!");
        
        cliente.Nome = request.Nome;
        cliente.Email = request.Email;

        context.Entry(cliente).State = EntityState.Modified;
        context.SaveChanges();

        return Task.FromResult(cliente);
    }
}
