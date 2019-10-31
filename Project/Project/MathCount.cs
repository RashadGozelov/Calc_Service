using Project.Interfaces;
using ProjectTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project
{
    public class MathCount:IMathCount
    {
        private CalculatorSoap calculatorSoap;

        public MathCount(CalculatorSoap calculator)
        {
            calculatorSoap = calculator;
        }

        public async Task<int> AddAsync(int NumOne, int NumTwo)
        {
            return await calculatorSoap.AddAsync(NumOne, NumTwo);
        }

        public async Task<int> SubtractAsync(int NumOne, int NumTwo)
        {
            return await calculatorSoap.SubtractAsync(NumOne, NumTwo);
        }

        public async Task<int> MultiplyAsync(int NumOne, int NumTwo)
        {
            return await calculatorSoap.MultiplyAsync(NumOne, NumTwo);
        }

        public async Task<int> DivideAsync(int NumOne, int NumTwo)
        {
            return await calculatorSoap.DivideAsync(NumOne, NumTwo);
        }
    }
}
