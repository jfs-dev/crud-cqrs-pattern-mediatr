using MediatR;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Commands;

public class CreateClienteCommand : IRequest<Cliente>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
