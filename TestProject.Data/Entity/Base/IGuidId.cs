﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data.Entity.Base {
    public interface IGuidId {
        Guid Id { get; set; }
    }
}
