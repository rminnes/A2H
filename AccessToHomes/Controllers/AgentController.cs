using AccessToHomes.Models.ViewModels;
using ATH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccessToHomes.Code.Factory;

namespace AccessToHomes.Controllers
{
    public class AgentController : Controller
    {
        IAgentService _agentService;


        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {

            var model = new AddAgentVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddAgentVM model)
        {
            _agentService.Create(model.Create());
            return View();
        }
    }
}