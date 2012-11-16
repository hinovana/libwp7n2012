using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;
using KOEI.WP7_2012.Horse.Breeding;
using KOEI.WP7_2012.Horse.Breeding.Enums;

namespace KOEI.WP7_2012.Horse
{
	/// <summary>
	/// 馬の血統管理クラス
	/// </summary>
	public class Pedigree
	{
		/// <summary>
		/// 血統ノード管理クラス
		/// </summary>
		public class Node
		{
			/// <summary>
			/// 血統タイプ 父系or母系
			/// </summary>
			public 血統タイプ    Type        { get; private set; }

			/// <summary>
			/// 0番から数えたノードの深さ
			/// </summary>
			public UInt32        NodeLevel   { get; private set; }

			/// <summary>
			/// 血統番号
			/// </summary>
			public UInt32        BloodNum    { get; private set; }

			/// <summary>
			/// 血統データ
			/// </summary>
			public HBloodData    Data        { get; private set; }

			/// <summary>
			/// ノードの位置を示す血統タイプの配列
			/// 母母父 => [ 血統タイプ.母系, 血統タイプ.母系, 血統タイプ.父系 ]
			/// 母父母 => [ 血統タイプ.母系, 血統タイプ.父系, 血統タイプ.母系 ]
			/// </summary>
			public 血統タイプ[]  Line        { get; private set; }

			/// <summary>
			/// 父馬の血統ノード
			/// </summary>
			public Node          Father      { get; set; }

			/// <summary>
			/// 母馬の血統ノード
			/// </summary>
			public Node          Mother      { get; set; }

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="wp">WP7</param>
			/// <param name="type">血統タイプ</param>
			/// <param name="nodeLevel">ノードレベル</param>
			/// <param name="bloodNum">血統番号</param>
			/// <param name="line">ノードの位置を示す血統タイプの配列</param>
			public Node( WP7 wp, 血統タイプ type, UInt32 nodeLevel, UInt32 bloodNum, 血統タイプ[] line )
				: this( wp, type, nodeLevel, bloodNum, line, null, null )
			{}

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="wp">WP7</param>
			/// <param name="type">血統タイプ</param>
			/// <param name="nodeLevel">ノードレベル</param>
			/// <param name="bloodNum">血統番号</param>
			/// <param name="line">ノードの位置を示す血統タイプの配列</param>
			/// <param name="fatherNode">父馬のノード</param>
			/// <param name="motherNode">母馬のノード</param>
			public Node( WP7 wp, 血統タイプ type, UInt32 nodeLevel, UInt32 bloodNum, 血統タイプ[] line, Node fatherNode, Node motherNode  )
			{
				this.Type = type;
				this.NodeLevel = nodeLevel;
				this.BloodNum = bloodNum;
				this.Line = line;

				this.Father = fatherNode;
				this.Mother = motherNode;

				var blood_data = new HBloodData();
				wp.HBloodTable.GetData( bloodNum, ref blood_data );

				this.Data = blood_data;
			}
		}
		
		/// <summary>
		/// 血統ノードと0番から数えたノードの深さのペア
		/// </summary>
		private class NodeLevelPair
		{
			/// <summary>
			/// 0番から数えたノードの深さ
			/// </summary>
			public UInt32 Level { get; set; }

			/// <summary>
			/// 血統ノード
			/// </summary>
			public Node   Node  { get; set; }

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="node_level">0番から数えたノードの深さ</param>
			/// <param name="node">血統ノード</param>
			public NodeLevelPair( UInt32 node_level, Node node )
			{
				this.Level = node_level;
				this.Node  = node;
			}
		}

		/// <summary>
		/// 血統ノードの最大深さ
		/// </summary>
		private readonly UInt32 NODE_MAX_LEVEL = 3;

		private WP7             wp;
		private NodeLevelPair[] NodeAndLevelList { get; set; }

		/// <summary>
		/// 馬番号
		/// </summary>
		public  UInt32          HorseNum         { get; private set; }

		/// <summary>
		/// 血統の血統タイプ
		/// </summary>
		public  血統タイプ      Type             { get; private set; }

		/// <summary>
		/// 血統番号
		/// </summary>
		public  UInt32          BloodNum         { get; private set; }

		/// <summary>
		/// 血統ツリー
		/// </summary>
		public  Node            Tree             { get; private set; }


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="wp">WP7</param>
		/// <param name="horseNum">馬番号</param>
		/// <param name="type">血統タイプ 父系or母系</param>
		public Pedigree( WP7 wp, UInt32 horseNum, 血統タイプ type )
		{
			this.wp = wp;
			this.Type = type;
			this.HorseNum = horseNum;

			switch( type ) {
			case 血統タイプ.父系:
				var sire_data = new HSireData();
				this.wp.HSireTable.GetData( this.HorseNum, ref sire_data );
				this.BloodNum = sire_data.blood_num;
				break;
			case 血統タイプ.母系:
				var dam_data = new HDamData();
				this.wp.HDamTable.GetData( this.HorseNum, ref dam_data );
				this.BloodNum = dam_data.blood_num;
				break;
			}
			this.Tree = new Node( wp, type, 0, this.BloodNum, new 血統タイプ[]{ type } );
			this.CreateTree( this.Tree );

			var list = new List< NodeLevelPair >();

			foreach( var node in this.NodeList() ) {
				list.Add( new NodeLevelPair( node.NodeLevel, node ) );
			}
			this.NodeAndLevelList = list.ToArray();
		}

		/// <summary>
		/// 血統ノードのリストを返すイテレータ
		/// </summary>
		/// <param name="level">血統ノードの深さ</param>
		/// <returns>血統ノード</returns>
		public IEnumerable<Node> NodeList( UInt32 level )
		{
			var query = from q in this.NodeAndLevelList
						where q.Level == level
						select q.Node;

			foreach( var node in query ) {
				yield return node;
			}
		}

		/// <summary>
		/// 血統ノードのリストを返すイテレータ
		/// </summary>
		/// <returns>血統ノード</returns>
		public IEnumerable<Node> NodeList()
		{
			yield return this.Tree;

			foreach( var node in this.NodeListSub( this.Tree ) ) {
				yield return node;
			}
		}

		private IEnumerable<Node> NodeListSub( Node node )
		{
			if( node != null ) {
				if( node.Father != null ) {
					yield return node.Father;
					foreach( var temp in this.NodeListSub( node.Father ) ) {
						yield return temp;
					}
				}
				if( node.Mother != null ) {
					yield return node.Mother;
					foreach( var temp in this.NodeListSub( node.Mother ) ) {
						yield return temp;
					}
				}
			}
		}

		private void CreateTree( Node node )
		{
			if( node.NodeLevel == this.NODE_MAX_LEVEL ) {
				return;
			}
			var node_data   = new HBloodData();
			this.wp.HBloodTable.GetData( node.BloodNum, ref node_data );

			var line = new List< 血統タイプ >();
			line.AddRange( node.Line );
			line.Add( 血統タイプ.父系 );

			node.Father = new Node( this.wp, 血統タイプ.父系, node.NodeLevel + 1, node_data.father_num, line.ToArray() );
			this.CreateTree( node.Father );

			line.Clear();
			line.AddRange( node.Line );
			line.Add( 血統タイプ.母系 );

			node.Mother = new Node( this.wp, 血統タイプ.母系, node.NodeLevel + 1, node_data.mother_num, line.ToArray() );
			this.CreateTree( node.Mother );
		}
	}
}
