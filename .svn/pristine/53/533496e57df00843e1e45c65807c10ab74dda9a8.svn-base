using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KOEI.WP7_2012.Horse
{
	/// <summary>
	/// 血統図の木を作成するクラス
	/// </summary>
	public class BloodLineTree
	{
		/// <summary>
		/// ノードをループで回すときのコールバック関数
		/// </summary>
		/// <param name="blood_num">血統番号</param>
		/// <param name="obj"></param>
		/// <param name="node_level">ノードの深さ</param>
		/// <param name="is_last_brother">最後の兄弟ノードかどうか</param>
		/// <param name="is_last_child">最後の子ノードかどうか</param>
		/// <returns>ループを抜けるかどうか</returns>
		public delegate EachStatus EachCallback
		(
			UInt32 blood_num,
			Object obj,
			int node_level,
			Boolean is_last_brother,
			Boolean is_last_child
		);
		
		/// <summary>
		/// ノード
		/// </summary>
		public class BloodNode
		{
			public UInt32 blood_num;
			public BloodNode childNode;
			public BloodNode nextBrother;
		}
		
		/// <summary>
		/// 血統ラインタイプ
		/// </summary>
		public enum BloodLineType
		{
			SIRE,
			MARE,
		}
		
		/// <summary>
		/// ループの戻り値
		/// </summary>
		public enum EachStatus
		{
			NEXT,
			BREAK,
		}

		private KOEI.WP7_2012.WP7 wp_;
		private BloodNode tree_;
		private BloodLineType type_;
			
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="wp">対象のプロセスメモリ</param>
		/// <param name="type">血統ラインタイプ</param>
		/// <param name="blood_num">起点にする血統番号</param>
		public BloodLineTree( KOEI.WP7_2012.WP7 wp, BloodLineType type, UInt32 blood_num )
		{
			this.wp_ = wp;
			this.type_ = type;
			this.tree_  = new BloodNode() {
				blood_num   = blood_num,
				childNode   = null,
				nextBrother = null,
			};
			this.Tree.childNode = this.CreateChildNode( this.tree_ );
		}
		
		/// <summary>
		/// 構築した血統の木を取得する
		/// </summary>
		public BloodNode Tree {
			get {
				return this.tree_;
			}
		}

		/// <summary>
		/// 血統のノードを再帰で構築する
		/// </summary>
		/// <param name="tree">親ノード</param>
		/// <returns>子ノード</returns>
		private BloodNode CreateChildNode( BloodNode tree )
		{
			BloodNode childNode     = null;
			BloodNode prevChildNode = null;

			var data = new KOEI.WP7_2012.Datastruct.HBloodData();

			for( var i=0; i<this.wp_.HBloodTable.RecordCount; ++i ) {
				this.wp_.HBloodTable.GetData( (uint)i, ref data );
				if( data.mother_num == 0  ) {
					continue;
				}
				var num = this.type_ == BloodLineType.SIRE ? data.father_num : data.mother_num;
				if( num == tree.blood_num ) {
					var currentChildNode = new BloodNode() {
						blood_num   = (uint)i,
						nextBrother = prevChildNode,
					};
					currentChildNode.childNode = this.CreateChildNode( currentChildNode );
					prevChildNode = currentChildNode;
					childNode = currentChildNode;
				}
			}
			return childNode;
		}

		/// <summary>
		/// NodeEachをbreakする際の例外クラス
		/// </summary>
		private class EachBreakException : Exception
		{
			public EachBreakException()
			{}
			public EachBreakException( string message )
				: base(message) {}
			protected EachBreakException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
				: base( info, context ) {}
			public EachBreakException( string message, Exception innerException )
				: base( message, innerException ) {}
		}

		/// <summary>
		/// ノードをループで回す
		/// </summary>
		/// <param name="func"></param>
		/// <param name="obj"></param>
		public void NodeEach( EachCallback func, Object obj )
		{
			try {
				this.NodeEachSub( this.tree_, obj, func, 0 );
			} catch( EachBreakException ) {
				// pass
			}
		}
		
		private void NodeEachSub( BloodNode node, Object obj, EachCallback func, int indentLevel )
		{
			var currentNode = node;

			while( true ) {
				var is_last_child = currentNode.childNode == null;
				var is_last_brother = currentNode.nextBrother == null;

				if( func( currentNode.blood_num, obj, indentLevel, is_last_brother, is_last_child ) == EachStatus.BREAK ) {
					throw new EachBreakException();
				}
				
				// 子血統があるなら、再帰で子血統ノードを解析する
				if( currentNode.childNode != null ) {
					var childNode = currentNode.childNode;
					this.NodeEachSub( childNode, obj, func, indentLevel + 1 );
				}
				
				// もう兄弟ノードがないなら抜ける
				if( currentNode.nextBrother == null ) {
					break;
				}
				
				// 次の兄弟ノード
				currentNode = currentNode.nextBrother;
			}
		}
	}
}
