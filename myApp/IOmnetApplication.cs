using System;

namespace OmnetServices {

	public class StaticOmnetInterface { 
	    
		public static void Method(int num)
        {
			OmnetInterface
        }

		public static void initSimulation()
        {
			
        }

		public static void simulationReady()
        {
			
        }

		public static void simulationFinished()
        {
			
        }
        
		public static void receptionNotify(ulong destId, ulong srcId, int msgId, int status)
        {

        }

		public static void timerNotify(ulong nodeId)
        {
			
        }

		public static void globalTimerNotify()
        {
			
        }

	}

	public class OmnetInterface
    {
		public void Method(int num)
        {
			
        }

        public void initSimulation()
        {
			Console.WriteLine("C# : initSimulation is called");
        }

        public void simulationReady()
        {
			Console.WriteLine("C# : simulationReady is called");
        }

        public void simulationFinished()
        {
			Console.WriteLine("C# : simulationFinished is called");
        }

        public void receptionNotify(ulong destId, ulong srcId, int msgId, int status)
        {
			Console.WriteLine("C# : receptionNotify is called with destID=" + destId + " srcId=" + srcId + " msgId=" + msgId + " status=" + status);
        }

        public void timerNotify(ulong nodeId)
        {
			Console.WriteLine("C# : timerNotify is called with nodeId=" + nodeId);
        }

        public void globalTimerNotify()
        {
			Console.WriteLine("C# : globalTimerNotify is called");
        }
    }
}