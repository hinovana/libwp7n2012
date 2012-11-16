using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 幼駒の成長上限を110にするWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HChildData CommandMain( WP7 wp, UInt32 horse_num, HChildData data ) {
		data.seigen = 10;
		
		return data;
	}
}


