# -*- coding: utf-8 -*-
"""
wp7breeding.pyを使って指定した番号の種牡馬と繁殖牝馬の配合して
結果を出力します

sire_numとdam_numの値を変えて使います

"""
from wp7breeding import *


# 配合したい種牡馬の番号 ULVの「馬番号カラム参照」
sire_num = 0xb9
	
# 配合したい繁殖牝馬の番号 ULVの「馬番号カラム参照」
dam_num  = 0x22
	

#region エントリーポイント
if __name__ == "__main__" :
	wp = WP7( Configuration.V101() )
	
	## 配合地域
	target_country = CountryEnum.JAPAN
	
	## 系統データのキャッシュ
	family_line_cache = create_family_line_cache( wp, target_country )
	
	dam_data = wp.HDamTable.GetData( dam_num, HDamData() )
	dam_blood = wp.HBloodTable.GetData( dam_data.blood_num, HBloodData() )
	
	## 繁殖牝馬の血統
	dam_pedigree = Pedigree(
		wp         = wp,
		ptype      = PedigreeTypeEnum.MARE,
		blood_num  = dam_data.blood_num,
		blood_data = dam_blood,
	)
	
	sire_data = wp.HSireTable.GetData( sire_num, HSireData() )
	sire_blood = wp.HBloodTable.GetData( sire_data.blood_num, HBloodData() )
	
	## 種牡馬の血統
	sire_pedigree = Pedigree(
		wp         = wp,
		ptype      = PedigreeTypeEnum.SIRE,
		blood_num  = sire_data.blood_num,
		blood_data = sire_blood,
	)

	## 配合する
	breeding = Breeding(
		wp                = wp,
		family_line_cache = family_line_cache,
		country           = target_country,
		sire_num          = sire_num,
		sire_pedigree     = sire_pedigree,
		dam_num           = dam_num,
		dam_pedigree      = dam_pedigree
	)
	
	## 配合結果を取得する
	combination = breeding.get_combination()
	bcp = combination.get_point( wp )
		
	## debug write
	print sprintf( "%s * %s", get_blood_name( wp, sire_blood ), get_blood_name( wp, dam_blood ) )
	print sprintf( "爆発力 .. %5d", bcp.point )
	print sprintf( "危険度 .. %5d", bcp.risk )
	print "--"
	
	combination_disp( wp = wp, combination = combination, )
	
#endregion
