# -*- coding: utf-8 -*-
"""
* wp7breeding.py
--
ウイニングポスト7 2012(Windows版)の配合支援モジュール
実行にはウイニングポスト7 2012(Windows版)、IronPython2.7、libwp7n2012が必要です

このスクリプトをそのまま実行すると
「表示中の種牡馬」と「自牧場(日本)に繁用している繁殖牝馬」の配合結果を出力します

importするとPythonモジュールとして振る舞います
ドキュメントやリファレンスはありません

V1.0.1.0で書いています、V1.0.0.0で使いたい場合は
wp = WP7( Configuration.V101() ) の行を
wp = WP7( Configuration.V100() ) に書き換えてください


* 更新履歴
--
2012/04/02
 * 最初 http://codepad.org/p1MsB2vB

2012/04/03
 * ひととおりの配合理論が実装できた

2012/04/04 (今ここ)
 * 修正 http://anago.2ch.net/test/read.cgi/game/1333320769/54-55
 * 爆発度/危険度の計算メソッド実装 BreedingCombination#get_point
 * その他何点かの修正


* リンク
--
Winning Post 7 2012
http://www.gamecity.ne.jp/keiba/wp7_2012/
IronPython
http://ironpython.codeplex.com/
libwp7n2012 - Winning Post 7 2012 Cheat Library - Google Project Hosting
http://code.google.com/p/libwp7n2012/
ウイニングポストの改造・ツール総合スレ Part11
http://anago.2ch.net/test/read.cgi/game/1333320769/


* 参考文献
--
配合理論 | ウイニングポスト7攻略 Sheep
http://www.wpclear.com/haigoriron/

Pythonのメタクラスについて — aodag documents v0.0 documentation
http://aodag.bitbucket.org/meta_class.html

"""

import sys, random, pprint, clr

clr.AddReference("KOEI.WP7_2012")
clr.AddReference("KOEI.WP7_2012.Configuration")

import System

from KOEI.WP7_2012 import *
from KOEI.WP7_2012.Datastruct import *

## pythonにはEnumは無い
class EnumType(type):
	def __init__(cls, name, bases, dct):
		super(EnumType, cls).__init__(name, bases, dct)
		cls._values = []

		for key, value in dct.iteritems():
			if not key.startswith('_'):
				v = cls(key, value)
				setattr(cls, key, v)
				cls._values.append(v)

	def __iter__(cls):
		return iter(cls._values)


class StandardEnum(object):
	__metaclass__ = EnumType
	
	def __init__(self, k, v):
		self.v = v
		self.k = k

	def __repr__(self):
		return "<%s.%s value=%s>" % (self.__class__.__name__, self.k, self.v)


# --------------------------------------------------------------------
# Symbols
# --------------------------------------------------------------------

## ラインブリード
class LineBreedEnum(StandardEnum):
	Type_1 = 0x01 # 親系統ラインブリード4本爆発SP型
	Type_2 = 0x02 # 親系統ラインブリード4本爆発型
	Type_3 = 0x03 # 親系統ラインブリード3本爆発SP型
	Type_4 = 0x04 # 親系統ラインブリード3本爆発型
	Type_5 = 0x05 # 子系統ラインブリードSP型
	Type_6 = 0x06 # 子系統ラインブリード
	Type_7 = 0x07 # 親系統ラインブリードSP型
	Type_8 = 0x08 # 親系統ラインブリード
	NONE   = 0x09 # ラインブリード無し


## ニックス
class NicksEnum(StandardEnum):
	Type_1 = 0x01 # シングルニックス
	Type_2 = 0x02 # ダブルニックス
	Type_3 = 0x03 # トリプルニックス
	Type_4 = 0x04 # フォースニックス
	Type_5 = 0x05 # ２次ニックス
	Type_6 = 0x06 # ３次ニックス
	Type_7 = 0x07 # ４次ニックス
	NONE   = 0x08 # ニックス無し


## 血脈活性化配合
class BloodActivityEnum(StandardEnum):
	Type_1 = 0x01 # 血脈活性化配合6本型
	Type_2 = 0x02 # 血脈活性化配合7本型
	Type_3 = 0x03 # 血脈活性化配合8本型
	NONE   = 0x04 # 無し
	

## 昇華配合
class AttrCombinationEnum(StandardEnum):
	Type_1 = 0x01 # SP|ST 昇華配合Lv1
	Type_2 = 0x02 # SP|ST 昇華配合Lv2
	Type_3 = 0x03 # SP|ST 昇華配合Lv3 
	NONE   = 0x04 # 無し


## ライン活性配合
class LineActivityEnum(StandardEnum):
	Male_1   = 0x01 # メールライン活性配合Lv1
	Male_2   = 0x02 # メールライン活性配合Lv2
	Male_3   = 0x03 # メールライン活性配合Lv3
	Bottom_1 = 0x04 # ボトムライン活性配合Lv1
	Bottom_2 = 0x05 # ボトムライン活性配合Lv2
	Bottom_3 = 0x06 # ボトムライン活性配合Lv3
	NONE     = 0x04 # 無し


## 母父
class BMSEnum(StandardEnum):
	Type_1  = 0x01 # 母父○
	Type_2  = 0x02 # 母父◎
	NONE    = 0x03 # 無し


## スピードorスタミナ
class SPSTTypeEnum(StandardEnum):
	SPEED   = 0x01 # 
	STAMINA = 0x02 # 
	UNKNOWN = 0x03 # 


## 血統タイプ
class PedigreeTypeEnum(StandardEnum):
	SIRE    = 0x01 # 
	MARE    = 0x02 # 
	UNKNOWN = 0x03 # 


## 地域
class CountryEnum(StandardEnum):
	JAPAN   = 0x01 # 
	USA     = 0x02 # 
	EURO    = 0x03 # 


# --------------------------------------------------------------------
# API 
# --------------------------------------------------------------------

## 血統ノードクラス
class PedigreeNode:
	ptype = PedigreeTypeEnum.UNKNOWN
	level     = 0
	data      = None
	blood_num = None
	line      = ""
	
	father    = None
	mother    = None
	
	def __init__( self, ptype, level, data, blood_num, line ):
		self.ptype = ptype
		self.level     = level
		self.data      = data
		self.blood_num = blood_num
		self.line      = line
		self.father    = None
		self.mother    = None


## 血統クラス
class Pedigree:
	SIRE_SIGN = "o"
	MARE_SIGN = "x"
	
	def __init__( self, wp, ptype, blood_data, blood_num, max_level = 3 ):
		self.wp = wp
		self.ptype = ptype
		self.max_level = max_level
		
		line = Pedigree.SIRE_SIGN if self.ptype == PedigreeTypeEnum.SIRE else Pedigree.MARE_SIGN
		self.tree = PedigreeNode( self.ptype, 0, blood_data, blood_num, line )
		self.__create_blood_tree__( self.tree )
	
	
	def __iter__( self ):
		yield self.tree
		
		for node in self.__iter_sub__( self.tree ):
			yield node
	
	
	def __iter_sub__( self, node ):
		if node == None :
			return 

		if node.father != None :
			yield node.father
			for n in self.__iter_sub__( node.father ):
				yield n
			
		if node.mother != None :
			yield node.mother
			for n in self.__iter_sub__( node.mother ):
				yield n
	
	
	def __create_blood_tree__( self, node ):
		if node.level == self.max_level :
			return 
		
		father = self.wp.HBloodTable.GetData( node.data.father_num, HBloodData() )
		temp = node.line + Pedigree.SIRE_SIGN
		node.father = PedigreeNode( PedigreeTypeEnum.SIRE, node.level + 1, father, node.data.father_num, temp )
		
		mother = self.wp.HBloodTable.GetData( node.data.mother_num, HBloodData() )
		temp = node.line + Pedigree.MARE_SIGN
		node.mother = PedigreeNode( PedigreeTypeEnum.MARE, node.level + 1, mother, node.data.mother_num, temp )
		
		self.__create_blood_tree__( node.father )
		self.__create_blood_tree__( node.mother )
	
	
	def each( self, callback, arg ):
		callback( node = self.tree, arg = arg )
		self.__each_sub__( self.tree, callback, arg )
	
	
	def __each_sub__( self, node, callback, arg ):
		if node == None :
			return
			
		if node.father != None :
			callback( node = node.father, arg = arg )
			self.__each_sub__( node.father, callback, arg )
			
		if node.mother != None :
			callback( node = node.mother, arg = arg )
			self.__each_sub__( node.mother, callback, arg )
	
	
	def dump( self ):
		print sprintf( "%s", get_blood_name( self.wp, self.tree.data ) )
		self.__dump_node_sub__( self.tree )
	
	
	def __dump_node_sub__( self, node ):
		if node == None :
			return
		
		indent = lambda n : "  " * n
		
		if node.father != None :
			print sprintf( "%s%s", indent( node.father.level ), get_blood_name( self.wp, node.father.data ) )
			self.__dump_node_sub__( node.father )
		
		if node.mother != None :
			print sprintf( "%s%s", indent( node.mother.level ), get_blood_name( self.wp, node.mother.data ) )
			self.__dump_node_sub__( node.mother )


## インブリード管理クラス
class InBreed:
	def __init__( self, pedigree_node, sire_level, mare_level ):
		self.node = pedigree_node
		self.sire_level = sire_level
		self.mare_level = mare_level


## 特殊配合
class BreedingCombinationSpecials:
	# お笑い配合
	owarai    = False
	
	# お似合い配合
	oniai     = False
	
	# サヨナラ配合
	sayonara  = False
	
	# Wサヨナラ配合
	wsayonara = False
	
	# 稲妻配合
	inazuma1  = False
	
	# 真稲妻配合
	inazuma2  = False
	
	# 疾風配合
	shippuu1  = False
	
	# 真疾風配合
	shippuu2  = False
	
	# 3冠配合
	sankan    = False



## 配合の爆発力管理クラス
class BreedingCombinationPoint:
	## 爆発力
	point = 0
	
	## 危険度
	risk  = 0


