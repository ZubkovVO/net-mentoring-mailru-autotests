using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.Utility
{
    public class MethodNameIdentifier
    {
        public string TestName{get; set;}
        
        public string TraceMessage([CallerMemberName] string memberName = "")
        {
            //Logger.Log.Info("Test name " + memberName);
            return memberName;
           
        }

    }
}
