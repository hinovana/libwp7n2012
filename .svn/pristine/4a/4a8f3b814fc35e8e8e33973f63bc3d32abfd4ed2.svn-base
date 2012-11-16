using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOEI.WP7_2012.Horse.Breeding
{
	/// <summary>
	/// 爆発力と危険をペアで管理するクラス
	/// 
	/// ToDo:
	///	  比較演算子のオーバーロードを付ける
	/// </summary>
	public class PointRiskPair
	{
		/// <summary>
		/// 爆発力
		/// </summary>
		public UInt32 Point { get; set; }

		/// <summary>
		/// 危険度
		/// </summary>
		public UInt32 Risk  { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="point">爆発力</param>
		/// <param name="risk">危険度</param>
		public PointRiskPair( UInt32 point, UInt32 risk )
		{
			this.Point = point;
			this.Risk = risk;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PointRiskPair()
			: this( 0, 0 )
		{}

		/// <summary>
		/// オブジェクトの比較
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals( object obj )
		{
			if( obj == null || this.GetType() != obj.GetType() ) {
				return false;
			}
			return (PointRiskPair)obj == this;
		}

		/// <summary>
		/// ハッシュコードの取得
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (int) ( ( this.Point << 16 ) + this.Risk );
		}

		/// <summary>
		/// == 演算子のオーバーロード
		/// </summary>
		/// <param name="a">左辺</param>
		/// <param name="b">右辺</param>
		/// <returns>比較すれば真</returns>
		public static bool operator ==( PointRiskPair a, PointRiskPair b )
		{
			return a.Point == b.Point && a.Risk == b.Risk;
		}

		/// <summary>
		/// != 演算子のオーバーロード
		/// </summary>
		/// <param name="a">左辺</param>
		/// <param name="b">右辺</param>
		/// <returns>一致しなければ真</returns>
		public static bool operator !=( PointRiskPair a, PointRiskPair b )
		{
			return !( a == b );
		}

	}
}
