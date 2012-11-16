/* coding: windows-31j */

#ifndef _LIBWP7M2008_H__
#define _LIBWP7M2008_H__

//#pragma comment( lib, "user32.lib" )

#pragma warning ( disable:4996 )
#pragma warning ( disable:4127 )

#include <windows.h>
#include <tlhelp32.h>
#include <assert.h>
#include <stdio.h>


#ifdef BUILDING_LIBWP7M2008_SHARED
#define WP7EXPORT __declspec(dllexport)
#define LIBWP7M2008EXPORT_INLINE __declspec(dllexport)
#elif USING_LIBWP7M2008_SHARED
#define WP7EXPORT __declspec(dllimport)
#define LIBWP7M2008EXPORT_INLINE
#else
#define WP7EXPORT
#define LIBWP7M2008EXPORT_INLINE
#endif  // BUILDING_LIBWP7M2008_SHARED


#define WP_PROCESS_NAME             "WP7M2008.EXE"


// 空データを示す血統番号
#define NULL_BLOOD_NUMBER           (25000)

// 空データを示す名前番号
#define NULL_NAME_NUMBER            (65535)


// 馬能力データへのアドレス
#define ABILITY_POINTER_ADDRESS     (0x00742070)

// 馬能力データのレコードサイズ
#define ABILITY_DATA_SIZE           (0x0000000C)

// 馬能力データの最大格納数
#define ABILITY_MAX                 (0x00007530)

/*
 * ウイニングポストの改造・ツール総合スレ Part7
 * http://yuzuru.2ch.net/test/read.cgi/game/1269438837/
 * 
 * 56 名前：名無しさんの野望[sage] 投稿日：2010/04/03(土) 23:17:16 ID:oK9hfcnk
 * WP7M2008の馬能力データ(スピードや毛色の情報) って最大何頭分用意されているか誰かご存じですか？
 * 
 * 57 名前：名無しさんの野望[sage] 投稿日：2010/04/04(日) 00:02:26 ID:zc9Po2mu
 * >>56
 * 25840頭分ありますよ。
 */
// 血統データへのアドレス
#define BLOOD_POINTER_ADDRESS        (0x0074205C)

// 血統データのレコードサイズ
#define BLOOD_DATA_SIZE              (0x0000000C)

// 血統データの最大格納数
#define BLOOD_MAX                    (0x000064F0)


// 系統データへのアドレス
#define FAMILY_LINE_POINTER_ADDRESS  (0x007427BC)

// 系統データのレコードサイズ
#define FAMILY_LINE_DATA_SIZE        (0x0000002C)

// 系統データの最大格納数
#define FAMILY_LINE_MAX              (0x00000096)


// 種牡馬データへのアドレス
#define HORSE_SIRE_POINTER_ADDRESS   (0x00745CE0)

// 種牡馬データのレコードサイズ
#define HORSE_SIRE_DATA_SIZE         (0x000000A4)

// 種牡馬データの最大格納数
#define HORSE_SIRE_MAX               (0x000007D0)


// 繁殖牝馬データへのアドレス
#define HORSE_DAM_POINTER_ADDRESS    (0x00743194)

// 繁殖牝馬データのレコードサイズ
#define HORSE_DAM_DATA_SIZE          (0x00000014)

// 繁殖牝馬データの最大格納数
#define HORSE_DAM_MAX                (0x00002710)


// 競走馬データへのアドレス
#define HORSE_RACE_POINTER_ADDRESS   (0x007429CC)

// 競走馬データのレコードサイズ
#define HORSE_RACE_DATA_SIZE         (0x00000038)

// 競走馬データの最大格納数
#define HORSE_RACE_MAX               (0x00001158)


// 110 名前：名無しさんの野望[sage] 投稿日：2010/04/14(水) 03:05:15 ID:jgC3Nsjp
// >>106
// 例えば、その馬名のデータの場合だと、
// 0x007479FCと0x00747A14に確保した領域のアドレスが入っていて、
// 0x00747A18に確保された領域のサイズが入っています。
// 大抵の場合、2個目のポインタの次(+4バイトの所)に
// 確保されている領域のサイズが入っていると思います。

// 馬名テーブルへのアドレス
#define HORSE_NAME_TABLE_POINTER_ADDRESS   (0x00747A14)

// 馬名テーブルの確保サイズのアドレス
#define HORSE_NAME_TABLE_SIZE_ADDRESS      (0x00747A18)