## 爆発力と危険度
class CombinationPointInfo:
	シングルニックス                  = (  2,  0 )
	ダブルニックス                    = (  4,  0 )
	トリプルニックス                  = (  6,  0 )
	フォースニックス                  = (  8,  0 )
	二次ニックス                      = (  1,  0 )
	三次ニックス                      = (  1,  0 )
	四次ニックス                      = (  1,  0 )
	親系統ラインブリード4本爆発SP型   = ( 13,  1 )
	親系統ラインブリード4本爆発型     = ( 11,  1 )
	親系統ラインブリード3本爆発SP型   = (  9,  1 )
	親系統ラインブリード3本爆発型     = (  7,  1 )
	親系統ラインブリードSP型          = (  3,  1 )
	親系統ラインブリード              = (  2,  1 )
	子系統ラインブリードSP型          = (  5,  2 )
	子系統ラインブリード              = (  3,  2 )
	血脈活性化配合6本型               = (  4,  0 )
	血脈活性化配合7本型               = (  6,  0 )
	血脈活性化配合8本型               = (  8,  0 )
	SP昇華配合Lv1                     = (  1,  0 )
	SP昇華配合Lv2                     = (  3,  0 )
	SP昇華配合Lv3                     = (  5,  0 )
	ST昇華配合Lv1                     = (  1,  0 )
	ST昇華配合Lv2                     = (  2,  0 )
	ST昇華配合Lv3                     = (  3,  0 )
	SPST融合配合                      = (  5,  0 )
	母父OO                            = (  4,  0 )
	母父O                             = (  2,  0 )
	名種牡馬型活力補完                = (  0,  0 )
	名牝型活力補完                    = (  0,  0 )
	異系血脈型活力補完                = (  0,  0 )
	完全型活力補完                    = (  3,  0 )
	メールライン活性配合Lv1           = (  3,  0 )
	メールライン活性配合Lv2           = (  6,  0 )
	メールライン活性配合Lv3           = ( 10,  0 )
	ボトムライン活性配合Lv1           = (  3,  0 )
	ボトムライン活性配合Lv2           = (  6,  0 )
	ボトムライン活性配合Lv3           = ( 10,  0 )
	活力源化大種牡馬因子              = (  1,  0 )
	活力源化名種牡馬因子              = (  1,  0 )
	お笑い配合                        = (  5,  0 )
	お似合い配合                      = (  5,  0 )
	サヨナラ配合                      = (  5,  0 )
	Wサヨナラ配合                     = (  8,  0 )
	稲妻配合                          = (  6,  0 )
	真稲妻配合                        = ( 12,  0 )
	疾風配合                          = (  6,  0 )
	真疾風配合                        = ( 12,  0 )
	三冠配合                          = (  4,  0 )
	隔世遺伝SP因子                    = (  3,  0 )
	インブリードSP因子                = (  3,  0 )
	
	インブリード危険度 = {
		(0,0) : 10,
		(0,1) :  9,
		(1,0) :  9,
		(0,2) :  8,
		(2,0) :  8,
		(0,3) :  7,
		(3,0) :  7,
		(1,0) :  9,
		(0,1) :  9,
		(1,1) :  6,
		(1,2) :  5,
		(2,1) :  5,
		(1,3) :  4,
		(3,1) :  4,
		(2,0) :  8,
		(0,2) :  8,
		(2,1) :  5,
		(1,2) :  5,
		(2,2) :  3,
		(2,3) :  2,
		(3,2) :  2,
		(3,0) :  7,
		(0,3) :  7,
		(3,1) :  4,
		(1,3) :  4,
		(3,2) :  2,
		(2,3) :  2,
		(3,3) :  1,
	}


## 配合結果管理クラス
class BreedingCombination:

	## 爆発度の計算
	def get_point( self, wp ):
		bcp = BreedingCombinationPoint()
		
		check_list = (
			## ラインブリード
			(self.linebreed_type, {
				LineBreedEnum.Type_1 : CombinationPointInfo.親系統ラインブリード4本爆発SP型,
				LineBreedEnum.Type_2 : CombinationPointInfo.親系統ラインブリード4本爆発型,
				LineBreedEnum.Type_3 : CombinationPointInfo.親系統ラインブリード3本爆発SP型,
				LineBreedEnum.Type_4 : CombinationPointInfo.親系統ラインブリード3本爆発型,
				LineBreedEnum.Type_5 : CombinationPointInfo.子系統ラインブリードSP型,
				LineBreedEnum.Type_6 : CombinationPointInfo.子系統ラインブリード,
				LineBreedEnum.Type_7 : CombinationPointInfo.親系統ラインブリードSP型,
				LineBreedEnum.Type_8 : CombinationPointInfo.親系統ラインブリード,
			}),
			
			## 血脈活性化配合
			(self.blood_activity, {
				BloodActivityEnum.Type_1 : CombinationPointInfo.血脈活性化配合6本型,
				BloodActivityEnum.Type_2 : CombinationPointInfo.血脈活性化配合7本型,
				BloodActivityEnum.Type_3 : CombinationPointInfo.血脈活性化配合8本型,
			}),

			## SP昇華配合
			(self.speed_combination, {
				AttrCombinationEnum.Type_1 : CombinationPointInfo.SP昇華配合Lv1,
				AttrCombinationEnum.Type_2 : CombinationPointInfo.SP昇華配合Lv2,
				AttrCombinationEnum.Type_3 : CombinationPointInfo.SP昇華配合Lv3,
			}),
			
			## ST昇華配合
			(self.stamina_combination, {
				AttrCombinationEnum.Type_1 : CombinationPointInfo.ST昇華配合Lv1,
				AttrCombinationEnum.Type_2 : CombinationPointInfo.ST昇華配合Lv2,
				AttrCombinationEnum.Type_3 : CombinationPointInfo.ST昇華配合Lv3,
			}),

			## 母父効果
			(self.bms_type, {
				BMSEnum.Type_1 : CombinationPointInfo.母父O,
				BMSEnum.Type_2 : CombinationPointInfo.母父OO,
			}),

			## メールラインorボトムライン 活性配合
			(self.male_line_activity, {
				LineActivityEnum.Male_1   : CombinationPointInfo.メールライン活性配合Lv1,
				LineActivityEnum.Male_2   : CombinationPointInfo.メールライン活性配合Lv2,
				LineActivityEnum.Male_3   : CombinationPointInfo.メールライン活性配合Lv3,
				LineActivityEnum.Bottom_1 : CombinationPointInfo.ボトムライン活性配合Lv1,
				LineActivityEnum.Bottom_2 : CombinationPointInfo.ボトムライン活性配合Lv2,
				LineActivityEnum.Bottom_3 : CombinationPointInfo.ボトムライン活性配合Lv3,
			}),
		)
		
		for check in check_list:
			obj = check[1].get( check[0], (0, 0) )
			
			bcp.point += obj[0]
			bcp.risk  += obj[1]
		
		
		check_list = (
			( self.fision_combination,      CombinationPointInfo.SPST融合配合 ),
			( self.all_katsuryoku_complate, CombinationPointInfo.完全型活力補完 ),
			( self.special.owarai,          CombinationPointInfo.お笑い配合 ),
			( self.special.oniai,           CombinationPointInfo.お似合い配合 ),
			( self.special.sayonara,        CombinationPointInfo.サヨナラ配合 ),
			( self.special.wsayonara,       CombinationPointInfo.Wサヨナラ配合 ),
			( self.special.inazuma1,        CombinationPointInfo.稲妻配合 ),
			( self.special.inazuma2,        CombinationPointInfo.真稲妻配合 ),
			( self.special.shippuu1,        CombinationPointInfo.疾風配合 ),
			( self.special.shippuu2,        CombinationPointInfo.真疾風配合 ),
			( self.special.sankan,          CombinationPointInfo.三冠配合 ),
		)
		
		for check in check_list:
			obj = check[1]
			if check[0] == True :
				bcp.point += obj[0]
				bcp.risk  += obj[1]
		
		
		## ニックス
		for nicks in self.nicks_list :
			obj = {
				NicksEnum.Type_1 : CombinationPointInfo.シングルニックス,
				NicksEnum.Type_2 : CombinationPointInfo.ダブルニックス,
				NicksEnum.Type_3 : CombinationPointInfo.トリプルニックス,
				NicksEnum.Type_4 : CombinationPointInfo.フォースニックス,
				NicksEnum.Type_5 : CombinationPointInfo.二次ニックス,
				NicksEnum.Type_6 : CombinationPointInfo.三次ニックス,
				NicksEnum.Type_7 : CombinationPointInfo.四次ニックス,
			}.get( nicks, "[BUG]" )
			
			bcp.point += obj[0]
			bcp.risk  += obj[1]
		
		## インブリード
		for inbreed in self.inbreed_list :
			## インブリードの濃さを見て危険度を決める
			bcp.risk += CombinationPointInfo.インブリード危険度[(inbreed.sire_level, inbreed.mare_level)]
			
			if inbreed.node.data.factor_left == 0 :
				bcp.point += CombinationPointInfo.インブリードSP因子[0]
				
			if inbreed.node.data.factor_right == 0 :
				bcp.point += CombinationPointInfo.インブリードSP因子[0]
		
		check_list = (
			( self.katsuryoku_complate_1, CombinationPointInfo.名種牡馬型活力補完 ),
			( self.katsuryoku_complate_2, CombinationPointInfo.名牝型活力補完     ),
			( self.katsuryoku_complate_3, CombinationPointInfo.異系血脈型活力補完 ),
		)
		
		for check in check_list:
			obj = check[1]
			bcp.point += obj[0] * check[0]
			bcp.risk  += obj[1] * check[0]
		
		
		## 隔世遺伝(因子番号の入ったタプル)
		for factor in self.kakusei_iden :
			if factor == 0 :
				bcp.point += CombinationPointInfo.隔世遺伝SP因子[0]
				bcp.risk += CombinationPointInfo.隔世遺伝SP因子[1]
		
		
		## 活力源化大種牡馬因子(血統番号の入ったタプル)
		## 活力源化名種牡馬因子(血統番号の入ったタプル)
		check_list = (
			(self.big_sire_factor_list,   CombinationPointInfo.活力源化大種牡馬因子 ),
			(self.small_sire_factor_list, CombinationPointInfo.活力源化名種牡馬因子 ),
		)
		
		for check in check_list :
			obj = check[1]
			
			## インブリードの場合、活力源化種牡馬因子の効果は半減する
			if self.is_inbreed() :
				bcp.point += obj[0] * ( len(check[0]) / 2 )
				bcp.risk  += obj[1] * ( len(check[0]) / 2 )
			else:
				bcp.point += obj[0] * len(check[0])
				bcp.risk  += obj[1] * len(check[0])
		
		return bcp
	
	
	## インブリードかどうか
	def is_inbreed( self ):
		return len( self.inbreed_list ) > 0
	
	## ラインブリードかどうか
	def is_linebreed( self ):
		return self.linebreed_type != LineBreedEnum.NONE
	
	## 隔世遺伝かどうか
	def is_kakusei_iden( self ):
		return len( self.kakusei_iden ) > 0
	
	## ニックス(NicksEnumのリストが入ったタプル)
	nicks_list            = ()
	
	## インブリード(InBreedのリストが入ったタプル)
	inbreed_list          = ()

	## ラインブリード
	linebreed_type        = LineBreedEnum.NONE
	
	## 血脈活性化配合
	blood_activity        = BloodActivityEnum.NONE
	
	## SP昇華配合
	speed_combination     = AttrCombinationEnum.NONE
	
	## ST昇華配合
	stamina_combination   = AttrCombinationEnum.NONE
	
	## SPST融合
	fision_combination    = False

	## 母父効果
	bms_type              = BMSEnum.NONE
	
	## 名種牡馬型活力補完(個数)
	katsuryoku_complate_1 = 0
	
	## 名牝型活力補完(個数)
	katsuryoku_complate_2 = 0
	
	## 異系血脈型活力補完(個数)
	katsuryoku_complate_3 = 0
	
	## 完全型活力補完
	all_katsuryoku_complate = False
	
	## 隔世遺伝(因子番号の入ったタプル)
	kakusei_iden = ()
	
	## メールラインorボトムライン活性配合
	male_line_activity = LineActivityEnum.NONE

	## 活力源化大種牡馬因子(血統番号の入ったタプル)
	big_sire_factor_list   = ()
	
	## 活力源化名種牡馬因子(血統番号の入ったタプル)
	small_sire_factor_list = ()
	
	## 特殊配合
	special  = BreedingCombinationSpecials()
	


