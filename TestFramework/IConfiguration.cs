using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public interface IConfiguration
    {
        TimeSpan DefaultWaitTimeout { get; }

        TimeSpan DefaultCommandTimeout { get; }

        TimeSpan IsPresentTimeout { get; }

        Browser Browser { get; }

        bool IsHeadless { get; set; }

        int? WindowHeight { get; set; }

        int? WindowWidth { get; set; }

        bool MaximizeWindow { get; set; }

        string StartPageUrl { get; set; }
    }
}
