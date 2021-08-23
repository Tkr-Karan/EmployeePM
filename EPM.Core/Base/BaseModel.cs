using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Core.Base
{
    //common Properties are here 
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
        public int Createdby { get; set; }
        public DateTime CreateddDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
