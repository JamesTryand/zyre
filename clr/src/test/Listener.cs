using clrzmq;
using clrzre;

// import org.zeromq.ZMsg;
// import org.zyre.ZreInterface;

public class Listener
{
    public static void main (string[] args)
    {
        ZreInterface inf = new ZreInterface ();
        while (true) {
            ZMsg incoming = inf.recv ();
            if (incoming == null)
                break;
            incoming.dump (System.out);
            incoming.destroy ();
        }
        inf.destroy ();
    }

}