using System.Collections.Generic;

namespace SpecFlowWithXUnitAndSeleniumAndAutofac {
    public class Calculator : ICalculator {
        private readonly Stack<int> operands = new Stack<int>();

        public int Result { get; private set; }
        public string LastOperationAsQuery { get; private set; }

        public void Enter(int operand) {
            operands.Push(operand);
        }

        public void Add() {
            int firstOperand = operands.Pop();
            int secondOperand = operands.Pop();
            LastOperationAsQuery = $"{firstOperand} + {secondOperand}";
            Result = firstOperand + secondOperand;
        }
    }
}