using System;
using System.Collections.Generic;
using System.Text;

namespace BuyCofeeTests.Common
{
    using Xunit;

    [CollectionDefinition("IntegrationTests")]
    [Collection("IntegrationTests")]

    public class BaseApiTest : IClassFixture<HostFixture>
    {
        protected HostFixture _server;

        public BaseApiTest(HostFixture host)
        {
            IsTestHost = true;
            _server = host;
        }

        public bool IsTestHost { get; }
    }
}