## 配合クラス
class Breeding:
	
	## ３冠配合が成立するレースID
	SANKAN_RACE_ID_LIST = [
		2207, # ３冠
		2208, # 牝馬３冠
		2209, # 米国３冠
		2210, # 欧州３冠
		2365, # トリプルティアラ
		2366, # 欧州オークス３冠
		2367, # 仏国牝馬３冠
		2373, # 秋古馬３冠
		2420, # 英国３冠
		2421, # 英国牝馬３冠
		2422, # 仏国３冠
		2423, # 愛国３冠
		2424, # 欧州牡馬マイル３冠
		2425, # 欧州牝馬マイル３冠
		2496, # 南関東３冠
	]
	
	def __init__( self, wp, family_line_cache, country, sire_num, sire_pedigree, dam_num, dam_pedigree ):
		self.__wp = wp
		self.__country = country
		self.__family_line_cache = family_line_cache
		self.__sire_num = sire_num
		self.__sire_pedigree = sire_pedigree
		self.__dam_num = dam_num
		self.__dam_pedigree  = dam_pedigree
		
		combination = BreedingCombination()
		
		## SPST融合配合
		family_line_data = self.__wp.HFamilyLineTable.GetData( self.__sire_pedigree.tree.data.family_line_num, HFamilyLineData() )
		
		if family_line_data.family_line_attr == 1 or family_line_data.family_line_attr == 2 :
			## SP昇華配合
			combination.speed_combination = self.__attr_combination_check( 1 )
			## ST昇華配合
			combination.stamina_combination = self.__attr_combination_check( 2 )
		
		combination.fision_combination = self.__attr_fision_combination_check()
		
		## 母父
		combination.bms_type = self.__bms_check()
		
		## 血脈活性化配合
		combination.blood_activity = self.__blood_activity_check()
		
		## ニックス
		combination.nicks_list = self.__nicks_check()
		
		## インブリード(重い)
		combination.inbreed_list = self.__inbreed_check()

		## ラインブリード
		combination.linebreed_type = self.__linebreed_check()
	
		## 活力補完
		( combination.katsuryoku_complate_1,
		  combination.katsuryoku_complate_2,
		  combination.katsuryoku_complate_3,
		  combination.all_katsuryoku_complate ) = self.__katsuryoku_complate_check()
		
		## 隔世遺伝
		combination.kakusei_iden = self.__kakusei_iden_check()
		
		## メール|ボトム ライン活性化配合
		combination.male_line_activity = self.__line_activity_check()
		
		## 活力源化種牡馬因子
		( combination.big_sire_factor_list,
		  combination.small_sire_factor_list ) = self.__activity_sire_factor_check()
		
		## 特殊配合のチェック
		combination.special = self.__special_combination_check( self.__sire_num, self.__dam_num )
		
		self.__combination = combination
	
	
	## ------------------------------------------------------------------
	## 配合結果を取得する
	## ------------------------------------------------------------------
	def get_combination( self ):
		return self.__combination
	
	
	## ------------------------------------------------------------------
	## 零細血統かどうか調べる
	## ------------------------------------------------------------------
	"""
		競馬用語辞典より
		
		零細血統 各地域(日本、米国、欧州)内で血統支配率が１％以下の子系統、もしくは 
		各地域での同じ子系統の現役種牡馬数が全体の１％以下あるいは１頭しかいない場合は零細血統とみなされる
	"""
	def is_reisai( self, country, family_line_num ):
		family_line_cache = self.__family_line_cache[ family_line_num ] 
		
		if family_line_cache.sire_count <= 1 :
			return True
		
		if family_line_cache.sire_percent <= 1.0:
			return True
		
		return {
			CountryEnum.JAPAN : family_line_cache.data.share_J <= 10,
			CountryEnum.USA   : family_line_cache.data.share_U <= 10,
			CountryEnum.EURO  : family_line_cache.data.share_E <= 10,
		}.get( country, False )
	
	
	## ------------------------------------------------------------------
	## 流行血統かどうか調べる
	## ------------------------------------------------------------------
	"""
		競馬用語辞典より
		
		流行血統 各地域(日本、米国、欧州)内で血統支配率が１０％以上の子系統、もしくは 
		各地域内で、同じ子系統の現役種牡馬数が 全体の１０％以上の場合、流行血統とみなされる。
	"""
	def is_ryuukou( self, country, family_line_num ):
		family_line_cache = self.__family_line_cache[ family_line_num ] 
		
		if family_line_cache.sire_percent >= 10.0:
			return True
		
		return {
			CountryEnum.JAPAN : family_line_cache.data.share_J >= 100,
			CountryEnum.USA   : family_line_cache.data.share_U >= 100,
			CountryEnum.EURO  : family_line_cache.data.share_E >= 100,
		}.get( country, False )
	
	
	## ------------------------------------------------------------------
	## 特殊配合のチェック
	## ------------------------------------------------------------------
	"""
		お笑い配合
			評価額が1億円以上で賢さも高い母に、種付け料100万円以下の父を配合する場合に成立します。
			精神力・賢さ・勝負根性・爆発力のアップが期待できます。
		
		お似合い配合
			種付け料が200万円以下で賢さが高い父と、評価額が1000万円以下で賢さが高い母を配合する場合に成立します。
			精神力・賢さ・勝負根性・爆発力のアップが期待できます。
		
		サヨナラ配合
			23歳以上で、同じ子系統の種牡馬がその地域（日本・米国・欧州）に1頭もいない父を配合する場合に成立します。
			神力・健康・勝負根性・爆発力のアップが期待できます。
		
		Wサヨナラ配合
			サヨナラ配合が成立する父と、15歳以上で零細血統の母を配合する場合に成立します。
			精神力・賢さ・健康・パワー・勝負根性・瞬発力・爆発力のアップが期待できます。
			
		稲妻配合
			瞬発力が高く勝負根性の低い父と、瞬発力が高く勝負根性の低い母を配合した場合に成立します。
			瞬発力・柔軟性・爆発力のアップが期待できますが、勝負根性がダウンします。
		
		真稲妻配合
			瞬発力が高く勝負根性の低い父（毛色が白毛または芦毛）と、
			瞬発力が高く勝負根性の低い母（毛色が白毛または芦毛）を配合した場合に成立します。
			瞬発力・柔軟性・爆発力のアップが期待できますが、勝負根性がダウンします。
		
		疾風配合
			勝負根性が高く瞬発力の低い父と、勝負根性が高く瞬発力の低い母を配合した場合に成立します。
			精神力・勝負根性・爆発力のアップが期待できますが、瞬発力がダウンします。
		
		真疾風配合
			勝負根性が高く瞬発力の低い父（毛色が黒鹿毛、青鹿毛または青毛）と、
			勝負根性が高く瞬発力の低い母（毛色が黒鹿毛、青鹿毛または青毛）を配合した場合に成立します。
			精神力・勝負根性・爆発力のアップが期待できますが、瞬発力がダウンします。
		
		3冠配合
			3冠馬の父と3冠馬の母を配合した場合に成立します（欧州3冠、秋古馬3冠など、普通の3冠以外でも可）。
			爆発力のアップが期待できます。
	"""
	def __special_combination_check( self, sire_num, dam_num ):
		
		special = BreedingCombinationSpecials()
		
		sire_data = self.__wp.HSireTable.GetData( sire_num, HSireData() )
		dam_data = self.__wp.HDamTable.GetData( dam_num, HDamData() )
		
		sire_abl = self.__wp.HAblTable.GetData( sire_data.abl_num, HAblData() )
		dam_abl = self.__wp.HAblTable.GetData( dam_data.abl_num, HAblData() )
		
		sire_blood = self.__wp.HBloodTable.GetData( sire_data.blood_num, HBloodData() )
		dam_blood = self.__wp.HBloodTable.GetData( dam_data.blood_num, HBloodData() )
		
		tanetsuke_price = ( sire_data.tanetsuke >> 1 ) * 100 + ( 50 if sire_data.tanetsuke & 0x1 == 1 else 0 )
		
		## お笑い配合
		if tanetsuke_price <= 100 and dam_data.price >= 100 and dam_abl.kashikosa >= 2 :
			special.owarai = True
		
		## お似合い配合
		if sire_abl.kashikosa >= 2 and dam_abl.kashikosa >= 2 and tanetsuke_price <= 200 and dam_data.price <= 20 :
			special.oniai = True
		
		## サヨナラ配合 Wサヨナラ配合
		if sire_data.age + 2 >= 23 and self.__family_line_cache[ sire_blood.family_line_num ].sire_count <= 1:
			if dam_data.age + 2 >= 15 and self.is_reisai( self.__country, dam_blood.family_line_num ):
				special.wsayonara = True
			else:
				special.sayonara = True
		
		## 稲妻配合 真稲妻配合
		if sire_abl.syunpatsu == 3 and sire_abl.konzyou <= 1 and dam_abl.syunpatsu == 3 and dam_abl.konzyou <= 1 :
			is_ashige = lambda x : x >= 6 and x <= 9
			if is_ashige( sire_abl.keiro ) and is_ashige( dam_abl.keiro ) :
				special.inazuma2 = True
			else:
				special.inazuma1 = True
		
		## 疾風配合 真疾風配合
		if sire_abl.konzyou == 3 and sire_abl.syunpatsu <= 1 and dam_abl.konzyou == 3 and dam_abl.syunpatsu <= 1 :
			if sire_abl.keiro == 1 and dam_abl.keiro == 1 :
				special.shippuu2 = True
			else:
				special.shippuu1 = True
		
		## 三冠配合
		if dam_data.kachikura in Breeding.SANKAN_RACE_ID_LIST :
			for kachikura in [ sire_data.kachikura_LT, sire_data.kachikura_LB, sire_data.kachikura_RT, sire_data.kachikura_RB ] :
				if kachikura in Breeding.SANKAN_RACE_ID_LIST :
					special.sankan = True
					break
		
		return special
	
	
	## ------------------------------------------------------------------
	## 活力源化種牡馬因子のチェック
	## ------------------------------------------------------------------
	"""
		活力源化大種牡馬因子
		父と母の先祖に「大種牡馬因子 」を持つ馬がいる場合に成立します。
		因子の数に応じて爆発力がアップします。ただしインブリードが発生した場合は、効果が半減します。
		
		活力源化名種牡馬因子
		父と母の先祖にそれぞれ「名種牡馬因子 」を持つ馬がいる場合に成立します。
		因子の数に応じて爆発力がアップします。ただしインブリードが発生した場合は、効果が半減します。
	"""
	def __activity_sire_factor_check( self ):
		big_sire_factor_list   = []
		small_sire_factor_list = []
		
		s_big_factor_having   = False
		s_small_factor_having = False
		
		for node in self.__sire_pedigree :
			family_line = self.__family_line_cache[ node.data.family_line_num ].data
			if family_line.blood_num == node.blood_num :
				if family_line.family_line_num == node.data.family_line_num :
					big_sire_factor_list.append( node.blood_num )
					s_big_factor_having = True
				else:
					small_sire_factor_list.append( node.blood_num )
					s_small_factor_having = True
		
		d_big_factor_having   = False
		d_small_factor_having = False
		
		for node in self.__dam_pedigree :
			family_line = self.__family_line_cache[ node.data.family_line_num ].data
			if family_line.blood_num == node.blood_num :
				if s_big_factor_having and family_line.family_line_num == node.data.family_line_num :
					big_sire_factor_list.append( node.blood_num )
					d_big_factor_having = True
				elif s_small_factor_having :
					small_sire_factor_list.append( node.blood_num )
					d_small_factor_having = True
		
		if not d_big_factor_having :
			big_sire_factor_list = []
		
		if not d_small_factor_having :
			small_sire_factor_list = []
		
		return tuple( big_sire_factor_list ), tuple( small_sire_factor_list )
	
	
	## ------------------------------------------------------------------
	## ライン活性配合のチェック
	## ------------------------------------------------------------------
	def __line_activity_check( self ):
		result = self.__sub_line_activity_check_male()
		
		if result != LineActivityEnum.NONE :
			return result
		
		return self.__sub_line_activity_check_bottom()
	
	
	## ------------------------------------------------------------------
	## ボトムライン 活性配合
	## ------------------------------------------------------------------
	""" 
		--------------------------------------------------------
		|             |             |   (こ)     | 父父父父    |
		|             |             |   父父父   +-------------|
		|             |             |            | 父父父母    |
		|             |    父父     +------------+-------------|
		|             |             |   (け)     | 父父母父    |
		|             |             |   父父母   +-------------|
		|  [零細]     |             |            | 父父母母    |
		| 父          |-------------+------------+-------------|
		|             |             |   (く)     | 父母父父    |
		|             |             |   父母父   +-------------|
		|             |             |            | 父母父母    |
		|             |    父母     +------------+-------------|
		|             |             |   (き)     | 父母母父    |
		|             |             |   父母母   +-------------|
		|             |             |            | 父母母母    |
		|-------------+-------------+------------+-------------|
		|             |             |   (か)     | 母父父父    |
		|             |             |   母父父   +-------------|
		|             |             |            | 母父父母    |
		|             |    母父     +------------+-------------|
		|             |             |   (お)     | 母父母父    |
		|             |             |   母父母   +-------------|
		|  (あ)       |             |            | 母父母母    |
		| 母          +-------------+------------+-------------|
		|             |             |   (え)     | 母母父父    |
		|             |             |   母母父   +-------------|
		|             |    (い)     |            | 母母父母    |
		|             |    母母     +------------+-------------|
		|             |             |   (う)     | 母母母父    |
		|             |             |   母母母   +-------------|
		|             |             |            | 母母母母    |
		--------------------------------------------------------
		
		ボトムライン活性配合Lv1
			父が「零細」で、母、母母、母母母が(あ・い・う)ともに流行か因子を持っている場合に成立します。
		
		ボトムライン活性配合Lv2
			加えて、父方の3代前の先祖(こ・け・く・き)がすべて零細血統だとより効果が高くなります。
		
		ボトムライン活性配合Lv3
			加えての母方の3代前の先祖(う・え・お・か)がすべて 
			流行血統だとさらに効果が高くなります
	"""
	def __sub_line_activity_check_bottom( self ):
		s_blood = self.__sire_pedigree.tree.data
		
		if not self.is_reisai( self.__country, s_blood.family_line_num ):
			return LineActivityEnum.NONE
			
		## Lv1のチェック
		level = LineActivityEnum.NONE
		
		data = self.__dam_pedigree.tree.data
		
		## (あ)の流行 or 因子チェック
		if self.is_ryuukou( self.__country, data.family_line_num ) or ( data.factor_left <= 8 or data.factor_right <= 8 ) :
			
			## (い),(う)の流行 or 因子チェック
			checks = tuple([
				self.__dam_pedigree.tree.mother,
				self.__dam_pedigree.tree.mother.mother,
			])
			
			## ボトムライン活性配合Lv1
			level = LineActivityEnum.Bottom_1
			
			for node in checks :
				if not self.is_ryuukou( self.__country, node.data.family_line_num ) :
					if node.data.factor_left > 8 and node.data.factor_right > 8 :
						## 無し
						level = LineActivityEnum.NONE
		
		
		## (こ),(け),(く),(き)の零細チェック
		checks = tuple([
			self.__sire_pedigree.tree.father.father,
			self.__sire_pedigree.tree.father.mother,
			self.__sire_pedigree.tree.mother.father,
			self.__sire_pedigree.tree.mother.mother,
		])
		
		for node in checks :
			if not self.is_reisai( self.__country, node.data.family_line_num ) :
				## メールライン活性配合Lv1 or 無し
				return level
		
		## (う),(え),(お),(か)の流行チェック((こ),(け),(く),(き)は零細確定済み)
		checks = tuple([
			self.__dam_pedigree.tree.mother.mother,
			self.__dam_pedigree.tree.mother.father,
			self.__dam_pedigree.tree.father.mother,
			self.__dam_pedigree.tree.father.father,
		])
		
		for node in checks :
			if not self.is_ryuukou( self.__country, node.data.family_line_num ) :
				## メールライン活性配合Lv2
				return LineActivityEnum.Bottom_2
		
		## メールライン活性配合Lv3
		return LineActivityEnum.Bottom_3
	
	
	## ------------------------------------------------------------------
	## メールライン 活性配合
	## ------------------------------------------------------------------
	""" 
		--------------------------------------------------------
		|             |             |   (け)     | 父父父父    |
		|             |             |   父父父   +-------------|
		|             |             |            | 父父父母    |
		|             |    父父     +------------+-------------|
		|             |             |   (く)     | 父父母父    |
		|  [流行]     |             |   父父母   +-------------|
		|             |             |            | 父父母母    |
		| 父          |-------------+------------+-------------|
		|             |             |   (き)     | 父母父父    |
		|             |             |   父母父   +-------------|
		|             |             |            | 父母父母    |
		|             |    父母     +------------+-------------|
		|             |             |   (か)     | 父母母父    |
		|             |             |   父母母   +-------------|
		|             |             |            | 父母母母    |
		|-------------+-------------+------------+-------------|
		|             |             |   (お)     | 母父父父    |
		|             |             |   母父父   +-------------|
		|             |             |            | 母父父母    |
		|             |    母父     +------------+-------------|
		|             |             |   (え)     | 母父母父    |
		|             |             |   母父母   +-------------|
		|  (あ)       |             |            | 母父母母    |
		| 母          +-------------+------------+-------------|
		|             |             |   (う)     | 母母父父    |
		|             |             |   母母父   +-------------|
		|             |             |            | 母母父母    |
		|             |    母母     +------------+-------------|
		|             |             |   (い)     | 母母母父    |
		|             |             |   母母母   +-------------|
		|             |             |            | 母母母母    |
		--------------------------------------------------------
		
		メールライン活性配合Lv1
			父が「流行」で、母、母母、母母母が(あ・い・う)ともに「零細」の場合に成立します。
			
		メールライン活性配合Lv2
			加えて、母方の3代前の先祖(え・お)がすべて零細血統だとより効果が高くなります。

		メールライン活性配合Lv3
			メールライン以外の3代前の先祖(い・う・え・お・か・き・く・け)がすべて零細血統だと
			さらに効果が高くなります
		
		
		> 88 名前：こんな名無しでは、どうしようもないよ。[sage] 投稿日：2012/03/30(金) 11:10:05.60 ID:wGxQ0LBn [1/2]
		> sheep（とそのパクリブログ）の配合理論　２０１２の相違点
		> メールラインLV3→父父父は流行でもよい
		
		×流行でもよい
		○零細で無くてもよい
	"""
	def __sub_line_activity_check_male( self ):
		s_blood = self.__sire_pedigree.tree.data
		
		if not self.is_ryuukou( self.__country, s_blood.family_line_num ):
			return LineActivityEnum.NONE
			
		## Lv1のチェック
		level = LineActivityEnum.NONE
		
		## (あ)の零細チェック
		if self.is_reisai( self.__country, self.__dam_pedigree.tree.data.family_line_num ) :
			## (い),(う)の零細チェック
			checks = tuple([
				self.__dam_pedigree.tree.mother.mother,
				self.__dam_pedigree.tree.mother.father,
			])
			
			## メールライン活性配合Lv1
			level = LineActivityEnum.Male_1
			
			for node in checks :
				if not self.is_reisai( self.__country, node.data.family_line_num ) :
					level = LineActivityEnum.NONE
		
		
		## (い),(う),(え),(お)の零細チェック
		checks = tuple([
			self.__dam_pedigree.tree.mother.mother,
			self.__dam_pedigree.tree.mother.father,
			self.__dam_pedigree.tree.father.mother,
			self.__dam_pedigree.tree.father.father,
		])
		
		for node in checks :
			if not self.is_reisai( self.__country, node.data.family_line_num ) :
				## メールライン活性配合Lv1 or 無し
				return level
		
		## (か),(き),(く),(け)の零細チェック((い),(う),(え),(お)は零細確定済み)
		checks = tuple([
			self.__sire_pedigree.tree.mother.mother,
			self.__sire_pedigree.tree.mother.father,
			self.__sire_pedigree.tree.father.mother,
			## (け)は零細の必要は無くなった 
			#self.__sire_pedigree.tree.father.father,
		])
		
		for node in checks :
			if not self.is_reisai( self.__country, node.data.family_line_num ) :
				## メールライン活性配合Lv2
				return LineActivityEnum.Male_2
		
		## メールライン活性配合Lv3
		return LineActivityEnum.Male_3
	
	
	## ------------------------------------------------------------------
	## 隔世遺伝
	## ------------------------------------------------------------------
	""" 
		--------------------------------------------------------
		|             |             |            | 父父父父    |
		|             |             |   父父父   +-------------|
		|             |    (う)     |            | 父父父母    |
		|             |    父父     +------------+-------------|
		|             |             |            | 父父母父    |
		|             |             |   父父母   +-------------|
		| (あ)        |             |            | 父父母母    |
		| 父          |-------------+------------+-------------|
		|             |             |            | 父母父父    |
		|             |             |   父母父   +-------------|
		|             |             |            | 父母父母    |
		|             |    父母     +------------+-------------|
		|             |             |            | 父母母父    |
		|             |             |   父母母   +-------------|
		|             |             |            | 父母母母    |
		|-------------+-------------+------------+-------------|
		|             |             |            | 母父父父    |
		|             |             |   母父父   +-------------|
		|             |    (え)     |            | 母父父母    |
		|             |    母父     +------------+-------------|
		|             |             |            | 母父母父    |
		|             |             |   母父母   +-------------|
		| (い)        |             |            | 母父母母    |
		| 母          +-------------+------------+-------------|
		|             |             |            | 母母父父    |
		|             |             |   母母父   +-------------|
		|             |             |            | 母母父母    |
		|             |    母母     +------------+-------------|
		|             |             |            | 母母母父    |
		|             |             |   母母母   +-------------|
		|             |             |            | 母母母母    |
		--------------------------------------------------------

		父と母(あ・い)がともに因子を持たず、祖父 (う・え)が因子を持っている場合に成立します。
		父 と母の祖父とも因子を持っている場合は、父方の祖父(う)が優先され、母方の祖父 (え)は影響しません。
		祖父の持つ因子の能力がアップします。(SP因子を持っている場合は爆発力がアップします)
	"""
	def __kakusei_iden_check( self ):
		s_blood = self.__sire_pedigree.tree.data
		d_blood = self.__dam_pedigree.tree.data
		
		## (あ),(い)の因子チェック
		if s_blood.factor_left <= 8 or s_blood.factor_right <= 8 or d_blood.factor_left <= 8 :
			return ()
		
		## (う),(え)の因子チェック
		for blood in [ self.__sire_pedigree.tree.father.data, self.__dam_pedigree.tree.father.data ]:
			if blood.factor_left <= 8 :
				factors = []
				factors.append( blood.factor_left )
				if blood.factor_right <= 8 :
					factors.append( blood.factor_right )
				
				return tuple( factors )
		
		return ()
	
	
	## ------------------------------------------------------------------
	## 活力補完
	## ------------------------------------------------------------------
	"""
		---------------------------------------------------
		|        |             |  (あ)      | 父父父父    |
		|        |             |   父父父   +-------------|
		|        |             |            | 父父父母    |
		|        |    父父     +------------+-------------|
		|        |             |  (い)      | 父父母父    |
		|        |             |   父父母   +-------------|
		|        |             |            | 父父母母    |
		| 父     |-------------+------------+-------------|
		|        |             |  (う)      | 父母父父    |
		|        |             |   父母父   +-------------|
		|        |             |            | 父母父母    |
		|        |    父母     +------------+-------------|
		|        |             |  (え)      | 父母母父    |
		|        |             |   父母母   +-------------|
		|        |             |            | 父母母母    |
		|--------+-------------+------------+-------------|
		|        |             |  (お)      | 母父父父    |
		|        |             |   母父父   +-------------|
		|        |             |            | 母父父母    |
		|        |    母父     +------------+-------------|
		|        |             |  (か)      | 母父母父    |
		|        |             |   母父母   +-------------|
		|        |             |            | 母父母母    |
		| 母     +-------------+------------+-------------|
		|        |             |  (き)      | 母母父父    |
		|        |             |   母母父   +-------------|
		|        |             |            | 母母父母    |
		|        |    母母     +------------+-------------|
		|        |             |  (く)      | 母母母父    |
		|        |             |   母母母   +-------------|
		|        |             |            | 母母母母    |
		---------------------------------------------------
		
		*名種牡馬型活力補完
			3代前先祖馬の中に、大種牡馬因子や名種牡馬因子を持つ(つまり系統を確立している)種牡馬がいる場合に成立します。 
			種牡馬の数に比例して、競走寿命のアップが期待できます。
			
		*名牝型活力補完
			3代前先祖馬の中に、因子を持つ繁殖牝馬がいる場合に成立します。
			繁殖牝馬の数に比例して、競走寿命のアップが期待できます。
			
		*異系血脈型活力補完
			3代前先祖馬の中に、零細血統の馬がいる場合に成立します。
			馬の数に比例して、競走寿命のアップが期待できます。
			
		*完全型活力補完
			3代前先祖馬すべてが、上記のいずれかの活力補完の対象になっている場合に成立します。
	"""
	def __katsuryoku_complate_check( self ):
		## 名種牡馬型活力補完
		katsuryoku_complate_1 = 0
		
		## 名牝型活力補完
		katsuryoku_complate_2 = 0
		
		## 異系血脈型活力補完
		katsuryoku_complate_3 = 0
		
		## 完全型活力補完
		all_katsuryoku_complate = True
		
		
		## (あ)～(え), (お)～(く)
		for padigree in [ self.__sire_pedigree, self.__dam_pedigree ] :
			for node in padigree :
				if node.level != 2 :
					continue

				match = False
				
				family_line_cache = self.__family_line_cache[ node.data.family_line_num ]
				
				if node.ptype == PedigreeTypeEnum.SIRE :
					if family_line_cache.data.blood_num == node.blood_num :
						katsuryoku_complate_1 += 1
						match = True
					
				elif node.ptype == PedigreeTypeEnum.MARE :
					if node.data.factor_left <= 8 :
						katsuryoku_complate_2 += 1
						match = True
				else :
					raise Exception, "[BUG]"
				
				if self.is_reisai( self.__country, node.data.family_line_num ) :
					katsuryoku_complate_3 += 1
					match = True
				
				if match == False :
					all_katsuryoku_complate = False
		
		return katsuryoku_complate_1, katsuryoku_complate_2, katsuryoku_complate_3, all_katsuryoku_complate
	
	
	## ------------------------------------------------------------------
	## 母父チェック
	## ------------------------------------------------------------------
	"""
		88 こんな名無しでは、どうしようもないよ。 sage 2012/03/30(金) 11:10:05.60 ID:wGxQ0LBn
		sheep(とそのパクリブログ)の配合理論　２０１２の相違点

		母父◎○→大種牡馬も名種牡馬も爆発力は(能力系因子×２)
		　　　　　　　　能力系因子２つ持ちは爆発力４　１つ持ちは爆発力２
	"""
	def __bms_check( self ):
		blood = self.__dam_pedigree.tree.data
		father_blood = self.__wp.HBloodTable.GetData( blood.father_num, HBloodData() )

		family_line_cache = self.__family_line_cache[ father_blood.family_line_num ]
		
		if family_line_cache.data.blood_num != blood.father_num :
			return BMSEnum.NONE
		
		factor_count = 0
		factor_count += 1 if father_blood.factor_left  <= 8 else 0
		factor_count += 1 if father_blood.factor_right <= 8 else 0
		
		return {
			1 : BMSEnum.Type_1,
			2 : BMSEnum.Type_2,
		}.get( factor_count, BMSEnum.NONE )
	
	
	## ------------------------------------------------------------------
	## SPST融合配合チェック
	## ------------------------------------------------------------------
	"""
		---------------------------------------------------
		|        |             |  (あ)      | 父父父父    |
		|        |             |   父父父   +-------------|
		|        |             |            | 父父父母    |
		|        |    父父     +------------+-------------|
		|        |             |  (い)      | 父父母父    |
		|        |             |   父父母   +-------------|
		|        |             |            | 父父母母    |
		| 父     |-------------+------------+-------------|
		|        |             |  (う)      | 父母父父    |
		|        |             |   父母父   +-------------|
		|        |             |            | 父母父母    |
		|        |    父母     +------------+-------------|
		|        |             |  (え)      | 父母母父    |
		|        |             |   父母母   +-------------|
		|        |             |            | 父母母母    |
		|--------+-------------+------------+-------------|
		|        |             |  (お)      | 母父父父    |
		|        |             |   母父父   +-------------|
		|        |             |            | 母父父母    |
		|        |    母父     +------------+-------------|
		|        |             |  (か)      | 母父母父    |
		|        |             |   母父母   +-------------|
		|        |             |            | 母父母母    |
		| 母     +-------------+------------+-------------|
		|        |             |  (き)      | 母母父父    |
		|        |             |   母母父   +-------------|
		|        |             |            | 母母父母    |
		|        |    母母     +------------+-------------|
		|        |             |  (く)      | 母母母父    |
		|        |             |   母母母   +-------------|
		|        |             |            | 母母母母    |
		---------------------------------------------------
		父方の3代前のすべての先祖(あ・い・う・え)がSP系統で、
		母方の3代前のすべての先祖(お・か・き・く)がST系統の場合に成立します(逆でも可)
		牝馬は、いずれかの因子を持っていれば、系統特性(SP系統・ST系統)でなくてもかまいません。
		爆発力・パワーのアップが期待できます。
	"""
	def __attr_fision_combination_check( self ):
		
		attr = None
		
		for node in self.__sire_pedigree :
			if node.level == 2 :
				family_line_cache = self.__family_line_cache[ node.data.family_line_num ]
				
				if attr == None :
					attr = family_line_cache.data.family_line_attr
					
					if attr != 1 and attr != 2 :
						return False
				
				elif family_line_cache.data.family_line_attr != attr :
					return False
		
		attr   = 1 if attr == 2 else 2
		factor = 0 if attr == 1 else 1
		
		for node in self.__dam_pedigree :
			if node.level == 2 :
				family_line_cache = self.__family_line_cache[ node.data.family_line_num ]
				
				if family_line_cache.data.family_line_attr != 1 and family_line_data.family_line_attr != 2 :
					return False
				
				if family_line_cache.data.family_line_attr != attr :
					if node.ptype != PedigreeTypeEnum.MARE :
						return False
					
					if node.data.factor_left != factor :
						return False
		
		return True
	
	
	## ------------------------------------------------------------------
	## SP|ST 昇華配合チェック
	## ------------------------------------------------------------------
	"""
		---------------------------------------------------
		|        |             |  (き)      | 父父父父    |
		|        |             |   父父父   +-------------|
		|        |    (う)     |            | 父父父母    |
		|        |    父父     +------------+-------------|
		|        |             |  (く)      | 父父母父    |
		|        |             |   父父母   +-------------|
		| (あ)   |             |            | 父父母母    |
		| 父     |-------------+------------+-------------|
		|        |             |  (け)      | 父母父父    |
		|        |             |   父母父   +-------------|
		|        |    (え)     |            | 父母父母    |
		|        |    父母     +------------+-------------|
		|        |             |  (こ)      | 父母母父    |
		|        |             |   父母母   +-------------|
		|        |             |            | 父母母母    |
		|--------+-------------+------------+-------------|
		|        |             |  (さ)      | 母父父父    |
		|        |             |   母父父   +-------------|
		|        |    (お)     |            | 母父父母    |
		|        |    母父     +------------+-------------|
		|        |             |  (し)      | 母父母父    |
		|        |             |   母父母   +-------------|
		| (い)   |             |            | 母父母母    |
		| 母     +-------------+------------+-------------|
		|        |             |  (す)      | 母母父父    |
		|        |             |   母母父   +-------------|
		|        |    (か)     |            | 母母父母    |
		|        |    母母     +------------+-------------|
		|        |             |  (せ)      | 母母母父    |
		|        |             |   母母母   +-------------|
		|        |             |            | 母母母母    |
		---------------------------------------------------
		
		父、母(あ・い)がともに SP|ST 系統の場合に成立します (レベル1)。
		爆発力のアップが期待できます。
		繁殖牝馬は、いずれかの因子を持っていれば、SP系統でなくてもかまいません。
		加えて、2代前のすべての先祖(う・え・お・か)が SP|ST 系統だとより効果が高く(レベル2)
		3代前のすべての先祖(き・ く・け・こ・さ・し・す・せ)が SP|ST 系統だとより効果が高くなります(レベル3)
		レベル3の場合は、瞬発力のアップも期待できます。
	"""
	def __attr_combination_check( self, attr ):
		
		class NOMATCH(Exception):
			pass
		
		s_family_line_cache = self.__family_line_cache[ self.__sire_pedigree.tree.data.family_line_num ]
		d_family_line_cache = self.__family_line_cache[ self.__dam_pedigree.tree.data.family_line_num ]
		
		if s_family_line_cache.data.family_line_attr != attr :
			return AttrCombinationEnum.NONE
		
		if d_family_line_cache.data.family_line_attr != attr :
			## ↓このチェックを忘れていた
			## 繁殖牝馬は、いずれかの因子を持っていれば、SP系統でなくてもかまいません。
			if self.__dam_pedigree.tree.data.factor_left > 8 and self.__dam_pedigree.tree.data.factor_right > 8:
				## SP|ST昇華配合無し
				return AttrCombinationEnum.NONE
		
		## (う)～(か)までを調べる
		try:
			for node in self.__sire_pedigree :
				if node.level == 1 :
					family_line_data = self.__wp.HFamilyLineTable.GetData( node.data.family_line_num, HFamilyLineData() )
					if family_line_data.family_line_attr != attr :
						raise NOMATCH
			
			for node in self.__dam_pedigree :
				if node.level == 1 :
					family_line_data = self.__wp.HFamilyLineTable.GetData( node.data.family_line_num, HFamilyLineData() )
					if family_line_data.family_line_attr != attr :
						raise NOMATCH
			
		except NOMATCH:
			## SP|ST昇華配合Lv1
			return AttrCombinationEnum.Type_1
			

		## (き)～(せ)までを調べる
		try:
			for node in self.__sire_pedigree :
				if node.level == 2 :
					family_line_data = self.__wp.HFamilyLineTable.GetData( node.data.family_line_num, HFamilyLineData() )
					if family_line_data.family_line_attr != attr :
						raise NOMATCH
			
			for node in self.__dam_pedigree :
				if node.level == 2 :
					family_line_data = self.__wp.HFamilyLineTable.GetData( node.data.family_line_num, HFamilyLineData() )
					if family_line_data.family_line_attr != attr :
						raise NOMATCH
			
		except NOMATCH:
			## SP|ST昇華配合Lv2
			return AttrCombinationEnum.Type_2
		
		## SP|ST昇華配合Lv3
		return AttrCombinationEnum.Type_3
	
	
	## ------------------------------------------------------------------
	## 血脈活性化配合チェック
	## ------------------------------------------------------------------
	"""
		---------------------------------------------------
		|        |             |  ※        | 父父父父    |
		|        |             |   父父父   +-------------|
		|        |             |            | 父父父母    |
		|        |    父父     +------------+-------------|
		|        |             |  ※        | 父父母父    |
		|        |             |   父父母   +-------------|
		|        |             |            | 父父母母    |
		| 父     |-------------+------------+-------------|
		|        |             |  ※        | 父母父父    |
		|        |             |   父母父   +-------------|
		|        |             |            | 父母父母    |
		|        |    父母     +------------+-------------|
		|        |             |  ※        | 父母母父    |
		|        |             |   父母母   +-------------|
		|        |             |            | 父母母母    |
		|--------+-------------+------------+-------------|
		|        |             |  ※        | 母父父父    |
		|        |             |   母父父   +-------------|
		|        |             |            | 母父父母    |
		|        |    母父     +------------+-------------|
		|        |             |  ※        | 母父母父    |
		|        |             |   母父母   +-------------|
		|        |             |            | 母父母母    |
		| 母     +-------------+------------+-------------|
		|        |             |  ※        | 母母父父    |
		|        |             |   母母父   +-------------|
		|        |             |            | 母母父母    |
		|        |    母母     +------------+-------------|
		|        |             |  ※        | 母母母父    |
		|        |             |   母母母   +-------------|
		|        |             |            | 母母母母    |
		---------------------------------------------------
		
		3代前の先祖馬の親系統が6種類以上の場合成立する。
		親系統の数に応じて爆発力がアップします。また同時にインブリードを成立させた場合、
		インブリードによるデメリットが少なくなります。
		(インブリードが3×4より薄い場合)7本型以上の場合はデメリットがなくなります。
	"""
	def __blood_activity_check( self ):
		activity_blood_list = []
			
		for node in self.__sire_pedigree :
			if node.level == 2 :
				activity_blood_list.append( node )
		
		for node in self.__dam_pedigree :
			if node.level == 2 :
				activity_blood_list.append( node )
		
		parent_family_line_list = []
		
		for node in activity_blood_list:
			family_line_cache = self.__family_line_cache[ node.data.family_line_num ]
			parent_family_line_list.append( family_line_cache.parent_family_line_num )
		
		#if self.__dam_num == 0x1e:
		#	for num in parent_family_line_list:
		#		data = self.__wp.HFamilyLineTable.GetData( num, HFamilyLineData() )
		#		print get_family_line_name( data )
		#	exit()
		
		## uniq
		parent_family_line_list = sorted( set( parent_family_line_list ), key = parent_family_line_list.index )
		
		return {
			6 : BloodActivityEnum.Type_1, # 血脈活性化配合6本型
			7 : BloodActivityEnum.Type_2, # 血脈活性化配合7本型
			8 : BloodActivityEnum.Type_3, # 血脈活性化配合8本型
		}.get( len(parent_family_line_list), BloodActivityEnum.NONE )
	
	
	## ------------------------------------------------------------------
	## ニックスのチェックをする
	## ------------------------------------------------------------------
	"""
		---------------------------------------------------
		|        |             |            | 父父父父    |
		|        |             |   父父父   +-------------|
		|        |             |            | 父父父母    |
		|        |    父父     +------------+-------------|
		|        |             |            | 父父母父    |
		|        |             |   父父母   +-------------|
		|  (あ)  |             |            | 父父母母    |
		| 父     |-------------+------------+-------------|
		|        |             |            | 父母父父    |
		|        |             |   父母父   +-------------|
		|        |             |            | 父母父母    |
		|        |    父母     +------------+-------------|
		|        |             |            | 父母母父    |
		|        |             |   父母母   +-------------|
		|        |             |            | 父母母母    |
		|--------+-------------+------------+-------------|
		|        |             |            | 母父父父    |
		|        |             |   母父父   +-------------|
		|        |     (い)    |            | 母父父母    |
		|        |    母父     +------------+-------------|
		|        |             |            | 母父母父    |
		|        |             |   母父母   +-------------|
		|        |             |            | 母父母母    |
		| 母     +-------------+------------+-------------|
		|        |             |     (う)   | 母母父父    |
		|        |             |   母母父   +-------------|
		|        |             |            | 母母父母    |
		|        |    母母     +------------+-------------|
		|        |             |            | 母母母父(え)|
		|        |             |   母母母   +-------------|
		|        |             |            | 母母母母(お)|
		---------------------------------------------------
		
		父と母父の子系統がニックス対象の場合成立します。
		
		シングルニックス        母父(い)
		ダブルニックス          母父(い)／母母父 (う)
		トリプルニックス        母父(い)／母母父 (う)／母母母父(え)
		フォースニックス        母父(い)／母母父 (う)／母母母父(え)／母母母母(お)
		2次ニックス             母母父 (う)
		3次ニックス             母母母父(え)
		4次ニックス             母母母母(お)
	"""
	def __nicks_check( self ):
		sire_family_line_num = self.__sire_pedigree.tree.data.family_line_num
		
		family_line_cache = self.__family_line_cache[ sire_family_line_num ]
		
		nicks_family_line_nums = []
		
		nicks_ary = [
			family_line_cache.data.nicks_1_num,
			family_line_cache.data.nicks_2_num,
			family_line_cache.data.nicks_3_num,
			family_line_cache.data.nicks_4_num,
			family_line_cache.data.nicks_5_num,
			family_line_cache.data.nicks_6_num,
			family_line_cache.data.nicks_7_num,
			family_line_cache.data.nicks_8_num,
			family_line_cache.data.nicks_9_num,
			family_line_cache.data.nicks_10_num,
		]

		for family_line_num in nicks_ary:
			# pythonのevalはめちゃくちゃ遅い
			# family_line_num =  eval( sprintf( "family_line_cache.data.nicks_%d_num", i ) )
			if family_line_num != self.__wp.Config.NullFamilyLineNumber :
				nicks_family_line_nums.append( family_line_num )
		
		target_family_line_nums = [None] * 4
		
		for node in self.__dam_pedigree :
			if node.ptype != PedigreeTypeEnum.MARE :
				continue
			
			if node.line.find( Pedigree.SIRE_SIGN ) == -1 :
				target_family_line_nums[ node.level ] = node.data.family_line_num
		
		match_count = 0
		
		for family_line_num in target_family_line_nums :
			if not (family_line_num in nicks_family_line_nums) :
				break
			match_count += 1
		
		result = []
		
		if match_count > 0 :
			result.append({
				1 : NicksEnum.Type_1, ## シングルニックス
				2 : NicksEnum.Type_2, ## ダブルニックス
				3 : NicksEnum.Type_3, ## トリプルニックス
				4 : NicksEnum.Type_4, ## フォースニックス
			}.get( match_count, NicksEnum.NONE ))
		
		if match_count == 0 :
			## 二次ニックス
			if target_family_line_nums[1] in nicks_family_line_nums :
				result.append( NicksEnum.Type_5 )
		
		if match_count < 2 :
			## 三次ニックス
			if target_family_line_nums[2] in nicks_family_line_nums :
				result.append( NicksEnum.Type_6 )
		
		if match_count < 3 :
			## 四次ニックス
			if target_family_line_nums[3] in nicks_family_line_nums :
				result.append( NicksEnum.Type_7 )
	
		return tuple( result )
	
	
	## ------------------------------------------------------------------
	## インブリードのチェックをする
	## ------------------------------------------------------------------
	def __inbreed_check( self ):
		inbreed_list = []
		
		memo = []
		
		for node in self.__dam_pedigree :
			memo.append( node.blood_num )
		
		memo = sorted( set(memo), key = memo.index )
			
		for node1 in self.__sire_pedigree :
			if node1.blood_num in memo :
				for node2 in self.__dam_pedigree :
					if node1.blood_num == node2.blood_num :
						inbreed_list.append( InBreed( pedigree_node = node1, sire_level = node1.level, mare_level = node2.level  ) )
		
		return tuple( inbreed_list )
	
	
	## ------------------------------------------------------------------
	## ラインブリードのチェックをする
	## ------------------------------------------------------------------
	"""
		--------------------------------------------------
		|        |             |    (あ)    | 父父父父   |
		|        |             |   父父父   +------------|
		|        |             |            | 父父父母   |
		|        |    父父     +------------+------------|
		|        |             |            | 父父母父   |
		|        |             |   父父母   +------------|
		|        |             |            | 父父母母   |
		| 父     |-------------+------------+------------|
		|        |             |    (い)    | 父母父父   |
		|        |             |   父母父   +------------|
		|        |             |            | 父母父母   |
		|        |    父母     +------------+------------|
		|        |             |            | 父母母父   |
		|        |             |   父母母   +------------|
		|        |             |            | 父母母母   |
		|--------+-------------+------------+------------|
		|        |             |    (う)    | 母父父父   |
		|        |             |   母父父   +------------|
		|        |             |            | 母父父母   |
		|        |    母父     +------------+------------|
		|        |             |            | 母父母父   |
		|        |             |   母父母   +------------|
		|        |             |            | 母父母母   |
		| 母     +-------------+------------+------------|
		|        |             |    (え)    | 母母父父   |
		|        |             |   母母父   +------------|
		|        |             |            | 母母父母   |
		|        |    母母     +------------+------------|
		|        |             |            | 母母母父   |
		|        |             |   母母母   +------------|
		|        |             |            | 母母母母   |
		--------------------------------------------------
		
		親系統ラインブリード4本爆発型(危険度1)
			3代目先祖の種牡馬4頭（あ・い・う・え）の親系統が全て同じで、
			子系統がすべて違う場合に成立します。
			父の特性がSPの場合は「親系統ラインブリード4本爆発SP型」になります。
			3代前の他の先祖馬がそれぞれ異なった親系統でないと、気性難や体質の弱化が起こる可能性 が高くなります。

		親系統ラインブリード3本爆発型(危険度1)
			3代目先祖の種牡馬4頭（あ・い・う・え）の うち、3頭の親系統が全て同じで、
			子系統がすべて違う場合に成立します。
			父の特性がSPの場合は「親系統ラインブリード3本爆発SP型」になります。
			3代前の他の先祖馬がそれぞれ異なった親系統でないと、気性難や体質の弱化が起こる可能性 が高くなります。

		親系統ラインブリード(危険度1)
			父母ともに、同じ親系統の場合成立します。
			父の特性がSPの場合は「親系統ラインブリードSP型」になります。3代前の祖先8頭のうち、
			親系統の種類が5より多いい場合は危険度が下がります。

		子系統ラインブリード(危険度2)
			父母ともに、同じ子系統の場合成立します。
			父の特性がSPの場合は「子系統ラインブリードSP型 」になります。
			3代前の祖先8頭のうち、親系統の種類が5より多いい場合は危険度が下がります。
	"""
	def __linebreed_check( self ):
		# ラインブリード対象になる血統を取得
		linebreed_blood_list = []
			
		for node in self.__sire_pedigree :
			if node.level == 2 and node.ptype == PedigreeTypeEnum.SIRE:
				linebreed_blood_list.append( node )
		
		for node in self.__dam_pedigree :
			if node.level == 2 and node.ptype == PedigreeTypeEnum.SIRE:
				linebreed_blood_list.append( node )
		
		
		blood1 = self.__wp.HBloodTable.GetData( linebreed_blood_list[0].blood_num, HBloodData() )
		blood2 = self.__wp.HBloodTable.GetData( linebreed_blood_list[1].blood_num, HBloodData() )
		blood3 = self.__wp.HBloodTable.GetData( linebreed_blood_list[2].blood_num, HBloodData() )
		blood4 = self.__wp.HBloodTable.GetData( linebreed_blood_list[3].blood_num, HBloodData() )

		child_line1 = self.__family_line_cache[ blood1.family_line_num ]
		child_line2 = self.__family_line_cache[ blood2.family_line_num ]
		child_line3 = self.__family_line_cache[ blood3.family_line_num ]
		child_line4 = self.__family_line_cache[ blood4.family_line_num ]
		
		ary = [
			child_line1.parent_family_line_num,
			child_line2.parent_family_line_num,
			child_line3.parent_family_line_num,
			child_line4.parent_family_line_num,
		]
		
		parent_line_match_count = 1
		
		## 出現率の1番多い親系統の数を数える
		for i in range( 0, len(ary) ) :
			temp = 1
			for ii in range( 0, len(ary) ):
				if i != ii and ary[i] == ary[ii]:
					temp += 1
			
			if temp > parent_line_match_count :
				parent_line_match_count = temp
		
		## 親系統ラインブリード爆発型のチェック
		if parent_line_match_count >= 3 :
			ary = [
				blood1.family_line_num,
				blood2.family_line_num,
				blood3.family_line_num,
				blood4.family_line_num,
			]
			
			## 重複した値を排除する
			ary = sorted( set(ary), key = ary.index )
			
			## 3代目先祖の種牡馬4頭(あ・い・う・え)の親系統が全て同じで、
			## 子系統がすべて違う場合に成立します。
			## 父の特性がSPの場合は「親系統ラインブリード4本爆発SP型」になります
			if parent_line_match_count == 4 and len( ary ) == 4 :
				if child_line1.data.family_line_attr == 1 :
					## 親系統ラインブリード4本爆発SP型
					return LineBreedEnum.Type_1
				else :
					## 親系統ラインブリード4本爆発型
					return LineBreedEnum.Type_2
			
			## 3代目先祖の種牡馬4頭(あ・い・う・え)の うち、3頭の親系統が全て同じで、
			## 子系統がすべて違う場合に成立します。
			## 父の特性がSPの場合は「親系統ラインブリード3本爆発SP型」になります。
			if parent_line_match_count == 3  and len( ary ) == 4 :
				if child_line1.data.family_line_attr == 1 :
					## 親系統ラインブリード3本爆発SP型
					return LineBreedEnum.Type_3
				else :
					## 親系統ラインブリード3本爆発型
					return LineBreedEnum.Type_4
		
		## 子系統ラインブリード
		## --
		## 父母ともに、同じ子系統の場合成立します。
		## 父の特性がSPの場合は「子系統ラインブリードSP型 」になります。
		## 3代前の祖先8頭のうち、親系統の種類が5より多いい場合は危険度が下がります。
		## --
		if self.__sire_pedigree.tree.data.family_line_num == self.__dam_pedigree.tree.data.family_line_num :
			if child_line1.data.family_line_attr == 1 :
				## 子系統ラインブリードSP型
				return LineBreedEnum.Type_5
			else :
				## 子系統ラインブリード
				return LineBreedEnum.Type_6

		## 親系統ラインブリードのチェック
		## --
		## 父母ともに、同じ親系統の場合成立します。
		## 父の特性がSPの場合は「親系統ラインブリードSP型」になります。
		## 3代前の祖先8頭のうち、親系統の種類が5より多い場合は危険度が下がります。
		## --
		s_temp = self.__family_line_cache[ self.__sire_pedigree.tree.data.family_line_num ]
		d_temp = self.__family_line_cache[ self.__dam_pedigree.tree.data.family_line_num ]
		
		if s_temp.parent_family_line_num == d_temp.parent_family_line_num :
			if child_line1.data.family_line_attr == 1 :
				## 親系統ラインブリードSP型
				return LineBreedEnum.Type_7
			else :
				## 親系統ラインブリード
				return LineBreedEnum.Type_8
		
		return LineBreedEnum.NONE


