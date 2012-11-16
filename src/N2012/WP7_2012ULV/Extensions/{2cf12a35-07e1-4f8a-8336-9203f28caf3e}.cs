using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の調子を絶好調にするWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		if( data.choushi_status == 3 ) {
			data.choushi = 50;
		} else {
			data.choushi = 45;
		}
		return data;
	}
}

