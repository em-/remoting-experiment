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
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Threading;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using Mono.Remoting.Channels.Unix;

public class Remoting : IDisposable {
    private Process mProcess;
    
    public string SocketPath {get; private set;}

    public Remoting()
    {
        SocketPath = Path.GetTempFileName();
    }

    ~Remoting()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if(disposing)
        {
            try {
               mProcess.Kill();
            } catch {}
            mProcess.Dispose();
            mProcess = null;
        }

        try {
           File.Delete(SocketPath);
        } catch {}
        SocketPath = null;
    }


    public void Start(string helper, string param)
    {
        mProcess = Process.Start(helper, param);
        Thread.Sleep(250);
    }
    
    public T Get<T>()
    {
        Hashtable props = new Hashtable();
        props ["name"] = "unix_"+Path.GetFileName(SocketPath);
        IChannel channel = new UnixChannel(props, null, null);
        ChannelServices.RegisterChannel(channel, false);

        T obj = (T) Activator.GetObject(
                typeof(T),
                String.Format("unix://{0}?/{1}", SocketPath, typeof(T)) );
        return obj;
    }

    public static void Publish(string socketPath, MarshalByRefObject obj)
    {
        IChannel channel = new UnixChannel(socketPath);
        ChannelServices.RegisterChannel(channel, false);
        
        RemotingServices.Marshal(obj, obj.GetType().ToString());
    }
}
