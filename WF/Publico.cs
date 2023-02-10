namespace WF
{
    public sealed class Publico
    {
        public static string UsuarioLogadoPerfil = "USR";
        public static string UsuarioLogadoNome = "";
        public static string telefoneDoCliente = "";
        public static int codigoDoCliente = 0;
        public static int codigoDoPedido = 0;
        public static int codigoDoItem = 0;

        public static string retornaCaminhoApp(string caminho)
        {
            if (caminho.IndexOf("\\bin\\Debug") > 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }
    }
}
