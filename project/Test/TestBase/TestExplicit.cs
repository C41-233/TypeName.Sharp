using System;
namespace TestBase
{
    public class TestExplicit : IDisposable
    {
        public void Dispose()
        {
        }

        void IDisposable.Dispose()
        {
        }
    }
}
