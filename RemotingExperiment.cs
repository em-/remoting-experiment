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
        using(Remoting helper = new Remoting()) {
            helper.Start("RemotingHelper.exe", helper.SocketPath);
            DoSomething doSomething = helper.Get<DoSomething>();
            doSomething.PrepareYourself();
            doSomething.SetThingsUp();
            doSomething.Go();
        }
        return 0;
    }

    public static int Help()
    {
        Console.WriteLine("Usage: RemotingExperiment.exe");
        return 1;
    }
}
