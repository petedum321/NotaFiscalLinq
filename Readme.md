1 - Criar as seguintes classes seguindo as respectivas estruturas:
CREATE TABLE CLIENTE
(
  id INTEGER NOT NULL,
  NOMECLIENTE VARCHAR(100)
);
CREATE TABLE PRODUTO
(
  id INTEGER NOT NULL,
  NOMEPRODUTO VARCHAR(100)
);
CREATE TABLE NOTAFISCAL
(
  id INTEGER NOT NULL,
  DATAEMISSAO DATETIME,
  TIPOFRETE varchar Dica: Tipos de frete possível, C - Cif, F - Fob,
  idcliente INTEGER,
  Status varchar     Dica: Status possíveis, A - Ativo, F - Faturado, C - Cancelado
);
CREATE TABLE ITENSNOTAFISCAL
(
  id INTEGER NOT NULL,
  idnotafiscal / notafiscalid INTEGER NOT NULL,
  idproduto / produtoid INTEGER NOT NULL,
  QUANTIDADE INTEGER NOT NULL,
  PRECOUNITARIO DECIMAL NOT NULL,
  total DECIMAL Dica: QUANTIDADE * PRECOUNITARIO
);
2 - Alimentar TODOS os objetos das classes criadas acima em estruturas <List>, criar no mínimo 10 objetos de cada classe
EXEMPLO:
var listaClientes = new List<Clientes>
var cliente1 = new Cliente("Jefté");
var cliente2 = new Cliente("Bruna");
var cliente3 = new Cliente("Mayara");
var listaProdutos = new List<Produto>
var produto1 = new Produto("Abacaxi");
var produto1 = new Produto("Laranja");
var produto1 = new Produto("Melão");
var pedido = new Pedido(1, datetime.now, 1);
Etc...
Lembrando que os dados precisam estar relacionados pelos respectivos Id
Ex: 
Cliente.Id = 1
NotaFiscal.IdCliente = 1
Etc...
3 - Usar FLUENT expression para retornar os seguintes resultados:
1) QUANTAS NOTAS FISCAIS FORAM FATURADAS Dica: count() com where()
1) QUANTAS NOTAS FISCAIS canceladas no dia Dica: count() com where()
2) QUAL É A DATA E HORA DA PRIMEIRA NOTA FISCAL ATIVA Dica: orderBy(data).firstordefault()
3) QUANTAS UNIDADES DE PRODUTOS FORAM VENDIDAS NAS NOTAS COM TIPO DE FRETE CIF e FORAM faturadas Dica: count().where(c => c.tipofrete = "cif")
4) QUAL O VALOR VENDIDO (faturado) COM AS NOTAS COM TIPO DE FRETE FOB  Dica: sum(c => c.valorvendido).where(c => c.tipofrete = "fob")
5) QUANTOS Abacaxis FORAM VENDIDOS (faturado)  Dica: count().any(c => c.NomeProduto.Contains("Abacaxi"))
6) QUAL FOI O LUCRO (faturado) TOTAL DE Abacaxi e Laranja Dica: decimal sum(c=> valor total).any(c => c.NomeProduto.Contains("Mouse")) + sum(c=> valor total).any(c => c.NomeProduto.Contains("Teclado"))
notasFiscais.Include(c => ItensNotaFiscal)
4 - Usar Query Expression para GERAR UM RELATÓRIO DE PEDIDOS COM O SEGUINTE LAYOUT Dica: Usar join
********** Pedido 99999999 - Emitido em: DD/MM/AAAA - HH/MM/SS - Tipo de Frete: C - Cif ou F - Fob - Situação: ativo / faturado / cancelado **********
Cliente: 999 - AAAAAAAAAAAAAAAAAAAAAAA
--------------- Itens do pedido --------------------
Produto                   qtde.          valor unit.           total
NOMEPRODUTO               9999                   999             999
NOMEPRODUTO               9999                   999             999
NOMEPRODUTO               9999                   999             999
NOMEPRODUTO               9999                   999             999