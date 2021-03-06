using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の成長度を+5するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		var max = (uint)( 100 + data.seigen );
		
		if( data.seichou + 5 > max ) {
			data.seichou = max;
		} else {
			data.seichou += 5;
		}
		return data;
	}
}


