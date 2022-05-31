namespace Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private Empresa Empresa { get; set;}
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, Empresa empresa, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Empresa = empresa;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "Gênero: " + Genero + Environment.NewLine;
            retorno += "Empresa: " + Empresa + Environment.NewLine;
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + Ano + Environment.NewLine;
            retorno += "Excluído: " + Excluido;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public bool RetornaExcluido()
        {
            return Excluido;
        }

        public void Excluir()
        {
            Excluido = true;
        }

    }

    
}