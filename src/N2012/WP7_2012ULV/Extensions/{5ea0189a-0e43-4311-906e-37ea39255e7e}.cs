using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の調子を-5するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		if( (int)data.choushi - 5 < 0 ) {
			data.choushi = 0;
		} else {
			data.choushi -=5 ;
		}
		return data;
	}
}

