using System;
using Microsoft.AspNet.Testing.xunit;

namespace E2ETests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SkipOn32BitOSAttribute : Attribute, ITestCondition
    {
        public bool IsMet
        {
            get
            {
                return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ProgramFiles(x86)"));
            }
        }

        public string SkipReason
        {
            get
            {
                return "Skipping the AMD64 test since the OS is 32-bit";
            }
        }
    }
}