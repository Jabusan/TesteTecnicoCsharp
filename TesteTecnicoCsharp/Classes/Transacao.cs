namespace TesteTecnicoCsharp.Classes;

public class Transacao
{
    public int IdTransacao { get; private set; }
    public int IdUsuario { get; set; }
    public string Descricao { get; set; }
    public required float Valor { get; set; }
    public required string Tipo { get; set; }

    public Transacao( int idUsuario, string descricao, float valor, string tipo)
    {
        IdUsuario = idUsuario;
        Descricao = descricao;
        Valor = valor;
        Tipo = tipo.ToUpper();
    }
    
    // a classe inicia com um contador em 1 e a cada nova instancia, ao invocar o metodo de contador se incrementa
    // mais um ao IdTransacao, criando assim um id de numeros inteiros e sequencial.
    private static int _idTransacaoContador = 1;
    
    public void TransacaoIdContador()
    {
        IdTransacao = _idTransacaoContador++;
    }
}