// 馬名テーブルのレコード数
#define HORSE_NAME_TABLE_SYSTEM_MAX        (14119)


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
	unsigned int father_num         : 15; // 父馬ポインタ
	unsigned int mother_num         : 15; // 母馬ポインタ
	unsigned int unknown_1          : 1;  // 
	unsigned int display            : 1;  // 馬名表示(0カナ,1英字)
	// data2
	unsigned int unknown_2          : 1;  // 
	unsigned int family_line        : 8;  // 子系統
	unsigned int unknown_3          : 15; // 
	unsigned int factor_left        : 4;  // 因子左
	unsigned int factor_right       : 4;  // 因子右
	// data3
	unsigned int name_left          : 16; // 馬名前半
	unsigned int name_right         : 16; // 馬名後半
} HBloodData;


// 系統データ
typedef struct HFamilyLineData {
	// data1
	unsigned int family_line        : 8;  // 親系統(自身を指せば親昇格)
	unsigned int attr_speed         : 1;  // スピード特性
	unsigned int attr_stamina       : 1;  // スタミナ特性
	unsigned int influence          : 1;  // 1で影響力強
	unsigned int bms_O              : 1;  // 母父○
	unsigned int unknown_1          : 1;  //
	unsigned int blood_num          : 15; // 血統ポインタ
	unsigned int unknown_2          : 4;  // 
	// data2
	unsigned int share_J            : 10; // 支配率(日本)
	unsigned int share_U            : 10; // 支配率(米国)
	unsigned int share_E            : 10; // 支配率(欧州)
	unsigned int unknown_3          : 2;  // 
	// data3
	unsigned int nicks_1_num        : 8;  // ニックス1系統
	unsigned int nicks_1_share      : 8;  // ニックス1繁栄度
	unsigned int nicks_2_num        : 8;  // ニックス2系統
	unsigned int nicks_2_share      : 8;  // ニックス2繁栄度
	// data4
	unsigned int nicks_3_num        : 8;  // ニックス3系統
	unsigned int nicks_3_share      : 8;  // ニックス3繁栄度
	unsigned int nicks_4_num        : 8;  // ニックス4系統
	unsigned int nicks_4_share      : 8;  // ニックス4繁栄度
	// data5
	unsigned int nicks_5_num        : 8;  // ニックス5系統
	unsigned int nicks_5_share      : 8;  // ニックス5繁栄度
	unsigned int nicks_6_num        : 8;  // ニックス6系統
	unsigned int nicks_6_share      : 8;  // ニックス6繁栄度
	// data6
	unsigned int nicks_7_num        : 8;  // ニックス7系統
	unsigned int nicks_7_share      : 8;  // ニックス7繁栄度
	unsigned int nicks_8_num        : 8;  // ニックス8系統
	unsigned int nicks_8_share      : 8;  // ニックス8繁栄度
	// data7
	unsigned int nicks_9_num        : 8;  // ニックス9系統
	unsigned int nicks_9_share      : 8;  // ニックス9繁栄度
	unsigned int nicks_10_num       : 8;  // ニックス10系統
	unsigned int nicks_10_share     : 8;  // ニックス10繁栄度
	// data8
	unsigned int name_1             : 8;  // 系統名1
	unsigned int name_2             : 8;  // 系統名2
	unsigned int name_3             : 8;  // 系統名3
	unsigned int name_4             : 8;  // 系統名4
	// data9
	unsigned int name_5             : 8;  // 系統名5
	unsigned int name_6             : 8;  // 系統名6
	unsigned int name_7             : 8;  // 系統名7
	unsigned int name_8             : 8;  // 系統名8
	// data10
	unsigned int name_9             : 8;  // 系統名9
	unsigned int name_10            : 8;  // 系統名10
	unsigned int name_11            : 8;  // 系統名11
	unsigned int name_12            : 8;  // 系統名12
	// data11
	unsigned int name_13            : 8;  // 系統名13
	unsigned int name_14            : 8;  // 系統名14
	unsigned int unknown_4          : 16; // 
} HFamilyLineData;


