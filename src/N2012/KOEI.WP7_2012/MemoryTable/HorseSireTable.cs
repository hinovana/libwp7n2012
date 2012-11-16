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
using System.Collections.Generic;

namespace KOEI.WP7_2012.MemoryTable
{
	public class HorseSireTable : ProcessMemoryTable
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pm">対象のプロセスメモリ</param>
		/// <param name="config">プロセスメモリ上のデータテーブル(配列)の構造情報</param>
		public HorseSireTable( KOEI.WP7_2012.Helper.ProcessMemory pm, ProcessMemoryTableConfiguration config )
			: base( pm, config ) {}

		/// <summary>
		/// 構造体をデータテーブルにセットする
		/// Commitするまでは実際のプロセスメモリには書き込まれません
		/// </summary>
		/// <param name="n">種牡馬番号</param>
		/// <param name="data">種牡馬データ</param>
		public void SetData( UInt32 n, ref Datastruct.HSireData data )
		{
			base.Write( n, data.Decode() );
		}

		/// <summary>
		/// データテーブルからレコード読み取って構造体にして返す
		/// </summary>
		/// <param name="n">種牡馬番号</param>
		/// <param name="data">種牡馬データ</param>
		public void GetData( UInt32 n, ref Datastruct.HSireData data )
		{
			base.GetDatastruct< Datastruct.HSireData >( n, ref data );
		}
	}
}
