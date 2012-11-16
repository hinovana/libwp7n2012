using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOEI.WP7_2012.Horse.Breeding.Combination
{
	/// <summary>
	/// インブリード管理クラス
	/// </summary>
	public class Inbreed
	{
		/// <summary>
		/// インブリードした血統番号
		/// </summary>
		public UInt32        BloodNum { get; private set; }

		/// <summary>
		/// インブリードした種牡馬側のノード
		/// </summary>
		public Pedigree.Node SireNode { get; private set; }

		/// <summary>
		/// インブリードした繁殖牝馬側のノード
		/// </summary>
		public Pedigree.Node MareNode { get; private set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="sireNode">種牡馬ノード</param>
		/// <param name="mareNode">繁殖牝馬ノード</param>
		/// <exception cref="ArgumentException">血統番号が不一致の場合発生する例外</exception>
		public Inbreed( Pedigree.Node sireNode, Pedigree.Node mareNode )
		{
			if( sireNode.BloodNum != mareNode.BloodNum ) {
				throw new ArgumentException("血統番号が不一致です");
			}
			this.BloodNum = sireNode.BloodNum;
			this.SireNode = sireNode;
			this.MareNode = mareNode;
		}
	}
}
