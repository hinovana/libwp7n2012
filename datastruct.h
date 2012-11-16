#ifndef _DATASTRUCT_H__
#define _DATASTRUCT_H__

#ifdef __csharp
/* libwp7n2012 -- Winning Post 7 2012 Cheat Library

   Copyright (C) 2012 AIPON of author

   This library is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 2.1 of the License, or (at your option) any later version.

   This library is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with this library; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

   Written by AIPON */

namespace KOEI.WP7_2012.Datastruct
{
	using System;
	using System.Runtime.InteropServices;
#endif

// 構造体のアライメント調整
#if defined __GNUC__
#pragma pack(1)
#elif defined _MSC_VER
#pragma pack(push,1)
#else
#error 未サポートのコンパイラです
#endif

// 血統データ
typedef struct HBloodData {
	// data1
	unsigned int father_num         : 15 ; /// <Summary>父馬血統番号</Summary><Description>父馬の血統番号</Description>
	unsigned int mother_num         : 15 ; /// <Summary>母馬血統番号</Summary><Description>母馬の血統番号</Description>
	unsigned int padding_1          : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int display            : 1 ;  /// <Summary>馬名表示(0カナ,1英字)</Summary><Description></Description>
	// data2
	unsigned int padding_2          : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int family_line_num    : 8 ;  /// <Summary>子系統</Summary><Description>系統番号</Description>
	unsigned int padding_3          : 15 ; /// <Summary></Summary><Description></Description>
	unsigned int factor_left        : 4 ;  /// <Summary>因子左</Summary><Description>0=スピード 1=スタミナ 2=パワー 3=瞬発力 4=勝負根性\r\n5=柔軟性 6=早熟 7=晩成 8=気性灘 9=無し</Description>
	unsigned int factor_right       : 4 ;  /// <Summary>因子右</Summary><Description>0=スピード 1=スタミナ 2=パワー 3=瞬発力 4=勝負根性\r\n5=柔軟性 6=早熟 7=晩成 8=気性灘 9=無し</Description>
	// data3
	unsigned int name_left          : 16 ; /// <Summary>馬名前半番号</Summary><Description></Description>
	unsigned int name_right         : 16 ; /// <Summary>馬名後半番号</Summary><Description></Description>
} HBloodData;


// 系統データ
typedef struct HFamilyLineData {
	// data1
	unsigned int family_line_num    : 8 ;  /// <Summary>親系統(自身を指せば親昇格)</Summary><Description></Description>
	unsigned int family_line_attr   : 2 ;  /// <Summary>系統特性</Summary><Description>0=無し 1=スピード 2=スタミナ 3=未定義</Description>
	unsigned int eikyouryoku        : 1 ;  /// <Summary>影響力</Summary><Description>0=影響力弱 1=影響力強</Description>
	unsigned int bms_O              : 1 ;  /// <Summary>母父○</Summary><Description></Description>
	unsigned int padding_1          : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int blood_num          : 15 ; /// <Summary>血統ポインタ</Summary><Description></Description>
	unsigned int padding_2          : 4 ;  /// <Summary></Summary><Description></Description>
	// data2
	unsigned int share_J            : 10 ; /// <Summary>支配率(日本)</Summary><Description></Description>
	unsigned int share_U            : 10 ; /// <Summary>支配率(米国)</Summary><Description></Description>
	unsigned int share_E            : 10 ; /// <Summary>支配率(欧州)</Summary><Description></Description>
	unsigned int padding_3          : 2 ;  /// <Summary></Summary><Description></Description>
	// data3
	unsigned int nicks_1_num        : 8 ;  /// <Summary>ニックス1系統</Summary><Description></Description>
	unsigned int nicks_1_share      : 8 ;  /// <Summary>ニックス1繁栄度</Summary><Description></Description>
	unsigned int nicks_2_num        : 8 ;  /// <Summary>ニックス2系統</Summary><Description></Description>
	unsigned int nicks_2_share      : 8 ;  /// <Summary>ニックス2繁栄度</Summary><Description></Description>
	// data4
	unsigned int nicks_3_num        : 8 ;  /// <Summary>ニックス3系統</Summary><Description></Description>
	unsigned int nicks_3_share      : 8 ;  /// <Summary>ニックス3繁栄度</Summary><Description></Description>
	unsigned int nicks_4_num        : 8 ;  /// <Summary>ニックス4系統</Summary><Description></Description>
	unsigned int nicks_4_share      : 8 ;  /// <Summary>ニックス4繁栄度</Summary><Description></Description>
	// data5
	unsigned int nicks_5_num        : 8 ;  /// <Summary>ニックス5系統</Summary><Description></Description>
	unsigned int nicks_5_share      : 8 ;  /// <Summary>ニックス5繁栄度</Summary><Description></Description>
	unsigned int nicks_6_num        : 8 ;  /// <Summary>ニックス6系統</Summary><Description></Description>
	unsigned int nicks_6_share      : 8 ;  /// <Summary>ニックス6繁栄度</Summary><Description></Description>
	// data6
	unsigned int nicks_7_num        : 8 ;  /// <Summary>ニックス7系統</Summary><Description></Description>
	unsigned int nicks_7_share      : 8 ;  /// <Summary>ニックス7繁栄度</Summary><Description></Description>
	unsigned int nicks_8_num        : 8 ;  /// <Summary>ニックス8系統</Summary><Description></Description>
	unsigned int nicks_8_share      : 8 ;  /// <Summary>ニックス8繁栄度</Summary><Description></Description>
	// data7
	unsigned int nicks_9_num        : 8 ;  /// <Summary>ニックス9系統</Summary><Description></Description>
	unsigned int nicks_9_share      : 8 ;  /// <Summary>ニックス9繁栄度</Summary><Description></Description>
	unsigned int nicks_10_num       : 8 ;  /// <Summary>ニックス10系統</Summary><Description></Description>
	unsigned int nicks_10_share     : 8 ;  /// <Summary>ニックス10繁栄度</Summary><Description></Description>
	// data8
	unsigned int name_1             : 8 ;  /// <Summary>系統名1</Summary><Description></Description>
	unsigned int name_2             : 8 ;  /// <Summary>系統名2</Summary><Description></Description>
	unsigned int name_3             : 8 ;  /// <Summary>系統名3</Summary><Description></Description>
	unsigned int name_4             : 8 ;  /// <Summary>系統名4</Summary><Description></Description>
	// data9
	unsigned int name_5             : 8 ;  /// <Summary>系統名5</Summary><Description></Description>
	unsigned int name_6             : 8 ;  /// <Summary>系統名6</Summary><Description></Description>
	unsigned int name_7             : 8 ;  /// <Summary>系統名7</Summary><Description></Description>
	unsigned int name_8             : 8 ;  /// <Summary>系統名8</Summary><Description></Description>
	// data10
	unsigned int name_9             : 8 ;  /// <Summary>系統名9</Summary><Description></Description>
	unsigned int name_10            : 8 ;  /// <Summary>系統名10</Summary><Description></Description>
	unsigned int name_11            : 8 ;  /// <Summary>系統名11</Summary><Description></Description>
	unsigned int name_12            : 8 ;  /// <Summary>系統名12</Summary><Description></Description>
	// data11
	unsigned int name_13            : 8 ;  /// <Summary>系統名13</Summary><Description></Description>
	unsigned int name_14            : 8 ;  /// <Summary>系統名14</Summary><Description></Description>
	unsigned int padding_4          : 16 ; /// <Summary></Summary><Description></Description>
} HFamilyLineData;


// 馬能力データ
typedef struct HAblData {
	// data1
	unsigned int speed              : 7 ; /// <Summary>スピード</Summary><Description>C=60 B=65 A=70 S=75</Description>
	unsigned int stamina            : 7 ; /// <Summary>スタミナ</Summary><Description></Description>
	unsigned int health             : 2 ; /// <Summary>健康</Summary><Description>サブパラ\r\n0=C 1=B 2=A 3=S</Description>
	unsigned int kodashi            : 4 ; /// <Summary>仔出し</Summary><Description>高いほど能力の高い馬が生みやすい</Description>
	unsigned int taikou             : 2 ; /// <Summary>体高</Summary><Description>0低 1普 2高</Description>
	unsigned int power              : 2 ; /// <Summary>パワー</Summary><Description>サブパラ\r\n0=C 1=B 2=A 3=S</Description>
	unsigned int zyuunan            : 2 ; /// <Summary>柔軟性</Summary><Description>サブパラ\r\n0=C 1=B 2=A 3=S</Description>
	unsigned int syunpatsu          : 2 ; /// <Summary>瞬発力</Summary><Description>サブパラ\r\n0=C 1=B 2=A 3=S</Description>
	unsigned int konzyou            : 2 ; /// <Summary>勝負根性</Summary><Description>サブパラ\r\n0=C 1=B 2=A 3=S</Description>
	unsigned int kashikosa          : 2 ; /// <Summary>賢さ</Summary><Description>サブパラ\r\n0=C 1=B 2=A 3=S</Description>
	// data2
	unsigned int babatekisei        : 2 ; /// <Summary>馬場適性</Summary><Description>0=芝 1=万能 2=ダート</Description>
	unsigned int bokuzyou           : 8 ; /// <Summary>繁養牧場</Summary><Description></Description>
	unsigned int zenchou            : 2 ; /// <Summary>全長</Summary><Description>0=短い 1=普通 2=長い</Description>
	unsigned int keiro              : 4 ; /// <Summary>毛色</Summary><Description>0鹿毛 1黒鹿毛 2栗毛 3栃栗毛 4青鹿毛 5青毛 6芦毛黒 7芦毛灰 8芦毛白 9白毛 10尾花栗毛</Description>
	unsigned int ryuusei            : 5 ; /// <Summary>星・流星</Summary><Description></Description>
	unsigned int seishin            : 2 ; /// <Summary>精神力</Summary><Description>サブパラ\r\n0=C 1=B 2=A 3=S</Description>
	unsigned int seichougata        : 3 ; /// <Summary>成長型</Summary><Description>0早熟 1普通早 2普通遅 3晩成 4超晩成 5早熟鍋 6普通鍋</Description>
	unsigned int seichouryoku       : 2 ; /// <Summary>成長力</Summary><Description>0=無し 1=普通 2=あり 3=持続</Description>
	unsigned int kisyou             : 3 ; /// <Summary>気性</Summary><Description>0=激2 1=激 2=荒い 3=普通 4=大人</Description>
	unsigned int padding_1          : 1 ; /// <Summary>08_8</Summary><Description></Description>
	// data3
	unsigned int seisankoku         : 4 ; /// <Summary>生産国</Summary><Description>0日本 1米国 2英国 3愛国 4仏国 5豪州 6独国 7伊国 8香港 9UAE 10加国 11南米</Description>
	unsigned int right_flont        : 2 ; /// <Summary>右前足模様</Summary><Description>0=無し 1=小 2=中 3=大</Description>
	unsigned int left_flont         : 2 ; /// <Summary>左前足模様</Summary><Description>0=無し 1=小 2=中 3=大</Description>
	unsigned int right_hind         : 2 ; /// <Summary>右後足模様</Summary><Description>0=無し 1=小 2=中 3=大</Description>
	unsigned int left_hinde         : 2 ; /// <Summary>左後足模様</Summary><Description>0=無し 1=小 2=中 3=大</Description>
	unsigned int senpou             : 3 ; /// <Summary>脚質</Summary><Description>0大逃げ 1逃げ 2先行 3差し 4追込 5自在先行 6自在差し 7自在</Description>
	unsigned int komawari_X         : 1 ; /// <Summary>小回り</Summary><Description></Description>
	unsigned int tokusei_1          : 1 ; /// <Summary>大舞台</Summary><Description></Description>
	unsigned int tokusei_2          : 1 ; /// <Summary>ＧⅡ横綱</Summary><Description></Description>
	unsigned int tokusei_3          : 1 ; /// <Summary>交流重賞</Summary><Description></Description>
	unsigned int tokusei_4          : 1 ; /// <Summary>ローカル</Summary><Description></Description>
	unsigned int tokusei_5          : 1 ; /// <Summary>スタート</Summary><Description></Description>
	unsigned int tokusei_6          : 1 ; /// <Summary>超長距離</Summary><Description></Description>
	unsigned int tokusei_7          : 1 ; /// <Summary>タフネス</Summary><Description></Description>
	unsigned int tokusei_8          : 1 ; /// <Summary>海外遠征</Summary><Description></Description>
	unsigned int tokusei_9          : 1 ; /// <Summary>男勝り</Summary><Description></Description>
	unsigned int tokusei_10         : 1 ; /// <Summary>夏馬</Summary><Description></Description>
	unsigned int tokusei_11         : 1 ; /// <Summary>軽ハンデ</Summary><Description></Description>
	unsigned int tokusei_12         : 1 ; /// <Summary>格上挑戦</Summary><Description></Description>
	unsigned int tokusei_13         : 1 ; /// <Summary>乾坤一擲</Summary><Description></Description>
	unsigned int tokusei_14         : 1 ; /// <Summary>大駆け</Summary><Description></Description>
	unsigned int tokusei_15         : 1 ; /// <Summary>鉄砲</Summary><Description></Description>
	unsigned int tokusei_16         : 1 ; /// <Summary>叩き良化</Summary><Description></Description>
} HAblData;


// 繁殖牝馬データ
typedef struct HDamData {
	// data1
	unsigned int price              : 10 ; /// <Summary>評価額</Summary><Description></Description>
	unsigned int tanetsuke_sire     : 11 ; /// <Summary>種付け種牡馬番号</Summary><Description></Description>
	unsigned int padding_1          : 7 ;  /// <Summary></Summary><Description></Description>
	unsigned int fuda_color         : 3 ;  /// <Summary>札</Summary><Description></Description>
	unsigned int padding_2          : 1 ;  /// <Summary></Summary><Description></Description>
	// data2
	unsigned int career_years       : 5 ;  /// <Summary>繁殖年数</Summary><Description></Description>
	unsigned int padding_3          : 5 ;  /// <Summary></Summary><Description></Description>
	unsigned int career_count       : 4 ;  /// <Summary>出産頭数</Summary><Description></Description>
	unsigned int status             : 2 ;  /// <Summary>受胎確認 0空胎 1受胎 2不受胎 3未確認</Summary><Description></Description>
	unsigned int intai              : 1 ;  /// <Summary>引退？</Summary><Description></Description>
	unsigned int padding_4          : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int g1_win_count       : 8 ;  /// <Summary>現役時代G1勝ち数</Summary><Description></Description>
	unsigned int age                : 5 ;  /// <Summary>+2歳</Summary><Description></Description>
	unsigned int padding_5          : 1 ;  /// <Summary></Summary><Description></Description>
	// data3
	unsigned int abl_num            : 15 ; /// <Summary>能力番号</Summary><Description></Description>
	unsigned int blood_num          : 15 ; /// <Summary>血統番号</Summary><Description></Description>
	unsigned int padding_6          : 2 ;  /// <Summary></Summary><Description></Description>
	// data4
	unsigned int kachikura          : 12 ; /// <Summary>主な勝ち鞍</Summary><Description></Description>
	unsigned int record_len         : 8 ;  /// <Summary>競走成績 戦数</Summary><Description></Description>
	unsigned int record_win         : 8 ;  /// <Summary>競走成績 勝数</Summary><Description></Description>
	unsigned int padding_7          : 4 ;  /// <Summary></Summary><Description></Description>
	// data5
	unsigned int shizitsu_num       : 13 ; /// <Summary>史実番号</Summary><Description></Description>
	unsigned int padding_8          : 2 ;  /// <Summary></Summary><Description></Description>
	unsigned int preg_shizitsu_num  : 13 ; /// <Summary>受胎中の史実番号</Summary><Description></Description>
	unsigned int padding_9          : 4 ;  /// <Summary></Summary><Description></Description>
} HDamData;


// 種牡馬データ
typedef struct HSireData {
	// data1
	unsigned int win_grade_count    : 10 ; /// <Summary>産駒重賞勝ち</Summary><Description></Description>
	unsigned int win_g1_count       : 10 ; /// <Summary>産駒G1勝ち</Summary><Description></Description>
	unsigned int tanetsuke          : 7 ;  /// <Summary>種付け料</Summary><Description>+  50万\r\n+ 100万 + 200万 + 400万\r\n+ 800万 +1600万 +3200万</Description>
	unsigned int padding_1          : 5 ;  /// <Summary></Summary><Description></Description>
	// data2                       
	unsigned int padding_2          : 23 ; /// <Summary></Summary><Description></Description>
	unsigned int record_len         : 8 ;  /// <Summary>出走数</Summary><Description></Description>
	unsigned int padding_3          : 1 ;  /// <Summary></Summary><Description></Description>
	// data3                       
	unsigned int abl_num            : 15 ; /// <Summary>能力番号</Summary><Description></Description>
	unsigned int blood_num          : 15 ; /// <Summary>血統番号</Summary><Description></Description>
	unsigned int intai              : 2 ;  /// <Summary>引退？</Summary><Description></Description>
	// data4                       
	unsigned int syoukin            : 20 ; /// <Summary>獲得賞金</Summary><Description></Description>
	unsigned int age                : 6 ;  /// <Summary>馬齢</Summary><Description></Description>
	unsigned int padding_4          : 6 ;  /// <Summary></Summary><Description></Description>
	// data5                       
	unsigned int padding_5          : 20 ; /// <Summary></Summary><Description></Description>
	unsigned int record_win         : 8 ;  /// <Summary>勝利回数</Summary><Description></Description>
	unsigned int padding_6          : 4 ;  /// <Summary></Summary><Description></Description>
	// data6                       
	unsigned int padding_7          : 28 ; /// <Summary></Summary><Description></Description>
	unsigned int bookfull           : 1 ;  /// <Summary>BookFull</Summary><Description></Description>
	unsigned int syndicate          : 1 ;  /// <Summary>シンジケート</Summary><Description></Description>
	unsigned int padding_8          : 2 ;  /// <Summary></Summary><Description></Description>
	// data7                       
	unsigned int padding_9          : 20 ; /// <Summary></Summary><Description></Description>
	unsigned int tanetsuke_count    : 8 ;  /// <Summary>種付け数</Summary><Description></Description>
	unsigned int padding_10         : 4 ;  /// <Summary></Summary><Description></Description>
	// data8                       
	unsigned int padding_80         : 32 ; /// <Summary></Summary><Description></Description>
	// data9                       
	unsigned int kachikura_LT       : 12 ; /// <Summary>主な勝ち鞍(左上)</Summary><Description></Description>
	unsigned int kachikura_LB       : 12 ; /// <Summary>主な勝ち鞍(左下)</Summary><Description></Description>
	unsigned int padding_12         : 8 ;  /// <Summary></Summary><Description></Description>
	// data10                      
	unsigned int kachikura_RT       : 12 ; /// <Summary>主な勝ち鞍(右上)</Summary><Description></Description>
	unsigned int kachikura_RB       : 12 ; /// <Summary>主な勝ち鞍(右下)</Summary><Description></Description>
	unsigned int youku1_count       : 8 ;  /// <Summary>1歳幼駒数</Summary><Description></Description>
	// data11                      
	unsigned int daihyousan_w1      : 12 ; /// <Summary>代表産駒主な勝ち鞍(1)</Summary><Description></Description>
	unsigned int daihyousan_w2      : 12 ; /// <Summary>代表産駒主な勝ち鞍(2)</Summary><Description></Description>
	unsigned int geneki_count       : 8 ;  /// <Summary>現役産駒数</Summary><Description></Description>
	// data12                      
	unsigned int daihyousan_w3      : 12 ; /// <Summary>代表産駒主な勝ち鞍(3)</Summary><Description></Description>
	unsigned int daihyousan_w4      : 12 ; /// <Summary>代表産駒主な勝ち鞍(4)</Summary><Description></Description>
	unsigned int rank_5_ago         : 8 ;  /// <Summary>5年前成績</Summary><Description></Description>
	// data13                      
	unsigned int daihyousan_1       : 32 ; /// <Summary>代表産駒1</Summary><Description></Description>
	// data14                      
	unsigned int daihyousan_2       : 32 ; /// <Summary>代表産駒2</Summary><Description></Description>
	// data15                      
	unsigned int daihyousan_3       : 32 ; /// <Summary>代表産駒3</Summary><Description></Description>
	// data16                      
	unsigned int daihyousan_4       : 32 ; /// <Summary>代表産駒4</Summary><Description></Description>
	// data17                      
	unsigned int rank_1_ago         : 8 ;  /// <Summary>1年前成績</Summary><Description></Description>
	unsigned int rank_2_ago         : 8 ;  /// <Summary>2年前成績</Summary><Description></Description>
	unsigned int rank_3_ago         : 8 ;  /// <Summary>3年前成績</Summary><Description></Description>
	unsigned int rank_4_ago         : 8 ;  /// <Summary>4年前成績</Summary><Description></Description>
	// data18
	unsigned int padding_13         : 32; /// <Summary></Summary><Description></Description>
	// data19
	unsigned int padding_14         : 32; /// <Summary></Summary><Description></Description>
	// data20
	unsigned int padding_15         : 32; /// <Summary></Summary><Description></Description>
	// data21
	unsigned int padding_16         : 32; /// <Summary></Summary><Description></Description>
	// data22
	unsigned int padding_17         : 32; /// <Summary></Summary><Description></Description>
	// data23
	unsigned int padding_18         : 32; /// <Summary></Summary><Description></Description>
	// data24
	unsigned int padding_19         : 32; /// <Summary></Summary><Description></Description>
	// data25
	unsigned int padding_20         : 32; /// <Summary></Summary><Description></Description>
	// data26
	unsigned int padding_21         : 32; /// <Summary></Summary><Description></Description>
	// data27
	unsigned int padding_22         : 32; /// <Summary></Summary><Description></Description>
	// data28
	unsigned int padding_23         : 32; /// <Summary></Summary><Description></Description>
	// data29
	unsigned int padding_24         : 32; /// <Summary></Summary><Description></Description>
	// data30
	unsigned int padding_25         : 32; /// <Summary></Summary><Description></Description>
	// data31
	unsigned int padding_26         : 32; /// <Summary></Summary><Description></Description>
	// data32
	unsigned int padding_27         : 32; /// <Summary></Summary><Description></Description>
	// data33
	unsigned int padding_28         : 32; /// <Summary></Summary><Description></Description>
	// data34
	unsigned int padding_29         : 32; /// <Summary></Summary><Description></Description>
	// data35
	unsigned int padding_30         : 32; /// <Summary></Summary><Description></Description>
	// data36
	unsigned int padding_31         : 32; /// <Summary></Summary><Description></Description>
	// data37
	unsigned int padding_32         : 32; /// <Summary></Summary><Description></Description>
	// data38
	unsigned int padding_33         : 32; /// <Summary></Summary><Description></Description>
	// data39
	unsigned int padding_34         : 32; /// <Summary></Summary><Description></Description>
	// data40
	unsigned int padding_35         : 32; /// <Summary></Summary><Description></Description>
	// data41
	unsigned int padding_36         : 32; /// <Summary></Summary><Description></Description>
	// data42
	unsigned int padding_37         : 32; /// <Summary></Summary><Description></Description>
	// data43
	unsigned int padding_38         : 32; /// <Summary></Summary><Description></Description>
} HSireData;


// 幼駒データ
typedef struct HChildData {
	// data1
	unsigned int price              : 14 ; /// <Summary>売買額 * 100万</Summary><Description></Description>
	unsigned int mother_num         : 14 ; /// <Summary>母</Summary><Description></Description>
	unsigned int weak_point_3       : 2 ;  /// <Summary>腰甘</Summary><Description></Description>
	unsigned int age                : 1 ;  /// <Summary>1で1歳</Summary><Description></Description>
	unsigned int gender             : 1 ;  /// <Summary>0牡 1牝</Summary><Description></Description>
	// data2
	unsigned int padding_1          : 7 ;  /// <Summary></Summary><Description></Description>
	unsigned int weak_point_1       : 2 ;  /// <Summary>脚部不安</Summary><Description></Description>
	unsigned int breeder            : 8 ;  /// <Summary>生産者</Summary><Description></Description>
	unsigned int padding_2          : 7 ;  /// <Summary></Summary><Description></Description>
	unsigned int zyumyou            : 7 ;  /// <Summary>競走寿命</Summary><Description></Description>
	unsigned int migimawari_X       : 1 ;  /// <Summary>右回り苦手</Summary><Description></Description>
	// data3
	unsigned int price2             : 10 ; /// <Summary>評価額 * 100万</Summary><Description></Description>
	unsigned int padding_3          : 7 ;  /// <Summary></Summary><Description></Description>
	unsigned int weak_point_2       : 2 ;  /// <Summary>喉なり</Summary><Description></Description>
	unsigned int father_num         : 11 ; /// <Summary>父馬番号</Summary><Description></Description>
	unsigned int padding_4          : 2 ;  /// <Summary></Summary><Description></Description>
	// data4
	unsigned int abl_num            : 15 ; /// <Summary>能力番号</Summary><Description></Description>
	unsigned int owner              : 12 ; /// <Summary>オーナー</Summary><Description></Description>
	unsigned int seigen             : 4 ;  /// <Summary>成長上限 +100</Summary><Description></Description>
	unsigned int hidarimawari_X     : 1 ;  /// <Summary>左回り×</Summary><Description></Description>
	// data5
	unsigned int shizitsu_num        : 13 ; /// <Summary>史実番号</Summary><Description></Description>
	unsigned int padding_5          : 5 ;  /// <Summary></Summary><Description></Description>
	unsigned int fuda_color         : 3 ;  /// <Summary>札</Summary><Description></Description>
	unsigned int padding_6          : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int torihiki           : 3 ;  /// <Summary>取引形態</Summary><Description></Description>
	unsigned int padding_7          : 7 ;  /// <Summary></Summary><Description></Description>
} HChildData;


// 競走馬データ
typedef struct HRaceData {
	// data1
	unsigned int mother_num         : 14 ; /// <Summary>母馬番号</Summary><Description>対象馬の母馬の血統番号</Description>
	unsigned int maruchihou         : 1 ;  /// <Summary>地方馬フラグ</Summary><Description>1=(地)\r\nフラグが立っていると(地)として表示されます</Description>
	unsigned int padding_2          : 3 ;  /// <Summary></Summary><Description></Description>
	unsigned int hidarimawari_X     : 1 ;  /// <Summary>左回り×</Summary><Description></Description>
	unsigned int padding_3          : 2 ;  /// <Summary></Summary><Description></Description>
	unsigned int shusen_jk_num      : 9 ;  /// <Summary>主戦騎手番号</Summary><Description></Description>
	unsigned int padding_4          : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int gender             : 1 ;  /// <Summary>性別</Summary><Description>0=牡馬 1=牝馬\r\nフラグが立っていると牝馬、立っていないと牡馬</Description>
	// data2                        
	unsigned int houbokuchuu        : 4 ;  /// <Summary>放牧中</Summary><Description>0デビュー前 1通常放牧 2熱発 3疲労\r\n4疝痛 5フレグモーネ 6鼻出血 7ソエ 8裂蹄\r\n9去勢 10繋靱帯炎 11骨折 12屈腱炎\r\n13屈腱断裂 14粉砕骨折 15繋靱帯断裂</Description>
	unsigned int padding_5          : 2 ;  /// <Summary></Summary><Description></Description>
	unsigned int kansen             : 1 ;  /// <Summary>観戦</Summary><Description>ONにすると観戦馬になる</Description>
	unsigned int weight_best        : 7 ;  /// <Summary>理想体重</Summary><Description>×2＋370kg</Description>
	unsigned int weight_now         : 7 ;  /// <Summary>馬体重</Summary><Description>×2＋370kg</Description>
	unsigned int zyumyou            : 7 ;  /// <Summary>競走寿命</Summary><Description>100以上にすると減らなくなる</Description>
	unsigned int age                : 3 ;  /// <Summary>年齢</Summary><Description>データ +2歳になる</Description>
	unsigned int padding_6          : 1 ;  /// <Summary></Summary><Description></Description>
	// data3
	unsigned int seichou            : 7 ;  /// <Summary>成長度</Summary><Description></Description>
	unsigned int keikenchi          : 7 ;  /// <Summary>経験値</Summary><Description></Description>
	unsigned int race_kan           : 7 ;  /// <Summary>レース勘</Summary><Description></Description>
	unsigned int choushi            : 6 ;  /// <Summary>調子</Summary><Description></Description>
	unsigned int klass              : 3 ;  /// <Summary>クラス</Summary><Description>0:新馬 1:未勝利 2:500万下 3:1000万下 4:1600万下 5:オープン</Description>
	unsigned int choushi_status     : 2 ;  /// <Summary>調子向き</Summary><Description>0↓ 1→ 2↑</Description>
	// data4
	unsigned int hirou              : 7 ;  /// <Summary>疲労度</Summary><Description></Description>
	unsigned int houboku_len        : 6 ;  /// <Summary>何週間放牧</Summary><Description>残りの放牧週</Description>
	unsigned int father_num         : 11 ; /// <Summary>父馬番号</Summary><Description>対象馬の父馬の血統番号</Description>
	unsigned int padding_8          : 8 ;  /// <Summary></Summary><Description></Description>
	// data5
	unsigned int padding_9          : 2 ;  /// <Summary></Summary><Description></Description>
	unsigned int intai              : 1 ;  /// <Summary>引退</Summary><Description>ONにすると引退</Description>
	unsigned int padding_10         : 9 ;  /// <Summary></Summary><Description></Description>
	unsigned int souhou             : 2 ;  /// <Summary>走法</Summary><Description>0普通 1ピッチ 2大飛び</Description>
	unsigned int weak_point_1       : 2 ;  /// <Summary>脚部不安</Summary><Description>0なし 1改善 2あり</Description>
	unsigned int weak_point_2       : 2 ;  /// <Summary>のどなり</Summary><Description>0なし 1改善 2あり</Description>
	unsigned int weak_point_3       : 2 ;  /// <Summary>腰甘</Summary><Description>0なし 1改善 2あり</Description>
	unsigned int breeder            : 8 ;  /// <Summary>生産者</Summary><Description></Description>
	unsigned int seigen             : 4 ;  /// <Summary>成長上限</Summary><Description>+100</Description>
	// data6
	unsigned int price              : 14 ; /// <Summary>売買額</Summary><Description></Description>
	unsigned int abl_num            : 15 ; /// <Summary>能力番号</Summary><Description></Description>
	unsigned int torihiki           : 3 ;  /// <Summary>取引形態</Summary><Description></Description>
	// data7
	unsigned int earning_hon        : 20 ; /// <Summary>本賞金</Summary><Description></Description>
	unsigned int owner              : 12 ; /// <Summary>オーナー</Summary><Description></Description>
	// data8
	unsigned int earning_all        : 20 ; /// <Summary>総賞金</Summary><Description></Description>
	unsigned int trainer            : 9 ;  /// <Summary>調教師</Summary><Description></Description>
	unsigned int padding_11         : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int nyuukyuu           : 1 ;  /// <Summary>入厩済み</Summary><Description></Description>
	unsigned int padding_12         : 1 ;  /// <Summary></Summary><Description></Description>
	// data9
	unsigned int padding_13         : 26 ; /// <Summary></Summary><Description></Description>
	unsigned int ensei              : 3 ;  /// <Summary>遠征先</Summary><Description>0or7他 1入厩前or放牧 2日本 3米国 4欧州 5ドバイ 6オセアニア</Description>
	unsigned int padding_14         : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int migimawari_X       : 1 ;  /// <Summary>右回り苦手</Summary><Description></Description>
	unsigned int senba              : 1 ;  /// <Summary>セン馬</Summary><Description></Description>
	// data10
	unsigned int padding_15         : 32 ; /// <Summary></Summary><Description></Description>
	// data11
	unsigned int padding_16         : 32 ; /// <Summary></Summary><Description></Description>
	// data12
	unsigned int padding_17         : 32 ; /// <Summary></Summary><Description></Description>
	// data13
	unsigned int name_left          : 16 ; /// <Summary>馬名前半</Summary><Description></Description>
	unsigned int name_right         : 16 ; /// <Summary>馬名後半</Summary><Description></Description>
	// data14
	unsigned int race_next_age      : 3 ;  /// <Summary>次走年齢 +2</Summary><Description></Description>
	unsigned int rase_next_location : 2 ;  /// <Summary>開催地</Summary><Description>0関東 1関西 2ローカル 3海外,地方</Description>
	unsigned int rase_next_sunday   : 1 ;  /// <Summary>曜日</Summary><Description>0土曜(米国,地方) 1日曜(欧州)</Description>
	unsigned int rase_next_num      : 4 ;  /// <Summary>レース番号</Summary><Description></Description>
	unsigned int rase_next_week     : 6 ;  /// <Summary>週番号</Summary><Description></Description>
	unsigned int race_last_age      : 3 ;  /// <Summary>前走年齢 +2</Summary><Description></Description>
	unsigned int rase_last_location : 2 ;  /// <Summary>開催地</Summary><Description>0関東 1関西 2ローカル 3海外,地方</Description>
	unsigned int rase_last_sunday   : 1 ;  /// <Summary>曜日</Summary><Description>0土曜(米国,地方) 1日曜(欧州)</Description>
	unsigned int rase_last_num      : 4 ;  /// <Summary>レース番号</Summary><Description></Description>
	unsigned int rase_last_week     : 6 ;  /// <Summary>週番号</Summary><Description></Description>
	// data15
	unsigned int career_shiba_1     : 8 ;  /// <Summary>芝成績1着</Summary><Description></Description>
	unsigned int career_shiba_2     : 8 ;  /// <Summary>芝成績2着</Summary><Description></Description>
	unsigned int career_shiba_3     : 8 ;  /// <Summary>芝成績3着</Summary><Description></Description>
	unsigned int career_shiba_4     : 8 ;  /// <Summary>芝成績4着以下</Summary><Description></Description>
	// data16
	unsigned int career_dirt_1      : 8 ;  /// <Summary>ダート成績1着</Summary><Description></Description>
	unsigned int career_dirt_2      : 8 ;  /// <Summary>ダート成績2着</Summary><Description></Description>
	unsigned int career_dirt_3      : 8 ;  /// <Summary>ダート成績3着</Summary><Description></Description>
	unsigned int career_dirt_4      : 8 ;  /// <Summary>ダート成績4着以下</Summary><Description></Description>
	// data17
	unsigned int padding_18         : 16 ; /// <Summary></Summary><Description></Description>
	unsigned int shizitsu_num       : 13 ; /// <Summary>史実番号</Summary><Description></Description>
	unsigned int padding_19         : 3 ;  /// <Summary></Summary><Description></Description>
} HRaceData;


typedef struct HOwnershipRaceData {
	// data0 0x00-0x04
	unsigned int horse_num          : 14 ; /// <Summary>馬番号</Summary><Description></Description>
	unsigned int padding_0          : 18 ; /// <Summary></Summary><Description></Description>
	// data1 0x04-0x08              
	unsigned int padding_10         : 32 ; /// <Summary></Summary><Description></Description>
	// data2 0x08-0x0C              
	unsigned int padding_20         : 32 ; /// <Summary></Summary><Description></Description>
	// data3 0x0C-0x10              
	unsigned int padding_30         : 32 ; /// <Summary></Summary><Description></Description>
	// data4 0x10-0x14              
	unsigned int voice_num          : 16 ; /// <Summary>音声番号</Summary><Description></Description>
	unsigned int padding_40         : 16 ; /// <Summary></Summary><Description></Description>
	// data5 0x14-0x18              
	unsigned int padding_50         : 32 ; /// <Summary></Summary><Description></Description>
	// data6 0x18-0x1C              
	unsigned int padding_60         : 32 ; /// <Summary></Summary><Description></Description>
	// data7 0x1C-0x20              
	unsigned int padding_70         : 32 ; /// <Summary></Summary><Description></Description>
	// data8 0x20-0x24              
	unsigned int padding_80         : 32 ; /// <Summary></Summary><Description></Description>
	// data9 0x24-0x28              
	unsigned int padding_90         : 32 ; /// <Summary></Summary><Description></Description>
	// data10 0x28-0x2C             
	unsigned int padding_100        : 32 ; /// <Summary></Summary><Description></Description>
	// data11 0x2C-0x30             
	unsigned int padding_110        : 32 ; /// <Summary></Summary><Description></Description>
	// data12 0x30-0x34             
	unsigned int padding_120        : 32 ; /// <Summary></Summary><Description></Description>
	// data13 0x34-0x38             
	unsigned int padding_130        : 32 ; /// <Summary></Summary><Description></Description>
	// data14 0x38-0x3C             
	unsigned int padding_140        : 32 ; /// <Summary></Summary><Description></Description>
	// data15 0x3C-0x40             
	unsigned int padding_150        : 32 ; /// <Summary></Summary><Description></Description>
	// data16 0x40-0x44             
	unsigned int padding_160        : 32 ; /// <Summary></Summary><Description></Description>
	// data17 0x44-0x48             
	unsigned int padding_170        : 32 ; /// <Summary></Summary><Description></Description>
	// data18 0x48-0x4C             
	unsigned int padding_180        : 32 ; /// <Summary></Summary><Description></Description>
	// data19 0x4C-0x50             
	unsigned int padding_190        : 32 ; /// <Summary></Summary><Description></Description>
	// data20 0x50-0x54             
	unsigned int padding_200        : 32 ; /// <Summary></Summary><Description></Description>
	// data21 0x54-0x58             
	unsigned int padding_210        : 32 ; /// <Summary></Summary><Description></Description>
	// data22 0x58-0x5C             
	unsigned int padding_220        : 32 ; /// <Summary></Summary><Description></Description>
	// data23 0x5C-0x60             
	unsigned int padding_230        : 32 ; /// <Summary></Summary><Description></Description>
	// data24 0x60-0x64             
	unsigned int padding_240        : 32 ; /// <Summary></Summary><Description></Description>
	// data25 0x64-0x68             
	unsigned int padding_250        : 32 ; /// <Summary></Summary><Description></Description>
	// data26 0x68-0x6C             
	unsigned int padding_260        : 32 ; /// <Summary></Summary><Description></Description>
	// data27 0x6C-0x70             
	unsigned int padding_270        : 32 ; /// <Summary></Summary><Description></Description>
	// data28 0x70-0x74             
	unsigned int padding_280        : 32 ; /// <Summary></Summary><Description></Description>
	// data29 0x74-0x78             
	unsigned int padding_290        : 32 ; /// <Summary></Summary><Description></Description>
	// data30 0x78-0x7C             
	unsigned int padding_300        : 32 ; /// <Summary></Summary><Description></Description>
	// data31 0x7C-0x80             
	unsigned int padding_310        : 32 ; /// <Summary></Summary><Description></Description>
	// data32 0x80-0x84             
	unsigned int padding_320        : 32 ; /// <Summary></Summary><Description></Description>
	// data33 0x84-0x88             
	unsigned int race_num_2         : 16 ;  /// <Summary>ローテーション(第2戦)</Summary><Description></Description>
	unsigned int race_num_3         : 16 ;  /// <Summary>ローテーション(第3戦)</Summary><Description></Description>
	// data34 0x88-0x8C             
	unsigned int race_num_4         : 16 ;  /// <Summary>ローテーション(第4戦)</Summary><Description></Description>
	unsigned int race_num_5         : 16 ;  /// <Summary>ローテーション(第5戦)</Summary><Description></Description>
	// data35 0x8C-0x90             
	unsigned int race_num_6         : 16 ;  /// <Summary>ローテーション(第6戦)</Summary><Description></Description>
	unsigned int race_num_7         : 16 ;  /// <Summary>ローテーション(第7戦)</Summary><Description></Description>
	// data36 0x90-0x94             
	unsigned int race_num_8         : 16 ;  /// <Summary>ローテーション(第8戦)</Summary><Description></Description>
	unsigned int race_num_9         : 16 ;  /// <Summary>ローテーション(第9戦)</Summary><Description></Description>
	// data37 0x94-0x98             
	unsigned int race_num_10        : 16 ;  /// <Summary>ローテーション(第10戦)</Summary><Description></Description>
	unsigned int jockey_1           : 16 ;  /// <Summary>騎手(第1戦)</Summary><Description></Description>
	// data38 0x98-0x9C             
	unsigned int jockey_2           : 16 ;  /// <Summary>騎手(第2戦)</Summary><Description></Description>
	unsigned int jockey_3           : 16 ;  /// <Summary>騎手(第3戦)</Summary><Description></Description>
	// data39 0x9C-0xA0             
	unsigned int jockey_4           : 16 ;  /// <Summary>騎手(第4戦)</Summary><Description></Description>
	unsigned int jockey_5           : 16 ;  /// <Summary>騎手(第5戦)</Summary><Description></Description>
	// data40 0xA0-0xA4             
	unsigned int jockey_6           : 16 ;  /// <Summary>騎手(第6戦)</Summary><Description></Description>
	unsigned int jockey_7           : 16 ;  /// <Summary>騎手(第7戦)</Summary><Description></Description>
	// data41 0xA4-0xA8             
	unsigned int jockey_8           : 16 ;  /// <Summary>騎手(第8戦)</Summary><Description></Description>
	unsigned int jockey_9           : 16 ;  /// <Summary>騎手(第9戦)</Summary><Description></Description>
	// data42 0xA8-0xAC             
	unsigned int jockey_10          : 16 ;  /// <Summary>騎手(第10戦)</Summary><Description></Description>
	unsigned int padding_420        : 16 ;  /// <Summary></Summary><Description></Description>
	// data43 0xAC-0xB0             
	unsigned int training_yellow    : 7 ;  /// <Summary>育成度(黄)</Summary><Description></Description>
	unsigned int training_green     : 7 ;  /// <Summary>育成度(緑)</Summary><Description></Description>
	unsigned int seichou_speed      : 7 ;  /// <Summary>成長(SP)</Summary><Description></Description>
	unsigned int seichou_konzyou    : 5 ;  /// <Summary>成長(根性)</Summary><Description></Description>
	unsigned int seichou_syunpatsu  : 5 ;  /// <Summary>成長(瞬発力)</Summary><Description></Description>
	unsigned int memo_open_1        : 1 ;  /// <Summary>メモ成長型表示</Summary><Description></Description>
	// data44 0xB0-0xB4             
	unsigned int seichou_power      : 5 ;  /// <Summary>成長(瞬発力)</Summary><Description></Description>
	unsigned int seichou_zyuunan    : 5 ;  /// <Summary>成長(柔軟性)</Summary><Description></Description>
	unsigned int seichou_seishin    : 5 ;  /// <Summary>成長(精神力)</Summary><Description></Description>
	unsigned int seichou_kashikosa  : 5 ;  /// <Summary>成長(賢さ)</Summary><Description></Description>
	unsigned int seichou_health     : 5 ;  /// <Summary>成長(健康)</Summary><Description></Description>
	unsigned int memo_open_2        : 1 ;  /// <Summary>メモ気性表示</Summary><Description></Description>
	unsigned int memo_open_3        : 1 ;  /// <Summary>メモ馬場適正表示</Summary><Description></Description>
	unsigned int memo_open_4        : 1 ;  /// <Summary>メモ重馬場適正表示</Summary><Description></Description>
	unsigned int padding_440        : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int mark               : 2 ;  /// <Summary>マーク表示 0無印 1春雷 2流星 3暁</Summary><Description></Description>
	unsigned int padding_441        : 1 ;  /// <Summary></Summary><Description></Description>
	// data45 0xB4-0xB8             
	unsigned int memo_open_5        : 1 ; /// <Summary>メモ回り表示(小回り)</Summary><Description></Description>
	unsigned int memo_open_6        : 1 ; /// <Summary>メモ回り表示(右)</Summary><Description></Description>
	unsigned int memo_open_7        : 1 ; /// <Summary>メモ回り表示(左)</Summary><Description></Description>
	unsigned int memo_open_8        : 1 ; /// <Summary>メモ走法表示</Summary><Description></Description>
	unsigned int memo_open_9        : 1 ; /// <Summary>メモ持病表示(喉なり)</Summary><Description></Description>
	unsigned int memo_open_10       : 1 ; /// <Summary>メモ持病表示(脚部不安)</Summary><Description></Description>
	unsigned int memo_open_11       : 1 ; /// <Summary>メモ持病表示(腰甘)</Summary><Description></Description>
	unsigned int memo_open_12       : 1 ; /// <Summary>メモSP表示</Summary><Description></Description>
	unsigned int memo_open_13       : 1 ; /// <Summary>メモ勝負根性表示</Summary><Description></Description>
	unsigned int memo_open_14       : 1 ; /// <Summary>メモ瞬発力表示</Summary><Description></Description>
	unsigned int memo_open_15       : 1 ; /// <Summary>メモパワー表示</Summary><Description></Description>
	unsigned int memo_open_16       : 1 ; /// <Summary>メモ柔軟性表示</Summary><Description></Description>
	unsigned int memo_open_17       : 1 ; /// <Summary>メモ精神力表示</Summary><Description></Description>
	unsigned int memo_open_18       : 1 ; /// <Summary>メモ賢さ表示</Summary><Description></Description>
	unsigned int memo_open_19       : 1 ; /// <Summary>メモ健康表示</Summary><Description></Description>
	unsigned int memo_open_20       : 1 ; /// <Summary>メモ適正距離表示</Summary><Description></Description>
	unsigned int memo_open_21       : 1 ; /// <Summary>スピード成長(表示のみ)</Summary><Description></Description>
	unsigned int memo_open_22       : 1 ; /// <Summary>勝負根性成長(表示のみ)</Summary><Description></Description>
	unsigned int memo_open_23       : 1 ; /// <Summary>瞬発力成長(表示のみ)</Summary><Description></Description>
	unsigned int memo_open_24       : 1 ; /// <Summary>パワー成長(表示のみ)</Summary><Description></Description>
	unsigned int memo_open_25       : 1 ; /// <Summary>柔軟性成長(表示のみ)</Summary><Description></Description>
	unsigned int memo_open_26       : 1 ; /// <Summary>精神力成長(表示のみ)</Summary><Description></Description>
	unsigned int memo_open_27       : 1 ; /// <Summary>賢さ成長(表示のみ)</Summary><Description></Description>
	unsigned int memo_open_28       : 1 ; /// <Summary>健康成長(表示のみ)</Summary><Description></Description>
	unsigned int padding_450        : 4 ;  /// <Summary></Summary><Description></Description>
	unsigned int memo_open_29       : 1 ;  /// <Summary>メモ脚質表示</Summary><Description></Description>
	unsigned int padding_451        : 3 ;  /// <Summary></Summary><Description></Description>
	// data46 0xB8-0xBC             
	unsigned int padding_460        : 32 ; /// <Summary></Summary><Description></Description>
	// data47 0xBC-0xC0             
	unsigned int padding_470        : 32 ; /// <Summary></Summary><Description></Description>
	// data48 0xC0-0xC4             
	unsigned int padding_480        : 32 ; /// <Summary></Summary><Description></Description>
	// data49 0xC4-0xC8             
	unsigned int padding_490        : 32 ; /// <Summary></Summary><Description></Description>
	// data50 0xC8-0xCC             
	unsigned int padding_500        : 32 ; /// <Summary></Summary><Description></Description>
	// data51 0xCC-0xD0             
	unsigned int padding_510        : 32 ; /// <Summary></Summary><Description></Description>
	// data52 0xD0-0xD4             
	unsigned int padding_520        : 32 ; /// <Summary></Summary><Description></Description>
	// data53 0xD4-0xD8             
	unsigned int padding_530        : 32 ; /// <Summary></Summary><Description></Description>
	// data54 0xD8-0xDC             
	unsigned int padding_540        : 32 ; /// <Summary></Summary><Description></Description>
	// data55 0xDC-0xE0             
	unsigned int padding_550        : 32 ; /// <Summary></Summary><Description></Description>
	// data56 0xE0-0xE4             
	unsigned int padding_560        : 32 ; /// <Summary></Summary><Description></Description>
	// data57 0xE4-0xE8             
	unsigned int padding_570        : 32 ; /// <Summary></Summary><Description></Description>
	// data58 0xE8-0xEC             
	unsigned int padding_580        : 32 ; /// <Summary></Summary><Description></Description>
	// data59 0xEC-0xF0             
	unsigned int padding_590        : 32 ; /// <Summary></Summary><Description></Description>
	// data60 0xF0-0xF4             
	unsigned int padding_600        : 32 ; /// <Summary></Summary><Description></Description>
	// data61 0xF4-0xF8             
	unsigned int padding_610        : 32 ; /// <Summary></Summary><Description></Description>
	// data62 0xF8-0xFC             
	unsigned int padding_620        : 32 ; /// <Summary></Summary><Description></Description>
	// data63 0xFC-0x100            
	unsigned int padding_630        : 32 ; /// <Summary></Summary><Description></Description>
	// data64 0x100-0x104           
	unsigned int padding_640        : 32 ; /// <Summary></Summary><Description></Description>
	// data65 0x104-0x108           
	unsigned int padding_650        : 32 ; /// <Summary></Summary><Description></Description>
	// data66 0x108-0x10C           
	unsigned int padding_660        : 32 ; /// <Summary></Summary><Description></Description>
	// data67 0x10C-0x110           
	unsigned int padding_670        : 32 ; /// <Summary></Summary><Description></Description>
	// data68 0x110-0x114           
	unsigned int padding_680        : 32 ; /// <Summary></Summary><Description></Description>
	// data69 0x114-0x118           
	unsigned int padding_690        : 32 ; /// <Summary></Summary><Description></Description>
	// data70 0x118-0x11C           
	unsigned int padding_700        : 32 ; /// <Summary></Summary><Description></Description>
} HOwnershipRaceData;

typedef struct HOwnershipChildData {
	// data0 0x00-0x04
	unsigned int horse_num          : 14 ; /// <Summary>馬番号</Summary><Description></Description>
	unsigned int padding_0          : 18 ; /// <Summary></Summary><Description></Description>
	// data1 0x04-0x08              
	unsigned int training_yellow    : 7 ;  /// <Summary>育成度(黄)</Summary><Description></Description>
	unsigned int training_green     : 7 ;  /// <Summary>育成度(緑)</Summary><Description></Description>
	unsigned int seichou_speed      : 7 ;  /// <Summary>成長(SP)</Summary><Description></Description>
	unsigned int seichou_konzyou    : 5 ;  /// <Summary>成長(根性)</Summary><Description></Description>
	unsigned int seichou_syunpatsu  : 5 ;  /// <Summary>成長(瞬発力)</Summary><Description></Description>
	unsigned int memo_open_1        : 1 ;  /// <Summary>メモ成長型表示</Summary><Description></Description>
	// data2 0x08-0x0C              
	unsigned int seichou_power      : 5 ;  /// <Summary>成長(瞬発力)</Summary><Description></Description>
	unsigned int seichou_zyuunan    : 5 ;  /// <Summary>成長(柔軟性)</Summary><Description></Description>
	unsigned int seichou_seishin    : 5 ;  /// <Summary>成長(精神力)</Summary><Description></Description>
	unsigned int seichou_kashikosa  : 5 ;  /// <Summary>成長(賢さ)</Summary><Description></Description>
	unsigned int seichou_health     : 5 ;  /// <Summary>成長(健康)</Summary><Description></Description>
	unsigned int memo_open_2        : 1 ;  /// <Summary>メモ気性表示</Summary><Description></Description>
	unsigned int memo_open_3        : 1 ;  /// <Summary>メモ馬場適正表示</Summary><Description></Description>
	unsigned int memo_open_4        : 1 ;  /// <Summary>メモ重馬場適正表示</Summary><Description></Description>
	unsigned int padding_20         : 1 ;  /// <Summary></Summary><Description></Description>
	unsigned int mark               : 2 ;  /// <Summary>マーク表示 0無印 1春雷 2流星 3暁</Summary><Description></Description>
	unsigned int padding_21         : 1 ;  /// <Summary></Summary><Description></Description>
	// data3 0x0C-0x10              
	unsigned int memo_open_5        : 1 ; /// <Summary>メモ回り表示(小回り)</Summary><Description></Description>
	unsigned int memo_open_6        : 1 ; /// <Summary>メモ回り表示(右)</Summary><Description></Description>
	unsigned int memo_open_7        : 1 ; /// <Summary>メモ回り表示(左)</Summary><Description></Description>
	unsigned int memo_open_8        : 1 ; /// <Summary>メモ走法表示</Summary><Description></Description>
	unsigned int memo_open_9        : 1 ; /// <Summary>メモ持病表示(喉なり)</Summary><Description></Description>
	unsigned int memo_open_10       : 1 ; /// <Summary>メモ持病表示(脚部不安)</Summary><Description></Description>
	unsigned int memo_open_11       : 1 ; /// <Summary>メモ持病表示(腰甘)</Summary><Description></Description>
	unsigned int memo_open_12       : 1 ; /// <Summary>メモSP表示</Summary><Description></Description>
	unsigned int memo_open_13       : 1 ; /// <Summary>メモ勝負根性表示</Summary><Description></Description>
	unsigned int memo_open_14       : 1 ; /// <Summary>メモ瞬発力表示</Summary><Description></Description>
	unsigned int memo_open_15       : 1 ; /// <Summary>メモパワー表示</Summary><Description></Description>
	unsigned int memo_open_16       : 1 ; /// <Summary>メモ柔軟性表示</Summary><Description></Description>
	unsigned int memo_open_17       : 1 ; /// <Summary>メモ精神力表示</Summary><Description></Description>
	unsigned int memo_open_18       : 1 ; /// <Summary>メモ賢さ表示</Summary><Description></Description>
	unsigned int memo_open_19       : 1 ; /// <Summary>メモ健康表示</Summary><Description></Description>
	unsigned int memo_open_20       : 1 ; /// <Summary>メモ適正距離表示</Summary><Description></Description>
	unsigned int padding_30         : 12 ; /// <Summary></Summary><Description></Description>
	unsigned int memo_open_29       : 1 ;  /// <Summary>メモ脚質表示</Summary><Description></Description>
	unsigned int padding_31         : 3 ;  /// <Summary></Summary><Description></Description>
	// data4 0x10-0x14
	unsigned int padding_40         : 32 ; /// <Summary></Summary><Description></Description>
	// data5 0x14-0x18
	unsigned int padding_50         : 32 ; /// <Summary></Summary><Description></Description>
	// data6 0x18-0x1C
	unsigned int padding_60         : 32 ; /// <Summary></Summary><Description></Description>
	// data7 0x1C-0x20
	unsigned int padding_70         : 32 ; /// <Summary></Summary><Description></Description>
	// data8 0x20-0x24
	unsigned int padding_80         : 32 ; /// <Summary></Summary><Description></Description>
	// data9 0x24-0x28
	unsigned int padding_90         : 32 ; /// <Summary></Summary><Description></Description>
	// data10 0x28-0x2C
	unsigned int padding_100        : 32 ; /// <Summary></Summary><Description></Description>
	// data11 0x2C-0x30
	unsigned int padding_110        : 32 ; /// <Summary></Summary><Description></Description>
	// data12 0x30-0x34
	unsigned int padding_120        : 32 ; /// <Summary></Summary><Description></Description>
	// data13 0x34-0x38
	unsigned int padding_130        : 32 ; /// <Summary></Summary><Description></Description>
	// data14 0x38-0x3C
	unsigned int padding_140        : 32 ; /// <Summary></Summary><Description></Description>
	// data15 0x3C-0x40
	unsigned int padding_150        : 32 ; /// <Summary></Summary><Description></Description>
	// data16 0x40-0x44
	unsigned int padding_160        : 32 ; /// <Summary></Summary><Description></Description>
	// data17 0x44-0x48
	unsigned int padding_170        : 32 ; /// <Summary></Summary><Description></Description>
	// data18 0x48-0x4C
	unsigned int padding_180        : 32 ; /// <Summary></Summary><Description></Description>
	// data19 0x4C-0x50
	unsigned int padding_190        : 32 ; /// <Summary></Summary><Description></Description>
	// data20 0x50-0x54
	unsigned int padding_200        : 32 ; /// <Summary></Summary><Description></Description>
	// data21 0x54-0x58
	unsigned int padding_210        : 32 ; /// <Summary></Summary><Description></Description>
	// data22 0x58-0x5C
	unsigned int padding_220        : 32 ; /// <Summary></Summary><Description></Description>
	// data23 0x5C-0x60
	unsigned int padding_230        : 32 ; /// <Summary></Summary><Description></Description>
	// data24 0x60-0x64
	unsigned int padding_240        : 32 ; /// <Summary></Summary><Description></Description>
	// data25 0x64-0x68
	unsigned int padding_250        : 32 ; /// <Summary></Summary><Description></Description>
	// data26 0x68-0x6C
	unsigned int padding_260        : 32 ; /// <Summary></Summary><Description></Description>
} HOwnershipChildData;


typedef struct RRaceData {
	// data0 0x00-0x04
	unsigned int race_name_num      : 16; /// <Summary>レース名番号</Summary><Description></Description>
	unsigned int race_kaku          : 16; /// <Summary>レース格</Summary><Description>値が小さいほど格が高い</Description>
	// data1 0x04-0x08
	unsigned int type_age           :  3; /// <Summary>馬齢条件</Summary><Description>0=2歳 1=2歳以上 2=3歳 3=3歳以上 4=4歳以上</Description>
	unsigned int type_gender        :  3; /// <Summary>性別条件</Summary><Description>0=限定無し 1=牡馬限定 2=牝馬限定 3=牡セン 4=牡牝</Description>
	unsigned int type_kokusai       :  3; /// <Summary>出走条件</Summary><Description>1=国際 2=外国地方招待 3=指定 4=国際指定</Description>
	unsigned int is_kongou          :  1; /// <Summary>混合？</Summary><Description></Description>
	unsigned int is_dirt            :  1; /// <Summary>ダート？</Summary><Description></Description>
	unsigned int distance           :  5; /// <Summary>距離</Summary><Description>0=1000m, 1=1100m, 2=1150m, 3=1200m, 4=1300m, 5=1400m, 6=1500m, 7=1600m, 8=1700m, 9=1777m, 10=1800m, 11=1850m, 12=1900m, 13=1950m, 14=2000m, 15=2100m, 16=2200m, 17=2300m, 18=2400m, 19=2500m, 20=2600m, 21=2800m, 22=3000m, 23=3100m, 24=3200m, 25=3300m, 26=3400m, 27=3600m, 28=4000m</Description>
	unsigned int grade              :  4; /// <Summary>グレード</Summary><Description>0=新馬, 1=未勝利, 2=500万下, 3=500万下, 4=1000万下, 5=1000万下, 6=1600万下, 7=オープン, 8=G3, 9=G2, 10=G1</Description>
	unsigned int fullgate           :  3; /// <Summary>フルゲート</Summary><Description>0=11頭, 1=12頭, 2=13頭, 3=14頭, 4=15頭, 5=16頭, 6=18頭</Description>
	unsigned int is_jpn             :  1; /// <Summary>JPN</Summary><Description></Description>
	unsigned int padding_20         :  8; /// <Summary></Summary><Description></Description>
	// data2 0x08-0x0C
	unsigned int ticket             :  3; /// <Summary>優先出走権</Summary><Description>1=皐月賞, 2=ダービー, 3=菊花賞, 4=桜花賞, 5=オークス, 6=秋華賞, 7=NHKマイルカップ</Description>
	unsigned int course             :  7; /// <Summary>競馬場</Summary><Description>0=京都, 1=小倉, 2=札幌, 3=中京, 4=東京, 5=中山, 6=新潟, 7=函館, 8=阪神, 9=福島, 10=アケダクト, 11=アーリントン, 12=ウッドバイン, 13=オークローン, 14=ガルフストリーム, 15=キーンランド, 16=サラトガ, 17=サンタアニタ, 18=ターフウェーパーク, 19=チャーチルダウンズ, 20=デルマー, 21=ハリウッドパーク, 22=ピムリコ, 23=ベルモントパーク, 24=モンマスパーク, 25=ルイジアナダウンズ, 26=ローレルパーク, 27=フェアグラウンズ, 28=シャティン, 29=カラー, 30=レパーズタウン, 31=アスコット, 32=エプソムダウンズ, 33=グッドウッド, 34=サンダウン, 35=ドンカスター, 36=ニューベリ, 37=ニューマーケット, 38=ヘイドックパーク, 39=ヨーク, 40=サンクルー, 41=シャンティイ, 42=ドーヴィル, 43=メゾンラフィット, 44=ロンシャン, 45=バーデンバーデン, 46=ミュールハイム, 47=ハンブルク, 48=クランジ, 49=ムーニーバレー, 50=フレミントン, 51=ナドアルシバ, 52=旭川, 53=浦和, 54=大井, 55=笠松, 56=金沢, 57=川崎, 58=高知, 59=佐賀, 60=高崎, 61=名古屋, 62=船橋, 63=盛岡, 64=門別, 65=園田, 66=上山, 67=宇都宮</Description>
	unsigned int weight             :  4; /// <Summary>基本斤量</Summary><Description></Description>
	unsigned int unknown_1          :  4; /// <Summary>表示方法？</Summary><Description></Description>
	unsigned int weight_ext         :  5; /// <Summary>負担重量条件</Summary><Description></Description>
	unsigned int padding_30         :  2; /// <Summary></Summary><Description></Description>
	unsigned int syoukin            :  7; /// <Summary>賞金</Summary><Description>0=390万, 1=400万, 2=440万, 3=500万, 4=510万, 5=540万, 6=600万, 7=650万, 8=700万, 9=750万, 10=800万, 11=900万, 12=1000万, 13=1050万, 14=1150万, 15=1400万, 16=1450万, 17=1500万, 18=1600万, 19=1700万, 20=1800万, 21=1900万, 22=2000万, 23=2200万, 24=2400万, 25=2500万, 26=2700万, 27=3000万, 28=3200万, 29=3500万, 30=3800万, 31=3900万, 32=4000万, 33=4100万, 34=4200万, 35=4300万, 36=4500万, 37=4700万, 38=5000万, 39=5200万, 40=5400万, 41=5500万, 42=5800万, 43=6000万, 44=6400万, 45=6500万, 46=7000万, 47=7500万, 48=8000万, 49=8600万, 50=8900万, 51=9200万, 52=9400万, 53=9700万, 54=10000万, 55=10700万, 56=11200万, 57=12000万, 58=13000万, 59=13200万, 60=14000万, 61=15000万, 62=18000万, 63=25000万, 64=43000万</Description>
} RRaceData;


#if defined __GNUC__
#pragma pack(0)
#elif defined _MSC_VER
#pragma pack(pop)
#endif

#ifdef __csharp
} // namespace KOEI.WP7_2012.Datastruct
#endif
	
#endif // _DATASTRUCT_H__

