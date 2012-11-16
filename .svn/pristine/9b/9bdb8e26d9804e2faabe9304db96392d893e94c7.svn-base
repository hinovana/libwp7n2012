using System;

namespace KOEI.WP7.M2008
{
	/// <summary>
	/// プロセスメモリ上のアドレスや定数を管理するクラス
	/// </summary>
	public interface ConfigurationInterface
	{
		/// <summary>
		/// プロセス名
		/// </summary>
		String ProcessName { get; }

		/// <summary>
		/// 空の血統を示す番号
		/// </summary>
		UInt32 NullBloodNumber { get; }

		/// <summary>
		/// 空の名前を示す番号
		/// </summary>
		UInt32 NullNameNumber { get; }

		/// <summary>
		/// ユーザ定義馬名の開始番号
		/// </summary>
		UInt32 UserNameTableStartNumber { get; }

		/// <summary>
		/// 空の能力を示す番号
		/// </summary>
		UInt32 NullAbilityNumber { get; }

		/// <summary>
		/// プロセスメモリ上の馬名(既定)テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.HorseNameTableConfiguration HorseNameSystemTable { get; }

		/// <summary>
		/// プロセスメモリ上の馬名(ユーザ定義)テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.HorseNameTableConfiguration HorseNameUserTable { get; }

		/// <summary>
		/// プロセスメモリ上の馬能力テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseAbilityTable { get; }

		/// <summary>
		/// プロセスメモリ上の血統テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseBloodTable { get; }

		/// <summary>
		/// プロセスメモリ上の系統テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseFamilyLineTable { get; }

		/// <summary>
		/// プロセスメモリ上の種牡馬テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseSireTable { get; }

		/// <summary>
		/// プロセスメモリ上の繁殖牝馬テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseDamTable { get; }

		/// <summary>
		/// プロセスメモリ上の現役馬テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseRaceTable { get; }

		/// <summary>
		/// プロセスメモリ上の幼駒テーブルの情報
		/// </summary>
		KOEI.WP7.M2008.MemoryTable.ProcessMemoryTableConfiguration HorseChildTable { get; }
	}
}
