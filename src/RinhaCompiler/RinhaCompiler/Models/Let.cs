﻿using RinhaCompiler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public class Let : TermBase
    {
        public Parameter Name { get; set; }
        public Term Value { get; set; }
        public Term Next { get; set; }
    }
}
