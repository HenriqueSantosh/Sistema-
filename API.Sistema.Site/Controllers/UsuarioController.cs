using API.Sistema.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Site.Controllers
{
    public class UsuarioController : Controller
    {

        public async Task<IActionResult> Index()
        {
            IEnumerable<Usuario> usuarios = new List<Usuario>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44358/v1/Usuario/GetListUsers"))
                {
                    string apiRespons = await response.Content.ReadAsStringAsync();
                    var retorno = JsonConvert.DeserializeObject<Resposta<Usuario>>(apiRespons);
                    if (retorno.success)
                    {
                        usuarios = retorno.data;
                    }

                }
            }
            return View(usuarios);
        }

        [HttpGet]
        public async Task<ViewResult> GetUsuarioById(Guid id)
        {
            Usuario usuarios = new Usuario();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44358/v1/Usuario/" + id))
                {
                    string apiRespons = await response.Content.ReadAsStringAsync();
                    var retorno = JsonConvert.DeserializeObject<RespostaSingle<Usuario>>(apiRespons);
                    if (retorno.success)
                    {
                        usuarios = retorno.data;
                    }

                }
            }
            return View(usuarios);
        }

        [HttpGet]
        public ViewResult AddUsuario()
        {
            ConfigSelect();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddUsuario([FromForm]Usuario usuario)
        {
            ConfigSelect();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(usuario),
                                                Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44358/v1/Usuario/", content))
                    {
                        string apiRespons = await response.Content.ReadAsStringAsync();
                        var retorno = JsonConvert.DeserializeObject<RespostaSingle<Usuario>>(apiRespons);

                        if(retorno.success)
                            return RedirectToAction("Index", "Usuario");
                        else
                        {
                            TempData["Error"] = retorno.errors.FirstOrDefault();
                        }

                     }
                    
                }
                return View(usuario);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUsuario(Guid id)
        {
            ConfigSelect();
            Usuario usuarios = new Usuario();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44358/v1/Usuario/" + id))
                {
                    string apiRespons = await response.Content.ReadAsStringAsync();
                    var retorno = JsonConvert.DeserializeObject<RespostaSingle<Usuario>>(apiRespons);
                    if (retorno.success)
                    {
                        usuarios = retorno.data;
                    }

                }
            }
            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsuario(Guid id,[FromForm]Usuario usuario)
        {
            ConfigSelect();
            usuario.Id = id;    
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(usuario),
                                                Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://localhost:44358/v1/Usuario/", content))
                    {
                        string apiRespons = await response.Content.ReadAsStringAsync();
                        var retorno = JsonConvert.DeserializeObject<RespostaSingle<Usuario>>(apiRespons);

                        if (retorno.success)
                            return RedirectToAction("Index", "Usuario");
                        else
                        {
                            TempData["Error"] = retorno.errors.FirstOrDefault();
                        }
                    }
                }
                return View(usuario);

            }

            return View();
        }

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            Usuario usuarios = new Usuario();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44358/v1/Usuario/"+ id))
                {
                    string apiRespons = await response.Content.ReadAsStringAsync();
                    var retorno = JsonConvert.DeserializeObject<RespostaSingle<Usuario>>(apiRespons);
                    ///success = retorno?.success;
                }
            }
            return RedirectToAction("Index");

        }

        private void ConfigSelect()
        {
            ViewBag.UfsSelect = new List<string>() { "SP", "RJ", "MA" };
            ViewBag.SexoSelect = new List<string>() { "Masculino", "Feminino" };
            ViewBag.EstadoCivilSelect = new List<string> { "Solteiro", "Casado", "Viúvo", "Divorciado" };
            ViewBag.OrgaoExpedicao = new List<string>() { "SSP", "SJC", "STD" };

        }
    }
}
