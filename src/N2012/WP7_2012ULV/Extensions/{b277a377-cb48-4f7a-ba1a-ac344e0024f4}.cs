using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
///  種牡馬のブックフルを解除するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HSireData CommandMain( WP7 wp, UInt32 horse_num, HSireData data ) {
		data.bookfull = 0;
		
		return data;
	}
}

