using QuickFix;
using System;

namespace LearningFix
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("usage: SimpleAcceptor CONFIG_FILENAME");
                System.Environment.Exit(2);
            }

            try
            {
                SessionSettings settings = new SessionSettings(args[0]);
                IApplication app = new AcceptorClass();
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new FileLogFactory(settings);
                IAcceptor acceptor = new ThreadedSocketAcceptor(app, storeFactory, settings, logFactory);

                acceptor.Start();
                while (true)
                {
                    System.Console.WriteLine("IN");
                    Console.ReadLine();
                }
                acceptor.Stop();
            }
            catch (System.Exception e)
            {
                Console.WriteLine("==FATAL ERROR==");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
