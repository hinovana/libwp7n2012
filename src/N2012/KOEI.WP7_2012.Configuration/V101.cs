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

namespace KOEI.WP7_2012.Configuration
{
	/// <summary>
	/// WP7_2012 1.0.1.0用の設定クラス
	/// </summary>
	public class V101 : KOEI.WP7_2012.ConfigurationInterface
	{
		private const UInt32 RelativePosition_1 = 0x1008;
		private const UInt32 RelativePosition_2 = 0x1000;

		/// <summary>
		/// プロセス名
		/// </summary>
		public String ProcessName {
			get {
				return V100.WP7_PROCESS_NAME;
			}
		}
	
		/// <summary>
		/// 1年の週の数
		/// </summary>
		public UInt32 YearWeekLength {
			get {
				return V100.WP7_YEAR_WEEK_LENGTH;
			}
		}

		/// <summary>
		/// 月の週数(1月は0、12月は11)
		/// </summary>
		public UInt32[] MonthWeekLen {
			get {
				return V100.WP7_MONTH_WEEKS;
			}
		}

		/// <summary>
		/// 空の血統を示す番号
		/// </summary>
		public UInt32 NullBloodNumber {
			get {
				return V100.NULL_BLOOD_NUMBER;
			}
		}

		/// <summary>
		/// 架空馬を示す史実番号
		/// </summary>
		public UInt32 NullShizitsuNumber {
			get {
				return V100.NULL_SHIZITSU_NUMBER;
			}
		}

		/// <summary>
		/// 空の能力を示す番号
		/// </summary>
		public UInt32 NullAbilityNumber { 
			get {
				return V100.NULL_ABILITY_NUMBER;	
			}
		}

		/// <summary>
		/// 空の名前を示す番号
		/// </summary>
		public UInt32 NullNameNumber {
			get {
				return V100.NULL_NAME_NUMBER;
			}
		}

		/// <summary>
		/// 空きの系統を示す番号
		/// </summary>
		public UInt32 NullFamilyLineNumber {
			get {
				return V100.NULL_FAMILY_LINE_NUMBER;
			}
		}

		/// <summary>
		/// ユーザ定義馬名の開始番号
		/// </summary>
		public UInt32 UserNameTableStartNumber {
			get {
				return V100.USER_NAME_TABLE_START_NUMBER;
			}
		}

		/// <summary>
		/// 無視すべき血統番号
		/// </summary>
		public UInt32 IgnoreBloodNumber {
			get {
				return V100.IGNORE_BLOOD_NUMBER;
			}
		}

		/// <summary>
		/// 空きを示す所有競走馬の番号
		/// </summary>
		public UInt32 NullOwnershipRaceHorseNumber {
			get {
				return V100.NULL_OWNERSHIP_RACE_NUMBER;
			}
		}

		/// <summary>
		/// 空きを示す種牡馬番号
		/// </summary>
		public UInt32 NullSireNumber { 
			get{
				return V100.NULL_SIRE_NUMBER;
			}
		}

		/// <summary>
		/// 現在の週番号を返す
		/// </summary>
		public UInt32 CurrentWeekAddress { 
			get {
				return V100.CURRENT_WEEK_ADDRESS + RelativePosition_2;
			}
		}

		/// <summary>
		/// 表示中のキャラクタ番号へのアドレス
		/// </summary>
		public UInt32 CurrentCharacterPointerAddress {
			get {
				return V100.CURRENT_CHARACTER_POINTER_ADDRESS + RelativePosition_2;
			}
		}

		/// <summary>
		/// レース開催表の空のデータを表すレース番号
		/// </summary>
		public UInt32 NullRaceProgramNumber {
			get {
				return V100.NULL_RACE_PROGRAM_NUMBER;
			}
		}

