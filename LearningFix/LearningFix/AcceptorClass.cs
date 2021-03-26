using QuickFix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningFix
{
    class AcceptorClass : IApplication
    {
        public void FromApp(Message msg, SessionID sessionID) { }
        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { }
        public void FromAdmin(Message msg, SessionID sessionID) { }
        public void ToAdmin(Message msg, SessionID sessionID) { }
        public void ToApp(Message msg, SessionID sessionID) { }
    }
}
