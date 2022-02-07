using System;

namespace Skeleton.Tests
{
    internal class TestcaseAttribute : Attribute
    {
        private int v1;
        private int v2;

        public TestcaseAttribute(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}