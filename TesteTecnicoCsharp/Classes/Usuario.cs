namespace TesteTecnicoCsharp.Classes;

public class Usuario
{
    public required string Nome { get; set; }
    public required int Idade { get; set; }
    public int IdUsuario { get; private set; }

    public Usuario(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    // a classe inicia com um contador em 1 e a cada nova instancia, ao invocar o metodo de contador se incrementa
    // mais um ao IdUsuario, criando assim um id de numeros inteiros e sequencial.
    private static int _idUsuarioContador = 1;

    public void UsuarioIdContador()
    {
        IdUsuario = _idUsuarioContador++;
    }
}