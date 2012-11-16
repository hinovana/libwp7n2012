using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KOEI.WP7_2012.Datastruct;

namespace KOEI.WP7_2012.Horse.Breeding.Combination
{
	/// <summary>
	/// 配合結果を管理するクラス
	/// </summary>
	public class Combination
	{
		/// <summary>
		/// 成立したニックスのリスト
		/// </summary>
		public Enums.ニックス[]     ニックス             = new KOEI.WP7_2012.Horse.Breeding.Enums.ニックス[0];

		/// <summary>
		/// 成立したインブリードのリスト
		/// </summary>
		public Inbreed[]            インブリード         = new Inbreed[0];

		/// <summary>
		/// アウトブリードかどうか
		/// </summary>
		public Boolean              アウトブリード       { get { return this.インブリード.Length == 0; } }

		/// <summary>
		/// 成立したラインブリード
		/// </summary>
		public Enums.ラインブリード ラインブリード       = KOEI.WP7_2012.Horse.Breeding.Enums.ラインブリード.無し;

		/// <summary>
		/// 成立した血脈活性化配合
		/// </summary>
		public Enums.血脈活性化配合 血脈活性化配合       = KOEI.WP7_2012.Horse.Breeding.Enums.血脈活性化配合.無し;

		/// <summary>
		/// 成立したSP昇華配合
		/// </summary>
		public Enums.昇華配合       SP昇華配合           = KOEI.WP7_2012.Horse.Breeding.Enums.昇華配合.無し;

		/// <summary>
		/// 成立したST昇華配合
		/// </summary>
		public Enums.昇華配合       ST昇華配合           = KOEI.WP7_2012.Horse.Breeding.Enums.昇華配合.無し;

		/// <summary>
		/// SPST融合配合が成立したかどうか
		/// </summary>
		public Boolean              SPST融合配合         = false;

		/// <summary>
		/// 母父効果
		/// </summary>
		public Enums.母父効果       母父効果             = KOEI.WP7_2012.Horse.Breeding.Enums.母父効果.無し;

		/// <summary>
		/// 名種牡馬型活力補完の個数
		/// </summary>
		public UInt32               名種牡馬型活力補完   = 0;

		/// <summary>
		/// 名牝型活力補完の個数
		/// </summary>
		public UInt32               名牝型活力補完       = 0;

		/// <summary>
		/// 異系血脈型活力補完の個数
		/// </summary>
		public UInt32               異系血脈型活力補完   = 0;

		/// <summary>
		/// 完全型活力補完が成立したかどうか
		/// </summary>
		public Boolean              完全型活力補完       = false;

		/// <summary>
		/// 隔世遺伝した血統番号
		/// していない場合は WP7#ConfigrationInterface#NullBloodNumber
		/// </summary>
		public UInt32               隔世遺伝             = 25000;

		/// <summary>
		/// 成立したライン活性配合
		/// </summary>
		public Enums.ライン活性配合 ライン活性配合       = KOEI.WP7_2012.Horse.Breeding.Enums.ライン活性配合.無し;

		/// <summary>
		/// 成立した活力源化大種牡馬因子
		/// 血統番号のリスト
		/// </summary>
		public UInt32[]             活力源化大種牡馬因子 = new UInt32[0];

		/// <summary>
		/// 成立した活力源化名種牡馬因子
		/// 血統番号のリスト
		/// </summary>
		public UInt32[]             活力源化名種牡馬因子 = new UInt32[0];

		/// <summary>
		/// お笑い配合が成立したかどうか
		/// </summary>
		public Boolean お笑い配合                        = false;

		/// <summary>
		/// お似合い配合が成立したかどうか
		/// </summary>
		public Boolean お似合い配合                      = false;

		/// <summary>
		/// サヨナラ配合が成立したかどうか
		/// </summary>
		public Boolean サヨナラ配合                      = false;

		/// <summary>
		/// Wサヨナラ配合が成立したかどうか
		/// </summary>
		public Boolean Wサヨナラ配合                     = false;

		/// <summary>
		/// 稲妻配合が成立したかどうか
		/// </summary>
		public Boolean 稲妻配合                           = false;

		/// <summary>
		/// 真稲妻配合が成立したかどうか
		/// </summary>
		public Boolean 真稲妻配合                         = false;

		/// <summary>
		/// 疾風配合が成立したかどうか
		/// </summary>
		public Boolean 疾風配合                           = false;