# --------------------------------------------------------------------
# Helper Method
# --------------------------------------------------------------------

## pythonにはsprintf無い
def sprintf( fmt, *args ):
	return fmt % args


## 牧場番号から国を取得する
def get_country_by_bokuzyou_num( bokuzyou ):
	if bokuzyou < 214 and bokuzyou != 27 and bokuzyou != 28 :
		return CountryEnum.JAPAN
	
	elif bokuzyou < 233 and bokuzyou != 28 :
		return CountryEnum.USA;

	return CountryEnum.EURO;


## 血統データの馬名を出力する
def get_blood_name( wp, blood_data ):
	disp = wp.HNameTable[ blood_data.name_left ].Kana
	right = wp.HNameTable[ blood_data.name_right ]
	if right != None :
		disp += right.Kana
	
	return disp


## 系統データの馬名を出力する
def get_family_line_name( family_line_data ):
	buffer = System.Array.CreateInstance( System.Type.GetType('System.Byte'), 14 )
	buffer[0]  = family_line_data.name_1
	buffer[1]  = family_line_data.name_2
	buffer[2]  = family_line_data.name_3
	buffer[3]  = family_line_data.name_4
	buffer[4]  = family_line_data.name_5
	buffer[5]  = family_line_data.name_6
	buffer[6]  = family_line_data.name_7
	buffer[7]  = family_line_data.name_8
	buffer[8]  = family_line_data.name_9
	buffer[9]  = family_line_data.name_10
	buffer[10] = family_line_data.name_11
	buffer[11] = family_line_data.name_12
	buffer[12] = family_line_data.name_13
	buffer[13] = family_line_data.name_14
	
	return Helper.KoeiCode.ToString( buffer )



