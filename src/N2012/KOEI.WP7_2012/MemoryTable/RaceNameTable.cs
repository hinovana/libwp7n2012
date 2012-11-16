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
	public class RaceNameTable
	{
		private KOEI.WP7_2012.Helper.ProcessMemory pm_;
		private KOEI.WP7_2012.Race.Name.NameData[] name_table_;
		private ConfigurationInterface config_;
		private RaceNameTableConfiguration name_config_;

		/// <summary>
		/// レース名の数
		/// </summary>
		public int NameCount {
			get;
			private set;
		}


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pm">対象のプロセスメモリ</param>
		/// <param name="config">プロセスメモリ上のアドレスや定数</param>
		public RaceNameTable( KOEI.WP7_2012.Helper.ProcessMemory pm, ConfigurationInterface config )
		{
			this.pm_ = pm;
			this.config_ = config;
			this.name_config_ = config.RaceNameTable;
			this.NameCount = (int)this.name_config_.RecordMaxLength / 2;
			this.name_table_ = new KOEI.WP7_2012.Race.Name.NameData[ this.NameCount ];

			this.CreateRaceRaceNameTable();
		}

		/// <summary>
		/// レース名を返すイテレータ(foreachで使用)
		/// </summary>
		/// <returns>馬名情報</returns>
		public IEnumerator< KOEI.WP7_2012.Race.Name.NameData > GetEnumerator()
		{
			foreach( var name in this.name_table_ ) {
				yield return name;
			}
		}

		/// <summary>
		/// レース名情報を返す
		/// </summary>
		/// <param name="n">レース名番号</param>
		/// <returns>レース名情報、見つから無い場合はnullを返す</returns>
		public KOEI.WP7_2012.Race.Name.NameData this[ int n ]
		{
			get {
				if( n < 0 || NameCount <= n ) {
					return null;
				}
				return this.name_table_[n];
			}
		}


		private void CreateRaceRaceNameTable()
		{
			var address = BitConverter.ToUInt32( this.pm_.ReadMemory( this.name_config_.PointerAddress, sizeof(UInt32) ), 0 );
			var table_size = BitConverter.ToUInt32( this.pm_.ReadMemory( this.name_config_.TableSizeAddress, sizeof(UInt32) ), 0 );
			var table = this.pm_.ReadMemory( address, table_size );

			using( var ms = new System.IO.MemoryStream( table ) ) {
				for( var i=0u; i<this.NameCount; ++i ) {
					this.name_table_[i] = new KOEI.WP7_2012.Race.Name.NameData();
					this.name_table_[i].FullName = this.__GetCString__( ms );
					this.name_table_[i].ShortName = this.__GetCString__( ms );
				}
			}
		}

		private String __GetCString__( System.IO.MemoryStream ms )
		{
			// '\0'を読み飛ばす
			while(true) {
				if( ms.ReadByte() != 0 ) {
					ms.Seek( -1, System.IO.SeekOrigin.Current );
					break;
				}
			}
			using( var temp = new System.IO.MemoryStream() ) {
				while(true) {
					var b = ms.ReadByte();
					if( b == -1 ) {
						throw new Exception("レース名テーブルが解析できませんでした");
					}
					if( b == 0 ) {
						return System.Text.Encoding.GetEncoding(932).GetString( temp.ToArray() );
					}
					temp.WriteByte( (byte)b );
				}
			}
		}
	}
}
