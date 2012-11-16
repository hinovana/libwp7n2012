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

namespace KOEI.WP7_2012.Horse.Name
{
	/// <summary>
	/// 馬名データの種類
	/// </summary>
	public enum NameDataType : int
	{
		/// <summary>
		/// システム定義馬名
		/// </summary>
		SYSTEM,

		/// <summary>
		/// ユーザ定義馬名
		/// </summary>
		USER,
	}

	/// <summary>
	/// 馬名データ(レコード)を管理するクラス
	/// </summary>
	public class NameData
	{
		/// <summary>
		/// 馬名ID
		/// </summary>
		public uint Id;

		/// <summary>
		/// 馬名データの種類
		/// </summary>
		public NameDataType Type;

		/// <summary>
		/// カナ名
		/// </summary>
		public String Kana;

		/// <summary>
		/// 英語名
		/// </summary>
		public String English;
	}
}
