﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Data
{
    public class Property
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get{return Value.GetType().Name;} set { }}
    }
}
