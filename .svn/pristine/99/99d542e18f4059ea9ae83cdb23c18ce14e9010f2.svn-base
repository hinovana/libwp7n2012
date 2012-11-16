/* libwp7n2012 -- Winning Post 7 2012 Cheat Library

   Copyright (C) 2012 AIPON of author

   This library is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 2.1 of the License, or (at your option) any later version.

   This library is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with this library; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

   Written by AIPON */

using System;

namespace KOEI.WP7_2012
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
		/// 1年の週の数
		/// </summary>
		UInt32 YearWeekLength { get; }

		/// <summary>
		/// 月の週数(1月は0、12月は11)
		/// </summary>
		UInt32[] MonthWeekLen { get; }

		/// <summary>
		/// 空きの系統を示す番号
		/// </summary>
		UInt32 NullFamilyLineNumber { get; }

		/// <summary>
		/// 空の血統を示す番号
		/// </summary>
		UInt32 NullBloodNumber { get; }

		/// <summary>
		/// 無視すべき血統番号
		/// </summary>
		UInt32 IgnoreBloodNumber { get; }

		/// <summary>
		/// 空の名前を示す番号
		/// </summary>
		UInt32 NullNameNumber { get; }

		/// <summary>
		/// 架空馬を示す史実番号
		/// </summary>
		UInt32 NullShizitsuNumber { get; }

		/// <summary>
		/// ユーザ定義馬名の開始番号
		/// </summary>
		UInt32 UserNameTableStartNumber { get; }

		/// <summary>
		/// 空の能力を示す番号
		/// </summary>
		UInt32 NullAbilityNumber { get; }

		/// <summary>
		/// 空きを示す所有競走馬の番号
		/// </summary>
		UInt32 NullOwnershipRaceHorseNumber { get; }

		/// <summary>
		/// 空きを示す種牡馬番号
		/// </summary>
		UInt32 NullSireNumber { get; }


		/// <summary>
		/// 現在の週番号を返す
		/// </summary>
		UInt32 CurrentWeekAddress { get; }
	
		/// <summary>
		/// レース開催表の空のデータを表すレース番号
		/// </summary>
		UInt32 NullRaceProgramNumber { get; }

		/// <summary>
		/// 表示中のキャラクタ番号へのアドレス
		/// </summary>
		UInt32 CurrentCharacterPointerAddress { get; }

		/// <summary>
		/// プロセスメモリ上の馬名(既定)テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration HorseNameSystemTable { get; }

		/// <summary>
		/// プロセスメモリ上の馬名(ユーザ定義)テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.HorseNameTableConfiguration HorseNameUserTable { get; }

		/// <summary>
		/// プロセスメモリ上の馬能力テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseAbilityTable { get; }

		/// <summary>
		/// プロセスメモリ上の血統テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseBloodTable { get; }

		/// <summary>
		/// プロセスメモリ上の系統テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseFamilyLineTable { get; }

		/// <summary>
		/// プロセスメモリ上の種牡馬テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseSireTable { get; }

		/// <summary>
		/// プロセスメモリ上の繁殖牝馬テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseDamTable { get; }

		/// <summary>
		/// プロセスメモリ上の現役馬テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseRaceTable { get; }

		/// <summary>
		/// プロセスメモリ上の幼駒テーブルの情報
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseChildTable { get; }
	
		/// <summary>
		/// 所有競走馬テーブル
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseOwnershipRaceTable { get; }
	
		/// <summary>
		/// 所有幼駒テーブル
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseOwnershipChildTable { get; }

		/// <summary>
		/// 史実名テーブル
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration HorseShizitsuNameTable { get; }

		/// <summary>
		/// レースデータテーブル
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration RaceDataTable { get; }

		/// <summary>
		/// レース名テーブル
		/// </summary>
		KOEI.WP7_2012.MemoryTable.RaceNameTableConfiguration RaceNameTable { get; }

		/// <summary>
		/// レース開催表テーブル
		/// </summary>
		KOEI.WP7_2012.MemoryTable.ProcessMemoryTableConfiguration RaceProgramTable { get; }
	}
}