// 馬能力データ
typedef struct HAblData {
	// data1
	unsigned int speed              : 7; // スピード
	unsigned int stamina            : 7; // スタミナ
	unsigned int health             : 2; // 健康
	unsigned int kodashi            : 4; // 03_1　仔出し
	unsigned int taikou             : 2; // 体高+1 0低 1普 2高
	unsigned int power              : 2; // パワー
	unsigned int zyuunan            : 2; // 柔軟性
	unsigned int syunpatsu          : 2; // 瞬発力
	unsigned int konzyou            : 2; // 勝負根性
	unsigned int kashikosa          : 2; // 賢さ
	// data2
	unsigned int babatekisei        : 2; // 馬場適性
	unsigned int bokuzyou           : 8; // 繁養牧場
	unsigned int zenchou            : 2; // 全長
	unsigned int keiro              : 4; // 毛色
	unsigned int ryuusei            : 5; // 星・流星
	unsigned int seishin            : 2; // 精神力
	unsigned int seichougata        : 3; // 成長型
	unsigned int seichouryoku       : 2; // 成長力
	unsigned int kisyou             : 2; // 気性
	unsigned int unknown_1          : 1; // 08_8
	// data3
	unsigned int seisankoku         : 4; // 生産国
	unsigned int right_flont        : 2; // 右前足模様
	unsigned int left_flont         : 2; // 左前足模様
	unsigned int right_hind         : 2; // 右後足模様
	unsigned int left_hinde         : 2; // 左後足模様
	unsigned int senpou             : 3; // 脚質
	unsigned int komawari_X         : 1; // 小回り
	unsigned int tokusei_1          : 1; // 大舞台
	unsigned int tokusei_2          : 1; // ＧⅡ横綱
	unsigned int tokusei_3          : 1; // 交流重賞
	unsigned int tokusei_4          : 1; // ローカル
	unsigned int tokusei_5          : 1; // スタート
	unsigned int tokusei_6          : 1; // 超長距離
	unsigned int tokusei_7          : 1; // タフネス
	unsigned int tokusei_8          : 1; // 海外遠征
	unsigned int tokusei_9          : 1; // 男勝り
	unsigned int tokusei_10         : 1; // 夏馬
	unsigned int tokusei_11         : 1; // 軽ハンデ
	unsigned int tokusei_12         : 1; // 格上挑戦
	unsigned int tokusei_13         : 1; // 乾坤一擲
	unsigned int tokusei_14         : 1; // 大駆け
	unsigned int tokusei_15         : 1; // 鉄砲
	unsigned int tokusei_16         : 1; // 叩き良化
} HAblData;


// 繁殖牝馬データ
typedef struct HDamData {
	// data1
	unsigned int price              : 10; // 評価額
	unsigned int tanetsuke_sire     : 11; // 種付け種牡馬番号
	unsigned int unknown_1          : 7;  // 
	unsigned int fuda_color         : 3;  // 札
	unsigned int unknown_2          : 1;  //
	// data2
	unsigned int career_years       : 5;  // 繁殖年数
	unsigned int unknown_3          : 5;  //
	unsigned int career_count       : 4;  // 出産頭数
	unsigned int status             : 2;  // 受胎確認 0空胎 1受胎 2不受胎 3未確認
	unsigned int intai              : 1;  // 引退？
	unsigned int unknown_4          : 9;  // 
	unsigned int age                : 5;  // +2歳
	unsigned int unknown_5          : 1;  // 
	// data3
	unsigned int abl_num            : 15; // 能力番号
	unsigned int blood_num          : 15; // 血統番号
	unsigned int unknown_6          : 2;  // 
	// data4
	unsigned int kachikura          : 12; // 主な勝ち鞍
	unsigned int record_len         : 8;  // 競走成績 戦数
	unsigned int record_win         : 8;  // 競走成績 勝数
	unsigned int unknown_7          : 4;  // 
	// data10
	unsigned int unknown_8          : 32; // 
} HDamData;

