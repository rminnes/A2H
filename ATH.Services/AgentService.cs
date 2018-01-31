using ATH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH.Services
{
    public class AgentService :EntityService<LettingAgent>,IAgentService        
    {

        IContext _context;


        public AgentService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<LettingAgent>();
        }

    }
}
