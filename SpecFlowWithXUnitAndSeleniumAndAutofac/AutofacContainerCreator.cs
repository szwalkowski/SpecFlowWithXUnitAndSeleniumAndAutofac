using System;
using System.Linq;
using Autofac;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace SpecFlowWithXUnitAndSeleniumAndAutofac {
    public static class AutofacContainerCreator {

        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder() {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Calculator>().As<ICalculator>().SingleInstance();

            //We're registering all test classes from assembly with [Binding] annotation
            containerBuilder.RegisterTypes(typeof(AutofacContainerCreator).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            return containerBuilder;
        }
    }
}