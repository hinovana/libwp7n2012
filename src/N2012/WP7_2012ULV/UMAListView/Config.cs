using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KOEI.WP7_2012.Horse;

namespace WP7_2012ULV.UMAListView
{
	public class Config
	{
		public UInt32[] TargetHorseNum = new UInt32[0];
		public Boolean Age_0         = true;
		public Boolean Age_1         = true;
		public Boolean Age_2         = true;
		public Boolean Age_3         = true;
		public Boolean Age_ETC       = true;
		public Boolean OwnerHorse    = true;
		public Boolean ClubHorse     = true;
		public Boolean SaleHorse     = true;
		public Boolean WatchHorse    = false;
		public Boolean CurrentHorse  = false;
		public Boolean Country_JAPAN = true;
		public Boolean Country_USA   = true;
		public Boolean Country_EURO  = true;
		public Boolean Status_Intai  = true;
		public Boolean Status_Geneki = true;
		public Area    BreedingArea  = Area.日本;
		public UInt32  MaxRisk       = 0;

		public Enums.NameType DispNameType = WP7_2012ULV.Enums.NameType.KANA;
	}
}
