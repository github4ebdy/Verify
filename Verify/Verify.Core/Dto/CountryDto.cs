﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verify.Core.Dto
{
    public class CountryDto:CountryDetailsDto
    {
        public List<StateDto>? StateList { get; set; }
    }
}
