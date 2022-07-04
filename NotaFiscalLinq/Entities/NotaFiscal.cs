using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscalLinq.Entities
{
    class NotaFiscal
    {

        public int Id { get; set; }
        public int IdCliente { get; private set; }
        public Cliente Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public char TipoFrete { get; set; }
        public char Status { get; set; }

        public NotaFiscal()
        {

        }
        public NotaFiscal(int id, Cliente cliente, DateTime dataEmissao, char tipoFrete, char status)
        {
            Id = id;
            //IdCliente = Cliente.IdCliente;
            Cliente = cliente;
            DataEmissao = dataEmissao;
            TipoFrete = tipoFrete;
            Status = status;
        }

        public override string ToString()
        {
            StringBuilder notaFiscal = new StringBuilder();
            notaFiscal.AppendLine($"********* Pedido {Id} - Emitido em: {DataEmissao:dd/MM/yyyy HH:mm:ss} - Tipo de Frete: {TipoFrete} - Status: {Status}");
            notaFiscal.AppendLine($"{Cliente.NomeCliente}");
            notaFiscal.AppendLine("--------------- Itens do pedido ---------------");
            notaFiscal.AppendLine("Produto".PadRight(20) + " Quantidade".PadRight(10) + " Preço Unitário".PadRight(20) + " Total".PadRight(25));
            return notaFiscal.ToString();
        }
    }
}
