using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の調子を下向きにするWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		if( data.choushi_status != 3) {
			data.choushi_status = 0;
		}
		return data;
	}
}


