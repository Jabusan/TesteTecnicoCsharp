using TesteTecnicoCsharp.Classes;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Declaração das listas para armazenamento em memória dos dados cadastrados.

var listaUsuarios = new List<Usuario>();
var listaTransacoes = new List<Transacao>();

// Funcionalidades do cadastro de usuários: Criação, listagem (todos e individual) e deleção.

app.MapPost("/usuarios", (Usuario usuario) =>
{
    usuario.UsuarioIdContador(); //chamada do metodo para incremento sequencial do IdUsuario
    listaUsuarios.Add(usuario);
    return Results.Ok(usuario);
});

app.MapGet("/usuarios", () =>
{
    if (listaUsuarios.Count == 0)
    {
        return Results.NotFound("Não há usuários cadastrados");
    }
    return Results.Ok(listaUsuarios);
});

app.MapGet("/usuarios/{id:int}", (int id) =>
{
    var usuario = listaUsuarios.Find(x => x.IdUsuario == id);
    if (usuario is null)
        return Results.NotFound("Usuário não encontrado na plataforma.");
    return Results.Ok(usuario);
});

app.MapDelete("/usuarios/{id:int}", (int id) =>
{
    listaTransacoes.RemoveAll(x => x.IdUsuario == id); //deleta as transações relacionadas ao usuario a ser removido

    var usuario = listaUsuarios.Find(x => x.IdUsuario == id);
    if (usuario is null)
        return Results.NotFound("Usuário não encontrado na plataforma.");
    listaUsuarios.Remove(usuario);
    
    return Results.Ok(listaUsuarios);
});

// Funcionalidades do cadastro de transações: Criação e Listagem de todas as transações.

app.MapPost("/transacoes", (Transacao transacao) =>
{
    var usuario = listaUsuarios.FirstOrDefault(x => x.IdUsuario == transacao.IdUsuario);
    if (usuario is null)
    {
        return Results.NotFound("Usuário não encontrado na plataforma.");
    }

    if (usuario.Idade < 18 && transacao.Tipo.ToUpper() != "DESPESA")  // condicional de restrição do tipo de transação para menores.
    {
        return Results.BadRequest("Menores de idade só podem realizar despesas.");
    }
    //condicional para restringir os inputs de Tipo de transação apenas para DESPESA e RECEITA
    else if (usuario.Idade >= 18 && (transacao.Tipo.ToUpper() != "DESPESA" && transacao.Tipo.ToUpper() != "RECEITA"))
    {
        return Results.BadRequest("São aceitos apenas valores de DESPESA ou RECEITA.");
    }

    transacao.TransacaoIdContador(); //chamada do metodo para incremento sequencial do IdContador
    listaTransacoes.Add(transacao);
    return Results.Ok(transacao);
});

app.MapGet("/transacoes", () =>
{
    if (listaTransacoes.Count == 0)
    {
        return Results.NotFound("Não existem transações cadastradas no sistema.");
    }
    return Results.Ok(listaTransacoes);
});

// Funcionalidade da Consulta de Totais: Faz a consulta e listagem da receita, despesa e saldo de cada usuário 
// individualmente e ao final lista o total de todos os usuários cadastrados.

app.MapGet("/consulta de totais", () =>
{
    //criação da variável que contém a lista com nova estrutura criada para a consulta de totais por usuario
    var consultaPorUsuario = listaUsuarios.Select((usuario) =>
    {
        var receitas = listaTransacoes.Where(x => x.IdUsuario == usuario.IdUsuario && x.Tipo.Equals("RECEITA")).Sum(x => x.Valor);
        var despesas = listaTransacoes.Where(x => x.IdUsuario == usuario.IdUsuario && x.Tipo.Equals("DESPESA")).Sum(x => x.Valor);
        var saldo = receitas - despesas;

        return new
        {
            IdUsuario = usuario.IdUsuario,
            Nome = usuario.Nome,
            Idade = usuario.Idade,
            Receitas = receitas,
            Despesas = despesas,
            Saldo = saldo
        };
    }).ToList();
    
    var consultaTotalReceitas = listaTransacoes.Where(x => x.Tipo.Equals("RECEITA")).Sum(x => x.Valor);
    var consultaTotalDespesas = listaTransacoes.Where(x => x.Tipo.Equals("DESPESA")).Sum(x => x.Valor);
    var consultaTotalSaldo = consultaTotalReceitas - consultaTotalDespesas;

    return new  //retorna o objeto anonimo com estrutura final para ser apresentado a consulta
    {
        ConsultaSaldo = consultaPorUsuario,
        ConsultaTotal = new
        {
            totalReceitas = consultaTotalReceitas,
            totalDespesas = consultaTotalDespesas,
            totalSaldo = consultaTotalSaldo
        }
    };
});

app.Run();
