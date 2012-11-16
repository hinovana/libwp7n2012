using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WP7_2012ULV
{
	static class Helper
	{
		public static readonly String[] 特性ラベル = new[] {
			"大舞台",
			"ＧⅡ横綱",
			"交流重賞",
			"ローカル",
			"スタート",
			"超長距離",
			"タフネス",
			"海外遠征",
			"男勝り",
			"夏馬",
			"軽ハンデ",
			"格上挑戦",
			"乾坤一擲",
			"大駆け",
			"鉄砲",
			"叩き良化",
		};

		/// <summary>
		/// 牧場番号から国を取得するメソッド
		/// </summary>
		/// <param name="bokuzyou"></param>
		/// <returns></returns>
		public static Enums.CountryType GetCountryByBokuzyouNum( UInt32 bokuzyou )
		{
			if( bokuzyou < 214 && bokuzyou != 27 && bokuzyou != 28 ) {
				return Enums.CountryType.JAPAN;
			} else if( bokuzyou < 233 && bokuzyou != 28 ) {
				return Enums.CountryType.USA;
			} else {
				return Enums.CountryType.EURO;
			}
		}

		public static String 放牧理由( this uint n )
		{
			return n ==  0 ? "デビュー前" 
				 : n ==  1 ? "通常" 
				 : n ==  2 ? "熱発" 
				 : n ==  3 ? "疲労"
				 : n ==  4 ? "疝痛"
				 : n ==  5 ? "フレグモーネ"
				 : n ==  6 ? "鼻出血"
				 : n ==  7 ? "ソエ"
				 : n ==  8 ? "裂蹄"
				 : n ==  9 ? "去勢"
				 : n == 10 ? "繋靱帯炎"
				 : n == 11 ? "骨折"
				 : n == 12 ? "屈腱炎"
				 : n == 13 ? "屈腱断裂"
				 : n == 14 ? "粉砕骨折"
				 : n == 15 ? "繋靱帯断裂"
				 : "？";
		}

		public static String 月週( this KOEI.WP7_2012.WP7 wp, uint week_num )
		{
			var counter = 0u;
			var month = 0u;
			var week = 0u;

			foreach( var n in wp.Config.MonthWeekLen ) {
				if( (counter + n) > week_num ) {
					week = ( week_num - counter );
					break;
				}
				counter += n;
				month++;
			}
			return String.Format( "{0,2}月{1}週", month + 1, week + 1 );
		}
		
		public static String 生産国( this uint n )
		{
			return n == 0 ? "日本" 
				 : n == 1 ? "米国" 
				 : n == 2 ? "英国" 
				 : n == 3 ? "愛国"
				 : n == 4 ? "仏国"
				 : n == 5 ? "豪州"
				 : n == 6 ? "独国"
				 : n == 7 ? "伊国"
				 : n == 8 ? "香港"
				 : n == 9 ? "UAE"
				 : n == 10 ? "加国"
				 : n == 11 ? "南米"
				 : "？";
		}

		public static String 戦法( this uint n )
		{
			return n == 0 ? "大逃" 
				 : n == 1 ? "逃げ" 
				 : n == 2 ? "先行" 
				 : n == 3 ? "差し"
				 : n == 4 ? "追込"
				 : n == 5 ? "自先"
				 : n == 6 ? "自差"
				 : n == 7 ? "自在"
				 : "？";
		}

		public static String 特殊配合( this KOEI.WP7_2012.Datastruct.HAblData abl_data )
		{
			if( abl_data.syunpatsu == 3 && abl_data.konzyou < 2 ) {
				if( abl_data.keiro >= 6 && abl_data.keiro <= 9 ) {
					return "真稲妻";
				}
				return "稲妻";
			} else if( abl_data.konzyou == 3 && abl_data.syunpatsu < 2 )  {
				if( abl_data.keiro == 1 ) {
					return "真疾風";
				}
				return "疾風";
			}
			return "";
		}

		public static String 因子( this uint n )
		{
			return n == 0 ? "スピ" 
				 : n == 1 ? "スタ" 
				 : n == 2 ? "パワ" 
				 : n == 3 ? "瞬発" 
				 : n == 4 ? "根性" 
				 : n == 5 ? "柔軟" 
				 : n == 6 ? "早熟" 
				 : n == 7 ? "晩成" 
				 : n == 8 ? "気難" 
				 : n == 9 ? "" 
				 : "？";
		}

		public static int レース距離( this uint n )
		{
			return n ==  0 ? 1000
				 : n ==  1 ? 1100
				 : n ==  2 ? 1150
				 : n ==  3 ? 1200
				 : n ==  4 ? 1300
				 : n ==  5 ? 1400
				 : n ==  6 ? 1500
				 : n ==  7 ? 1600
				 : n ==  8 ? 1700
				 : n ==  9 ? 1777
				 : n == 10 ? 1800
				 : n == 11 ? 1850
				 : n == 12 ? 1900
				 : n == 13 ? 1950
				 : n == 14 ? 2000
				 : n == 15 ? 2100
				 : n == 16 ? 2200
				 : n == 17 ? 2300
				 : n == 18 ? 2400
				 : n == 19 ? 2500
				 : n == 20 ? 2600
				 : n == 21 ? 2800
				 : n == 22 ? 3000
				 : n == 23 ? 3100
				 : n == 24 ? 3200
				 : n == 25 ? 3300
				 : n == 26 ? 3400
				 : n == 27 ? 3600
				 : n == 28 ? 4000
				 : -1;
		}

		public static String 馬印( this uint n )
		{
			return n == 0 ? ""
				 : n == 1 ? "春雷"
				 : n == 2 ? "流星"
				 : n == 3 ? "暁"
				 : "？";
		}

		public static String お札( this uint n )
		{
			return n == 0 ? "" 
				 : n == 1 ? "赤" 
				 : n == 2 ? "銅" 
				 : n == 3 ? "銀" 
				 : n == 4 ? "金" 
				 : "？";
		}

		public static String 繁殖牝馬状態( this uint n )
		{
			return n == 0 ? "空胎" 
				 : n == 1 ? "受胎" 
				 : n == 2 ? "不受胎" 
				 : n == 3 ? "未確認" 
				 : "？";
		}

		public static String 成長力( this uint n )
		{
			return n == 0 ? "無" 
				 : n == 1 ? "普" 
				 : n == 2 ? "有" 
				 : n == 3 ? "持" 
				 : "？";
		}

		public static String 苦手( this uint n )
		{
			return n == 0 ? "" 
				 : n == 1 ? "×" 
				 : "？";
		}

		public static String 国( this Enums.CountryType country )
		{
			return country == Enums.CountryType.JAPAN ? "日本"
				:  country == Enums.CountryType.USA   ? "米国"
				:  country == Enums.CountryType.EURO  ? "欧州"
				:  "？";
		}

		public static String クラス( this uint klass )
		{
			return klass == 0 ? "新馬"
				:  klass == 1 ? "未勝利"
				:  klass == 2 ? "500万下"
				:  klass == 3 ? "1000万下"
				:  klass == 4 ? "1600万下"
				:  klass == 5 ? "オープン"
				:  "？";
		}

		public static int 距離適性上限( this uint stamina, uint zyuunan )
		{
			var basic = 1000 + stamina * 20;
			var pm = ( stamina + 100 ) * ( zyuunan + 1 );

			var max = Math.Floor( (basic + pm) / 100.0 ) * 100;

			return (int) max;
		}

		public static int 距離適性下限( this uint stamina, uint zyuunan )
		{
			var basic = 1000 + stamina * 20;
			var pm = ( stamina + 100 ) * ( zyuunan + 1 );

			var min = Math.Ceiling( (basic - pm) / 100.0 ) * 100;

			return (int)( min < 1000 ? 1000 : min );
		}

		public static String 距離適性( this uint stamina, uint zyuunan )
		{
			var basic = 1000 + stamina * 20;
			var pm = ( stamina + 100 ) * ( zyuunan + 1 );

			var max = Math.Floor( (basic + pm) / 100.0 ) * 100;
			var min = Math.Ceiling( (basic - pm) / 100.0 ) * 100;

			return String.Format( "{0:D}m～{1:D}m", min < 1000 ? 1000 : (int)min , (int)max );
		}

		public static String 調子向き( this uint n )
		{
			return n == 0 ? "↓" 
				 : n == 1 ? "→" 
				 : n == 2 ? "↑" 
				 : n == 3 ? "出"
				 : "？";
		}

		public static String 持病( this uint n )
		{
			return n == 0 ? "" 
				 : n == 1 ? "△" 
				 : n == 2 ? "×" 
				 : "？";
		}

		public static String 走法( this uint n )
		{
			return n == 0 ? "普通" 
				 : n == 1 ? "ピッチ" 
				 : n == 2 ? "大跳び" 
				 : "？";
		}

		public static String 体高( this uint n )
		{
			return n == 0 ? "低" 
				 : n == 1 ? "普" 
				 : n == 2 ? "高" 
				 : "？";
		}

		public static String 全長( this uint n )
		{
			return n == 0 ? "短" 
				 : n == 1 ? "普" 
				 : n == 2 ? "高" 
				 : "？";
		}

		public static String 毛色( this uint n )
		{
			return n == 0 ? "鹿" 
				 : n == 1 ? "黒鹿" 
				 : n == 2 ? "栗" 
				 : n == 3 ? "栃栗" 
				 : n == 4 ? "青鹿"
				 : n == 5 ? "青"
				 : n == 6 ? "芦黒"
				 : n == 7 ? "芦灰"
				 : n == 8 ? "芦白"
				 : n == 9 ? "白"
				 : n == 10 ? "尻花栗"
				 : "？";
		}

		public static String 気性( this uint n )
		{
			return n == 0 ? "超激" 
				 : n == 1 ? "激" 
				 : n == 2 ? "荒" 
				 : n == 3 ? "普通" 
				 : n == 4 ? "大人" 
				 : "？";
		}

		public static String 馬場適正( this uint n )
		{
			return n == 0 ? "芝" 
				 : n == 1 ? "万能" 
				 : n == 2 ? "ダート" 
				 : "？";
		}

		public static String 成長型( this uint n )
		{
			return n == 0 ? "早熟" 
				 : n == 1 ? "普早" 
				 : n == 2 ? "普遅" 
				 : n == 3 ? "晩成" 
				 : n == 4 ? "超晩" 
				 : n == 5 ? "早鍋" 
				 : n == 6 ? "普鍋"
				 : "？";
		}

		public static String 性別( this uint n )
		{
			return n == 0 ? "牡"
				 : n == 1 ? "牝"
				 : "？";
		}

		public static String 特性二進数( this KOEI.WP7_2012.Datastruct.HAblData abl_data )
		{
			var str = "";

			var tokusei_list = new[] {
				abl_data.tokusei_1, abl_data.tokusei_2, abl_data.tokusei_3, abl_data.tokusei_4,
				abl_data.tokusei_5, abl_data.tokusei_6, abl_data.tokusei_7, abl_data.tokusei_8,
				abl_data.tokusei_9, abl_data.tokusei_10, abl_data.tokusei_11, abl_data.tokusei_12,
				abl_data.tokusei_13, abl_data.tokusei_14, abl_data.tokusei_15, abl_data.tokusei_16,
			};
			foreach( var tokusei in tokusei_list ) {
				str += tokusei == 0 ? "0" : "1";
			}
			return str;
		}

		public static String 特性( this KOEI.WP7_2012.Datastruct.HAblData abl_data, String sep )
		{
			var tokusei_list = new[] {
				abl_data.tokusei_1, abl_data.tokusei_2, abl_data.tokusei_3, abl_data.tokusei_4,
				abl_data.tokusei_5, abl_data.tokusei_6, abl_data.tokusei_7, abl_data.tokusei_8,
				abl_data.tokusei_9, abl_data.tokusei_10, abl_data.tokusei_11, abl_data.tokusei_12,
				abl_data.tokusei_13, abl_data.tokusei_14, abl_data.tokusei_15, abl_data.tokusei_16,
			};
			var list = new System.Collections.Generic.List< String >();

			for( var i=0; i<tokusei_list.Length; ++i ) {
				if( tokusei_list[i] != 0 ) {
					list.Add( 特性ラベル[i] );
				}
			}
			return String.Join( sep, list.ToArray() );
		}
	
		public static String サブパラ( this uint n )
		{
			return n == 0 ? "C"
				 : n == 1 ? "B"
				 : n == 2 ? "A"
				 : n == 3 ? "S"
				 : "?";
		}

		public static String 系統名( this KOEI.WP7_2012.Datastruct.HFamilyLineData data )
		{
			var name = "";
			var codes = new UInt32[] {
				data.name_1,
				data.name_2,
				data.name_3,
				data.name_4,
				data.name_5,
				data.name_6,
				data.name_7,
				data.name_8,
				data.name_9,
				data.name_10,
				data.name_11,
				data.name_12,
				data.name_13,
				data.name_14,
			};
			foreach( var code in codes ) {
				if( code == 0 ) {
					break;
				}
				name += KOEI.WP7_2012.Helper.KoeiCode.ToString( code );
			}
			return name;
		}

		public static String 馬名カナ( this KOEI.WP7_2012.WP7 wp, UInt32 name_left, UInt32 name_right )
		{
			KOEI.WP7_2012.Horse.Name.NameData left, right;
			var name = "";

			left = wp.HNameTable[ (int)name_left ];

			name = left != null ? left.Kana : String.Format( "(不明{0})", name_left );

			if( name_right != wp.Config.NullNameNumber ) {
				right = wp.HNameTable[ (int)name_right ];
				name += right != null ? right.Kana : String.Format( "(不明{0})", name_right );
			}
			return name;
		}

		public static String 馬名英語( this KOEI.WP7_2012.WP7 wp, UInt32 name_left, UInt32 name_right )
		{
			KOEI.WP7_2012.Horse.Name.NameData left, right;
			var name = "";

			left = wp.HNameTable[ (int)name_left ];

			name = left != null ? left.English : String.Format( "(不明{0})", name_left );

			if( name_right != wp.Config.NullNameNumber ) {
				right = wp.HNameTable[ (int)name_right ];
				name += " ";
				name += right != null ? right.English : String.Format( "(不明{0})", name_right );
			}
			return name;
		}

		public static String 馬名( this KOEI.WP7_2012.WP7 wp, Enums.NameType name_type, UInt32 name_left, UInt32 name_right )
		{
			if( name_type == WP7_2012ULV.Enums.NameType.KANA ) {
				return wp.馬名カナ( name_left, name_right );
			}

			KOEI.WP7_2012.Horse.Name.NameData
				left = null,
				right = null;

			left = wp.HNameTable[ (int)name_left ];

			if( name_right != wp.Config.NullNameNumber ) {
				right = wp.HNameTable[ (int)name_right ];
			}

			if( name_right == wp.Config.NullNameNumber || left == null || right == null ) {
				return wp.馬名英語( name_left, name_right );
			}

			if( left.Type == KOEI.WP7_2012.Horse.Name.NameDataType.USER ||
				right.Type == KOEI.WP7_2012.Horse.Name.NameDataType.USER ) {
				return wp.馬名カナ( name_left, name_right );
			}
			return wp.馬名英語( name_left, name_right );
		}

 	}
}
