using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace WP7_2012ULV
{
	static class Program
	{
		/// <summary>
		/// デフォルトの拡張機能ディレクトリへのパス
		/// </summary>
		public const String DEFAULT_EXTENSION_DIR = @"Extensions";

		/// <summary>
		/// 拡張機能の設定ファイル名
		/// </summary>
		public const String EXTENSIONS_SETTING_FILE_NAME = "Extensions.xml";

		/// <summary>
		/// WEBサイトのURL
		/// </summary>
		public const String WEBSITE_URL = "http://code.google.com/p/libwp7n2012/";

		/// <summary>
		/// バージョンを取得する
		/// </summary>
		/// <returns>アセンブリ名</returns>
		public static Version AssemblyVersion {
			get {
				var asm = System.Reflection.Assembly.GetExecutingAssembly();
				return asm.GetName().Version;
			}
		}

		/// <summary>
		/// アセンブリ名を取得する
		/// </summary>
		/// <returns>アセンブリ名</returns>
		public static String AssemblyName {
			get {
				var asm = System.Reflection.Assembly.GetExecutingAssembly();
				return asm.GetName().Name;
			}
		}

		/// <summary>
		/// 設定ファイル名を取得する
		/// </summary>
		public static String SettingFileName {
			get {
				return String.Format( "{0}\\{1}.{2}",
					System.Environment.CurrentDirectory, Program.AssemblyName, "setting.xml" );
			}
		}

		/// <summary>
		/// 設定ファイル名を取得する
		/// </summary>
		public static String VersionSettingFileName {
			get {
				return String.Format( "{0}\\{1}",
					System.Environment.CurrentDirectory, "Version.xml" );
			}
		}

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
