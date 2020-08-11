using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Biing2WPF.Biing2
{
    public static class Memory
    {
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_WM_READ = 0x0010;
        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);
        public static Process GetProcessByName(string processName)
        {

            Process[] processes = Process.GetProcessesByName(processName);
            try
            {
                return Process.GetProcessesByName(processName)[0];
            }
            catch
            {
                MessageBox.Show($"Process {processName} is not running!", "Process Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }

        }
        public static IntPtr GetModuleBaseAddress(Process p, string moduleName)
        {
            foreach (ProcessModule m in p.Modules)
            {
                if (m.ModuleName == moduleName)
                {
                    return m.BaseAddress;
                }
            }
            return IntPtr.Zero;
        }
        public static uint ReadInt32Ptr(int pHandle, int address)
        {
            return BitConverter.ToUInt32(Read(pHandle, address, 4));
        }
        public static byte[] Read(int pHandle, int address, uint tSize)
        {
            int bytesRead = 0;
            byte[] pBuffer = new byte[tSize];
            ReadProcessMemory(pHandle, address, pBuffer, pBuffer.Length, ref bytesRead);
            return pBuffer;
        }
        public static void Write(uint pHandle, uint address, byte value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, buffer.Length);
        }
        public static void Write(uint pHandle, uint address, ushort value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, buffer.Length);
        }
        public static void Write(uint pHandle, uint address, uint value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, buffer.Length);
        }
        static void Write(uint pHandle, uint address, byte[] buffer, int tSize)
        {
            int bytesWritten = 0;
            WriteProcessMemory((int)pHandle, (int)address, buffer, tSize, ref bytesWritten);
        }
    }
}
