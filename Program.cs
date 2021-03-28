using QuickFix;
using System;
using System.IO;

namespace QuickfixAcceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = File.OpenText("SessionSettings.cfg");
            SessionSettings settings = new SessionSettings(file);
            IApplication app = new AcceptorApplication();
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            IAcceptor acceptor = new ThreadedSocketAcceptor(app, storeFactory, settings, logFactory);
            acceptor.Start();
            Console.WriteLine("press <enter> to quit");
            Console.Read();
            acceptor.Stop();
        }
    }
}
