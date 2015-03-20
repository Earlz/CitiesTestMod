using ICities;
using ChirpLogger;

namespace YourNameSpaceHere
{

    public class MyIThreadingExtensionBase: ThreadingExtensionBase
    {
		//Thread: Main
		public override void OnCreated(IThreading threading)
		{
			ChirpLog.Debug("IThreading Created");
		}
		//Thread: Main
		public override void OnReleased()
		{
		
		}
		

		
	 }
}
