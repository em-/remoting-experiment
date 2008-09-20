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
using System.Runtime.Remoting;

public class DoSomething : MarshalByRefObject
{
    private int mCount = 0;

    public void PrepareYourself()
    {
        Console.WriteLine("ready");
    }
    
    public void SetThingsUp()
    {
        Console.WriteLine("set");
    }
    
    public void Go()
    {
        Console.WriteLine("go");
    }

    public bool HaveYouFinished()
    {
        return mCount++ > 30000;
    }

    public object[] WhatsUp()
    {
        object[] values = new object[] {
            "42 42 42 42 42 42 42 42 42 42 42 42 42 42 42 42",
            (int) 42,
            (decimal) 42.0,
            (long) 42,
            (double) 42,
            (float) 42
        };
        return values;
    }
}
