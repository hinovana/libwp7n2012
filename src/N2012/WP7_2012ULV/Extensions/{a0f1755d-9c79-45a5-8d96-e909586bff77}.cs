using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 幼駒の持病を取り除くWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HChildData CommandMain( WP7 wp, UInt32 horse_num, HChildData data ) {
		var abl_data = new HAblData();
		
		wp.HAblTable.GetData( data.abl_num, ref abl_data );
		
		if( abl_data.komawari_X != 0 ) {
			abl_data.komawari_X = 0;
			wp.HAblTable.SetData( data.abl_num, ref abl_data );
			wp.HAblTable.Commit( data.abl_num );
		}
		data.migimawari_X   = 0;
		data.hidarimawari_X = 0;
		data.weak_point_1   = 0;
		data.weak_point_2   = 0;
		data.weak_point_3   = 0;
		
		return data;
	}
}