// 種牡馬データ
typedef struct HSireData {
	// data1
	unsigned int win_grade_count    : 10; // 産駒重賞勝ち
	unsigned int win_g1_count       : 10; // 産駒G1勝ち
	unsigned int tanetsuke          : 7;  // 種付け料
	unsigned int unknown_1          : 5;  // 
	// data2                       
	unsigned int unknown_2          : 23; // 
	unsigned int syussou_count      : 8;  // 出走数
	unsigned int unknown_3          : 1;  //
	// data3                       
	unsigned int abl_num            : 15; // 能力番号
	unsigned int blood_num          : 15; // 血統番号
	unsigned int intai              : 2;  // 引退？
	// data4                       
	unsigned int syoukin            : 20; // 獲得賞金
	unsigned int age                : 6;  // 馬齢
	unsigned int unknown_4          : 6;  // 
	// data5                       
	unsigned int unknown_5          : 20; //
	unsigned int win_count          : 8;  // 勝利回数
	unsigned int unknown_6          : 4;  //
	// data6                       
	unsigned int unknown_7          : 28; // 
	unsigned int bookfull           : 1;  // BookFull
	unsigned int syndicate          : 1;  // シンジケート
	unsigned int unknown_8          : 2;  // 
	// data7                       
	unsigned int unknown_9          : 20; // 
	unsigned int tanetsuke_count    : 8;  // 種付け数
	unsigned int unknown_10         : 4;  // 
	// data8                       
	unsigned int unknown_11         : 32; // 
	// data9                       
	unsigned int kachikura_LT       : 12; // 主な勝ち鞍(左上)
	unsigned int kachikura_LB       : 12; // 主な勝ち鞍(左下)
	unsigned int unknown_12         : 8;  // 
	// data10                      
	unsigned int kachikura_RT       : 12; // 主な勝ち鞍(右上)
	unsigned int kachikura_RB       : 12; // 主な勝ち鞍(右下)
	unsigned int youku1_count       : 8;  // 1歳幼駒数
	// data11                      
	unsigned int daihyousan_w1      : 12; // 代表産駒主な勝ち鞍(1)
	unsigned int daihyousan_w2      : 12; // 代表産駒主な勝ち鞍(2)
	unsigned int geneki_count       : 8;  // 現役産駒数
	// data12                      
	unsigned int daihyousan_w3      : 12; // 代表産駒主な勝ち鞍(3)
	unsigned int daihyousan_w4      : 12; // 代表産駒主な勝ち鞍(4)
	unsigned int rank_5_ago         : 8;  // 5年前成績
	// data13                      
	unsigned int daihyousan_1       : 32; // 代表産駒1
	// data14                      
	unsigned int daihyousan_2       : 32; // 代表産駒2
	// data15                      
	unsigned int daihyousan_3       : 32; // 代表産駒3
	// data16                      
	unsigned int daihyousan_4       : 32; // 代表産駒4
	// data17                      
	unsigned int rank_1_ago         : 8;  // 1年前成績
	unsigned int rank_2_ago         : 8;  // 2年前成績
	unsigned int rank_3_ago         : 8;  // 3年前成績
	unsigned int rank_4_ago         : 8;  // 4年前成績
	// data18
	unsigned int unknown_13         : 32;
	// data19
	unsigned int unknown_14         : 32;
	// data20
	unsigned int unknown_15         : 32;
	// data21
	unsigned int unknown_16         : 32;
	// data22
	unsigned int unknown_17         : 32;
	// data23
	unsigned int unknown_18         : 32;
	// data24
	unsigned int unknown_19         : 32;
	// data25
	unsigned int unknown_20         : 32;
	// data26
	unsigned int unknown_21         : 32;
	// data27
	unsigned int unknown_22         : 32;
	// data28
	unsigned int unknown_23         : 32;
	// data29
	unsigned int unknown_24         : 32;
	// data30
	unsigned int unknown_25         : 32;
	// data31
	unsigned int unknown_26         : 32;
	// data32
	unsigned int unknown_27         : 32;
	// data33
	unsigned int unknown_28         : 32;
	// data34
	unsigned int unknown_29         : 32;
	// data35
	unsigned int unknown_30         : 32;
	// data36
	unsigned int unknown_31         : 32;
	// data37
	unsigned int unknown_32         : 32;
	// data38
	unsigned int unknown_33         : 32;
	// data39
	unsigned int unknown_34         : 32;
	// data40
	unsigned int unknown_35         : 32;
	// data41
	unsigned int unknown_36         : 32;
} HSireData;


