using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
///  種牡馬をプレイヤー日本牧場に強奪するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HSireData CommandMain( WP7 wp, UInt32 horse_num, HSireData data ) {
		var abl_data = new HAblData();
		
		wp.HAblTable.GetData( data.abl_num, ref abl_data );
		
		abl_data.bokuzyou = 25;
		
		wp.HAblTable.SetData( data.abl_num, ref abl_data );
		wp.HAblTable.Commit( data.abl_num );
		
		return data;
	}
}

