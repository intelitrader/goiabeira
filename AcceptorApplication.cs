using QuickFix;
using System;

namespace QuickfixAcceptor
{
    public class AcceptorApplication : IApplication
    {
        public void FromApp(Message message, SessionID sessionID)
        {
            Console.WriteLine("IN:  " + message);
        }

        public void ToApp(Message message, SessionID sessionID)
        {
            Console.WriteLine("OUT: " + message);
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
            Console.WriteLine("IN:  " + message);
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            Console.WriteLine("OUT:  " + message);
        }

        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { }
    }
}