// 競走馬データ
typedef struct HRaceData {
	// data1
	unsigned int mother_num         : 13; // 母
	unsigned int unknown_1          : 1;  // 
	unsigned int maruchihou         : 1;  // 地方馬フラグ
	unsigned int unknown_2          : 3;  // 
	unsigned int hirari_X           : 1;  // 左回り×
	unsigned int unknown_3          : 2;  // 
	unsigned int shusen_jk_num      : 9;  // 主戦騎手
	unsigned int unknown_4          : 1;  // 
	unsigned int gender             : 1;  // 性別
	// data2                        
	unsigned int houbokuchuu        : 4;  // 放牧中
	unsigned int unknown_5          : 2;  // 
	unsigned int kansen             : 1;  // 観戦
	unsigned int weight_best        : 7;  // 理想体重
	unsigned int weight_now         : 7;  // 馬体重
	unsigned int zyumyou            : 7;  // 競走寿命
	unsigned int age                : 3;  // 年齢 +2
	unsigned int unknown_6          : 1;  // 
	// data3
	unsigned int seichou            : 7;  // 成長度
	unsigned int keikenchi          : 7;  // 経験値
	unsigned int race_kan           : 7;  // レース勘
	unsigned int choushi            : 6;  // 調子
	unsigned int klass              : 3;  // クラス
	unsigned int unknonw_7          : 2;  // 
	// data4
	unsigned int hirou              : 7;  // 疲労度
	unsigned int houboku_len        : 6;  // 何週間放牧
	unsigned int father             : 10; // 父馬
	unsigned int unknown_8          : 9;  // 
	// data5
	unsigned int unknown_9          : 2;  //
	unsigned int intai              : 1;  // 引退
	unsigned int unknown_10         : 9;  // 
	unsigned int souhou             : 2;  // 走法 0普通 1ピッチ 2大飛び
	unsigned int weak_point_1       : 2;  // 脚部不安 0なし 1改善 2あり
	unsigned int weak_point_2       : 2;  // のどなり
	unsigned int weak_point_3       : 2;  // 腰甘
	unsigned int breeder            : 8;  // 生産者
	unsigned int seigen             : 4;  // 成長上限 +100
	// data6
	unsigned int price              : 14; // 売買額
	unsigned int abl_num            : 15; // 能力番号
	unsigned int torihiki           : 3;  // 取引形態
	// data7
	unsigned int earning_hon        : 20; // 本賞金
	unsigned int owner              : 12; // オーナー
	// data8
	unsigned int earning_all        : 20; // 総賞金
	unsigned int trainer            : 9;  // 調教師
	unsigned int unknown_11         : 1;  // 
	unsigned int nyuukyuu           : 1;  // 入厩済み
	unsigned int unknown_12         : 1;  // 
	// data9
	unsigned int sizitsu_num        : 13; // 史実番号
	unsigned int unknown_13         : 13; //
	unsigned int ensei              : 3;  // 遠征先 0,7他 1入厩前,放牧 2日本 3米国 4欧州 5ドバイ 6オセアニア
	unsigned int unknown_14         : 1;  // 
	unsigned int migimawari         : 1;  // 右回り苦手
	unsigned int senba              : 1;  // セン馬
	// data10
	unsigned int unknown_15         : 32; //
	// data11
	unsigned int name_left          : 16; // 馬名前半
	unsigned int name_right         : 16; // 馬名後半
	// data12
	unsigned int race_next_age      : 3;  // 次走年齢 +2
	unsigned int rase_next_location : 2;  // 開催地 0関東 1関西 2ローカル 3海外,地方
	unsigned int rase_next_sunday   : 1;  // 曜日 0土曜(米国,地方) 1日曜(欧州)
	unsigned int rase_next_num      : 4;  // レース番号
	unsigned int rase_next_week     : 6;  // 週番号
	unsigned int race_last_age      : 3;  // 前走年齢 +2
	unsigned int rase_last_location : 2;  // 開催地 0関東 1関西 2ローカル 3海外,地方
	unsigned int rase_last_sunday   : 1;  // 曜日 0土曜(米国,地方) 1日曜(欧州)
	unsigned int rase_last_num      : 4;  // レース番号
	unsigned int rase_last_week     : 6;  // 週番号
	// data13
	unsigned int career_shiba_1     : 8;  // 芝成績1着
	unsigned int career_shiba_2     : 8;  // 芝成績2着
	unsigned int career_shiba_3     : 8;  // 芝成績3着
	unsigned int career_shiba_4     : 8;  // 芝成績4着以下
	// data14
	unsigned int career_dirt_1      : 8;  // ダート成績1着
	unsigned int career_dirt_2      : 8;  // ダート成績2着
	unsigned int career_dirt_3      : 8;  // ダート成績3着
	unsigned int career_dirt_4      : 8;  // ダート成績4着以下
} HRaceData;

#if defined __GNUC__
#pragma pack(0)
#elif defined _MSC_VER
#pragma pack(pop)
#endif


