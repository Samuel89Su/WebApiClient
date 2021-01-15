using System.Globalization;
using System.Threading;
using Xunit;

namespace WebApiClientCore.Test
{
    public class ApiActionDescriptorTest
    {
        [Fact]
        public void CtorTest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var str = Resx.contenType_RemainAs.Format("hhaha");
            Assert.Equal("Content-Type must remain as hhaha.", str);

            var m = typeof(IDescriptorApi).GetMethod("Get1");
            var d = new ApiActionDescriptor(m);

            Assert.True(d.Attributes.Count == 3);
            Assert.True(d.FilterAttributes.Count == 1);
            Assert.True(d.Parameters.Count == 2);
            Assert.True(d.Name == m.Name);
            Assert.True(d.Member == m);
            Assert.True(d.Return.Attributes.Count == 1);
            Assert.True(d.Return.ReturnType == m.ReturnType);
        }
    }
}
