using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdministrationSystem
{
    public class Cursus
    {
        public Cursus(string code)
        {
            this.Code = code;
        }
        public string Code { get; set; }
    }
}
