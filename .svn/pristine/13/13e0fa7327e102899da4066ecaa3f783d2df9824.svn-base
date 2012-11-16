using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
///  繁殖牝馬の子出しを10にセットするWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HDamData CommandMain( WP7 wp, UInt32 horse_num, HDamData data ) {
		var abl_data = new HAblData();
		
		wp.HAblTable.GetData( data.abl_num, ref abl_data );
		
		abl_data.kodashi = 10;
		
		wp.HAblTable.SetData( data.abl_num, ref abl_data );
		wp.HAblTable.Commit( data.abl_num );
		
		return data;
	}
}

