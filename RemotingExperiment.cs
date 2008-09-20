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

public class RemotingExperiment
{
    public static int Main(string[] args)
    {
        if(args.Length == 0)
            return Run();
        else
            return Help();
    }

    public static int Run()
    {
        DoSomething doSomething;
        TimeSpan time;

        using(Remoting helper = new Remoting()) {
            helper.Start("RemotingHelper.exe", helper.SocketPath);
            doSomething = helper.Get<DoSomething>();
            time = Do(doSomething);
            Console.WriteLine("Elapsed (remote): {0}", time);
        }

        doSomething = new DoSomething();
        time = Do(doSomething);
        Console.WriteLine("Elapsed (local): {0}", time);
        return 0;
    }

    public static TimeSpan Do(DoSomething doSomething)
    {
        DateTime start = DateTime.Now;
        while(!doSomething.HaveYouFinished()) {
            object[] results = doSomething.WhatsUp();
            // just to say that whe use the results
            results.ToString();
        }
        DateTime end = DateTime.Now;
        return end - start;
    }

    public static int Help()
    {
        Console.WriteLine("Usage: RemotingExperiment.exe");
        return 1;
    }
}
