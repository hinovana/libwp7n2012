using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WP7_2012ULV.Setting
{
	[Serializable]
	public class ExtensionSetting
	{
		[Serializable]
		public class Setting
		{
			public ExtensionSetting.Command[] HorseRaceExtensions;
			public ExtensionSetting.Command[] HorseChildExtensions;
			public ExtensionSetting.Command[] HorseDamExtensions;
			public ExtensionSetting.Command[] HorseSireExtensions;

			/// <summary>
			/// 拡張機能設定をファイルから読み込む
			/// </summary>
			public static ExtensionSetting.Setting LoadFromFile( String file_name )
			{
				ExtensionSetting.Setting setting;

				var serializer = new System.Xml.Serialization.XmlSerializer( typeof(ExtensionSetting.Setting) );

				using( var fs = new System.IO.FileStream( file_name, System.IO.FileMode.Open ) ) {
					setting = (ExtensionSetting.Setting) serializer.Deserialize( fs );
				}
				return setting;
			}

			/// <summary>
			/// デフォルトの拡張機能設定を取得する
			/// </summary>
			public static ExtensionSetting.Setting DefaultExtensionSetting {
				get {
					return new ExtensionSetting.Setting() {
						HorseChildExtensions = new ExtensionSetting.Command[0],
						HorseDamExtensions   = new ExtensionSetting.Command[0],
						HorseRaceExtensions  = new ExtensionSetting.Command[0],
						HorseSireExtensions  = new ExtensionSetting.Command[0],			
					};
				}
			}

		}

		[Serializable]
		public class Command
		{
			public String Guid;
			public String Title;
			public String Description;
			public int Index;
			public MenuType Type;
			public String[] RequireDLLs;
			public Manifest Manifest = new Manifest();
		}

		[Serializable]
		public class Manifest
		{
			public KOEI.WP7_2012.ReadWriteMode Mode;
		}

		[Serializable]
		public enum MenuType : int
		{
			BUTTON,
			SEPARATOR,
		}
	}
}
