#define TRACE
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using RDES.Common.Lumberjack;

namespace Lumberjack
{
	public class Logger
	{
		private TraceSource mySource;

		private Guid myID = Guid.NewGuid();

		private string _prog = string.Empty;

		private int _importance = 1;

		public string logDirectory { get; set; }

		public string NamePrefix { get; set; }

		public string ProgramName => _prog;

		public string FileName => NamePrefix + " - " + GetDateDisplay("_") + "-" + GetTimeDisplay("_", includeMiliSeconds: false, includeTab: false) + ".log";

		public Logger(string LogDirectory, string LogNamePrefix, string ProgName)
		{
			logDirectory = LogDirectory;
			NamePrefix = LogNamePrefix;
			_prog = ProgName;
			if (!Directory.Exists(logDirectory))
			{
				Directory.CreateDirectory(logDirectory);
			}
			string fileName = Path.Combine(LogDirectory, FileName);
			mySource = new TraceSource(myID.ToString(), SourceLevels.All);
			mySource.Switch = new SourceSwitch("sourceSwitch");
			mySource.Switch.Level = SourceLevels.All;
			mySource.Listeners.Remove("Default");
			RDTraceListener listener = new RDTraceListener(fileName)
			{
				Filter = new SourceFilter(myID.ToString())
			};
			mySource.Listeners.Add(listener);
			AddLine("File log created by lumberjack version " + Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor, flush: false);
			AddLine("Created\t\t" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + GetTimeDisplay(":", includeMiliSeconds: true, includeTab: true), flush: false);
			AddLine("Program Name\t" + ProgramName, flush: false);
			//AddLine("OS\t\t" + GetOSString(), flush: false);
			AddLine("OS Numerical\t" + Environment.OSVersion.Version.ToString(), flush: false);
			AddLine("OS 64 Bit\t" + Environment.Is64BitOperatingSystem, flush: false);
			AddLine("");
		}

		public void AddLine(string txt, bool flush = true)
		{
			if (txt == "")
			{
				mySource.TraceEvent(TraceEventType.Information, 1, txt);
			}
			else
			{
				mySource.TraceEvent(TraceEventType.Information, 1, GetTimeDisplay(":", includeMiliSeconds: true, includeTab: true) + "\t" + txt);
			}
			if (flush)
			{
				mySource.Flush();
			}
		}

		public void AddLine(string txt, string ModuleCode, bool flush = true)
		{
			if (txt == "")
			{
				mySource.TraceEvent(TraceEventType.Information, 1, txt);
			}
			else
			{
				mySource.TraceEvent(TraceEventType.Information, 1, GetTimeDisplay(":", includeMiliSeconds: true, includeTab: true) + ModuleCode + "\t" + txt);
			}
			if (flush)
			{
				mySource.Flush();
			}
		}

		public void Flush()
		{
			mySource.Flush();
		}

		public void Close()
		{
			if (mySource != null)
			{
				mySource.Flush();
				mySource.Close();
			}
		}

		public void CleanDirectory(int AgingDays)
		{
			string[] files = Directory.GetFiles(logDirectory, "*.log", SearchOption.TopDirectoryOnly);
			foreach (string path in files)
			{
				DateTime creationTime = File.GetCreationTime(path);
				TimeSpan timeSpan = DateTime.Now - creationTime;
				TimeSpan timeSpan2 = new TimeSpan(AgingDays, 0, 0, 0);
				if (timeSpan > timeSpan2)
				{
					try
					{
						File.Delete(path);
					}
					catch
					{
					}
				}
			}
		}

		private string GetTimeDisplay(string delimiter, bool includeMiliSeconds, bool includeTab)
		{
			string text = DateTime.Now.Hour.ToString();
			string text2 = DateTime.Now.Minute.ToString();
			string text3 = DateTime.Now.Second.ToString();
			string text4 = DateTime.Now.Millisecond.ToString();
			if (text.Length == 1)
			{
				text = "0" + text;
			}
			if (text2.Length == 1)
			{
				text2 = "0" + text2;
			}
			if (text3.Length == 1)
			{
				text3 = "0" + text3;
			}
			switch (text4.Length)
			{
			case 1:
				text4 = "00" + text4;
				break;
			case 2:
				text4 = "0" + text4;
				break;
			}
			string text5 = text + delimiter + text2 + delimiter + text3;
			if (includeMiliSeconds)
			{
				text5 = text5 + "." + text4;
			}
			if (includeTab)
			{
				text5 += "\t";
			}
			return text5;
		}

		private string GetDateDisplay(string delimiter)
		{
			string text = DateTime.Now.Year.ToString();
			string text2 = DateTime.Now.Month.ToString();
			string text3 = DateTime.Now.Day.ToString();
			if (text2.Length == 1)
			{
				text2 = "0" + text2;
			}
			if (text3.Length == 1)
			{
				text3 = "0" + text3;
			}
			return text + delimiter + text2 + delimiter + text3;
		}

		//private string GetOSString()
		//{
		//	string empty = string.Empty;
		//	empty = Environment.OSVersion.Version.Major switch
		//	{
		//		5 => Environment.OSVersion.Version.Minor switch
		//		{
		//			0 => empty + "Windows 2000", 
		//			1 => empty + "Windows XP", 
		//			2 => empty + "Windows 2003", 
		//			_ => empty + "Windows Undetermined", 
		//		}, 
		//		6 => Environment.OSVersion.Version.Minor switch
		//		{
		//			0 => empty + "Windows Vista", 
		//			1 => empty + "Windows 7", 
		//			2 => empty + "Windows 8", 
		//			_ => empty + "Windows Undetermined", 
		//		}, 
		//		_ => empty + "Windows Undetermined", 
		//	};
		//	empty = ((!Environment.Is64BitOperatingSystem) ? (empty + " x86") : (empty + " x64"));
		//	if (!string.IsNullOrEmpty(Environment.OSVersion.ServicePack))
		//	{
		//		empty = empty + " - " + Environment.OSVersion.ServicePack;
		//	}
		//	return empty;
		//}
	}
}
