﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactID { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string Message { get; set; }
    }
}
