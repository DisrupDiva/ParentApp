using System.Runtime.Serialization;

namespace api_restful.models;

public class Estabelecimento
{
    public int ID { get; private set; }
    public string CNPJ { get; set; }
    public string DESCRICAO { get; set; }
    public string EMAIL { get; set; }
    public string NOME { get; set; }
    public string TELEFONE { get; set; }
    
    //buscar na tabela n*n os serviços
    //public List<Servico>? SERVICOS { get; set; }
    
}