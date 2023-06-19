using MediatR;
using Microsoft.Extensions.DependencyInjection;
using crud_cqrs_pattern_mediatr.Commands;
using crud_cqrs_pattern_mediatr.Data;
using crud_cqrs_pattern_mediatr.Queries;
using crud_cqrs_pattern_mediatr.Services;

var serviceProvider = new ServiceCollection()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly))
    .BuildServiceProvider();

var mediator = serviceProvider.GetService<IMediator>() ?? throw new InvalidOperationException("Não foi possível obter o serviço do mediador. Verifique a configuração do serviço!");

Console.WriteLine("Incluir cliente");
Console.WriteLine("---------------");

var createClientePeterParkerCommand = new CreateClienteCommand {Nome = "Peter Parker", Email = "peter.parker@marvel.com"};
var createClienteBenParkerCommand = new CreateClienteCommand {Nome = "Ben Parker", Email = "ben.parker@marvel.com"};
var createClienteMaryJaneCommand = new CreateClienteCommand {Nome = "Mary Jane", Email = "mary.jane@marvel.com"};
var peterParker = await mediator.Send(createClientePeterParkerCommand);
var benParker =await mediator.Send(createClienteBenParkerCommand);
var maryJane = await mediator.Send(createClienteMaryJaneCommand);

Console.WriteLine($"Cliente incluído - {peterParker.Id} - {peterParker.Nome}");
Console.WriteLine($"Cliente incluído - {benParker.Id} - {benParker.Nome}");
Console.WriteLine($"Cliente incluído - {maryJane.Id} - {maryJane.Nome}");
Console.WriteLine("");

Console.WriteLine("Atualizar cliente");
Console.WriteLine("-----------------");

var updateClienteCommand = new UpdateClienteCommand {Id = 3, Nome = "Mary Jane Watson", Email = "mary.jane@marvel.com"};
var maryJaneUpdate = await mediator.Send(updateClienteCommand);

Console.WriteLine($"Cliente atualizado - {maryJaneUpdate.Id} - {maryJaneUpdate.Nome}");
Console.WriteLine("");

Console.WriteLine("Excluir cliente");
Console.WriteLine("---------------");

var deleteClienteCommand = new DeleteClienteCommand {Id = 2};
var benParkerDelete = await mediator.Send(deleteClienteCommand);

Console.WriteLine($"Cliente excluído - {benParkerDelete.Id} - {benParkerDelete.Nome}");
Console.WriteLine("");

DbMirrorService.Sync(new AppDbContextWrite(), new AppDbContextRead());

Console.WriteLine("Obter cliente");
Console.WriteLine("-------------");

var getClienteByIdQuery = new GetClienteByIdQuery {Id = 1};
var returnClienteQuery = await mediator.Send(getClienteByIdQuery);

Console.WriteLine($"Cliente obtido - {returnClienteQuery.Id} - {returnClienteQuery.Nome}");
Console.WriteLine("");

Console.WriteLine("Obter todos os clientes");
Console.WriteLine("-----------------------");

var getAllClientesQuery = new GetAllClientesQuery();
var returnAllClientesQuery = await mediator.Send(getAllClientesQuery);

foreach (var currentCliente in returnAllClientesQuery)
{
    Console.WriteLine($"{currentCliente.Id} - {currentCliente.Nome}");
}
