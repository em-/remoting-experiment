/* RemotingExperiment
 *
 * Experiment with Remoting in Mono
 *
 * (c) 2008 Emanuele Aina <em@nerd.ocracy.org>
 * http://nerd.ocracy.org/em
 *
 * Do whatever you want with it.
 */

using System;
using System.Threading;

public class RemotingHelper
{
    public static int Main(string[] args)
    {
        if(args.Length == 1)
            return Helper(args[0]);
        else
            return Help();
    }

    public static int Helper(string socketPath)
    {
        DoSomething self = new DoSomething();
        Remoting.Publish(socketPath, self);

        Thread.Sleep(Timeout.Infinite);
        return 0;
    }

    public static int Help()
    {
        Console.WriteLine("Usage: RemotingHelper.exe SOCKETPATH");
        return 1;
    }
}

