using System;
using Fubu;
using FubuCore.CommandLine;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FubuMVC.Tests.Commands
{
    [TestFixture]
    public class usage_graph_smoke_tester
    {
        [Test]
        public void all_commands_usage_graph_works()
        {
            var factory = new CommandFactory();
            factory.RegisterCommands(typeof(AliasCommand).Assembly);
            factory.RegisterCommands(typeof(IFubuCommand).Assembly);

            factory.AllCommandTypes().Each(t =>
            {

                try
                {
                    var usageGraph = new UsageGraph(t);
                    usageGraph.WriteUsages();

                    Assert.IsTrue(usageGraph.Usages.Any(), "Found usages for " + t.FullName);
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Command type:  " + t.FullName, e);
                }
            });
        }

        [Test]
        public void vdir()
        {
            new UsageGraph(typeof(CreateVdirCommand)).WriteUsages();
        }
    }
}