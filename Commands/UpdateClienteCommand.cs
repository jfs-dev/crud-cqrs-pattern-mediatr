using MediatR;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Commands;

public class UpdateClienteCommand : IRequest<Cliente>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
