using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WP7_2012ULV.Setting
{
	[Serializable]
	public class ProgramSetting
	{	
		public Setting.MainFormSetting MainFormSetting;
		public String ExtensionDir;

		public KOEI.WP7_2012.ReadWriteMode Mode;
		public WPVersionConfig.Assembly VersionConfigAssembly;

		public UMAListView.Setting HorseChildSetting;
		public UMAListView.Setting HorseDamSetting;
		public UMAListView.Setting HorseRaceSetting;
		public UMAListView.Setting HorseSireSetting;

		public Breeding.ListViewSetting BreedingToSireSetting;
		public Breeding.ListViewSetting BreedingToDamSetting;

		public Enums.NameType DispNameType;

		/// <summary>
		/// 設定をファイルから読み込む
		/// </summary>
		/// <param name="file_name">設定ファイルパス</param>
		public static ProgramSetting LoadFromFile( String file_name )
		{
			ProgramSetting setting;

			var serializer = new System.Xml.Serialization.XmlSerializer( typeof(Setting.ProgramSetting) );

			using( var fs = new System.IO.FileStream( file_name, System.IO.FileMode.Open ) ) {
				setting = (Setting.ProgramSetting) serializer.Deserialize( fs );
			}

			if( setting.ExtensionDir == null || setting.ExtensionDir == "" ) {
				setting.ExtensionDir = Program.DEFAULT_EXTENSION_DIR;
			}
			return setting;
		}

		/// <summary>
		/// 設定をファイルに書き出す
		/// </summary>
		/// <param name="file_name">書きだしたい設定</param>
		/// <param name="file_name">設定ファイルパス</param>
		public static void SaveToFile( ProgramSetting setting, String file_name )
		{
			var serializer = new System.Xml.Serialization.XmlSerializer( typeof(ProgramSetting) );

			using( var fs = new System.IO.FileStream( file_name, System.IO.FileMode.Create ) ) {
				serializer.Serialize( fs, setting );
			}
		}

		/// <summary>
		/// デフォルトの設定を読み込む
		/// </summary>
		public static ProgramSetting DefaultSetting {
			get {
				return new ProgramSetting() {
					HorseChildSetting = new UMAListView.Setting(),
					HorseDamSetting = new UMAListView.Setting(),
					HorseRaceSetting = new UMAListView.Setting(),
					HorseSireSetting = new UMAListView.Setting(),
					BreedingToDamSetting = new WP7_2012ULV.Breeding.ListViewSetting(),
					BreedingToSireSetting = new WP7_2012ULV.Breeding.ListViewSetting(),
					ExtensionDir = Program.DEFAULT_EXTENSION_DIR,
					VersionConfigAssembly = new WPVersionConfig.Assembly(){
						AssemblyName = "KOEI.WP7_2012.Configuration",
						ClassName = "KOEI.WP7_2012.Configuration.V100",
						AssemblyString = "WP7 2012 1.0.0.0",
					},
					MainFormSetting = new Setting.MainFormSetting() {
						Top    = 100,
						Left   = 100,
						Width  = 1090,
						Height = 600,
					},
				};
			}
		}
	}
}
