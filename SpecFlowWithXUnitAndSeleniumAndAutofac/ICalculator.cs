namespace SpecFlowWithXUnitAndSeleniumAndAutofac {
    public interface ICalculator {
        int Result { get; }
        string LastOperationAsQuery { get; }
        void Add();
        void Enter(int operand);
    }
}
