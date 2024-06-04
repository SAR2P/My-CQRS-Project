using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.Common.baseEntity
{
    public abstract class BaseEntity
    {
        public long id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
