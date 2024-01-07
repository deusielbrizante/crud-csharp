using Microsoft.AspNetCore.Mvc;
using crud_csharp.Model;
using crud_csharp.Repository;

namespace crud_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UIUsuarioRepository _repository;

        public UsuarioController(UIUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.BuscaUsuarios();

            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.BuscaUsuario(id);

            return usuario != null ? Ok(usuario) : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AdicionaUsuario(usuario);
            return await _repository.SalvarMudancasAsync() ? Ok("Usuário adicionado com sucesso") : BadRequest("Erro ao salvar o usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var BuscaUsuario = await _repository.BuscaUsuario(id);
            if(BuscaUsuario == null){
                return NotFound("Usuário não encontrado");
            }

            BuscaUsuario.Nome = usuario.Nome;
            BuscaUsuario.DataNascimento = usuario.DataNascimento;
        
            _repository.AtualizaUsuario(BuscaUsuario);
            
            return await _repository.SalvarMudancasAsync() ? Ok("Usuário atualizado com sucesso") : BadRequest("Erro ao atualizar usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var BuscaUsuario = await _repository.BuscaUsuario(id);
            if(BuscaUsuario == null){
                return NotFound("Usuário não encontrado");
            }

            _repository.DeletaUsuario(BuscaUsuario);

            return await _repository.SalvarMudancasAsync() ? Ok("Usuário deletado com sucesso") : BadRequest("Erro ao deletar usuário");
        }
    }
}