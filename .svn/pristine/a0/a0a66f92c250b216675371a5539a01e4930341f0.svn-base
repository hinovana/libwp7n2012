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
	/// <summary>
	/// プロセスメモリ上の馬名テーブルを管理するクラス
	/// </summary>
	public class HorseNameTable
	{
		private KOEI.WP7_2012.Helper.ProcessMemory pm_;
		private Dictionary< int, KOEI.WP7_2012.Horse.Name.NameData > name_data_dic_;
		private ConfigurationInterface config_;
		private HorseNameTableConfiguration system_table_config_;
		private HorseNameTableConfiguration user_table_config_;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pm">対象のプロセスメモリ</param>
		/// <param name="config">プロセスメモリ上のアドレスや定数</param>
		public HorseNameTable( KOEI.WP7_2012.Helper.ProcessMemory pm, ConfigurationInterface config )
		{
			this.pm_ = pm;
			this.name_data_dic_ = new Dictionary< int, KOEI.WP7_2012.Horse.Name.NameData >();
			this.config_ = config;
			this.system_table_config_ = config.HorseNameSystemTable;
			this.user_table_config_ = config.HorseNameUserTable;

			// システム既定の馬名テーブルを作成する
			this.CreateSystemNameTable();

			// ユーザー定義の馬名テーブルを作成する
			this.CreateUserNameTable();
		}

		/// <summary>
		/// 馬名情報を返すイテレータ(foreachで使用)
		/// </summary>
		/// <returns>馬名情報</returns>
		public IEnumerator< KOEI.WP7_2012.Horse.Name.NameData > GetEnumerator()
		{
			foreach( var name_data in this.name_data_dic_ ) {
				yield return name_data.Value;
			}
		}

		/// <summary>
		/// 馬名情報を返す
		/// </summary>
		/// <param name="n">馬名番号</param>
		/// <returns>馬名情報、見つから無い場合はnullを返す</returns>
		public KOEI.WP7_2012.Horse.Name.NameData this[int n]
		{
			get {
				if( !this.name_data_dic_.ContainsKey(n) ) {
					return null;
				}
				return this.name_data_dic_[n];
			}
		}

		private static bool IsKana( byte x )
		{
			return ( x >= 0xB6 && x <= 0xC4 ) || ( x >= 0x01 && x <= 0x56 ) || ( x >= 0xA2 && x <= 0xAB ) || ( x >= 0xB6 && x <= 0xC4  ) || ( x==0xFE );
		}

		private static bool IsEnglish( byte x )
		{
			return ( x >= 0x57 && x <= 0x9E ) || ( x >= 0x9F && x <= 0xA1 ) || ( x >= 0xAC && x <= 0xB4 ) || ( x == 0xFD );
		}

		private void CreateSystemNameTable()
		{
			var table_size = BitConverter.ToUInt32( this.pm_.ReadMemory( this.system_table_config_.TableSizeAddress, 4 ), 0 );
			var pointer_address = BitConverter.ToUInt32( this.pm_.ReadMemory( this.system_table_config_.PointerAddress, 4 ), 0 );
			var table = this.pm_.ReadMemory( pointer_address, table_size );

			using( var ms = new System.IO.MemoryStream( table ) ) {
				for( var i=0; i<this.system_table_config_.RecordMaxLength; ++i ) {
					var b = 0;
					var name_data = new KOEI.WP7_2012.Horse.Name.NameData() {
						Id = (uint)i,
						Type = KOEI.WP7_2012.Horse.Name.NameDataType.SYSTEM,
					};
					using( var buff = new System.IO.MemoryStream() ) {
						while( true ) {
							if( ( b = ms.ReadByte() ) == -1 ) {
								throw new Exception("馬名テーブルが解析できませんでした");
							}
							if( !IsKana( (byte)b ) && !IsEnglish( (byte)b ) ) {
								throw new Exception("馬名テーブルが解析できませんでした(カナ)");
							}
							if( !IsKana( (byte)b ) ) {
								ms.Seek( -1, System.IO.SeekOrigin.Current );							
								name_data.Kana = KOEI.WP7_2012.Helper.KoeiCode.ToString( buff.ToArray() );
								break;
							}
							buff.WriteByte( (byte)b );
						}
					}
					using( var buff = new System.IO.MemoryStream() ) {
						while( true ) {
							if( ( b = ms.ReadByte() ) == -1 ) {
								break;
//								throw new Exception("馬名テーブルが解析できませんでした");
							}
							if( !IsKana( (byte)b ) && !IsEnglish( (byte)b ) && i != this.system_table_config_.RecordMaxLength ) {
								throw new Exception("馬名テーブルが解析できませんでした(英語)");
							}
							if( !IsEnglish( (byte)b ) ) {
								ms.Seek( -1, System.IO.SeekOrigin.Current );
								name_data.English = KOEI.WP7_2012.Helper.KoeiCode.ToString( buff.ToArray() );
								break;
							}
							// ①とか余計な文字は無視する
							if( ( b >= 0x57 && b <= 0x9E ) || b == 0xFD ) {
								buff.WriteByte( (byte)b );
							}
						}
					}
					this.name_data_dic_[i] = name_data;
				}
			}
		}

		private void CreateUserNameTable()
		{
			var table_size = BitConverter.ToUInt32( this.pm_.ReadMemory( this.user_table_config_.TableSizeAddress, 4 ), 0 );
			var pointer_address = BitConverter.ToUInt32( this.pm_.ReadMemory( this.user_table_config_.PointerAddress, 4 ), 0 );
			var table = this.pm_.ReadMemory( pointer_address, table_size );

			var i = this.user_table_config_.StartNumber;

			using( var ms = new System.IO.MemoryStream( table ) ) {
				var buff = new byte[9];
				while(true) {
					if( ms.Read( buff, 0, buff.Length ) != buff.Length ) {
						break;
					}
					if( buff[0] == 0 && i > config_.UserNameTableStartNumber + 1 ) {
						break;
					}
					var name = KOEI.WP7_2012.Helper.KoeiCode.ToString( buff );

					this.name_data_dic_[ (int)i ] = new KOEI.WP7_2012.Horse.Name.NameData() {
						Id = i,
						Kana = name,
						English = name,
						Type = KOEI.WP7_2012.Horse.Name.NameDataType.USER,
					};
					i++;
				}
			}
		}

	}
}
