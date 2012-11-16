using System;
using System.Collections.Generic;

namespace KOEI.WP7.M2008.MemoryTable
{
	/// <summary>
	/// プロセスメモリ上のデータテーブル(配列)を管理するクラス
	/// </summary>
	public class ProcessMemoryTable : IDisposable
	{
		/// <summary>
		/// 対象のプロセスメモリ
		/// </summary>
		protected KOEI.WP7.M2008.Helper.ProcessMemory pm_;

		/// <summary>
		/// データテーブル
		/// </summary>
		protected System.IO.MemoryStream table_;

		/// <summary>
		/// データテーブルへのポインタアドレス
		/// </summary>
		protected UInt32 pointer_address_;

		/// <summary>
		/// レコードサイズ
		/// </summary>
		protected UInt32 record_size_;

		/// <summary>
		/// レコード数
		/// </summary>
		protected UInt32 record_length_;


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pm">対象のプロセスメモリ</param>
		/// <param name="config">プロセスメモリ上のデータテーブル(配列)の構造情報</param>
		public ProcessMemoryTable( KOEI.WP7.M2008.Helper.ProcessMemory pm, ProcessMemoryTableConfiguration config )
		{
			this.pm_ = pm;

			this.pointer_address_ = config.PointerAddress;
			this.record_size_ = config.RecordSize;
			this.record_length_ = config.RecordMaxLength;

			this.table_ = new System.IO.MemoryStream( this.ReadMemory() );
		}

		/// <summary>
		/// デストラクタ
		/// </summary>
		~ProcessMemoryTable()
		{
			this.Dispose();
		}

		/// <summary>
		/// オブジェクトの破棄、すべてのリソースを解放します
		/// </summary>
		public void Dispose()
		{
			if( this.table_ != null  ) {
				this.table_.Close();
				this.table_ = null;
			}
		}

		/// <summary>
		/// レコード数
		/// </summary>
		public UInt32 RecordCount {
			get {
				return this.record_length_;
			}
		}

		/// <summary>
		/// プロセスメモリからメモリ読み取る
		/// </summary>
		/// <returns>読み取ったメモリ</returns>
		protected byte[] ReadMemory()
		{
			var table_size = this.record_size_ * this.record_length_;
			var table_address = BitConverter.ToUInt32( this.pm_.ReadMemory( this.pointer_address_, 4 ), 0 );

			return this.pm_.ReadMemory( table_address, table_size );
		}

		/// <summary>
		/// プロセスメモリにメモリを書き込む
		/// </summary>
		protected void WriteMemory()
		{
			var table_size = this.record_size_ * this.record_length_;
			var table_address = BitConverter.ToUInt32( this.pm_.ReadMemory( this.pointer_address_, 4 ), 0 );

			this.pm_.WriteMemory( table_address, this.table_.ToArray() );
		}

		/// <summary>
		/// レコードをforeachで回すイテレータ
		/// </summary>
		/// <returns></returns>
		public IEnumerator< byte[] > GetEnumerator()
		{
			for( var i=0; i<this.record_length_; ++i ) {
				yield return this.Read( (UInt32)i );
			}
		}

		/// <summary>
		/// データテーブルをプロセスメモリに書き込む
		/// </summary>
		public void Commit()
		{
			this.WriteMemory();
		}


		/// <summary>
		/// データテーブルにレコードを書き込む
		/// Commitメソッドを呼び出すまではプロセスメモリには反映されません
		/// </summary>
		/// <param name="n">レコード番号</param>
		/// <param name="record">レコード</param>
		public void Write( UInt32 n, UInt32[] record )
		{
			var ms = new System.IO.MemoryStream();
			foreach( var u in record ) {
				ms.Write( BitConverter.GetBytes( u ), 0, 4 );
			}
			this.Write( n, ms.ToArray() );
		}


		/// <summary>
		/// データテーブルにレコードを書き込む
		/// Commitメソッドを呼び出すまではプロセスメモリには反映されません
		/// </summary>
		/// <param name="n">レコード番号</param>
		/// <param name="record">レコード</param>
		public void Write( UInt32 n, byte[] record )
		{
			if( record.Length != this.record_size_ ) {
				throw new ArgumentException(
					String.Format("配列の長さが要求と違う({0} for {1})", record.Length, this.record_size_ )
				);
			}
			this.table_.Seek( this.record_size_ * n, System.IO.SeekOrigin.Begin );
			this.table_.Write( record, 0, (int)this.record_size_ );
		}

		/// <summary>
		/// データテーブルからレコードを読み取る
		/// </summary>
		/// <param name="n">レコード番号</param>
		/// <returns>レコード</returns>
		public byte[] Read( UInt32 n )
		{
			var buff = new byte[ this.record_size_ ];
			this.table_.Seek( this.record_size_ * n, System.IO.SeekOrigin.Begin );
			this.table_.Read( buff, 0, (int)this.record_size_ );
			return buff;
		}

		/// <summary>
		/// データテーブルからレコードを読み書きする
		/// </summary>
		/// <param name="n">レコード番号</param>
		/// <returns>レコード</returns>
		public byte[] this[ UInt32 n ] {
			get {
				return this.Read( n );
			}
			set {
				this.Write( n, value );
			}
		}

		/// <summary>
		/// データテーブルからレコード読み取って構造体にキャストして返す
		/// </summary>
		/// <typeparam name="T">キャストする構造体の型</typeparam>
		/// <param name="n">レコード番号</param>
		/// <param name="record">レコード(構造体なので戻り値にすると多分遅い)</param>
		public void GetDatastruct<T>( int n, ref T record )
			where T: DatastructInterface, new()
		{
			this.GetDatastruct<T>( (UInt32)n, ref record );
		}
		

		/// <summary>
		/// データテーブルからレコードを読み書きする
		/// </summary>
		/// <param name="n">レコード番号</param>
		/// <param name="record">レコード(構造体なので戻り値にすると多分遅い)</param>
		public void GetDatastruct<T>( UInt32 n, ref T record )
			where T: DatastructInterface, new()
		{
			var data = this.Read( n );
			var ary = new UInt32[ data.Length / 4 ];
			for( var i=0; i<ary.Length; ++i ) {
				ary[i] = BitConverter.ToUInt32( data, i * 4 );
			}
			//record = new T();
			record.Encode( ary );
		}
	}
}