		/// <summary>
		/// 真疾風配合が成立したかどうか
		/// </summary>
		public Boolean 真疾風配合                         = false;

		/// <summary>
		/// 3冠配合が成立したかどうか
		/// </summary>
		public Boolean 三冠配合                           = false;


		public class CombinationPointDetail
		{
			/// <summary></summary>
			public PointRiskPair ニックス = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair インブリード = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair ラインブリード = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 血脈活性化配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair SP昇華配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair ST昇華配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 母父効果 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair ライン活性配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair SPST融合配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 完全型活力補完 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair お笑い配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair お似合い配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair サヨナラ配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair Wサヨナラ配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 稲妻配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 真稲妻配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 疾風配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 真疾風配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 三冠配合 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 名種牡馬型活力補完 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 名牝型活力補完 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 異系血脈型活力補完 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 隔世遺伝 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 活力源化大種牡馬因子 = new PointRiskPair();
			/// <summary></summary>
			public PointRiskPair 活力源化名種牡馬因子 = new PointRiskPair();

			/// <summary>
			/// 爆発力を取得するアクセサ
			/// </summary>
			public UInt32 Point {
				get {
					var ary = new[] {
						ニックス, インブリード, ラインブリード, 血脈活性化配合, SP昇華配合, ST昇華配合, 
						母父効果, ライン活性配合, SPST融合配合, 完全型活力補完, お笑い配合, お似合い配合, 
						サヨナラ配合, Wサヨナラ配合, 稲妻配合, 真稲妻配合, 疾風配合, 真疾風配合, 三冠配合, 
						名種牡馬型活力補完, 名牝型活力補完, 異系血脈型活力補完, 隔世遺伝, 活力源化大種牡馬因子, 
						活力源化名種牡馬因子,
					};
					var point = 0u;
					foreach( var p in ary ) {
						point += p.Point;
					}
					return point;
				}
			}

			/// <summary>
			/// 危険度を取得するアクセサ
			/// </summary>
			public UInt32 Risk {
				get {
					var ary = new[] {
						ニックス, インブリード, ラインブリード, 血脈活性化配合, SP昇華配合, ST昇華配合, 
						母父効果, ライン活性配合, SPST融合配合, 完全型活力補完, お笑い配合, お似合い配合, 
						サヨナラ配合, Wサヨナラ配合, 稲妻配合, 真稲妻配合, 疾風配合, 真疾風配合, 三冠配合, 
						名種牡馬型活力補完, 名牝型活力補完, 異系血脈型活力補完, 隔世遺伝, 活力源化大種牡馬因子, 
						活力源化名種牡馬因子,
					};
					var risk = 0u;
					foreach( var p in ary ) {
						risk += p.Risk;
					}
					return risk;
				}
			}
		}

