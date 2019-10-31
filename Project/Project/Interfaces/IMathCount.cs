using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Interfaces
{
    public interface IMathCount
    {
        Task<int> AddAsync(int NumOne, int NumTwo);
        Task<int> SubtractAsync(int NumOne, int NumTwo);
        Task<int> MultiplyAsync(int NumOne, int NumTwo);
        Task<int> DivideAsync(int NumOne, int NumTwo);
    }
}
