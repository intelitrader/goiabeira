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
        public void FromApp(Message msg, SessionID sessionID) { Console.WriteLine("IN:  " + Decoder.Decode(msg)); }
        public void ToApp(Message msg, SessionID sessionID) { Console.WriteLine("OUT: " + Decoder.Decode(msg)); }
        public void FromAdmin(Message msg, SessionID sessionID) { Console.WriteLine("IN:  " + Decoder.Decode(msg)); }
        public void ToAdmin(Message msg, SessionID sessionID) { Console.WriteLine("OUT:  " + Decoder.Decode(msg)); }
        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { }

    }
}
