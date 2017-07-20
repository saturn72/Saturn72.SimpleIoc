using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace Saturn72.SimpleIoc.Tests
{
    [TestFixture]
    public class IocManagerTests
    {
        #region Registration

        [Test]
        public void IocManager_Register_AddToRegistrationDictionary()
        {
            var tim = new TestIocManager();
            var expected = "test123";
            tim.Register<string>(() => expected);
            tim.ResolutionDictionary.Count.ShouldBe(1);
            tim.ResolutionDictionary[typeof(string)]().ToString().ShouldBe(expected);
        }

        #endregion
    }

    public class TestIocManager : IocManager
    {
        internal new IDictionary<Type, Func<object>> ResolutionDictionary => base.ResolutionDictionary;
    }
}