using System;

namespace KOEI.WP7.M2008.Configuration
{
	public class V101 : KOEI.WP7.M2008.ConfigurationInterface
	{
		public String ProcessName {
			get {
				return WP7_PROCESS_NAME;
			}
		}
	
		public UInt32 NullBloodNumber {
			get {
				return NULL_BLOOD_NUMBER;
			}
		}

		public UInt32 NullAbilityNumber { 
			get {
				return NULL_ABILITY_NUMBER;	
			}
		}

		public UInt32 NullNameNumber {
			get {
				return NULL_NAME_NUMBER;
			}
		}

		public UInt32 UserNameTableStartNumber {
			get {
				return USER_NAME_TABLE_START_NUMBER;
			}
		}

		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseAbilityTable {
			get {
				return new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_ABILITY_POINTER_ADDRESS,
					RecordSize      = HORSE_ABILITY_DATA_SIZE,
					RecordMaxLength = HORSE_ABILITY_MAX,
				};
			}
		}

		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseBloodTable { 
			get {
				return new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_BLOOD_POINTER_ADDRESS,
					RecordSize      = HORSE_BLOOD_DATA_SIZE,
					RecordMaxLength = HORSE_BLOOD_MAX,
				};
			}
		}

		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseFamilyLineTable {
			get {
				return new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_FAMILY_LINE_POINTER_ADDRESS,
					RecordSize      = HORSE_FAMILY_LINE_DATA_SIZE,
					RecordMaxLength = HORSE_FAMILY_LINE_MAX,
				};
			}
		}

		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseSireTable { 
			get {
				return new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_SIRE_POINTER_ADDRESS,
					RecordSize      = HORSE_SIRE_DATA_SIZE,
					RecordMaxLength = HORSE_SIRE_MAX,
				};
			}
		}

		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseDamTable { 
			get {
				return new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_DAM_POINTER_ADDRESS,
					RecordSize      = HORSE_DAM_DATA_SIZE,
					RecordMaxLength = HORSE_DAM_MAX,
				};
			}		
		}

		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseRaceTable {
			get {
				return new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_RACE_POINTER_ADDRESS,
					RecordSize      = HORSE_RACE_DATA_SIZE,
					RecordMaxLength = HORSE_RACE_MAX,
				};
			}		
		}

		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseChildTable {
			get {
				return new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration() {
					PointerAddress  = HORSE_CHILD_POINTER_ADDRESS,
					RecordSize      = HORSE_CHILD_DATA_SIZE,
					RecordMaxLength = HORSE_CHILD_MAX,
				};
			}		
		}

		public KOEI.WP7.M2008.MemoryTable.HorseNameTableConfiguration HorseNameSystemTable {
			get {
				return new KOEI.WP7.M2008.MemoryTable.HorseNameTableConfiguration() {
					PointerAddress   = HORSE_SYSTEM_NAME_TABLE_POINTER_ADDRESS,
					TableSizeAddress = HORSE_SYSTEM_NAME_TABLE_SIZE_ADDRESS,
					RecordMaxLength  = HORSE_SYSTEM_NAME_RECORD_MAX,
					StartNumber      = 0,
				};
			}		
		}

		public KOEI.WP7.M2008.MemoryTable.HorseNameTableConfiguration HorseNameUserTable {
			get {
				return new KOEI.WP7.M2008.MemoryTable.HorseNameTableConfiguration() {
					PointerAddress   = HORSE_USER_NAME_TABLE_POINTER_ADDRESS,
					TableSizeAddress = HORSE_USER_NAME_TABLE_SIZE_ADDRESS,
					RecordMaxLength  = 0,
					StartNumber      = UserNameTableStartNumber,
				};
			}
		}

		public const String WP7_PROCESS_NAME = "WP7M2008.EXE";

		// 空データを示す血統番号
		public const UInt32 NULL_BLOOD_NUMBER = (25000);

		// 空データを示す名前番号
		public const UInt32 NULL_NAME_NUMBER = (65535);

		// 空データを示す能力番号
		private const UInt32 NULL_ABILITY_NUMBER = (25840);
	
		// ユーザ定義馬名テーブルの開始番号
		public const UInt32 USER_NAME_TABLE_START_NUMBER = (15000);

		// 馬能力データへのアドレス
		public const UInt32 HORSE_ABILITY_POINTER_ADDRESS = (0x00742070);

		// 馬能力データのレコードサイズ
		public const UInt32 HORSE_ABILITY_DATA_SIZE = (0x0000000C);

		// 馬能力データの最大格納数
		public const UInt32 HORSE_ABILITY_MAX = (0x00007530);

		/*
		 * ウイニングポストの改造・ツール総合スレ Part7
		 * http://yuzuru.2ch.net/test/read.cgi/game/1269438837/
		 * 
		 * 56 名前：名無しさんの野望[sage] 投稿日：2010/04/03(土) 23:17:16 ID:oK9hfcnk
		 * WP7M2008の馬能力データ(スピードや毛色の情報) って最大何頭分用意されているか誰かご存じですか？
		 * 
		 * 57 名前：名無しさんの野望[sage] 投稿日：2010/04/04(日) 00:02:26 ID:zc9Po2mu
		 * >>56
		 * 25840頭分ありますよ。
		 */
		// 血統データへのアドレス
		public const UInt32 HORSE_BLOOD_POINTER_ADDRESS = (0x0074205C);

		// 血統データのレコードサイズ
		public const UInt32 HORSE_BLOOD_DATA_SIZE = (0x0000000C);

		// 血統データの最大格納数
		public const UInt32 HORSE_BLOOD_MAX = (0x000064F0);


		// 系統データへのアドレス
		public const UInt32 HORSE_FAMILY_LINE_POINTER_ADDRESS = (0x007427BC);

		// 系統データのレコードサイズ
		public const UInt32 HORSE_FAMILY_LINE_DATA_SIZE = (0x0000002C);

		// 系統データの最大格納数
		public const UInt32 HORSE_FAMILY_LINE_MAX = (0x00000096);


		// 種牡馬データへのアドレス
		public const UInt32 HORSE_SIRE_POINTER_ADDRESS = (0x00745CE0);

		// 種牡馬データのレコードサイズ
		public const UInt32 HORSE_SIRE_DATA_SIZE = (0x000000A4);

		// 種牡馬データの最大格納数
		public const UInt32 HORSE_SIRE_MAX = (0x000007D0);


		// 繁殖牝馬データへのアドレス
		public const UInt32 HORSE_DAM_POINTER_ADDRESS = (0x00743194);

		// 繁殖牝馬データのレコードサイズ
		public const UInt32 HORSE_DAM_DATA_SIZE = (0x00000014);

		// 繁殖牝馬データの最大格納数
		public const UInt32 HORSE_DAM_MAX = (0x00002710);


		// 競走馬データへのアドレス
		public const UInt32 HORSE_RACE_POINTER_ADDRESS = (0x007429CC);

		// 競走馬データのレコードサイズ
		public const UInt32 HORSE_RACE_DATA_SIZE = (0x00000038);

		// 競走馬データの最大格納数
		public const UInt32 HORSE_RACE_MAX = (0x00001158);


		// 幼駒データへのアドレス
		public const UInt32 HORSE_CHILD_POINTER_ADDRESS = (0x0074334C);

		// 幼駒データのレコードサイズ
		public const UInt32 HORSE_CHILD_DATA_SIZE = (0x00000014);

		// 幼駒データの最大格納数
		public const UInt32 HORSE_CHILD_MAX = (0x000009C4);


		// 110 名前：名無しさんの野望[sage] 投稿日：2010/04/14(水) 03:05:15 ID:jgC3Nsjp
		// >>106
		// 例えば、その馬名のデータの場合だと、
		// 0x007479FCと0x00747A14に確保した領域のアドレスが入っていて、
		// 0x00747A18に確保された領域のサイズが入っています。
		// 大抵の場合、2個目のポインタの次(+4バイトの所)に
		// 確保されている領域のサイズが入っていると思います。

		// 馬名テーブルへのアドレス
		public const UInt32 HORSE_SYSTEM_NAME_TABLE_POINTER_ADDRESS = (0x00747A14);

		// 馬名テーブルの確保サイズのアドレス
		public const UInt32 HORSE_SYSTEM_NAME_TABLE_SIZE_ADDRESS = (0x00747A18);

		// 馬名テーブルのレコード数
		public const UInt32 HORSE_SYSTEM_NAME_RECORD_MAX = (14119);

	
		// ユーザー定義馬名テーブルへのアドレス
		public const UInt32 HORSE_USER_NAME_TABLE_POINTER_ADDRESS = (0x00747A54);

		// ユーザー定義馬名テーブルの確保サイズのアドレス
		public const UInt32 HORSE_USER_NAME_TABLE_SIZE_ADDRESS = (0x00747A58);

	}
}
