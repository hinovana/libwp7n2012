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
	/// WP7_2012 1.0.0.0用の設定クラス
	/// </summary>
	public class V100 : KOEI.WP7_2012.ConfigurationInterface
	{
		/// <summary>
		/// プロセス名
		/// </summary>
		public String ProcessName {
			get {
				return WP7_PROCESS_NAME;
			}
		}
	
		/// <summary>
		/// 1年の週の数
		/// </summary>
		public UInt32 YearWeekLength {
			get {
				return WP7_YEAR_WEEK_LENGTH;
			}
		}

		/// <summary>
		/// 月の週数(1月は0、12月は11)
		/// </summary>
		public UInt32[] MonthWeekLen {
			get {
				return WP7_MONTH_WEEKS;
			}
		}

		/// <summary>
		/// 空の血統を示す番号
		/// </summary>
		public UInt32 NullBloodNumber {
			get {
				return NULL_BLOOD_NUMBER;
			}
		}

		/// <summary>
		/// 架空馬を示す史実番号
		/// </summary>
		public UInt32 NullShizitsuNumber {
			get {
				return NULL_SHIZITSU_NUMBER;
			}
		}

		/// <summary>
		/// 空の能力を示す番号
		/// </summary>
		public UInt32 NullAbilityNumber { 
			get {
				return NULL_ABILITY_NUMBER;	
			}
		}

		/// <summary>
		/// 空の名前を示す番号
		/// </summary>
		public UInt32 NullNameNumber {
			get {
				return NULL_NAME_NUMBER;
			}
		}

		/// <summary>
		/// ユーザ定義馬名の開始番号
		/// </summary>
		public UInt32 UserNameTableStartNumber {
			get {
				return USER_NAME_TABLE_START_NUMBER;
			}
		}

		/// <summary>
		/// 無視すべき血統番号
		/// </summary>
		public UInt32 IgnoreBloodNumber {
			get {
				return IGNORE_BLOOD_NUMBER;
			}
		}

		/// <summary>
		/// 空きを示す所有競走馬の番号
		/// </summary>
		public UInt32 NullOwnershipRaceHorseNumber {
			get {
				return NULL_OWNERSHIP_RACE_NUMBER;
			}
		}

		/// <summary>
		/// 空きの系統を示す番号
		/// </summary>
		public UInt32 NullFamilyLineNumber {
			get {
				return NULL_FAMILY_LINE_NUMBER;
			}
		}

		/// <summary>
		/// 空きを示す種牡馬番号
		/// </summary>
		public UInt32 NullSireNumber { 
			get{
				return NULL_SIRE_NUMBER;
			}
		}

		/// <summary>
		/// 現在の週番号を返す
		/// </summary>
		public UInt32 CurrentWeekAddress { 
			get {
				return CURRENT_WEEK_ADDRESS;
			}
		}

		/// <summary>
		/// 表示中のキャラクタ番号へのアドレス
		/// </summary>
		public UInt32 CurrentCharacterPointerAddress {
			get {
				return CURRENT_CHARACTER_POINTER_ADDRESS;
			}
		}

		/// <summary>
		/// レース開催表の空のデータを表すレース番号
		/// </summary>
		public UInt32 NullRaceProgramNumber {
			get {
				return NULL_RACE_PROGRAM_NUMBER;
			}
		}

		/// <summary>
		/// プロセスメモリ上の馬名(既定)テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration HorseNameSystemTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration() {
					PointerAddress   = HORSE_SYSTEM_NAME_TABLE_POINTER_ADDRESS,
					TableSizeAddress = HORSE_SYSTEM_NAME_TABLE_SIZE_ADDRESS,
					RecordMaxLength  = HORSE_SYSTEM_NAME_RECORD_MAX,
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
					PointerAddress   = HORSE_USER_NAME_TABLE_POINTER_ADDRESS,
					TableSizeAddress = HORSE_USER_NAME_TABLE_SIZE_ADDRESS,
					RecordMaxLength  = 0,
					StartNumber      = UserNameTableStartNumber,
				};
			}
		}
	
		/// <summary>
		/// プロセスメモリ上の馬能力テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseAbilityTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_ABILITY_POINTER_ADDRESS,
					RecordSize      = HORSE_ABILITY_DATA_SIZE,
					RecordMaxLength = HORSE_ABILITY_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の血統テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseBloodTable { 
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_BLOOD_POINTER_ADDRESS,
					RecordSize      = HORSE_BLOOD_DATA_SIZE,
					RecordMaxLength = HORSE_BLOOD_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の系統テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseFamilyLineTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_FAMILY_LINE_POINTER_ADDRESS,
					RecordSize      = HORSE_FAMILY_LINE_DATA_SIZE,
					RecordMaxLength = HORSE_FAMILY_LINE_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の種牡馬テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseSireTable { 
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_SIRE_POINTER_ADDRESS,
					RecordSize      = HORSE_SIRE_DATA_SIZE,
					RecordMaxLength = HORSE_SIRE_MAX,
				};
			}
		}

		/// <summary>
		/// プロセスメモリ上の繁殖牝馬テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseDamTable { 
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_DAM_POINTER_ADDRESS,
					RecordSize      = HORSE_DAM_DATA_SIZE,
					RecordMaxLength = HORSE_DAM_MAX,
				};
			}		
		}

		/// <summary>
		/// プロセスメモリ上の現役馬テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseRaceTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_RACE_POINTER_ADDRESS,
					RecordSize      = HORSE_RACE_DATA_SIZE,
					RecordMaxLength = HORSE_RACE_MAX,
				};
			}		
		}

		/// <summary>
		/// プロセスメモリ上の幼駒テーブルの情報
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseChildTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_CHILD_POINTER_ADDRESS,
					RecordSize      = HORSE_CHILD_DATA_SIZE,
					RecordMaxLength = HORSE_CHILD_MAX,
				};
			}		
		}

		/// <summary>
		/// 所有競走馬テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseOwnershipRaceTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_OWNERSHIP_RACE_TABLE_POINTER_ADDRESS,
					RecordSize      = HORSE_OWNERSHIP_RACE_DATA_SIZE,
					RecordMaxLength = HORSE_OWNERSHIP_RACE_MAX,
				};
			}
		}

		/// <summary>
		/// 所有幼駒テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseOwnershipChildTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_OWNERSHIP_CHILD_TABLE_POINTER_ADDRESS,
					RecordSize      = HORSE_OWNERSHIP_CHILD_DATA_SIZE,
					RecordMaxLength = HORSE_OWNERSHIP_CHILD_MAX,
				};
			}
		}

		/// <summary>
		/// 史実名テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseShizitsuNameTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_SHIZITSU_NAME_TABLE_POINTER_ADDRESS,
					RecordSize      = HORSE_SHIZITSU_NAME_DATA_SIZE,
					RecordMaxLength = HORSE_SHIZITSU_NAME_MAX,
				};
			}
		}

		/// <summary>
		/// レースデータテーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration RaceDataTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = RACE_DATA_TABLE_POINTER_ADDRESS,
					RecordSize      = RACE_DATA_DATA_SIZE,
					RecordMaxLength = RACE_DATA_MAX_LEN,
				};
			}
		}

		/// <summary>
		/// レース名テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.RaceNameTableConfiguration RaceNameTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.RaceNameTableConfiguration() {
					PointerAddress = RACE_NAME_TABLE_POINTER_ADDRESS,
					TableSizeAddress = RACE_NAME_TABLE_SIZE_ADDRESS,
					RecordMaxLength = RACE_NAME_TABLE_RECORD_MAX,
				};
			}
		}

		/// <summary>
		/// レース開催表テーブル
		/// </summary>
		public KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration RaceProgramTable {
			get {
				return new KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = RACE_PROGRAM_TABLE_POINTER_ADDRESS,
					RecordSize      = RACE_PROGRAM_DATA_SIZE,
					RecordMaxLength = RACE_PROGRAM_MAX_LEN,
				};
			}
		}

		/// <summary>
		/// プロセス名
		/// </summary>
		public const String WP7_PROCESS_NAME = "WP7_2012.EXE";

		/// <summary>
		/// 1年の週の数
		/// </summary>
		public const UInt32 WP7_YEAR_WEEK_LENGTH = 52;

		/// <summary>
		/// 月の週数(1月は0、12月は11)
		/// </summary>
		public static UInt32[] WP7_MONTH_WEEKS = new UInt32[] {
			4, 4, 5, 4, 5, 4, 4, 5, 4, 5, 4, 4
		};

		/// <summary>
		/// 空データを示す血統番号
		/// </summary>
		public const UInt32 NULL_BLOOD_NUMBER = (25000);

		/// <summary>
		/// 空きを示す種牡馬番号
		/// </summary>
		public const UInt32 NULL_SIRE_NUMBER = (2000);


		/// <summary>
		/// 空きの系統を示す番号
		/// </summary>
		public const UInt32 NULL_FAMILY_LINE_NUMBER = 150;

		/// <summary>
		/// 空データを示す名前番号
		/// </summary>	
		public const UInt32 NULL_NAME_NUMBER = (65535);

		/// <summary>
		/// 空データを示す能力番号
		/// </summary>
		public const UInt32 NULL_ABILITY_NUMBER = (25840);

		/// <summary>
		/// 無視すべき血統番号
		/// </summary>
		public const UInt32 IGNORE_BLOOD_NUMBER = (28685);
	
		/// <summary>
		/// レース開催表の空のデータを表すレース番号
		/// </summary>
		public const UInt32 NULL_RACE_PROGRAM_NUMBER = 0xFFFF;

		/// <summary>
		/// 空データを示す史実番号
		/// </summary>
		public const UInt32 NULL_SHIZITSU_NUMBER = (7500);

		/// <summary>
		/// ユーザ定義馬名テーブルの開始番号
		/// </summary>
		public const UInt32 USER_NAME_TABLE_START_NUMBER = (16000);

		/// <summary>
		/// 空きに使われる所有競走馬の番号
		/// </summary>
		public const UInt32 NULL_OWNERSHIP_RACE_NUMBER = (11340);
		
		/// <summary>
		/// 表示中のキャラクタ番号へのアドレス
		/// </summary>
		public const UInt32 CURRENT_CHARACTER_POINTER_ADDRESS = 0x00930AE8;

		/// <summary>
		/// 馬能力データへのアドレス
		/// </summary>
		public const UInt32 HORSE_ABILITY_POINTER_ADDRESS = (0x00C456C0);

		/// <summary>
		/// 馬能力データのレコードサイズ
		/// </summary>
		public const UInt32 HORSE_ABILITY_DATA_SIZE = (0x0000000C);

		/// <summary>
		/// 馬能力データの最大格納数
		/// </summary>
		public const UInt32 HORSE_ABILITY_MAX = (0x00007530);

		/// <summary>
		/// 現在の週番号を格納しているアドレス
		/// 
		/// 683 名前：名無しさんの野望[sage] 投稿日：2012/03/25(日) 00:01:31.66 ID:xSYjXg68 [2/2]
		/// >>681
		/// 自分のツールとアドレスが違うな～
		/// 確かにロード直後はULVの表示おかしかった。
		/// 
		/// 参考までに自分が使ってるアドレスのせておきます。
		/// 925B90
		/// 現在月週１バイトデータ
		/// 上位４ビットが週で下位４ビットが月
		/// 両方とも０スタート、例：２月３週 0x21
		/// </summary>
