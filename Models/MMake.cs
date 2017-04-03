using System;
using System.Collections.Generic;

namespace vega.Models
{
    public partial class MMake
    {
        public MMake()
        {
            MModel = new HashSet<MModel>();
        }

        public int Id { get; set; }
        public string Make { get; set; }

        public virtual ICollection<MModel> MModel { get; set; }
    }
}
