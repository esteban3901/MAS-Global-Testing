using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASGlobalTesting.API.Models
{
    public class APIResponseModel<T> where T : class
    {
        public bool Status { get; set; }
        public T Result { get; set; }
    }
}
