using System;
using Microsoft.EntityFrameworkCore;

namespace AntonyWippich.Models;

public class Cliente
{
    public int id { get; set; }
    public string? cpf { get; set; }
    public int mes { get; set; }
    public int ano { get; set; }
    public double m3Consumidos { get; set; }
    public string? bandeira { get; set; }
    public bool possuiEsgoto { get; set; }
    public double consumoFaturado { get; set; }
    public double tarifa { get; set; }
    public double valorAgua { get; set; }
    public double adicionalBandeira { get; set; }
    public double taxaEsgoto { get; set; }
    public double total { get; set; }

}


