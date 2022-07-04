using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscalLinq.Entities
{
    class Consultas
    {
        public List<NotaFiscal> ListNotaFiscal { get; set; }
        public List<ItensNotaFiscal> ListItensNotaFiscal { get; set; }
        public List<Cliente> ListClientes { get; set; }
        public List<Produto> ListProduto { get; set; }

        public Consultas(List<NotaFiscal> listNotaFiscal, List<ItensNotaFiscal> listItensNotaFiscal, List<Cliente> listClientes, List<Produto> listProduto)
        {
            ListNotaFiscal = listNotaFiscal;
            ListItensNotaFiscal = listItensNotaFiscal;
            ListClientes = listClientes;
            ListProduto = listProduto;
        }

        public void NotaFiscalAtualizadas()
        {
            int notaFicalAtualizadas = ListNotaFiscal.Where(p => p.Status == 'F').Count();
            Console.WriteLine($"Temos {notaFicalAtualizadas} Notas Fiscais Atualizadas.");
            Console.WriteLine();
        }

        public void NotaFiscalCanceladas()
        {
            var notaFicalCanceladas = ListNotaFiscal.Where(p => p.Status == 'C').Count();
            Console.WriteLine($"{notaFicalCanceladas} Notas Fiscais foram Canceladas");
            Console.WriteLine();
        }

        public void PrimeiraNotaAtiva()
        {
            var primeiraNotaAtiva = ListNotaFiscal.Where(x => x.Status == 'A').OrderBy(x => x.DataEmissao).FirstOrDefault();
            Console.WriteLine($"O Id da primeira nota ativa é {primeiraNotaAtiva.Id}, do cliente {primeiraNotaAtiva.Cliente.NomeCliente}");
            Console.WriteLine();
        }

        public void NotaFaturadaCIF()
        {
            var notaFaturadaCIF = ListItensNotaFiscal.Where(x => x.NotaFiscal.Status == 'F' && x.NotaFiscal.TipoFrete == 'C').Sum(x => x.Quantidade);
            Console.WriteLine($"A quantidade de notas Faturadad com frete CIF é: {notaFaturadaCIF}");
            Console.WriteLine();
        }

        public void ValorVendidoFOB()
        {
            var valorVendidoFOB = ListItensNotaFiscal.Where(x => x.NotaFiscal.Status == 'F' && x.NotaFiscal.TipoFrete == 'F').Sum(x => x.Total());
            Console.WriteLine($"Valor total de notas FOB faturadas: R$ {valorVendidoFOB:F2}");
            Console.WriteLine();
        }

        public void AbacaxisVendidos()
        {
            var abacaxisVendidos = ListItensNotaFiscal.Where(x => x.Produto.NomeProduto.ToUpper().Contains("abacaxi".ToUpper()) && x.NotaFiscal.Status == 'F').Sum(x => x.Quantidade);
            Console.WriteLine($"Foram vendidos {abacaxisVendidos} abacaxi(s)");
            Console.WriteLine();
        }

        public void ConsultaNotaFiscal()
        {
            var nota = from item in ListItensNotaFiscal
                        group item by item.IdNotaFiscal into grupoNotas
                        orderby grupoNotas.Key ascending
                        select grupoNotas;

            foreach (var itens in nota)
            {
                var notaFiscal = ListNotaFiscal.First(x => x.Id == itens.Key);
                Console.WriteLine(notaFiscal);
                Console.WriteLine();
                foreach (var item in itens)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
        }
    }
}
