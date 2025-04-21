using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Services.Abstractions
{
    public interface IServiceManager
    {

       public IProductService ProductService { get; }



    }
}
