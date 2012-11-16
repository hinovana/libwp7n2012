using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMAListView
{
	static class Extensions
	{
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

		public static String 持病( this uint n )
		{
			return n == 0 ? "" 
				 : n == 1 ? "△" 
				 : n == 2 ? "×" 
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
	
		public static String サブパラ( this uint n )
		{
			return n == 0 ? "C"
				 : n == 1 ? "B"
				 : n == 2 ? "A"
				 : n == 3 ? "S"
				 : "?";
		}

		public static String 系統名( this KOEI.WP7.M2008.Datastruct.HFamilyLineData data )
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
				name += KOEI.WP7.M2008.Helper.KoeiCode.ToString( code );
			}
			return name;
		}

		public static String 馬名( this KOEI.WP7.M2008.WP7 wp, UInt32 name_left, UInt32 name_right )
		{
			var obj = wp.HNameTable[ (int)name_left ];
			var name = obj != null ? obj.Kana : String.Format( "(不明{0})", name_left );

			if( name_right != wp.Config.NullNameNumber ) {
				obj = wp.HNameTable[ (int)name_right ];
				name += obj != null ? obj.Kana : String.Format( "(不明{0})", name_right );
			}
			return name;
		}

	}
}
