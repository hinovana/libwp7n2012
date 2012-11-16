# -*- coding: utf-8 -*-
"""
wp7breeding.pyを使って表示中の繁殖牝馬と配合地域の種牡馬を配合して
結果として爆発力と危険度のリストを出力します


"""
from wp7breeding import *


#region エントリーポイント
if __name__ == "__main__" :
	wp = WP7( Configuration.V101() )
	
	## 配合地域
	target_country = CountryEnum.JAPAN
	
	## 系統データのキャッシュ
	family_line_cache = create_family_line_cache( wp, target_country )
	
	dam_num = wp.GetCurrentCharacterNumber()
	dam_data = wp.HDamTable.GetData( dam_num, HDamData() )
	dam_blood = wp.HBloodTable.GetData( dam_data.blood_num, HBloodData() )
	
	## 繁殖牝馬の血統
	dam_pedigree = Pedigree(
		wp         = wp,
		ptype      = PedigreeTypeEnum.MARE,
		blood_num  = dam_data.blood_num,
		blood_data = dam_blood,
	)
	
	sire_list = {}
	
	for sire_num in range( 0, wp.HSireTable.RecordCount ) :
		sire_data = wp.HSireTable.GetData( sire_num, HSireData() )
		
		if sire_data.intai != 0 :
			continue
		
		sire_abl = wp.HAblTable.GetData( sire_data.abl_num, HAblData() )
		
		if get_country_by_bokuzyou_num( sire_abl.bokuzyou ) != target_country :
			continue
			
		sire_blood = wp.HBloodTable.GetData( sire_data.blood_num, HBloodData() )
		
		if sire_blood.father_num == wp.Config.IgnoreBloodNumber :
			continue
		
		sire_list[( sire_blood.name_left, sire_blood.name_right )] = sire_num
	
	
	for key in sorted( sire_list ) :
		sire_num = sire_list[key]
		sire_data = wp.HSireTable.GetData( sire_num, HSireData() )
		sire_abl = wp.HAblTable.GetData( sire_data.abl_num, HAblData() )
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
		print sprintf( "|%5d|%5d|%s|%s", bcp.point, bcp.risk, get_blood_name( wp, dam_blood ), get_blood_name( wp, sire_blood ) )
		## print "--"
		## combination_disp( wp = wp, combination = combination, )
	
	print len( sire_list )
#endregion
