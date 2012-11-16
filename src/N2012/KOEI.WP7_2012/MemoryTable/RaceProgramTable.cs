using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOEI.WP7_2012.MemoryTable
{
	public class RaceProgramTable : ProcessMemoryTable
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pm">対象のプロセスメモリ</param>
		/// <param name="config">プロセスメモリ上のデータテーブル(配列)の構造情報</param>
		public RaceProgramTable( KOEI.WP7_2012.Helper.ProcessMemory pm, ProcessMemoryTableConfiguration config )
			: base( pm, config ) {}


		/// <summary>
		/// データテーブルからレコードを読み書きする
		/// </summary>
		/// <param name="n">レコード番号</param>
		/// <returns>レコード</returns>
		public new UInt16[] this[ UInt32 n ] {
			get {
				var data = this.Read( n );
				var len = data.Length / sizeof(UInt16);
				var result = new UInt16[len];
				for( int i=0, j=0; i<data.Length; i+=2, ++j ) {
					result[j] = BitConverter.ToUInt16( data, i );
				}
				return result;
			}
		}
	}
}
