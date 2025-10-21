using System.Security.Cryptography;
using AntonyWippich.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapPost("AntonyWippich/consumo/cadastrar", async ([FromBody] Cliente cliente, AppDbContext db) =>
{
    if (cliente.mes <= 0 || cliente.mes > 12)
    {
        return Results.BadRequest("Mês inválido");
    }

    if (cliente.ano < 2000)
    {
        return Results.BadRequest("Ano inválido");
    }

    if (cliente.m3Consumidos < 0)
    {
        return Results.BadRequest("Metros cubicos inválidos");
    }

    // Nao esquecer validação de mmesmo mes ;



    if (cliente.m3Consumidos <= 10)
    {
        cliente.consumoFaturado = 10;
    } else
    {
        cliente.consumoFaturado = cliente.m3Consumidos;
    }

    if (cliente.consumoFaturado == 10)
    {
        cliente.tarifa = cliente.consumoFaturado * 2.5;
    } if( cliente.consumoFaturado >= 11 && cliente.consumoFaturado <= 20 ){
        cliente.tarifa = cliente.consumoFaturado * 3.5;
        
    }if( cliente.consumoFaturado >= 21 && cliente.consumoFaturado <= 50 ){
        cliente.tarifa = cliente.consumoFaturado * 5;
        
    }if( cliente.consumoFaturado > 50)
    {
        cliente.tarifa = cliente.consumoFaturado * 6.5;
    }
    ;

    cliente.valorAgua = cliente.consumoFaturado * cliente.tarifa;


    if (cliente.bandeira == "Verde")
    {
        cliente.adicionalBandeira = 0;
    }
    if (cliente.bandeira == "Amarela")
    {
        cliente.adicionalBandeira = cliente.valorAgua * 0.10;
    }
    if (cliente.bandeira == "Vermelha")
    {
        cliente.adicionalBandeira = cliente.valorAgua * 0.20;
    }

    if (cliente.possuiEsgoto == true)
    {
        cliente.taxaEsgoto = (cliente.valorAgua + cliente.adicionalBandeira) * 0.80;
    }
    else
    {
        cliente.taxaEsgoto = 0;
    }


    cliente.total = cliente.valorAgua + cliente.adicionalBandeira + cliente.taxaEsgoto;

    db.Add(cliente);
    await db.SaveChangesAsync();
    return Results.Created($"/cliente", cliente);
});







app.MapGet("AntonyWippich/consumo/listar", async (AppDbContext db) =>
{
    var cliente = db.Clientes.ToList();
    return Results.Ok(cliente);
});


app.MapGet("AntonyWippich/consumo/buscar/{cpf}/{mês}/{ano}", async (string cpf, int mes, int ano, AppDbContext db) =>
{
    var cliente = await db.Clientes.Where(c => c.cpf.Contains(cpf)).ToListAsync();

    return cliente.Any() ? Results.Ok(cliente) : Results.NotFound("Registro não encontrado");
 });



app.Run();
