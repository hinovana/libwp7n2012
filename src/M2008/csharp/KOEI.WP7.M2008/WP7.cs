using System;

namespace KOEI.WP7.M2008
{
	/// <summary>
	/// ウイニングポスト7のプロセスメモリを管理するクラス
	/// </summary>
	public class WP7 :IDisposable
	{
		private String process_name_;

		private KOEI.WP7.M2008.Helper.ProcessMemory pm_;

		private KOEI.WP7.M2008.MemoryTable.HorseNameTable name_table_;
		private KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable h_abl_table_;
		private KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable h_blood_table_;
		private KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable h_family_line_table_;
		private KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable h_race_table_;
		private KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable h_sire_table_;
		private KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable h_dam_table_;
		private KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable h_child_table_;

		private KOEI.WP7.M2008.ConfigurationInterface config_;


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="process_name">ウイニングポスト7のプロセス名</param>
		/// <param name="config">プロセスメモリのメモリアドレスなどの設定</param>
		public WP7( String process_name, ConfigurationInterface config )
		{
			this.process_name_ = process_name;
			this.config_ = config;
			this.Transaction();
		}

		/// <summary>
		/// オブジェクトを破棄します
		/// </summary>
		public void Dispose()
		{
			if( this.pm_ != null ) {
				this.pm_.Dispose();
				this.pm_ = null;
			}
		}

		/// <summary>
		/// プロセスメモリのメモリアドレスなどの設定
		/// </summary>
		public ConfigurationInterface Config {
			get {
				return this.config_;
			}
		}

		/// <summary>
		/// トランザクションを開始します
		/// </summary>
		private void Transaction()
		{
			this.pm_ = new KOEI.WP7.M2008.Helper.ProcessMemory( this.process_name_ );

			this.name_table_ = new KOEI.WP7.M2008.MemoryTable.HorseNameTable(
				this.pm_,
				this.config_.HorseNameSystemTable,
				this.config_.HorseNameUserTable
			);

			this.h_abl_table_ = new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseAbilityTable
			);
			this.h_family_line_table_ = new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseFamilyLineTable
			);
			this.h_blood_table_ = new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseBloodTable
			);
			this.h_race_table_ = new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseRaceTable
			);
			this.h_sire_table_ = new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseSireTable
			);
			this.h_dam_table_ = new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseDamTable
			);
			this.h_child_table_ = new KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable(
				this.pm_,
				this.config_.HorseChildTable
			);
		}

		/// <summary>
		/// 馬名情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.HorseNameTable HNameTable {
			get {
				return this.name_table_;
			}
		}
	
		/// <summary>
		/// 馬能力情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable HAblTable {
			get {
				return this.h_abl_table_;
			}
		}
	
		/// <summary>
		/// 血統情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable HBloodTable {
			get {
				return this.h_blood_table_;
			}
		}
	
		/// <summary>
		/// 系統情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable HFamilyLineTable {
			get {
				return this.h_family_line_table_;
			}
		}
	
		/// <summary>
		/// 現役競走馬情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable HRaceTable {
			get {
				return this.h_race_table_;
			}
		}
	
		/// <summary>
		/// 種牡馬情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable HSireTable {
			get {
				return this.h_sire_table_;
			}
		}
	
		/// <summary>
		/// 繁殖牝馬情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable HDamTable {
			get {
				return this.h_dam_table_;
			}
		}

		/// <summary>
		/// 幼駒情報テーブル
		/// </summary>
		public KOEI.WP7.M2008.MemoryTable.ProcessMemoryTable HChildTable {
			get {
				return this.h_child_table_;
			}
		}
	
	}
}
