﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMEditComboBoxItemsSample.MockModel
{
    class Thing
    {
        public string Name { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
