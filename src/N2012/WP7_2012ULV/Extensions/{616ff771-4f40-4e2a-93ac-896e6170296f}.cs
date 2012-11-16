using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
///  繁殖牝馬の年齢を+1するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HDamData CommandMain( WP7 wp, UInt32 horse_num, HDamData data ) {
		if( data.age < HDamData.age_MAXVALUE ) {
			data.age++;
		}
		return data;
	}
}

