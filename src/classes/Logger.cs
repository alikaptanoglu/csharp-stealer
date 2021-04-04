using System;
using System.IO;
using System.Text;
using System.Management;

namespace Logger
{
	public class logger
	{
		private string stamp;
		private string path;
		
		public logger(string path, string stamp)
		{
			this.stamp = stamp;
			this.path = @path;
		}

		public void write(string text)
		{
			try{
				if (!File.Exists(path))
				{
					using (StreamWriter sw = File.CreateText(path))
					{
						sw.WriteLine(stamp);
						Console.WriteLine(stamp);
					}
					write(text);
				} else {
					using (StreamWriter sw = File.AppendText(path))
					{
						sw.WriteLine(text);
						Console.WriteLine(text);
					}
				}
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine(e);
			}

		}
		public void GetComponent(string hwclass, string premessage, string syntax, string aftermessage)
		{
			try{
				ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
				foreach (ManagementObject mo in mos.Get()){
					write(premessage + Convert.ToString(mo[syntax]) + aftermessage);
				}
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine(e);
			}
		}
	}
}