//		public const UInt32 CURRENT_WEEK_ADDRESS = 0x00C49144;
		public const UInt32 CURRENT_WEEK_ADDRESS = 0x00925B90;

		/// <summary>
		/// レースデータへのポインタアドレス
		/// </summary>
		public const UInt32 RACE_DATA_TABLE_POINTER_ADDRESS = 0x00C45474;

		/// <summary>
		/// レースデータサイズ
		/// </summary>
		public const UInt32 RACE_DATA_DATA_SIZE = 0x0000000C;

		/// <summary>
		/// レースデータの最大数
		/// </summary>
		public const UInt32 RACE_DATA_MAX_LEN = 0x00000A65;

		/*
		 * ウイニングポストの改造・ツール総合スレ Part7
		 * http://yuzuru.2ch.net/test/read.cgi/game/1269438837/
		 * 
		 * 56 名前：名無しさんの野望[sage] 投稿日：2010/04/03(土) 23:17:16 ID:oK9hfcnk
		 * WP7_2012の馬能力データ(スピードや毛色の情報) って最大何頭分用意されているか誰かご存じですか？
		 * 
		 * 57 名前：名無しさんの野望[sage] 投稿日：2010/04/04(日) 00:02:26 ID:zc9Po2mu
		 * >>56
		 * 25840頭分ありますよ。
		 */

		/// <summary>
		/// 血統データへのアドレス
		/// </summary>
		public const UInt32 HORSE_BLOOD_POINTER_ADDRESS = (0x00C456AC);

		/// <summary>
		/// 血統データのレコードサイズ
		/// </summary>
		public const UInt32 HORSE_BLOOD_DATA_SIZE = (0x0000000C);

		/// <summary>
		/// 血統データの最大格納数
		/// </summary>
		public const UInt32 HORSE_BLOOD_MAX = (0x000064F0);


		/// <summary>
		/// 系統データへのアドレス
		/// </summary>
		public const UInt32 HORSE_FAMILY_LINE_POINTER_ADDRESS = (0x00C45E0C);

		
		/// <summary>
		/// 系統データのレコードサイズ
		/// </summary>
		public const UInt32 HORSE_FAMILY_LINE_DATA_SIZE = (0x0000002C);

		/// <summary>
		/// 系統データの最大格納数
		/// </summary>
		public const UInt32 HORSE_FAMILY_LINE_MAX = (0x00000096);

		///<summary>
		/// 種牡馬データへのアドレス
		///</summary>
		public const UInt32 HORSE_SIRE_POINTER_ADDRESS = (0x00C493F4);

		///<summary>
		/// 種牡馬データのレコードサイズ
		///</summary>
		public const UInt32 HORSE_SIRE_DATA_SIZE = (0x000000AC);

		///<summary>
		/// 種牡馬データの最大格納数
		///</summary>
		public const UInt32 HORSE_SIRE_MAX = (0x000007D0);


		///<summary>
		/// 繁殖牝馬データへのアドレス
		///</summary>
		public const UInt32 HORSE_DAM_POINTER_ADDRESS = (0x00C467D4);

		///<summary>
		/// 繁殖牝馬データのレコードサイズ
		///</summary>
		public const UInt32 HORSE_DAM_DATA_SIZE = (0x00000014);

		///<summary>
		/// 繁殖牝馬データの最大格納数
		///</summary>
		public const UInt32 HORSE_DAM_MAX = (0x00002710);


		///<summary>
		/// 競走馬データへのアドレス
		///</summary>
		public const UInt32 HORSE_RACE_POINTER_ADDRESS = (0x00C46014);

		///<summary>
		/// 競走馬データのレコードサイズ
		///</summary>
		public const UInt32 HORSE_RACE_DATA_SIZE = (0x00000044);

		///<summary>
		/// 競走馬データの最大格納数
		///</summary>
		public const UInt32 HORSE_RACE_MAX = (0x00001158);


		///<summary>
		/// 幼駒データへのアドレス
		///</summary>
		public const UInt32 HORSE_CHILD_POINTER_ADDRESS = (0x00C4696C);

		///<summary>
		/// 幼駒データのレコードサイズ
		///</summary>
		public const UInt32 HORSE_CHILD_DATA_SIZE = (0x00000014);

		///<summary>
		/// 幼駒データの最大格納数
		///</summary>
		public const UInt32 HORSE_CHILD_MAX = (0x000009C4);


		// 110 名前：名無しさんの野望[sage] 投稿日：2010/04/14(水) 03:05:15 ID:jgC3Nsjp
		// >>106
		// 例えば、その馬名のデータの場合だと、
		// 0x007479FCと0x00747A14に確保した領域のアドレスが入っていて、
		// 0x00747A18に確保された領域のサイズが入っています。
		// 大抵の場合、2個目のポインタの次(+4バイトの所)に
		// 確保されている領域のサイズが入っていると思います。

		///<summary>
		/// 馬名テーブルへのアドレス
		///</summary>
		public const UInt32 HORSE_SYSTEM_NAME_TABLE_POINTER_ADDRESS = (0x00C49830);

		///<summary>
		/// 馬名テーブルの確保サイズのアドレス
		///</summary>
		public const UInt32 HORSE_SYSTEM_NAME_TABLE_SIZE_ADDRESS = (0x00C49834);

		///<summary>
		/// 馬名テーブルのレコード数
		///</summary>
		public const UInt32 HORSE_SYSTEM_NAME_RECORD_MAX = (15409);

	
		///<summary>
		/// ユーザー定義馬名テーブルへのアドレス
		///</summary>
		public const UInt32 HORSE_USER_NAME_TABLE_POINTER_ADDRESS = (0x00C49870);

		///<summary>
		/// ユーザー定義馬名テーブルの確保サイズのアドレス
		///</summary>
		public const UInt32 HORSE_USER_NAME_TABLE_SIZE_ADDRESS = (0x00C49874);


		/// <summary>
		/// 所有馬テーブルへのポインタアドレス
		/// </summary>
		public const UInt32 HORSE_OWNERSHIP_RACE_TABLE_POINTER_ADDRESS = 0x00C49470;

		/// <summary>
		/// 所有馬テーブルのレコードサイズ
		/// </summary>
		public const UInt32 HORSE_OWNERSHIP_RACE_DATA_SIZE = 0x0000011C;

		/// <summary>
		/// 所有馬テーブルの最大レコード数
		/// </summary>
		public const UInt32 HORSE_OWNERSHIP_RACE_MAX = 108;

			/// <summary>
		/// 所有幼駒テーブルへのポインタアドレス
		/// </summary>
		public const UInt32 HORSE_OWNERSHIP_CHILD_TABLE_POINTER_ADDRESS = 0x00C494D0;

		/// <summary>
		/// 所有幼駒テーブルのレコードサイズ
		/// </summary>
		public const UInt32 HORSE_OWNERSHIP_CHILD_DATA_SIZE = 0x0000006C;

		/// <summary>
		/// 所有幼駒テーブルの最大レコード数
		/// </summary>
		public const UInt32 HORSE_OWNERSHIP_CHILD_MAX = 101;


		/// <summary>
		/// 史実テーブルへのポインタアドレス
		/// </summary>
		public const UInt32 HORSE_SHIZITSU_NAME_TABLE_POINTER_ADDRESS = (0x00C468EC);

		/// <summary>
		/// 史実テーブルのレコードサイズ
		/// </summary>
		public const UInt32 HORSE_SHIZITSU_NAME_DATA_SIZE = 0x00000002;

		/// <summary>
		/// 史実テーブルの最大レコード数
		/// </summary>
		public const UInt32 HORSE_SHIZITSU_NAME_MAX = 7500;

		/// <summary>
		/// レース名テーブルへのポインタアドレス
		/// </summary>
		public const UInt32 RACE_NAME_TABLE_POINTER_ADDRESS = 0x00C45464;

		/// <summary>
		/// レース名テーブルの確保サイズへのアドレス
		/// </summary>
		public const UInt32 RACE_NAME_TABLE_SIZE_ADDRESS = 0x00C45468;

		/// <summary>
		/// レース名の最大数
		/// </summary>
		public const UInt32 RACE_NAME_TABLE_RECORD_MAX = 3994;

		/// <summary>
		/// レース開催表へのポインタアドレス
		/// </summary>
		public const UInt32 RACE_PROGRAM_TABLE_POINTER_ADDRESS = 0x00C45484;

		/// <summary>
		/// レース開催表のデータサイズ(2バイト*96レース)
		/// </summary>
		public const UInt32 RACE_PROGRAM_DATA_SIZE = 2 * 96;

		/// <summary>
		/// レース開催表の最大数(52週)
		/// </summary>
		public const UInt32 RACE_PROGRAM_MAX_LEN = 52;
	}
}
