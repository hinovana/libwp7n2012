using System;
using System.Windows.Forms;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
///  繁殖牝馬の能力を大幅にアップするWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	private static bool is_first_call = true;
	private static bool is_cancel = false;
	
	public static HDamData CommandMain( WP7 wp, UInt32 horse_num, HDamData data ) {
		var abl_data = new HAblData();
		
		if( is_cancel == true ) {
			return data;
		}
		if( is_first_call == true ) {
			if( MessageBox.Show( "メモリを書き換えますよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question ) == DialogResult.Cancel ) {
				is_cancel = true;
				return data;
			}
			is_first_call = false;
		}
		
		wp.HAblTable.GetData( data.abl_num, ref abl_data );
		
		abl_data.speed     = 75;
		abl_data.health    = 3; // 健康
		abl_data.power     = 3; // パワー
		abl_data.zyuunan   = 3; // 柔軟性
		abl_data.syunpatsu = 3; // 瞬発力
		abl_data.konzyou   = 3; // 勝負根性
		abl_data.kashikosa = 3; // 賢さ
		abl_data.seishin   = 3; // 精神力
		
		abl_data.kodashi   = 10; // 子出し
		
		wp.HAblTable.SetData( data.abl_num, ref abl_data );
		wp.HAblTable.Commit( data.abl_num );
		
		return data;
	}
}

