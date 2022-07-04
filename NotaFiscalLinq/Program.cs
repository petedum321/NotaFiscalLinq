using NotaFiscalLinq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotaFiscalLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaClientes = new List<Cliente>()
            {
            new Cliente() { IdCliente = 1, NomeCliente = "Abel" } ,
            new Cliente() { IdCliente = 2, NomeCliente = "Marcos Rocha" },
            new Cliente() { IdCliente = 3, NomeCliente = "Piquerez" },
            new Cliente() { IdCliente = 4, NomeCliente = "Danilo" },
            new Cliente() { IdCliente = 5, NomeCliente = "Zé Rafael" },
            new Cliente() { IdCliente = 6, NomeCliente = "Rony" },
            new Cliente() { IdCliente = 7, NomeCliente = "Weverton" },
            new Cliente() { IdCliente = 8, NomeCliente = "Dudu" },
            new Cliente() { IdCliente = 9, NomeCliente = "Veiga" },
            new Cliente() { IdCliente = 10, NomeCliente = "Scarpa" },
            };


            var listaProdutos = new List<Produto>()
            {
            new Produto() { IdProduto = 1, NomeProduto = "Camiseta" },
            new Produto() { IdProduto = 2, NomeProduto = "Caneta" },
            new Produto() { IdProduto = 3, NomeProduto = "Notebook" },
            new Produto() { IdProduto = 4, NomeProduto = "Mouse" },
            new Produto() { IdProduto = 5, NomeProduto = "PS5" },
            new Produto() { IdProduto = 6, NomeProduto = "TV" },
            new Produto() { IdProduto = 7, NomeProduto = "Relógio" },
            new Produto() { IdProduto = 8, NomeProduto = "Chinelo" },
            new Produto() { IdProduto = 9, NomeProduto = "Abacaxi" },
            new Produto() { IdProduto = 10, NomeProduto = "Livro" },
            };

            var listaNotaFiscal = new List<NotaFiscal>()
            {
            new NotaFiscal(1, listaClientes[0], new DateTime(2003, 06, 17), 'C', 'A'),
            new NotaFiscal(2, listaClientes[1], new DateTime(1999, 03, 10), 'C', 'F'),
            new NotaFiscal(3, listaClientes[2], new DateTime(2020, 01, 30), 'C', 'A'),
            new NotaFiscal(4, listaClientes[3], new DateTime(2021, 11, 27), 'F', 'A'),
            new NotaFiscal(5, listaClientes[4], new DateTime(2022, 06, 17), 'F', 'F'),
            new NotaFiscal(6, listaClientes[5], new DateTime(2020, 01, 01), 'F', 'C'),
            new NotaFiscal(7, listaClientes[6], new DateTime(2014, 06, 13), 'C', 'C'),
            new NotaFiscal(8, listaClientes[7], new DateTime(2013, 12, 24), 'C', 'C'),
            new NotaFiscal(9, listaClientes[8], new DateTime(2022, 05, 16), 'F', 'F'),
            new NotaFiscal(10, listaClientes[9], new DateTime(2022, 03, 04), 'C', 'A'),
            };

            var itensNotaFiscal = new List<ItensNotaFiscal>()
            {
                new ItensNotaFiscal (1, listaNotaFiscal[0], listaProdutos[0], 1, 10M),
                new ItensNotaFiscal (2, listaNotaFiscal[1], listaProdutos[1], 10, 1.50M),
                new ItensNotaFiscal (3, listaNotaFiscal[2], listaProdutos[2], 3, 5M),
                new ItensNotaFiscal (4, listaNotaFiscal[3], listaProdutos[3], 6, 9.99M),
                new ItensNotaFiscal (5, listaNotaFiscal[4], listaProdutos[4], 5, 3.50M),
                new ItensNotaFiscal (6, listaNotaFiscal[5], listaProdutos[5], 9, 10M),
                new ItensNotaFiscal (7, listaNotaFiscal[6], listaProdutos[6], 3, 50M),
                new ItensNotaFiscal (8, listaNotaFiscal[7], listaProdutos[7], 15, 40M),
                new ItensNotaFiscal (9, listaNotaFiscal[8], listaProdutos[8], 1, 4.99M),
                new ItensNotaFiscal (10, listaNotaFiscal[9], listaProdutos[9], 33, 1.0M),
            };

            Consultas consultas = new Consultas(listaNotaFiscal, itensNotaFiscal, listaClientes, listaProdutos);

            consultas.NotaFiscalAtualizadas();
            consultas.NotaFiscalCanceladas();
            consultas.PrimeiraNotaAtiva();         
            consultas.NotaFaturadaCIF();
            consultas.ValorVendidoFOB();
            consultas.AbacaxisVendidos();

            consultas.ConsultaNotaFiscal();

        }
    }
}
