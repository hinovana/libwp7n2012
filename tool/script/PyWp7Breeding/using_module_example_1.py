# -*- coding: utf-8 -*-
"""
wp7breeding.pyを使って「表示繁殖牝馬」と「ディープインパクト」を「日本」で配合します
ディープインパクトが存在しない場合 別の185番の種牡馬との配合になります


出力例1) 2013年スタート時に「エアグルーヴ」を表示した状態で実行
ディープインパクト × エアグルーヴ
--
シングルニックス
アウトブリード
血脈活性化配合7本型
名種牡馬型活力補完(1本)
異系血脈型活力補完(5本)
活力源化大種牡馬因子 * 2
        サンデーサイレンス
        ノーザンダンサー
活力源化名種牡馬因子 * 3
        ヘイルトゥリーズン
        リファール
        ノーザンテースト


出力例2) 2013年スタート時に「ダイワスカーレット」を表示した状態で実行
ディープインパクト × ダイワスカーレット
--
インブリード
        サンデーサイレンス 2×3 (37.50%)
        ヘイロー 3×4 (18.75%)
        ウィッシングウェル 3×4 (18.75%)
血脈活性化配合7本型
名種牡馬型活力補完(2本)
名牝型活力補完(1本)
異系血脈型活力補完(4本)
活力源化大種牡馬因子 * 3
        サンデーサイレンス
        サンデーサイレンス
        ノーザンダンサー
活力源化名種牡馬因子 * 3
        ヘイルトゥリーズン
        リファール
        ノーザンテースト

"""
from wp7breeding import *


#region エントリーポイント
if __name__ == "__main__" :
	wp = WP7( Configuration.V101() )
	
	## 配合地域
	target_country = CountryEnum.JAPAN
	
	## 系統データのキャッシュ
	family_line_cache = create_family_line_cache( wp, target_country )
	
	## ディープインパクトの番号185 
	sire_num = 185
	
	sire_data = wp.HSireTable.GetData( sire_num, HSireData() )
	sire_blood_data = wp.HBloodTable.GetData( sire_data.blood_num, HBloodData() )

	## 種牡馬の血統
	sire_pedigree = Pedigree(
		wp         = wp,
		ptype      = PedigreeTypeEnum.SIRE,
		blood_num  = sire_data.blood_num,
		blood_data = sire_blood_data,
	)
	
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
	
	## debug write
	print sprintf( "%s × %s", get_blood_name( wp, sire_blood_data ), get_blood_name( wp, dam_blood ) )
	print "--"
	
	combination_disp( wp = wp, combination = combination, )
	
#endregion
