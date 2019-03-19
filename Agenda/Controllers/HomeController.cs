using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using agenda.Repository;
using agenda.Domain;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        public readonly AgendasRepository agendas;
        public readonly ContatosRepository contatos;

        public HomeController(
            IRepository<Agendas> _agendas,
            IRepository<Contatos> _contatos
            )
        {
            agendas = _agendas as AgendasRepository;
            contatos = _contatos as ContatosRepository;
        }

        public ActionResult Index()
        {
            var models = new List<AgendaModel>();
            //if (agendas.GetUnid() == 0)
            //{
            //    var model = new AgendaModel
            //    {
            //        Id = 1,
            //        Nome = "",
            //        Status = false,
            //    };
            //    models.Add(model);
            //}
            //else
            //{

                foreach(var age in agendas.GetAll())
                {
                    var modelAgenda = new AgendaModel
                    {
                        Id = age.Id,
                        Nome = age.Nome,
                        Status = age.Status
                    };
                    modelAgenda.Contatos = new List<ContatoModel>();
                    foreach (var cont in contatos.GetAll())
                    {
                        if (cont.AgendasID == age.Id) {
                            var modelCont = new ContatoModel
                            {
                                Id = cont.Id,
                                AgendasID = cont.AgendasID,
                                Email = cont.Email,
                                Status = cont.Status,
                                Telefone = cont.Telefone
                            };
                            modelAgenda.Contatos.Add(modelCont);
                        }
                    }

                    models.Add(modelAgenda);
                }
            //}
            

                //models = agendas.GetAll();

            return View(models);
        }

        public ActionResult AdicionarAgenda()
        {
            return View();
        }

        public ActionResult SalvarAgenda(String nome)
        {
            var modelAgenda = new Agendas
            {
                Nome = nome,
                Status = true
            };
            agendas.Add(modelAgenda);
            agendas.Save();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SaveContato(Contatos contatoModels)
        {
            var modelContato = new Contatos
            {
                Email = contatoModels.Email,
                AgendasID = contatoModels.AgendasID,
                Telefone = contatoModels.Telefone,
                Status = true
            };
            contatos.Add(modelContato);
            contatos.Save();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteAgenda(long id)
        {
            var agenda = agendas.GetElement(id);
            agenda.Status = false;
            agendas.Update(agenda);
            agendas.Save();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContato(long id)
        {
            var contato = contatos.GetElement(id);
            contato.Status = false;
            contatos.Update(contato);
            contatos.Save();
            return RedirectToAction("Index");
        }
    }
}