## to_s method

def get_nicks_label( nicks_type ):
	return {
		NicksEnum.Type_1 : "シングルニックス",
		NicksEnum.Type_2 : "ダブルニックス",
		NicksEnum.Type_3 : "トリプルニックス",
		NicksEnum.Type_4 : "フォースニックス",
		NicksEnum.Type_5 : "２次ニックス",
		NicksEnum.Type_6 : "３次ニックス",
		NicksEnum.Type_7 : "４次ニックス",
	}.get( nicks_type, "[NICKS NONE]" )


def get_linebreed_label( line_breed_type ) :
	return {
		LineBreedEnum.Type_1 : "親系統ラインブリード4本爆発SP型",
		LineBreedEnum.Type_2 : "親系統ラインブリード4本爆発型",
		LineBreedEnum.Type_3 : "親系統ラインブリード3本爆発SP型",
		LineBreedEnum.Type_4 : "親系統ラインブリード3本爆発型",
		LineBreedEnum.Type_5 : "子系統ラインブリードSP型",
		LineBreedEnum.Type_6 : "子系統ラインブリード",
		LineBreedEnum.Type_7 : "親系統ラインブリードSP型",
		LineBreedEnum.Type_8 : "親系統ラインブリード",
	}.get( line_breed_type, "[LINE BREED NONE]" )


