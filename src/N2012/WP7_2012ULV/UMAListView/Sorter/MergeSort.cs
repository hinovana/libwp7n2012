using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WP7_2012ULV.UMAListView.Sorter
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

	class MergeSort
	{
		/// <summary>
		/// マージソート → 挿入ソートに切り替える配列長の閾値。
		/// </summary>
		private const int THREASHOLD = 64;

		/// <summary>
		/// マージソート。
		/// </summary>
		/// <param name="a">対象の配列</param>
		public static void Sort( ListViewItem[] ary, int column, ComparerMode mode, SortOrder order )
		{
			var work = new ListViewItem[ ary.Length / 2 ];
			Sort( ary, column, mode, order, 0, ary.Length, work );		
		}

		/// <summary>
		/// スワップ関数
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="a">A</param>
		/// <param name="b">B</param>
		private static void Swap( ref ListViewItem a, ref ListViewItem b )
		{
			var temp = a;
			a = b;
			b = temp;
		}

		/// <summary>
		/// 挿入ソート。
		/// 配列のどこからどこまでをソートするかを指定するバージョン。
		/// </summary>
		/// <param name="a">対象の配列</param>
		/// <param name="first">ソート対象の先頭インデックス</param>
		/// <param name="last">ソート対象の末尾インデックス</param>
		private static void InsertSort( ListViewItem[] ary, int column, ComparerMode mode, SortOrder order, int first, int last )
		{

			for( int i = first + 1; i <= last; i++ ) {
				for (int j = i; j > first && Compare( ary[j-1], ary[j], column, mode, order ) > 0; --j) {
					Swap( ref ary[j], ref ary[j - 1] );
				}
			}
		}

		/// <summary>
		/// マージソート。
		/// 配列のどこからどこまでをソートするかを指定するバージョン。
		/// </summary>
		/// <param name="ary">対象の配列</param>
		/// <param name="begin">ソート対象部分の先頭</param>
		/// <param name="end">ソート対象部分の末尾＋1</param>
		/// <param name="work">作業領域。a の 1/2 のサイズが必要。</param>
		private static void Sort( ListViewItem[] ary, int column, ComparerMode mode, SortOrder order, int begin, int end, ListViewItem[] work )
		{
			if (end - begin < THREASHOLD) {
				InsertSort( ary, column, mode, order, begin, end - 1 );
				return;
			}

			int mid = (begin + end) / 2;

			Sort( ary, column, mode, order, begin, mid, work );
			Sort( ary, column, mode, order, mid, end, work );
			Merge( ary, column, mode, order, begin, mid, end, work);
		}

		private static int Compare( ListViewItem a, ListViewItem b, int column, ComparerMode mode, SortOrder order )
		{
			var result = 0;
			
			var item_a = a;
			var item_b = b;

			// aとbを比較する
			switch( mode )
			{
			case ComparerMode.STRING:
				result = String.Compare( item_a.SubItems[column].Text, item_b.SubItems[column].Text );
				break;
			case ComparerMode.NUMERIC:
				result = Int32.Parse( item_a.SubItems[column].Text) - Int32.Parse(item_b.SubItems[column].Text );
				break;
			case ComparerMode.TAG_DATETIME:
				result = DateTime.Compare( DateTime.Parse(item_a.SubItems[column].Text ), DateTime.Parse(item_b.SubItems[column].Text ) );
				break;
			case ComparerMode.TAG_HEXADECIMAL:
				result = Int32.Parse( item_a.SubItems[column].Text, System.Globalization.NumberStyles.HexNumber );
				break;
			case ComparerMode.TAG_NUMERIC:
				result = (int)item_a.SubItems[column].Tag - (int)item_b.SubItems[column].Tag;
				break;
			case ComparerMode.TAG_STRING:
				result = String.Compare( (string)item_a.SubItems[column].Tag, (string)item_b.SubItems[column].Tag );
				break;
			}

			if( order == SortOrder.Descending ) {
				result = -result;
			} else if ( order == SortOrder.None ) {
				result = 0;
			}
			return result;
		}


		/// <summary>
		/// 配列 a の、[begin, mid) の部分と [mid, end) の部分をマージ。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="a">マージ対象の配列</param>
		/// <param name="begin1">aの先頭</param>
		/// <param name="mid">aの分割点</param>
		/// <param name="end">aの末尾＋1</param>
		/// <param name="work">作業領域</param>
		private static void Merge( ListViewItem[] ary, int column, ComparerMode mode, SortOrder order, int begin, int mid, int end, ListViewItem[] work )
		{
			int i, j, k;

			for (i = begin, j = 0; i != mid; ++i, ++j)
				work[j] = ary[i];

			mid -= begin;

			for (j = 0, k = begin; i != end && j != mid; ++k) {
				if( Compare( ary[i], work[j], column, mode, order ) < 0 ) {
					ary[k] = ary[i];
					++i;
				} else {
					ary[k] = work[j];
					++j;
				}
			}

			for (; i < end; ++i, ++k) {
				ary[k] = ary[i];
			}

			for (; j < mid; ++j, ++k) {
				ary[k] = work[j];
			}
		}
	}
}
