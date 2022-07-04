using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscalLinq.Entities
{
    class ItensNotaFiscal
    {
        public int Id { get; set; }
        public int IdNotaFiscal { get; private set; }
        public int IdProduto { get; private set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
        public Produto Produto { get; set; }
        
        public ItensNotaFiscal(int id, NotaFiscal notaFiscal, Produto produto, int quantidade, decimal valorUnitario)
        {
            Id = id;
            IdNotaFiscal = notaFiscal.Id;
            IdProduto = produto.IdProduto;
            NotaFiscal = notaFiscal;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = valorUnitario;
        }

        public decimal Total()
        {
            return Quantidade * PrecoUnitario;
        }

        public override string ToString()
        {
            StringBuilder itens = new StringBuilder();
            itens.AppendLine($"{Produto.NomeProduto,-25} {Quantidade,-10} {PrecoUnitario,-25} {Total().ToString("F2"),-20}");
            return itens.ToString();
        }
    }
}
