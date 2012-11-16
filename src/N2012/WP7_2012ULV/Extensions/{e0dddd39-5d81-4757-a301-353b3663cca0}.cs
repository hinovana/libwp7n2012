using System;
using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

/// <summary>
///  種牡馬の因子左を次にするWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	public static HSireData CommandMain( WP7 wp, UInt32 horse_num, HSireData data ) {
		var blood_data = new HBloodData();
		
		wp.HBloodTable.GetData( data.blood_num, ref blood_data );
		
		if( blood_data.factor_left >= 9 ) {
			blood_data.factor_left = 0;
		} else {
			blood_data.factor_left++;
		}
		wp.HBloodTable.SetData( data.blood_num, ref blood_data );
		wp.HBloodTable.Commit( data.blood_num );
		
		return data;
	}
}

