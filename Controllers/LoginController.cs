using DocumentFormat.OpenXml.Wordprocessing;
using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class LoginController : Controller
    {

        readonly private ApplicationDbContext _db;

        public LoginController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Login()
        {
            return View("Index");
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == null || password == null) {
                return NotFound();
            }

            UsuariosModel EMAIL = _db.Usuarios.FirstOrDefault(x => x.Email == email);

            UsuariosModel SENHA = _db.Usuarios.FirstOrDefault(x => x.Password == password);

            if (EMAIL == null || SENHA == null)
            {
                return View("Views/Login/Index.cshtml");
            }

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult Cadastro(){
          
            return View();
        }
    }
}
