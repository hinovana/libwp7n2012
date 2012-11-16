using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WP7_2012ULV.Setting
{
	[Serializable]
	public class WPVersionConfig
	{
		public Assembly[] VersionConfigList;

		[Serializable]
		public class Assembly
		{
			public String AssemblyName;
			public String ClassName;
			public String AssemblyString;
		}

		/// <summary>
		/// 拡張機能設定をファイルから読み込む
		/// </summary>
		public static WPVersionConfig LoadFromFile( String file_name )
		{
			WPVersionConfig setting;

			var serializer = new System.Xml.Serialization.XmlSerializer( typeof(WPVersionConfig) );

			using( var fs = new System.IO.FileStream( file_name, System.IO.FileMode.Open ) ) {
				setting = (WPVersionConfig) serializer.Deserialize( fs );
			}
			return setting;
		}

		/// <summary>
		/// デフォルトの拡張機能設定を取得する
		/// </summary>
		public static WPVersionConfig DefaultExtensionSetting {
			get {
				return new WPVersionConfig() {
					VersionConfigList = new WPVersionConfig.Assembly[0],
				};
			}
		}
	}
}
