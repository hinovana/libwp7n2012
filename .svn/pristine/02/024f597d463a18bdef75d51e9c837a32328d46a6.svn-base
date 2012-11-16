using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の気性を1悪くするWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		var abl_data = new HAblData();
		
		wp.HAblTable.GetData( data.abl_num, ref abl_data );
		
		if( abl_data.kisyou > 0 ) {
			abl_data.kisyou -= 1;
		}
		
		wp.HAblTable.SetData( data.abl_num, ref abl_data );
		wp.HAblTable.Commit( data.abl_num );
		
		return data;
	}
}

