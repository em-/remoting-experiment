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
        return false;
    }

    public object[] WhatsUp()
    {
        object[] values = new object[] {};
        return values;
    }
}
