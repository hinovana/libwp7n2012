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

namespace KOEI.WP7_2012
{
	/// <summary>
	/// ウイニングポスト7のプロセスメモリを管理するクラス
	/// </summary>
	public class WP7 :IDisposable
	{
		private String process_name_;

		private KOEI.WP7_2012.Helper.ProcessMemory pm_;

		private KOEI.WP7_2012.MemoryTable.HorseNameTable name_table_;
		private KOEI.WP7_2012.MemoryTable.ProcessMemoryTable h_shizitsu_name_table_;

		private KOEI.WP7_2012.MemoryTable.HorseAblDataTable h_abl_table_;
		private KOEI.WP7_2012.MemoryTable.HorseBloodTable h_blood_table_;
		private KOEI.WP7_2012.MemoryTable.HorseFamilyLineTable h_family_line_table_;
		private KOEI.WP7_2012.MemoryTable.HorseRaceTable h_race_table_;
		private KOEI.WP7_2012.MemoryTable.HorseSireTable h_sire_table_;
		private KOEI.WP7_2012.MemoryTable.HorseDamTable h_dam_table_;
		private KOEI.WP7_2012.MemoryTable.HorseChildTable h_child_table_;
		private KOEI.WP7_2012.MemoryTable.HorseOwnershipRaceTable h_ownership_race_table_;
		private KOEI.WP7_2012.MemoryTable.HorseOwnershipChildTable h_ownership_child_table_;
		private KOEI.WP7_2012.MemoryTable.RaceNameTable r_name_table_;
		private KOEI.WP7_2012.MemoryTable.RaceDataTable r_data_table_;
		private KOEI.WP7_2012.MemoryTable.RaceProgramTable r_program_table_;

		private UInt32 transaction_week_number_;

		private KOEI.WP7_2012.ConfigurationInterface config_;


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="process_name">ウイニングポスト7のプロセス名</param>
		/// <param name="config">プロセスメモリのメモリアドレスなどの設定</param>
		/// <param name="mode">読み書きモード</param>
		public WP7( String process_name, ConfigurationInterface config, ReadWriteMode mode )
		{
			this.process_name_ = process_name;
			this.config_ = config;
			this.Transaction( mode );
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="config">プロセスメモリのメモリアドレスなどの設定</param>
		/// <param name="mode">読み書きモード</param>
		public WP7( ConfigurationInterface config, ReadWriteMode mode )
			: this( config.ProcessName, config, mode )
		{}

		/// <summary>
		/// コンストラクタ
		/// トランザクションを読み書きモードで開始します
		/// </summary>
		/// <param name="config">プロセスメモリのメモリアドレスなどの設定</param>
		public WP7( ConfigurationInterface config )
			: this( config.ProcessName, config, ReadWriteMode.ReadWrite )
		{}

		/// <summary>
		/// コンストラクタ
		/// トランザクションを読み書きモードで開始します
		/// </summary>
		/// <param name="process_name">ウイニングポスト7のプロセス名</param>
		/// <param name="config">プロセスメモリのメモリアドレスなどの設定</param>
		public WP7( String process_name, ConfigurationInterface config )
			: this( process_name, config, ReadWriteMode.ReadWrite )
		{}

		/// <summary>
		/// オブジェクトを破棄します
		/// </summary>
		public void Dispose()
		{
			if( this.pm_ != null ) {
				this.pm_.Dispose();
				this.pm_ = null;
			}
		}

		/// <summary>
		/// プロセスメモリのメモリアドレスなどの設定
		/// </summary>
		public ConfigurationInterface Config {
			get {
				return this.config_;
			}
		}

		/// <summary>
		/// 読み書きモード(既定はReadWriteMode.ReadWrite)
		/// </summary>
		public ReadWriteMode ReadWriteMode {
			get {
				return this.pm_.Mode;	
			}
			set {
				this.pm_.Mode = value;
			}
		}
		
		/// <summary>
		/// トランザクションを開始します
		/// </summary>
		private void Transaction( ReadWriteMode mode )
		{
			this.pm_ = new KOEI.WP7_2012.Helper.ProcessMemory( this.process_name_, mode );

			this.transaction_week_number_ = this.GetCurrentWeekNumber();

			this.name_table_ = new KOEI.WP7_2012.MemoryTable.HorseNameTable(
				this.pm_,
				this.config_
			);
			this.h_shizitsu_name_table_ = new KOEI.WP7_2012.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseShizitsuNameTable
			);

			this.h_abl_table_ = new KOEI.WP7_2012.MemoryTable.HorseAblDataTable(
				this.pm_,
				this.config_.HorseAbilityTable
			);
			this.h_family_line_table_ = new KOEI.WP7_2012.MemoryTable.HorseFamilyLineTable(
				this.pm_,
				this.config_.HorseFamilyLineTable
			);
			this.h_blood_table_ = new KOEI.WP7_2012.MemoryTable.HorseBloodTable(
				this.pm_,
				this.config_.HorseBloodTable
			);
			this.h_race_table_ = new KOEI.WP7_2012.MemoryTable.HorseRaceTable(
				this.pm_,
				this.config_.HorseRaceTable
			);
			this.h_sire_table_ = new KOEI.WP7_2012.MemoryTable.HorseSireTable(
				this.pm_,
				this.config_.HorseSireTable
			);
			this.h_dam_table_ = new KOEI.WP7_2012.MemoryTable.HorseDamTable(
				this.pm_,
				this.config_.HorseDamTable
			);
			this.h_child_table_ = new KOEI.WP7_2012.MemoryTable.HorseChildTable(
				this.pm_,
				this.config_.HorseChildTable
			);
			this.h_ownership_race_table_ = new KOEI.WP7_2012.MemoryTable.HorseOwnershipRaceTable(
				this.pm_,
				this.config_.HorseOwnershipRaceTable
			);
			this.h_ownership_child_table_ = new KOEI.WP7_2012.MemoryTable.HorseOwnershipChildTable(
				this.pm_,
				this.config_.HorseOwnershipChildTable
			);
			this.r_name_table_ = new KOEI.WP7_2012.MemoryTable.RaceNameTable(
				this.pm_,
				this.config_
			);
			this.r_data_table_ = new KOEI.WP7_2012.MemoryTable.RaceDataTable(
				this.pm_,
				this.config_.RaceDataTable
			);
			this.r_program_table_ = new KOEI.WP7_2012.MemoryTable.RaceProgramTable(
				this.pm_,
				this.config_.RaceProgramTable
			);
		}

