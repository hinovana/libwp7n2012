/* libwp7n2012 -- Winning Post 7 2012 Cheat Library

   Copyright (C) 2012 AIPON of author

   This library is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 2.1 of the License, or (at your option) any later version.

   This library is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with this library; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

   Written by AIPON */

using System;
using System.Runtime.InteropServices;

namespace KOEI.WP7_2012.Helper
{
	class Win32API
	{
		[Flags]
		public enum SnapshotFlags : uint
		{
			HeapList = 0x00000001,
			Process  = 0x00000002,
			Thread   = 0x00000004,
			Module   = 0x00000008,
			Module32 = 0x00000010,
			Inherit  = 0x80000000,
			All      = 0x0000001F
		};

		//inner struct used only internally
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct PROCESSENTRY32
		{
			const int MAX_PATH = 260;
			internal UInt32   dwSize;
			internal UInt32   cntUsage;
			internal UInt32   th32ProcessID;
			internal IntPtr   th32DefaultHeapID;
			internal UInt32   th32ModuleID;
			internal UInt32   cntThreads;
			internal UInt32   th32ParentProcessID;
			internal Int32    pcPriClassBase;
			internal UInt32   dwFlags;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			internal string   szExeFile;
		};

		[Flags]
		public enum ProcessAccessFlags : uint
		{
			All              = 0x001F0FFF,
			Terminate        = 0x00000001,
			CreateThread     = 0x00000002,
			VMOperation      = 0x00000008,
			VMRead           = 0x00000010,
			VMWrite          = 0x00000020,
			DupHandle        = 0x00000040,
			SetInformation   = 0x00000200,
			QueryInformation = 0x00000400,
			Synchronize      = 0x00100000
		};

		[DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern IntPtr CreateToolhelp32Snapshot
		(
			[In] UInt32 dwFlags,
			[In] UInt32 th32ProcessID
		);

		[DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern Boolean Process32First
		(
			[In] IntPtr hSnapshot,
			ref PROCESSENTRY32 lppe
		);

		[DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern bool Process32Next
		(
			[In] IntPtr hSnapshot,
			ref PROCESSENTRY32 lppe
		);

		[DllImport("kernel32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle
		(
			[In] IntPtr hObject
		);

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess
		(
			ProcessAccessFlags dwDesiredAccess,
			[MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
			int dwProcessId
		);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory
		(
			IntPtr hProcess,
			IntPtr lpBaseAddress,
			[Out] byte[] lpBuffer,
			int dwSize,
			out int lpNumberOfBytesRead
		);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory
		(
			IntPtr hProcess,
			IntPtr lpBaseAddress,
			[Out(), MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
			UInt32 dwSize,
			out int lpNumberOfBytesRead
		);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory
		(
			IntPtr hProcess,
			IntPtr lpBaseAddress,
			IntPtr lpBuffer,
			UInt32 dwSize,
			out int lpNumberOfBytesRead
		);

		[DllImport("kernel32.dll",SetLastError = true)]
		public static extern bool WriteProcessMemory
		(
			IntPtr hProcess,
			IntPtr lpBaseAddress,
			byte [] lpBuffer,
			uint nSize,
			out int lpNumberOfBytesWritten
		);
	}
}