def get_bloodactivity_label( bloodactivity_type ) :
	return {
		BloodActivityEnum.Type_1 : "血脈活性化配合6本型",
		BloodActivityEnum.Type_2 : "血脈活性化配合7本型",
		BloodActivityEnum.Type_3 : "血脈活性化配合8本型",
	}.get( bloodactivity_type, "[BLOOD ACTIVITY NONE]" )


def get_bloodactivity_label( bloodactivity_type ) :
	return {
		BloodActivityEnum.Type_1 : "血脈活性化配合6本型",
		BloodActivityEnum.Type_2 : "血脈活性化配合7本型",
		BloodActivityEnum.Type_3 : "血脈活性化配合8本型",
	}.get( bloodactivity_type, "[BLOOD ACTIVITY NONE]" )


def get_bms_label( bms_type ) :
	return {
		BMSEnum.Type_1 : "母父○",
		BMSEnum.Type_2 : "母父◎",
	}.get( bms_type, "[BMS NONE]" )


def get_attr_combination_label( spst_type, attr_combination ) :
	attr = {
		SPSTTypeEnum.SPEED   : "SP",
		SPSTTypeEnum.STAMINA : "ST",
	}.get( spst_type, "[NONE]" )
	
	return {
		AttrCombinationEnum.Type_1 : sprintf( "%s昇華配合Lv1", attr ),
		AttrCombinationEnum.Type_2 : sprintf( "%s昇華配合Lv2", attr ),
		AttrCombinationEnum.Type_3 : sprintf( "%s昇華配合Lv3", attr ),
	}.get( attr_combination, sprintf( "%s[ATTR COMBINATION NONE]", attr ) )