		/// <summary>
		/// トランザクションが開始された際の週番号
		/// </summary>
		public UInt32 TransactionWeekNumber {
			get {
				return this.transaction_week_number_;
			}
		}

		/// <summary>
		/// 現在の週番号を返す
		/// </summary>
		public UInt32 GetCurrentWeekNumber()
		{
			var mem = this.ProcessMemory.ReadMemory( this.config_.CurrentWeekAddress, 1 )[0];

			var w = mem >> 4;
			var m = mem & 0x0f;

			return (UInt32)(m * 4 + w);
		}

		/// <summary>
		/// 表示中のキャラ番号
		/// </summary>
		/// <returns></returns>
		public UInt32 GetCurrentCharacterNumber()
		{
			var address = BitConverter.ToUInt32( this.ProcessMemory.ReadMemory( this.config_.CurrentCharacterPointerAddress, 4 ), 0);
			return (UInt32) BitConverter.ToUInt16( this.ProcessMemory.ReadMemory( address + 0x64, 2 ), 0 );
		}


		/// <summary>
		/// トランザクション中のプロセスメモリ
		/// </summary>
		public KOEI.WP7_2012.Helper.ProcessMemory ProcessMemory {
			get {
				
				return this.pm_;
			}
		}

		/// <summary>
		/// 馬名情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseNameTable HNameTable {
			get {
				return this.name_table_;
			}
		}
	
		/// <summary>
		/// 史実名テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTable HShizitsuNameTable {
			get {
				return this.h_shizitsu_name_table_;
			}
		}

		/// <summary>
		/// 馬能力情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseAblDataTable HAblTable {
			get {
				return this.h_abl_table_;
			}
		}
	
		/// <summary>
		/// 血統情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseBloodTable HBloodTable {
			get {
				return this.h_blood_table_;
			}
		}
	
		/// <summary>
		/// 系統情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseFamilyLineTable HFamilyLineTable {
			get {
				return this.h_family_line_table_;
			}
		}
	
		/// <summary>
		/// 現役競走馬情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseRaceTable HRaceTable {
			get {
				return this.h_race_table_;
			}
		}
	
		/// <summary>
		/// 種牡馬情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseSireTable HSireTable {
			get {
				return this.h_sire_table_;
			}
		}
	
		/// <summary>
		/// 繁殖牝馬情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseDamTable HDamTable {
			get {
				return this.h_dam_table_;
			}
		}

		/// <summary>
		/// 幼駒情報テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseChildTable HChildTable {
			get {
				return this.h_child_table_;
			}
		}
	
		/// <summary>
		/// 所有競走馬テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseOwnershipRaceTable HOwnershipRaceTable {
			get {
				return this.h_ownership_race_table_;
			}
		}

		/// <summary>
		/// 所有幼駒テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseOwnershipChildTable HOwnershipChildTable {
			get {
				return this.h_ownership_child_table_;
			}
		}

		/// <summary>
		/// レースデータテーブルを返す
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.RaceDataTable RDataTable {
			get {
				return this.r_data_table_;
			}
		}

		/// <summary>
		/// レース名テーブルを返す
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.RaceNameTable RNameTable {
			get {
				return this.r_name_table_;
			}
		}

		/// <summary>
		/// レース開催表テーブルを返す
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.RaceProgramTable RProgramTable {
			get {
				return this.r_program_table_;
			}
		}
	}
}
