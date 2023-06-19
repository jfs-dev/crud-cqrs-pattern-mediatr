using MediatR;
using Microsoft.EntityFrameworkCore;
using crud_cqrs_pattern_mediatr.Commands;
using crud_cqrs_pattern_mediatr.Data;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Handlers;

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Cliente>
{
    public Task<Cliente> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        using var context = new AppDbContextWrite();
        
        var cliente = new Cliente { Nome = request.Nome, Email = request.Email };

        context.Entry(cliente).State = EntityState.Added;
        context.SaveChanges();

        return Task.FromResult(cliente);
    }
}
