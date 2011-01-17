﻿using FubuMVC.Core.UI.Scripts;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Tests.UI.Scripts
{
    [TestFixture]
    public class ScriptObjectBaseTester
    {
        private ScriptObjectBase theObject;

        [SetUp]
        public void SetUp()
        {
            theObject = MockRepository.GenerateMock<ScriptObjectBase>();
            theObject.Name = "The name";
        }

        [Test]
        public void matches_its_name()
        {
            theObject.Matches(theObject.Name).ShouldBeTrue();

            theObject.Matches("something else").ShouldBeFalse();
        }

        [Test]
        public void matches_is_case_insensitive()
        {
            theObject.Matches("the name").ShouldBeTrue();
            theObject.Matches("the Name").ShouldBeTrue();
        }

        [Test]
        public void matches_aliases_too()
        {
            theObject.AddAlias("alias1");
            theObject.AddAlias("alias2");
            theObject.AddAlias("alias3");
            theObject.Matches("alias1").ShouldBeTrue();
            theObject.Matches("alias2").ShouldBeTrue();
            theObject.Matches("alias3").ShouldBeTrue();
            theObject.Matches("alias4").ShouldBeFalse();
        }
    }
}