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
using System.Diagnostics;

namespace KOEI.WP7_2012.Helper 
{
	/// <summary>
	/// プロセスメモリを管理するクラス
	/// </summary>
	public class ProcessMemory : IDisposable
	{
		private Process process_;
		private string processName_;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="processName">対象のプロセス名</param>
		/// <exception cref="ArgumentException">引数で指定したプロセス名が見つからなかった場合に発生する例外</exception>
		public ProcessMemory( String processName )
			: this( processName, ReadWriteMode.ReadWrite )
		{}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="processName">対象のプロセス名</param>
		/// <param name="mode">読み書きモード</param>
		/// <exception cref="ArgumentException">引数で指定したプロセス名が見つからなかった場合に発生する例外</exception>
		public ProcessMemory( String processName, ReadWriteMode mode )
		{
			this.processName_ = processName;
			this.Mode = mode;
			this.process_ = ProcessMemory.FindProcess( this.processName_ );
			if( this.process_ == null ) {
				throw new ArgumentException( String.Format( "プロセス {0} が見つかりません", processName ) );
			}
		}

		/// <summary>
		/// 読み書きモード
		/// </summary>
		public ReadWriteMode Mode {
			get;
			set;
		}

		/// <summary>
		/// プロセスID
		/// </summary>
		public int ProcessId {
			get {
				return this.process_.Id;
			}
		}

		/// <summary>
		/// インスタンスの破棄
		/// </summary>
		public void Dispose()
		{
			if( this.process_ != null ) {
				this.process_ = null;
			}
		}

		/// <summary>
		/// 最後に発生したエラー番号
		/// </summary>
		/// <returns>DllImportAttribute.SetLastError フラグを設定したプラットフォーム呼び出しを使用して呼び出した、最終アンマネージ関数によって返されるエラー コードを返します。</returns>
		public int GetLastWin32Error()
		{
			return Marshal.GetLastWin32Error();
		}

		/// <summary>
		/// バイト配列をプロセスメモリの指定したアドレスに書き込む
		/// </summary>
		/// <param name="address">プロセスメモリ上のアドレス</param>
		/// <param name="writeData">書き込むデータ</param>
		/// <returns>書き込んだバイト数</returns>
		/// <exception cref="ApplicationException">書き込みに失敗した場合に発生する例外</exception>
		public int WriteMemory( UInt32 address, byte[] writeData  )
		{
			if( this.Mode == ReadWriteMode.ReadOnly ) {
				throw new ApplicationException("WriteMemory - Failed Read Only Mode");
			}

			var write_byte = 0;

			if( Win32API.WriteProcessMemory( this.process_.Handle, (IntPtr)address, writeData, (UInt32)writeData.Length, out write_byte ) == false ) {
				throw new ApplicationException(
					String.Format("WriteProcessMemory - Failed with win32 error code .. {0} address .. {1:X}", Marshal.GetLastWin32Error(), address )
				);
			}
			return write_byte;
		}

		/// <summary>
		/// アドレスを指定してプロセスメモリからデータを読み取り
		/// </summary>
		/// <param name="address">読み込み先のアドレス</param>
		/// <param name="size">読み込みたいサイズ</param>
		/// <returns>読み込んだデータ</returns>
		/// <exception cref="ApplicationException">読み取りに失敗した場合に発生する例外</exception>
		public byte[] ReadMemory( UInt32 address, UInt32 size  )
		{
			var buff = new byte[size];
			var read_byte = 0;

			if( Win32API.ReadProcessMemory( this.process_.Handle, (IntPtr)address, buff, size, out read_byte ) == false ) {
				throw new ApplicationException(
					String.Format("ReadProcessMemory - Failed with win32 error code .. {0} address .. {1:X}", Marshal.GetLastWin32Error(), address )
				);
			}
			return buff;
		}

		/// <summary>
		/// 引数で与えた文字列とプロセス名が一致するプロセスを探す
		/// </summary>
		/// <param name="processName">プロセス名</param>
		/// <returns>プロセス情報</returns>
		public static System.Diagnostics.Process FindProcess( String processName )
		{
			var handleToSnapshot = IntPtr.Zero;

			if( processName == "" ) {
				return null;
			}

			try {
				var pe = new Win32API.PROCESSENTRY32() {
					dwSize = (UInt32)Marshal.SizeOf( typeof(Win32API.PROCESSENTRY32) ),
				};
				if( ( handleToSnapshot = Win32API.CreateToolhelp32Snapshot( (uint)Win32API.SnapshotFlags.Process, 0 ) ).ToInt32() == -1 ) {
					throw new ApplicationException(
						String.Format( "CreateToolhelp32Snapshot - Failed with win32 error code .. {0}", Marshal.GetLastWin32Error() ) );
				}
				if( Win32API.Process32First( handleToSnapshot, ref pe ) ) {
					do {
						if( pe.szExeFile.ToLower() == processName.ToLower() ) {
							return System.Diagnostics.Process.GetProcessById( (int)pe.th32ProcessID );
						}
					} while( Win32API.Process32Next( handleToSnapshot, ref pe) );
				} else {
					throw new ApplicationException(
						String.Format( "Process32First - Failed with win32 error code .. {0}", Marshal.GetLastWin32Error() ) );
				}
			} catch( Exception ex ) {
				throw new ApplicationException( "Can't get the process.", ex );
			} finally {
				Win32API.CloseHandle( handleToSnapshot );
			}
			return null;
		}
	}
}
