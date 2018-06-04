using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amil.SisMed.API.ViewModels
{
    public class RetornoAppServerViewModel
    {
        public string Command { get; set; }
        public List<RetornoAppServerValue> Parameters { get; set; }
        public string Flag { get; set; }
    }

    public class RetornoAppServerValue
    {
        public SubObject Value { get; set; }
    }

    public class SubObject
    {
        public List<AtendimentoViewModel> SubObjects { get; set; }
    }


    public class SubSubObject
    {
        public List<AgendaViewModel> SubObjects { get; set; }
    }
}
