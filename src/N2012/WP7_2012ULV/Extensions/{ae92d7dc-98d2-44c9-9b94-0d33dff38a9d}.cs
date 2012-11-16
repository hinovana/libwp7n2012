using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の成長度を-5するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		if( (int)data.seichou - 5 < 0 ) {
			data.seichou = 0;
		} else {
			data.seichou -= 5;
		}
		return data;
	}
}

