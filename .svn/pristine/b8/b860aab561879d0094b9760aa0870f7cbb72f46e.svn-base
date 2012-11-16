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

namespace KOEI.WP7_2012.Helper
{
	/// <summary>
	/// KOEIコード(仮名)を扱うためのヘルパークラス
	/// </summary>
	public class KoeiCode
	{
		/// <summary>
		/// KOEIコード(仮名)配列の長さ
		/// </summary>
		public const UInt32 KOEI_CODE_LENGTH = (256);

		/// <summary>
		/// KOEIコード(仮名)配列
		/// </summary>
		public static readonly String[] KOEI_CODE_TABLE = new String[] {
			"　",
			"ァ","ア","ィ","イ","ゥ","ウ","ェ","エ","ォ","オ","カ","ガ","キ","ギ",
			"ク","グ","ケ","ゲ","コ","ゴ","サ","ザ","シ","ジ","ス","ズ","セ","ゼ","ソ",
			"ゾ","タ","ダ","チ","ヂ","ッ","ツ","ヅ","テ","デ","ト","ド","ナ","ニ","ヌ",
			"ネ","ノ","ハ","バ","パ","ヒ","ビ","ピ","フ","ブ","プ","ヘ","ベ","ペ","ホ",
			"ボ","ポ","マ","ミ","ム","メ","モ","ャ","ヤ","ュ","ユ","ョ","ヨ","ラ","リ",
			"ル","レ","ロ","ヮ","ワ","ヰ","ヱ","ヲ","ン","ヴ",
			"ｶ","ｹ",
			"0","1","2","3","4","5","6","7","8","9","0","1","2","3","4","5","6","7","8","9",
			"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T",
			"U","V","W","X","Y","Z",
			"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t",
			"u","v","w","x","y","z",
			" ","'",".",
			"Ⅰ","Ⅱ","Ⅲ","Ⅳ","Ⅴ","Ⅵ","Ⅶ","Ⅷ","Ⅸ","Ⅹ",
			"①","②","③","④","⑤","⑥","⑦","⑧","⑨",
			"　",
			"第","一","二","三","四","五","六","七","八","九","十","壱","弐","参","拾","☆",
			"ｱ","ｱ","ｱ","ｱ","ｱ",
			"","","","","","","","","","","","","","","","","","","","","","","","","","","",
			"","","","","","",
			"ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ","ｱ",
			"-","ー",
			"無",
		};

		/// <summary>
		/// byte配列に入ったKOEIコード(仮名)配列を文字列にして返す
		/// </summary>
		/// <param name="ary">KOEIコード(仮名)の入った配列</param>
		/// <returns>デコード後の文字列</returns>
		public static String ToString( byte[] ary )
		{
			var str = "";

			for( var i=0; i<ary.Length; ++i ) {
				if( ary[i] == 0 ) {
					break;
				}
				str += ToString( ary[i] );
			}
			return str;
		}

		/// <summary>
		/// KOEIコード(仮名)を文字列にして返す
		/// </summary>
		/// <param name="n">KOEIコード(仮名)</param>
		/// <returns>デコード後の文字列</returns>
		public static String ToString( UInt32 n )
		{
			return KOEI.WP7_2012.Helper.KoeiCode.KOEI_CODE_TABLE[n];
		}
	}
}