def get_male_line_activity_label( male_line_activity_type ):
	return {
		LineActivityEnum.Male_1   : "メールライン活性配合 Lv1",
		LineActivityEnum.Male_2   : "メールライン活性配合 Lv2",
		LineActivityEnum.Male_3   : "メールライン活性配合 Lv3",
		LineActivityEnum.Bottom_1 : "ボトムライン活性配合 Lv1",
		LineActivityEnum.Bottom_2 : "ボトムライン活性配合 Lv2",
		LineActivityEnum.Bottom_3 : "ボトムライン活性配合 Lv3",
	}.get( male_line_activity_type, "[MALE LINE ACTIVITY NONE]" )
	


# --------------------------------------------------------------------
# 系統データのキャッシュデータ
# --------------------------------------------------------------------
class FamilyLineCacheData(object):
	## 系統番号
	num          = None
	
	## 系統データ
	data         = None
	
	## 大元の親系統番号
	parent_num   = 0
	
	## 地域の種牡馬数
	sire_count   = 0
	
	## 地域の種牡馬数(パーセント)
	sire_percent = 0.0
	
	def __init__( self, num, data, parent_family_line_num ):
		self.num = num
		self.data = data
		self.parent_family_line_num = parent_family_line_num
		self.sire_count = 0
		self.sire_percent = 0.0


