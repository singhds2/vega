using System;
using System.Collections.Generic;

namespace vega.Models
{
    public partial class MModel
    {
        public int Id { get; set; }
        public int? MakeId { get; set; }
        public string Model { get; set; }

        public virtual MMake Make { get; set; }
    }
}

