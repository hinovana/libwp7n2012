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

namespace KOEI.WP7_2012.MemoryTable
{
	/// <summary>
	/// プロセスメモリ上の馬名データテーブル(配列)の構造情報を管理するクラス
	/// </summary>
	public class HorseNameTableConfiguration
	{
		/// <summary>
		/// データテーブル(配列)へのポインタアドレス
		/// </summary>
		public UInt32 PointerAddress;

		/// <summary>
		/// データテーブル(配列)のメモリ確保サイズへのアドレス
		/// </summary>
		public UInt32 TableSizeAddress;

		/// <summary>
		/// 最大レコード数
		/// </summary>
		public UInt32 RecordMaxLength;

		/// <summary>
		/// 開始番号
		/// </summary>
		public UInt32 StartNumber;
	}
}
