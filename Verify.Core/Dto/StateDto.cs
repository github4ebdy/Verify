using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verify.Core.Dto
{
    public  class StateDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? isActive { get; set; }
        public List<DistrictDto>? DistrictList { get; set; }
    }
}
