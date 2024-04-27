using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Linq;

namespace UsbDemo
{


    /// <summary>
    /// 获取硬盘号和CPU号
    /// </summary>
    public class WmiHelper
    {
        public class MachineNumber
        {
            public static string 系统_获取IP地址()
            {
                var st = string.Empty;
                var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                var moc = mc.GetInstances();
                foreach (var o in moc)
                {
                    var mo = (ManagementObject)o;
                    if (!(bool)mo["IPEnabled"]) continue;
                    var ar = (Array)(mo.Properties["IpAddress"].Value);
                    st = ar.GetValue(0).ToString();
                    break;
                }
                return st;
            }
            /// <summary>
            /// 获得本机IP地址
            /// </summary>
            /// <param name="hostname"></param>
            /// <returns></returns>
            public static string DoGetHostEntry()
            {
                System.Net.IPHostEntry IpEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                string localhostipv4Address = "";

                for (int i = 0; i != IpEntry.AddressList.Length; i++)
                {
                    if (!IpEntry.AddressList[i].IsIPv6LinkLocal)
                    {
                        localhostipv4Address = IpEntry.AddressList[i].ToString();
                        break;
                    }
                }

                return localhostipv4Address;
            }
            public static string Get显示器()
            {      // string disply_Info = MachineNumber.Get显示器();
                   //string[] display = disply_Info.Split('\\');//处理获取信息 依据实际情况为准    
                   //textBox9.Text = display[1];
                string str = "";
                ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_DesktopMonitor");
                foreach (ManagementObject mo in mos.Get())
                {
                    str = mo["PNPDeviceID"].ToString();
                }
                return str;
            }
            public static string 获取内存条大小()
            {   double capacity = 0;
                ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo1 in moc1)
                {
                    capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
                }
                moc1.Dispose();
                cimobject1.Dispose();
                return capacity.ToString(); ;
            }


            public static string 系统_CPU名称信息()
            {
                ManagementObjectSearcher driveId = new ManagementObjectSearcher("Select * from Win32_Processor");
                foreach (ManagementObject o in driveId.Get())
                {
                    return o["Name"].ToString();
                }
                return null;
            }
            public static string 系统_时区()
            {
                ManagementObjectSearcher driveId = new ManagementObjectSearcher("Select * from Win32_TimeZone");
                foreach (ManagementObject o in driveId.Get())
                {
                    return o["Caption"].ToString();
                }
                return null;
            }


            public static string 系统_取内存个数()
            {
                ManagementObjectSearcher searcherd = new ManagementObjectSearcher("Select * From Win32_PhysicalMemory");
                foreach (ManagementObject mo in searcherd.Get())
                {
                   return mo["Tag"].ToString() ;
                }
                return null;
            }
                public static string 取显卡信息()
            {
                try
                {
                ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_DisplayConfiguration");
                foreach (ManagementObject obj in objvide.Get())
                {
                    return obj["DeviceName"].ToString();
                }
                return "........";
                }
                catch
                {
                    return "........";
                }
            }
            public static string 取USB信息()
            {
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_USBController");
                    foreach (ManagementObject mo in searcher.Get())
                    {
                        return mo["Name"].ToString().Trim();
                    }
                    return "........";
                }
                catch
                {
                    return "........";
                }
            }
            public static string 取声卡信息()
            {
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_SoundDevice");
                    foreach (ManagementObject mo in searcher.Get())
                    {
                        return mo["Name"].ToString().Trim();
                    }
                    return "........";
                }
                catch
                {
                    return "........";
                }
            }
      
            public static string 取内存信息()
            {   try
                { ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_SoundDevice");
                    foreach (ManagementObject mo in searcher.Get())
                    {
                        return mo["Name"].ToString().Trim();
                    }
                    return "........";
                }
                catch
                {
                    return "........";
                }
            }
            public static string 系统_主板型号()
            { try
                {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_BaseBoard");
                foreach (ManagementObject mo in mos.Get())
                {
                    return mo["Product"].ToString();
                }
                return "........";
                }
                catch
                {
                    return "........";
                }
            }

        }
}
}


    

 
