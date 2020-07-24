using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using System;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class SomeFixture : IDisposable
    {

        public SomeFixture()
        {
            Logger.InitLogger();

        }

        public void Dispose()
        {
            /* GenerateReport report = new GenerateReport();
             report.Report();
            */
        }

    }

    [CollectionDefinition("Sequential")]
    public class TestCollection : ICollectionFixture<SomeFixture>
    {

    }

}