		/// <summary>
		/// 爆発力と危険度を計算する
		/// </summary>
		/// <param name="wp">WP7</param>
		/// <returns>爆発力と危険度</returns>
		public CombinationPointDetail GetPoint( WP7 wp )
		{
			var pointDetail = new CombinationPointDetail();

			var check_list_1 = new object[][]{
				new object[] {
					pointDetail.ラインブリード,
					(int) this.ラインブリード,
					new Dictionary< int, PointRiskPair >() {
						{ (int)Enums.ラインブリード.親系統4本爆発SP型, CombinationPointInfo.親系統ラインブリード4本爆発SP型 },
						{ (int)Enums.ラインブリード.親系統4本爆発型, CombinationPointInfo.親系統ラインブリード4本爆発型 },
						{ (int)Enums.ラインブリード.親系統3本爆発SP型, CombinationPointInfo.親系統ラインブリード3本爆発SP型 },
						{ (int)Enums.ラインブリード.親系統3本爆発型, CombinationPointInfo.親系統ラインブリード3本爆発型 },
						{ (int)Enums.ラインブリード.子系統SP型, CombinationPointInfo.子系統ラインブリードSP型 },
						{ (int)Enums.ラインブリード.子系統, CombinationPointInfo.子系統ラインブリード },
						{ (int)Enums.ラインブリード.親系統SP型, CombinationPointInfo.親系統ラインブリードSP型 },
						{ (int)Enums.ラインブリード.親系統, CombinationPointInfo.親系統ラインブリード },
					}
				},
				new object[] {
					pointDetail.血脈活性化配合,
					(int) this.血脈活性化配合,
					new Dictionary< int, PointRiskPair >() {
						{ (int)Enums.血脈活性化配合.六本型, CombinationPointInfo.血脈活性化配合6本型 },
						{ (int)Enums.血脈活性化配合.七本型, CombinationPointInfo.血脈活性化配合7本型 },
						{ (int)Enums.血脈活性化配合.八本型, CombinationPointInfo.血脈活性化配合8本型 },
					}
				},
				new object[] {
					pointDetail.SP昇華配合,
					(int) this.SP昇華配合,
					new Dictionary< int, PointRiskPair >() {
						{ (int)Enums.昇華配合.Lv1, CombinationPointInfo.SP昇華配合Lv1 },
						{ (int)Enums.昇華配合.Lv2, CombinationPointInfo.SP昇華配合Lv2 },
						{ (int)Enums.昇華配合.Lv3, CombinationPointInfo.SP昇華配合Lv3 },
					}
				},
				new object[] {
					pointDetail.ST昇華配合,
					(int) this.ST昇華配合, 
					new Dictionary< int, PointRiskPair >() {
						{ (int)Enums.昇華配合.Lv1, CombinationPointInfo.ST昇華配合Lv1 },
						{ (int)Enums.昇華配合.Lv2, CombinationPointInfo.ST昇華配合Lv2 },
						{ (int)Enums.昇華配合.Lv3, CombinationPointInfo.ST昇華配合Lv3 },
					}
				},
				new object[] {
					pointDetail.母父効果,
					(int) this.母父効果, 
					new Dictionary< int, PointRiskPair >() {
						{ (int)Enums.母父効果.小, CombinationPointInfo.母父O },
						{ (int)Enums.母父効果.大, CombinationPointInfo.母父OO }
					}
				},
				new object[] {
					pointDetail.ライン活性配合,
					(int) this.ライン活性配合, 
					new Dictionary< int, PointRiskPair >() {
						{ (int)Enums.ライン活性配合.メールライン活性配合Lv1, CombinationPointInfo.メールライン活性配合Lv1 },
						{ (int)Enums.ライン活性配合.メールライン活性配合Lv2, CombinationPointInfo.メールライン活性配合Lv2 },
						{ (int)Enums.ライン活性配合.メールライン活性配合Lv3, CombinationPointInfo.メールライン活性配合Lv3 },
						{ (int)Enums.ライン活性配合.ボトムライン活性配合Lv1, CombinationPointInfo.ボトムライン活性配合Lv1 },
						{ (int)Enums.ライン活性配合.ボトムライン活性配合Lv2, CombinationPointInfo.ボトムライン活性配合Lv2 },
						{ (int)Enums.ライン活性配合.ボトムライン活性配合Lv3, CombinationPointInfo.ボトムライン活性配合Lv3 },
					}
				},
			};

			foreach( var check in check_list_1 ) {
				var detail = (PointRiskPair) check[0];
				var val = (int) check[1];
				var dict = (Dictionary< int, PointRiskPair >) check[2];
				if( dict.ContainsKey(val) ) {
					detail.Point = dict[val].Point;
					detail.Risk = dict[val].Risk;
				}
			}

			var check_list_2 = new object[][] {
				new object[] { pointDetail.SPST融合配合, this.SPST融合配合, CombinationPointInfo.SPST融合配合 },
				new object[] { pointDetail.完全型活力補完, this.完全型活力補完, CombinationPointInfo.完全型活力補完 },
				new object[] { pointDetail.お笑い配合, this.お笑い配合, CombinationPointInfo.お笑い配合 },
				new object[] { pointDetail.お似合い配合, this.お似合い配合, CombinationPointInfo.お似合い配合 },
				new object[] { pointDetail.サヨナラ配合, this.サヨナラ配合, CombinationPointInfo.サヨナラ配合 },
				new object[] { pointDetail.Wサヨナラ配合, this.Wサヨナラ配合, CombinationPointInfo.Wサヨナラ配合 },
				new object[] { pointDetail.稲妻配合, this.稲妻配合, CombinationPointInfo.稲妻配合 },
				new object[] { pointDetail.真稲妻配合, this.真稲妻配合, CombinationPointInfo.真稲妻配合 },
				new object[] { pointDetail.疾風配合, this.疾風配合, CombinationPointInfo.疾風配合 },
				new object[] { pointDetail.真疾風配合, this.真疾風配合, CombinationPointInfo.真疾風配合 },
				new object[] { pointDetail.三冠配合, this.三冠配合, CombinationPointInfo.三冠配合 },
			};
			
			foreach( var check in check_list_2 ) {
				var detail = (PointRiskPair) check[0];
				var val = (Boolean) check[1];
				var point = (PointRiskPair) check[2];
				if( val == true ) {
					detail.Point = point.Point;
					detail.Risk = point.Risk;
				}
			}

			foreach( var nicks in this.ニックス ) {
				var point = new PointRiskPair( 0, 0 );
				switch( nicks ) {
				case Enums.ニックス.シングルニックス:
					point = CombinationPointInfo.シングルニックス;
					break;
				case Enums.ニックス.ダブルニックス:
					point = CombinationPointInfo.ダブルニックス;
					break;
				case Enums.ニックス.トリプルニックス:
					point = CombinationPointInfo.トリプルニックス;
					break;
				case Enums.ニックス.フォースニックス:
					point = CombinationPointInfo.フォースニックス;
					break;
				case Enums.ニックス.二次ニックス:
					point = CombinationPointInfo.二次ニックス;
					break;
				case Enums.ニックス.三次ニックス:
					point = CombinationPointInfo.三次ニックス;
					break;
				case Enums.ニックス.四次ニックス:
					point = CombinationPointInfo.四次ニックス;
					break;
				}
				pointDetail.ニックス.Point += point.Point;
				pointDetail.ニックス.Risk += point.Risk;
			}

			foreach( var inbreed in this.インブリード ) {
				if( inbreed.SireNode.Data.factor_left == 0 ) {
					pointDetail.インブリード.Point += CombinationPointInfo.インブリードSP因子.Point;
				}
				if( inbreed.SireNode.Data.factor_right == 0 ) {
					pointDetail.インブリード.Point += CombinationPointInfo.インブリードSP因子.Point;
				}
				var delph = new PointRiskPair( inbreed.SireNode.NodeLevel, inbreed.MareNode.NodeLevel );
				pointDetail.インブリード.Risk += CombinationPointInfo.インブリード危険度[ delph ];
			}

			var check_list_3 = new object[][] {
				new object[] { pointDetail.名種牡馬型活力補完, this.名種牡馬型活力補完 , CombinationPointInfo.名種牡馬型活力補完 },
				new object[] { pointDetail.名牝型活力補完, this.名牝型活力補完     , CombinationPointInfo.名牝型活力補完     },
				new object[] { pointDetail.異系血脈型活力補完, this.異系血脈型活力補完 , CombinationPointInfo.異系血脈型活力補完 },
			};
			foreach( var check in check_list_3 ) {
				var detail = (PointRiskPair) check[0];
				var count = (uint) check[1];
				var point = (PointRiskPair) check[2];
				detail.Point = count * point.Point;
				detail.Point = count * point.Risk;
			}


			if( this.隔世遺伝 != wp.Config.NullBloodNumber ) {
				var blood = new HBloodData();
				wp.HBloodTable.GetData( this.隔世遺伝, ref blood );
				if( blood.factor_left == 0 ) {
					pointDetail.隔世遺伝.Point += CombinationPointInfo.隔世遺伝SP因子.Point;
					pointDetail.隔世遺伝.Risk += CombinationPointInfo.隔世遺伝SP因子.Risk;
				}
				if( blood.factor_right == 0 ) {
					pointDetail.隔世遺伝.Point += CombinationPointInfo.隔世遺伝SP因子.Point;
					pointDetail.隔世遺伝.Risk += CombinationPointInfo.隔世遺伝SP因子.Risk;
				}
			}

			var check_list_4 = new object[][] {
				new object[] { pointDetail.活力源化大種牡馬因子, this.活力源化大種牡馬因子, CombinationPointInfo.活力源化大種牡馬因子 },
				new object[] { pointDetail.活力源化名種牡馬因子, this.活力源化名種牡馬因子, CombinationPointInfo.活力源化名種牡馬因子 },
			};
			foreach( var check in check_list_4 ) {
				var detail = (PointRiskPair) check[0];
				var blood_num_list = (UInt32[]) check[1];
				var point = (PointRiskPair) check[2];
				var plus = point.Point * (uint)blood_num_list.Length;
				if( !this.アウトブリード ) {
					plus = plus / 2;
				}
				detail.Point = plus;
				detail.Risk = point.Risk;
			}
			return pointDetail;
		}
	}
}
