using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の疲労を+5するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		if( HRaceData.hirou_MAXVALUE < data.hirou + 5 ) {
			data.hirou = HRaceData.hirou_MAXVALUE;
		} else {
			data.hirou += 5;
		}
		
		return data;
	}
}

