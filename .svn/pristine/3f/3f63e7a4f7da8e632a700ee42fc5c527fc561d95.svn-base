using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOEI.WP7_2012.Horse.Breeding
{
	/// <summary>
	/// 配合理論ごとの爆発力と危険度の定義をしているクラス
	/// </summary>
	public class CombinationPointInfo
	{
		/// <summary></summary>
		public static readonly PointRiskPair シングルニックス                  = new PointRiskPair(  2,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair ダブルニックス                    = new PointRiskPair(  4,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair トリプルニックス                  = new PointRiskPair(  6,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair フォースニックス                  = new PointRiskPair(  8,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 二次ニックス                      = new PointRiskPair(  1,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 三次ニックス                      = new PointRiskPair(  1,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 四次ニックス                      = new PointRiskPair(  1,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 親系統ラインブリード4本爆発SP型   = new PointRiskPair( 13,  1 );
		/// <summary></summary>
		public static readonly PointRiskPair 親系統ラインブリード4本爆発型     = new PointRiskPair( 11,  1 );
		/// <summary></summary>
		public static readonly PointRiskPair 親系統ラインブリード3本爆発SP型   = new PointRiskPair(  9,  1 );
		/// <summary></summary>
		public static readonly PointRiskPair 親系統ラインブリード3本爆発型     = new PointRiskPair(  7,  1 );
		/// <summary></summary>
		public static readonly PointRiskPair 親系統ラインブリードSP型          = new PointRiskPair(  3,  1 );
		/// <summary></summary>
		public static readonly PointRiskPair 親系統ラインブリード              = new PointRiskPair(  2,  1 );
		/// <summary></summary>
		public static readonly PointRiskPair 子系統ラインブリードSP型          = new PointRiskPair(  5,  2 );
		/// <summary></summary>
		public static readonly PointRiskPair 子系統ラインブリード              = new PointRiskPair(  3,  2 );
		/// <summary></summary>
		public static readonly PointRiskPair 血脈活性化配合6本型               = new PointRiskPair(  4,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 血脈活性化配合7本型               = new PointRiskPair(  6,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 血脈活性化配合8本型               = new PointRiskPair(  8,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair SP昇華配合Lv1                     = new PointRiskPair(  1,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair SP昇華配合Lv2                     = new PointRiskPair(  3,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair SP昇華配合Lv3                     = new PointRiskPair(  5,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair ST昇華配合Lv1                     = new PointRiskPair(  1,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair ST昇華配合Lv2                     = new PointRiskPair(  2,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair ST昇華配合Lv3                     = new PointRiskPair(  3,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair SPST融合配合                      = new PointRiskPair(  5,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 母父OO                            = new PointRiskPair(  4,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 母父O                             = new PointRiskPair(  2,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 名種牡馬型活力補完                = new PointRiskPair(  0,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 名牝型活力補完                    = new PointRiskPair(  0,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 異系血脈型活力補完                = new PointRiskPair(  0,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 完全型活力補完                    = new PointRiskPair(  3,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair メールライン活性配合Lv1           = new PointRiskPair(  3,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair メールライン活性配合Lv2           = new PointRiskPair(  6,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair メールライン活性配合Lv3           = new PointRiskPair( 10,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair ボトムライン活性配合Lv1           = new PointRiskPair(  3,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair ボトムライン活性配合Lv2           = new PointRiskPair(  6,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair ボトムライン活性配合Lv3           = new PointRiskPair( 10,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 活力源化大種牡馬因子              = new PointRiskPair(  1,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 活力源化名種牡馬因子              = new PointRiskPair(  1,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair お笑い配合                        = new PointRiskPair(  5,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair お似合い配合                      = new PointRiskPair(  5,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair サヨナラ配合                      = new PointRiskPair(  5,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair Wサヨナラ配合                     = new PointRiskPair(  8,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 稲妻配合                          = new PointRiskPair(  6,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 真稲妻配合                        = new PointRiskPair( 12,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 疾風配合                          = new PointRiskPair(  6,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 真疾風配合                        = new PointRiskPair( 12,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 三冠配合                          = new PointRiskPair(  4,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair 隔世遺伝SP因子                    = new PointRiskPair(  3,  0 );
		/// <summary></summary>
		public static readonly PointRiskPair インブリードSP因子                = new PointRiskPair(  3,  0 );
		
		/// <summary></summary>
		public static readonly Dictionary< PointRiskPair, UInt32 > インブリード危険度 = new Dictionary< PointRiskPair, UInt32 >() {
			{ new PointRiskPair( 0, 0 ),  10 },
			{ new PointRiskPair( 0, 1 ),   9 },
			{ new PointRiskPair( 0, 2 ),   8 },
			{ new PointRiskPair( 0, 3 ),   7 },
			{ new PointRiskPair( 1, 0 ),   9 },
			{ new PointRiskPair( 1, 1 ),   6 },
			{ new PointRiskPair( 1, 2 ),   5 },
			{ new PointRiskPair( 1, 3 ),   4 },
			{ new PointRiskPair( 2, 1 ),   5 },
			{ new PointRiskPair( 2, 0 ),   8 },
			{ new PointRiskPair( 2, 2 ),   3 },
			{ new PointRiskPair( 2, 3 ),   2 },
			{ new PointRiskPair( 3, 0 ),   7 },
			{ new PointRiskPair( 3, 1 ),   4 },
			{ new PointRiskPair( 3, 2 ),   2 },
			{ new PointRiskPair( 3, 3 ),   1 },
		};
	}
}
