using Series.Classes;
class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();


    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while(opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;

                case "2":
                    InserirSerie();
                    break;

                case "3":
                    AtualizarSerie();
                    break;

                case "4":
                    ExcluirSerie();
                    break;

                case "5":
                    VisualizarSerie();
                    break;
                
                case "C":
                    Console.Clear();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }
    }

    private static void ListarSeries()
    {
        System.Console.WriteLine("Listar séries");
        var lista = repositorio.Lista();

        if(lista.Count == 0)
        {
            System.Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }

        foreach (var serie in lista)
        {
            var excluido = serie.RetornaExcluido();
            System.Console.WriteLine($"{serie.RetornaId()} - {serie.RetornaTitulo()} - {(excluido ? "====Excluído====" : "")}");
        }
    }

    private static void InserirSerie()
    {
        Serie novaSerie = RecebeSerie(repositorio.ProximoId());
        repositorio.Insere(novaSerie);
    }

    private static void AtualizarSerie()
    {
        System.Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        Serie serieAtualizada = RecebeSerie(indiceSerie);
        repositorio.Atualiza(indiceSerie, serieAtualizada);
    }

    public static Serie RecebeSerie(int indiceSerie)
    {
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Empresa)))
        {
            System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Empresa), i)}");
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaEmpresa = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie serieRecebida = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            empresa: (Empresa)entradaEmpresa,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
        return serieRecebida;
    }

    public static void ExcluirSerie()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }

    public static void VisualizarSerie()
    {
        System.Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }

    private static string ObterOpcaoUsuario()
    {
        System.Console.WriteLine("DIO Séries a seu dispor!!!");
        System.Console.WriteLine("Informe a opção desejada:");
        System.Console.WriteLine("1 - Listar séries");
        System.Console.WriteLine("2 - Inserir nova série");
        System.Console.WriteLine("3 - Atualizar série");
        System.Console.WriteLine("4 - Excluir série");
        System.Console.WriteLine("5 - Visualizar série");
        System.Console.WriteLine("C - Limpar tela");
        System.Console.WriteLine("X - Sair");
        
        return Console.ReadLine().ToUpper();
    }
}