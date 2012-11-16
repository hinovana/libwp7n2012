using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の競走寿命を+5するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		if( data.zyumyou + 5 >= 100 ) {
			data.zyumyou = 100;
		} else {
			data.zyumyou += 5 ;
		}
		return data;
	}
}

