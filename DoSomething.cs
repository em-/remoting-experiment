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
    }
    
    public void SetThingsUp()
    {
    }
    
    public void Go()
    {
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