# --------------------------------------------------------------------
# 系統データのキャッシュを作る(毎回計算すると遅いので)
# --------------------------------------------------------------------
def create_family_line_cache( wp, country ):
	family_line_cache = [None] * int(wp.HFamilyLineTable.RecordCount)
	
	for i in range( 0, wp.HFamilyLineTable.RecordCount ):
		family_line_num = i
		data = wp.HFamilyLineTable.GetData( family_line_num, HFamilyLineData() )
		
		## 大元の親系統番号を取得する
		parent_family_line_num = family_line_num
		parent_data = data
		
		if parent_data.family_line_num != wp.Config.NullFamilyLineNumber:
			while True:
				if parent_data.family_line_num == parent_family_line_num :
					break
				
				parent_family_line_num = parent_data.family_line_num
				
				if parent_family_line_num == wp.Config.NullFamilyLineNumber :
					raise Exception, "[BUG]"
				
				parent_data = wp.HFamilyLineTable.GetData( parent_family_line_num, HFamilyLineData() )
			
		family_line_cache[i] = FamilyLineCacheData( i, data, parent_family_line_num )
	
	
	sire_total_len = 0
	
	for i in range( 0, wp.HSireTable.RecordCount ):
		data = wp.HSireTable.GetData( i, HSireData() )
		
		if data.intai != 0 :
			continue
		
		abl =  wp.HAblTable.GetData( data.abl_num, HAblData() )
		
		if get_country_by_bokuzyou_num( abl.bokuzyou ) != country :
			continue
		
		blood = wp.HBloodTable.GetData( data.blood_num, HBloodData() )
		
		if blood.father_num == wp.Config.IgnoreBloodNumber :
			continue

		sire_total_len += 1
		family_line_cache[ blood.family_line_num ].sire_count += 1
	
	
	for cache in family_line_cache:
		cache.sire_percent = float(cache.sire_count) / float(sire_total_len) * 100
	
	return family_line_cache


# --------------------------------------------------------------------
# debug write
# --------------------------------------------------------------------
def combination_disp( wp, combination ):
	for nicks_type in combination.nicks_list:
		print get_nicks_label( nicks_type )
	
	if not combination.is_inbreed() :
		print "アウトブリード"
	else :
		print "インブリード"
		for inbreed in combination.inbreed_list :
			n1 = 100.0 / ( 2 ** ( inbreed.sire_level + 1 ) )
			n2 = 100.0 / ( 2 ** ( inbreed.mare_level + 1 ) )
			b = wp.HBloodTable.GetData( inbreed.node.blood_num, HBloodData() )
			print( "\t%s %d×%d (%.2f%%)" % ( get_blood_name( wp, b ), inbreed.sire_level + 1, inbreed.mare_level + 1, n1 + n2 ) )
		
	if combination.is_linebreed() :
		print get_linebreed_label( combination.linebreed_type )
	
	
	if combination.blood_activity != BloodActivityEnum.NONE :
		print get_bloodactivity_label( combination.blood_activity )
	
	if combination.speed_combination != AttrCombinationEnum.NONE :
		print get_attr_combination_label( SPSTTypeEnum.SPEED, combination.speed_combination )
	
	if combination.stamina_combination != AttrCombinationEnum.NONE :
		print get_attr_combination_label( SPSTTypeEnum.STAMINA, combination.stamina_combination )
	
	if combination.fision_combination :
		print "SPST融合配合"
	
	if combination.bms_type != BMSEnum.NONE :
		print get_bms_label( combination.bms_type )
	
	
	if combination.katsuryoku_complate_1 > 0 :
		print sprintf( "名種牡馬型活力補完(%d本)", combination.katsuryoku_complate_1 )
	
	if combination.katsuryoku_complate_2 > 0 :
		print sprintf( "名牝型活力補完(%d本)", combination.katsuryoku_complate_2 )
	
	if combination.katsuryoku_complate_3 > 0 :
		print sprintf( "異系血脈型活力補完(%d本)", combination.katsuryoku_complate_3 )
	
	if combination.all_katsuryoku_complate :
		print "完全型活力補完"
	
	if combination.is_kakusei_iden() :
		print {
			1: lambda : sprintf( "隔世遺伝(%d)", combination.kakusei_iden[0] ),
			2: lambda : sprintf( "隔世遺伝(%d)(%d)", combination.kakusei_iden[0], combination.kakusei_iden[1] ),
		}.get( len(combination.kakusei_iden), lambda : "[BUG]" )()
	
	if combination.male_line_activity != LineActivityEnum.NONE :
		print get_male_line_activity_label( combination.male_line_activity )
	
	
	if len( combination.big_sire_factor_list ) > 0 :
		print sprintf( "活力源化大種牡馬因子 * %d", len( combination.big_sire_factor_list ) )
		for blood_num in combination.big_sire_factor_list :
			blood = wp.HBloodTable.GetData( blood_num, HBloodData() )
			print "\t" + get_blood_name( wp, blood )
		
	if len( combination.small_sire_factor_list ) > 0 :
		print sprintf( "活力源化名種牡馬因子 * %d", len( combination.small_sire_factor_list ) )
		for blood_num in combination.small_sire_factor_list :
			blood = wp.HBloodTable.GetData( blood_num, HBloodData() )
			print "\t" + get_blood_name( wp, blood )
	
	if combination.special.owarai :
		print "お笑い配合"
	
	if combination.special.oniai :
		print "お似合い配合"
	
	if combination.special.sayonara :
		print "サヨナラ配合"
	elif combination.special.wsayonara :
		print "Wサヨナラ配合"
	
	if combination.special.inazuma1 :
		print "稲妻配合"
	elif combination.special.inazuma2 :
		print "真稲妻配合"
		
	if combination.special.shippuu1 :
		print "疾風配合"
	elif combination.special.shippuu2 :
		print "真疾風配合"
		
	if combination.special.sankan :
		print "三冠配合"
	
	print ""
	sys.stdout.flush()


#region エントリーポイント
if __name__ == "__main__" :
	wp = WP7( Configuration.V101() )
	
	target_country = CountryEnum.JAPAN
	family_line_cache = create_family_line_cache( wp, target_country )
	
	horse_num = wp.GetCurrentCharacterNumber()
	
	sire_num = horse_num
	sire_data = wp.HSireTable.GetData( sire_num, HSireData() )
	sire_blood_data = wp.HBloodTable.GetData( sire_data.blood_num, HBloodData() )

	sire_pedigree = Pedigree(
		wp         = wp,
		ptype      = PedigreeTypeEnum.SIRE,
		blood_data = sire_blood_data,
		blood_num  = sire_data.blood_num,
	)
	
	for i in range( 0, wp.HDamTable.RecordCount ):
		dam_num = i
		dam_data = wp.HDamTable.GetData( dam_num, HDamData() )
		
		if dam_data.intai != 0 :
			continue
		
		dam_abl = wp.HAblTable.GetData( dam_data.abl_num, HAblData() )
		
		## 自牧場以外は無視
		if dam_abl.bokuzyou != 25:
			continue
		
		if get_country_by_bokuzyou_num( dam_abl.bokuzyou ) != target_country :
			continue
			
		dam_blood = wp.HBloodTable.GetData( dam_data.blood_num, HBloodData() )
		
		if dam_blood.father_num == wp.Config.IgnoreBloodNumber :
			continue
		
		## 繁殖牝馬の血統
		dam_pedigree = Pedigree(
			wp         = wp,
			ptype      = PedigreeTypeEnum.MARE,
			blood_data = dam_blood,
			blood_num  = dam_data.blood_num,
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
		combination = breeding.get_combination()
		
		## debug write
		print sprintf( "%s × %s", get_blood_name( wp, sire_blood_data ), get_blood_name( wp, dam_blood ) )
		print "--"
	
		bcp = combination.get_point( wp )
		
		print sprintf( "爆発力 .. %d", bcp.point  )
		print sprintf( "危険度 .. %d", bcp.risk  )
	
		combination_disp( wp = wp, combination = combination, )

#endregion

