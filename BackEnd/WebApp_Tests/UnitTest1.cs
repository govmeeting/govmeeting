using System;
using Xunit;
//using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using GM.WebApp;

namespace GM.WebApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(2 + 2 == 4, "2 + 2 = 4");
        }
    }
}
