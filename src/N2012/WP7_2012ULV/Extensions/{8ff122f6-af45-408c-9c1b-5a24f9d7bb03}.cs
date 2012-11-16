using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
///  ”ÉB–Ä”n‚ğ“ú–{–qê‚É‹­’D‚·‚éWP7_2012ULVŠg’£ƒXƒNƒŠƒvƒg
/// </summary>
class WP7_2012ULV_Extension {
	public static HDamData CommandMain( WP7 wp, UInt32 horse_num, HDamData data ) {
		var abl_data = new HAblData();
		
		wp.HAblTable.GetData( data.abl_num, ref abl_data );
		
		abl_data.bokuzyou = 25;
		
		wp.HAblTable.SetData( data.abl_num, ref abl_data );
		wp.HAblTable.Commit( data.abl_num );
		
		return data;
	}
}

