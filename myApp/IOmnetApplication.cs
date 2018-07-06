using System;

namespace OmnetServices {

	public class OmnetInterface { 
	    
		public static void Method(int num)
        {
			//IOmnetApplication.Method(num);
            Console.WriteLine("Hello C# static " + num);
			OmnetSimulation.GetInstance().Test();
        }

		public static void initSimulation()
        {
			Console.WriteLine("C# : initSimulation is called");
			OmnetSimulation.GetInstance().CreateNode(1);
			OmnetSimulation.GetInstance().CreateNode(2);
        }

		public static void simulationReady()
        {
			Console.WriteLine("C# : simulationReady is called");
			OmnetSimulation.GetInstance().Send(1, 2, 10, 123);
        }

		public static void simulationFinished()
        {
			Console.WriteLine("C# : simulationFinished is called");
        }

		public static void receptionNotify(ulong destId, ulong srcId, int msgId, int status)
        {
			Console.WriteLine("C# : receptionNotify is called with destID=" + destId + " srcId=" + srcId +" msgId=" + msgId +" status=" + status);
        }

		public static void timerNotify(ulong nodeId)
        {
			Console.WriteLine("C# : timerNotify is called with nodeId=" + nodeId);
        }

		public static void globalTimerNotify()
        {
			Console.WriteLine("C# : globalTimerNotify is called");
        }

	}
}