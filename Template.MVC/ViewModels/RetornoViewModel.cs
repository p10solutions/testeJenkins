namespace Template.MVC.ViewModels
{
    public class RetornoViewModel
    {
        public bool sucesso { get; set; }
        public string mensagem { get; set; }

        public static class RetornoViewModelFactory
        {
            public static RetornoViewModel Sucesso(string mensagem)
            {
                return new RetornoViewModel { mensagem = mensagem, sucesso = true };
            }

            public static RetornoViewModel Erro(string mensagem)
            {
                return new RetornoViewModel { mensagem = mensagem, sucesso = false };
            }
        }
    }
}
