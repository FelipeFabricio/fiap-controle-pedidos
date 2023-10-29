﻿namespace Application.Dtos;

public sealed record  ProdutoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Descricao { get; set; }
    public string ImagemUrl { get; set; }
    public string Categoria { get; set; }
}