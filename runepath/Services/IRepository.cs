using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace runepath.Services
{
    public interface IRepository<T>
    {
         Task<List<T>> Get();
    }
}