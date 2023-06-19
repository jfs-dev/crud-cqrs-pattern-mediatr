using MediatR;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Commands;

public class DeleteClienteCommand : IRequest<Cliente>
{
    public int Id { get; set; }
}
