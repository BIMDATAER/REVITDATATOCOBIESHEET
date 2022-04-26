#define TRACE
using System.Diagnostics;
using System.IO;

namespace RDES.Common.Lumberjack
{
	public class RDTraceListener : TextWriterTraceListener
	{
		public RDTraceListener(string fileName)
		{
			try
			{
				base.Writer = new StreamWriter(fileName);
			}
			catch
			{
				base.Writer = new StreamWriter(Path.GetTempFileName());
			}
		}

		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
		{
			WriteLine("");
			Trace.WriteLine("");
		}

		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
		{
			Trace.WriteLine(message);
			WriteLine(message);
		}
	}
}
