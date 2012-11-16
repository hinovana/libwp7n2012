using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WP7_2012ULV.UMAListView
{
	public class ListViewItemComparer : IComparer
	{
		public enum ComparerMode
		{
			STRING,
			NUMERIC,
			TAG_HEXADECIMAL,
			TAG_DATETIME,
			TAG_NUMERIC,
			TAG_STRING,
		};

		private int _column;
		private SortOrder _order;
		private ComparerMode _mode;
		private ComparerMode[] _columnModes;


		/// <summary>
		/// 並び替えるListView列の番号
		/// </summary>
		public int Column
		{
			set {
				if( this._column == value ) {
					if( this._order == SortOrder.Ascending ) {
						this._order = SortOrder.Descending;
					} else if (_order == SortOrder.Descending) {
						this._order = SortOrder.Ascending;
					}
				}
				this._column = value;
			}
			get {
				return this._column;
			}
		}

		public SortOrder Order {
			set {
				this._order = value;
			}
			get {
				return this._order;
			}
		}
		public ComparerMode Mode {
			set {
				this._mode = value;
			}
			get {
				return this._mode;
			}
		}

		public ComparerMode[] ColumnModes {
			set {
				this._columnModes = value;
			}
		}

		/// <summary>
		/// ListViewItemComparerクラスのコンストラクタ
		/// </summary>
		/// <param name="col">並び替える列番号</param>
		/// <param name="ord">昇順か降順か</param>
		/// <param name="cmod">並び替えの方法</param>
		public ListViewItemComparer( int col, SortOrder ord, ComparerMode cmod )
		{
			this._column = col;
			this._order = ord;
			this._mode = cmod;
		}

		public ListViewItemComparer()
		{
			this._column = 0;
			this._order = SortOrder.Ascending;
			this._mode = ComparerMode.STRING;
		}

		//xがyより小さいときはマイナスの数、大きいときはプラスの数、
		//同じときは0を返す
		public int Compare( object a, object b )
		{
			var result = 0;
			
			// ListViewItemの取得
			var item_a = (ListViewItem) a;
			var item_b = (ListViewItem) b;

			// 並べ替えの方法を決定
			if( this._columnModes != null && _columnModes.Length > _column) {
				this._mode = this._columnModes[ this._column ];
			}

			// aとbを比較する
			switch( _mode )
			{
			case ComparerMode.STRING:
				result = String.Compare( item_a.SubItems[this._column].Text, item_b.SubItems[this._column].Text );
				break;
			case ComparerMode.NUMERIC:
				result = Int32.Parse( item_a.SubItems[this._column].Text) - Int32.Parse(item_b.SubItems[this._column].Text );
				break;
			case ComparerMode.TAG_DATETIME:
				result = DateTime.Compare( DateTime.Parse(item_a.SubItems[this._column].Text ), DateTime.Parse(item_b.SubItems[this._column].Text ) );
				break;
			case ComparerMode.TAG_HEXADECIMAL:
				result = Int32.Parse( item_a.SubItems[this._column].Text, System.Globalization.NumberStyles.HexNumber );
				break;
			case ComparerMode.TAG_NUMERIC:
				result = (int)item_a.SubItems[this._column].Tag - (int)item_b.SubItems[this._column].Tag;
				break;
			case ComparerMode.TAG_STRING:
				result = String.Compare( (string)item_a.SubItems[this._column].Tag, (string)item_b.SubItems[this._column].Tag );
				break;
			}

			if( this._order == SortOrder.Descending ) {
				result = -result;
			} else if ( this._order == SortOrder.None ) {
				result = 0;
			}
			return result;
		}
	}
}
