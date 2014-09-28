using System;
using TestAssert=NUnit.Framework.Assert;
using NUnit.Framework;

namespace ModestTree.Zenject.Test
{
    [TestFixture]
    public class TestUnbind : TestWithContainer
    {
        interface IFoo
        {
        }

        class Foo : IFoo
        {
        }

        [Test]
        public void TestCase1()
        {
            _container.Bind<IFoo>().ToSingle<Foo>();

            TestAssert.That(_container.ValidateResolve<IFoo>().IsEmpty());

            _container.Unbind<IFoo>();

            TestAssert.That(!_container.ValidateResolve<IFoo>().IsEmpty());
        }
    }
}