typedef struct ProcessMemory {
	HANDLE handle;
	DWORD  processId;
} ProcessMemory;

typedef struct ProcessMemoryTable {
	ProcessMemory *ps;
	unsigned char *data;
	size_t data_size;
	DWORD pointer_address;
	DWORD record_size;
	DWORD record_length;
} ProcessMemoryTable;

typedef struct HNameData {
	DWORD id;
	char *kana;
	char *english;
} HNameData;

typedef enum HNAME_TYPE {
	HNAME_TYPE_SYSTEM = 1,
	HNAME_TYPE_KANMEI,
	HNAME_TYPE_USER,
	HNAME_TYPE_UNKNOWN,
} HNAME_TYPE;

typedef struct HNameTable {
	ProcessMemory *ps;
	HNameData system[ HORSE_NAME_TABLE_SYSTEM_MAX + 1 ];
} HNameTable;

typedef struct BNode {
	int value;
	void *data;
	struct BNode *left;
	struct BNode *right;
} BNode;

typedef struct WPEnvelope {
	ProcessMemory *ps;
	HNameTable *name_table;
	ProcessMemoryTable *sire_table;
	ProcessMemoryTable *abl_table;
	ProcessMemoryTable *blood_table;
	ProcessMemoryTable *family_line_table;
	ProcessMemoryTable *dam_table;
	ProcessMemoryTable *hrace_table;
} WPEnvelope;


#define XABORT(x) do { \
	fprintf( stderr, "ERROR -- %s\n", x ); \
	exit(1); \
} while(0)


#define BIT_ON(x,y)                do {x |=  (1<<y);}while(0)
#define BIT_OFF(x,y)               do {x &= ~(1<<y);}while(0)

void *xmalloc( size_t size );
void xfree( void *ptr );

// ----------------------------------------------------------------------------
// API
// ----------------------------------------------------------------------------
#ifdef __cplusplus
extern "C" {
#endif // __cplusplus

WP7EXPORT void WINAPI Setup_Envelope( WPEnvelope *env, char *wp7_process_name );
WP7EXPORT void WINAPI Dispose_Envelope( WPEnvelope *env );


// ProcessMemory Memory Class
WP7EXPORT ProcessMemory* WINAPI process_memory_new( DWORD processId );
WP7EXPORT void WINAPI process_memory_dispose( ProcessMemory *self );
WP7EXPORT BOOL WINAPI process_memory_read( ProcessMemory *self, DWORD address, DWORD size, void* buffer );
WP7EXPORT BOOL WINAPI process_memory_write( ProcessMemory *self, DWORD address, DWORD size, void* buffer );


// ProcessMemory Memory Table Class
WP7EXPORT ProcessMemoryTable* WINAPI process_memory_table_new( ProcessMemory *ps,
															   DWORD pointer_address,
															   DWORD record_size,
															   DWORD record_length );
WP7EXPORT void WINAPI process_memory_table_dispose( ProcessMemoryTable *self );
WP7EXPORT void* WINAPI process_memory_table_at( ProcessMemoryTable *self, DWORD num );
WP7EXPORT BOOL WINAPI process_memory_table_commit( ProcessMemoryTable *self );


// Famyly Line Data Class
WP7EXPORT int WINAPI hfamily_line_data_get_name( HFamilyLineData *self, char *buffer, size_t len );


// Binary Node Class
WP7EXPORT BNode* WINAPI bnode_new( int value, void *data );
WP7EXPORT void WINAPI bnode_insert( BNode *self, int value, void *data );
WP7EXPORT void* WINAPI bnode_find( BNode *self, int value );
WP7EXPORT void WINAPI bnode_dispose( BNode *self, void (WINAPI *free_func)(void*) );


// Name Table Class
WP7EXPORT HNameTable* WINAPI hname_table_new( ProcessMemory *ps );
WP7EXPORT void WINAPI hname_table_dispose( HNameTable *self );
WP7EXPORT HNameData* WINAPI hname_table_at( HNameTable *self, DWORD n );


// Name Data Class
WP7EXPORT HNameData* WINAPI hname_data_new( int id, char *kana, char *english );
WP7EXPORT void WINAPI hname_data_dispose( HNameData *self );


WP7EXPORT int WINAPI koei_codes_to_array( int *koei_codes, size_t len, char *buffer, size_t buffer_len );


#ifdef __cplusplus
}
#endif // __cplusplus

#endif // _LIBWP7M2008_H__
