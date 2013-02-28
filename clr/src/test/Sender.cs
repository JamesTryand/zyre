using clrzmq;
using clrzre;

// import org.zeromq.ZMsg;
// import org.zyre.ZreInterface;

namespace examples {
	public class Sender
	{
		public static void main (string[] args)
		{
			if (args.Length < 2) {
				System.Console.WriteLine("Syntax: Sender.exe filename virtualname");
				return;
			}
			System.Console.WriteLine("Publishing {0} as {1}\n", args [0], args [1]);
			ZreInterface inf = new ZreInterface ();
			inf.publish (args [0], args [1]);
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
}