		/// <summary>
		/// プロセスメモリ上の馬名(既定)テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration HorseNameSystemTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration() {
					PointerAddress   = V100.HORSE_SYSTEM_NAME_TABLE_POINTER_ADDRESS + RelativePosition_1,
					TableSizeAddress = V100.HORSE_SYSTEM_NAME_TABLE_SIZE_ADDRESS + RelativePosition_1,
					RecordMaxLength  = V100.HORSE_SYSTEM_NAME_RECORD_MAX,
					StartNumber      = 0,
				};
			}		
		}

		/// <summary>
		/// プロセスメモリ上の馬名(ユーザ定義)テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration HorseNameUserTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration() {
					PointerAddress   = V100.HORSE_USER_NAME_TABLE_POINTER_ADDRESS + RelativePosition_1,
					TableSizeAddress = V100.HORSE_USER_NAME_TABLE_SIZE_ADDRESS + RelativePosition_1,
					RecordMaxLength  = 0,
					StartNumber      = V100.USER_NAME_TABLE_START_NUMBER,
				};
			}
		}
	
		/// <summary>
		/// プロセスメモリ上の馬能力テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseAbilityTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_ABILITY_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_ABILITY_DATA_SIZE,
					RecordMaxLength = V100.HORSE_ABILITY_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の血統テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseBloodTable { 
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_BLOOD_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_BLOOD_DATA_SIZE,
					RecordMaxLength = V100.HORSE_BLOOD_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の系統テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseFamilyLineTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_FAMILY_LINE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_FAMILY_LINE_DATA_SIZE,
					RecordMaxLength = V100.HORSE_FAMILY_LINE_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の種牡馬テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseSireTable { 
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_SIRE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_SIRE_DATA_SIZE,
					RecordMaxLength = V100.HORSE_SIRE_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の繁殖牝馬テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseDamTable { 
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_DAM_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_DAM_DATA_SIZE,
					RecordMaxLength = V100.HORSE_DAM_MAX,
				};
			}		
		}

		/// <summary>
		/// プロセスメモリ上の現役馬テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseRaceTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_RACE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_RACE_DATA_SIZE,
					RecordMaxLength = V100.HORSE_RACE_MAX,
				};
			}		
		}

		/// <summary>
		/// プロセスメモリ上の幼駒テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseChildTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_CHILD_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_CHILD_DATA_SIZE,
					RecordMaxLength = V100.HORSE_CHILD_MAX,
				};
			}		
		}

		/// <summary>
		/// 所有競走馬テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseOwnershipRaceTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_OWNERSHIP_RACE_TABLE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_OWNERSHIP_RACE_DATA_SIZE,
					RecordMaxLength = V100.HORSE_OWNERSHIP_RACE_MAX,
				};
			}
		}

		/// <summary>
		/// 所有幼駒テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseOwnershipChildTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_OWNERSHIP_CHILD_TABLE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_OWNERSHIP_CHILD_DATA_SIZE,
					RecordMaxLength = V100.HORSE_OWNERSHIP_CHILD_MAX,
				};
			}
		}

		/// <summary>
		/// 史実名テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseShizitsuNameTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.HORSE_SHIZITSU_NAME_TABLE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.HORSE_SHIZITSU_NAME_DATA_SIZE,
					RecordMaxLength = V100.HORSE_SHIZITSU_NAME_MAX,
				};
			}
		}

		/// <summary>
		/// レースデータテーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration RaceDataTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.RACE_DATA_TABLE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.RACE_DATA_DATA_SIZE,
					RecordMaxLength = V100.RACE_DATA_MAX_LEN,
				};
			}
		}

		/// <summary>
		/// レース名テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.RaceNameTableConfiguration RaceNameTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.RaceNameTableConfiguration() {
					PointerAddress   = V100.RACE_NAME_TABLE_POINTER_ADDRESS + RelativePosition_1,
					TableSizeAddress = V100.RACE_NAME_TABLE_SIZE_ADDRESS + RelativePosition_1,
					RecordMaxLength  = V100.RACE_NAME_TABLE_RECORD_MAX,
				};
			}
		}

		/// <summary>
		/// レース開催表テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration RaceProgramTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = V100.RACE_PROGRAM_TABLE_POINTER_ADDRESS + RelativePosition_1,
					RecordSize      = V100.RACE_PROGRAM_DATA_SIZE,
					RecordMaxLength = V100.RACE_PROGRAM_MAX_LEN,
				};
			}
		}
	}
}
