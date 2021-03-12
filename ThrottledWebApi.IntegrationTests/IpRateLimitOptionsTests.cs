using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThrottledWebApi.IntegrationTests
{
    [TestClass]
    public class IpRateLimitOptionsTests
    {
        [TestMethod]
        public void CheckIpRateLimitOptions()
        {
            using var factory = new WebApplicationFactory<Startup>();
            var options = factory.Services.GetRequiredService<IOptions<IpRateLimitOptions>>();
            Assert.AreEqual(1, options.Value.GeneralRules.Count);
            var generalRule = options.Value.GeneralRules[0];
            Assert.AreEqual("*:/api/*", generalRule.Endpoint);
            Assert.AreEqual("1s", generalRule.Period);
            Assert.AreEqual(2, generalRule.Limit);
        }
    }
}
