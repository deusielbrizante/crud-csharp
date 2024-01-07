using crud_csharp.Model;

namespace crud_csharp.Repository
{
    public interface UIUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscaUsuarios();
        Task<Usuario> BuscaUsuario(int id);
        void AdicionaUsuario(Usuario usuario);
        void AtualizaUsuario(Usuario usuario);
        void DeletaUsuario(Usuario usuario);

        Task<bool> SalvarMudancasAsync();
    }
}