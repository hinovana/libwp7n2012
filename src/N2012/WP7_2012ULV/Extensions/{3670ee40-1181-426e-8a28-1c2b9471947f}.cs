using System;
using System.Windows.Forms;
using System.Drawing;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Horse;
using KOEI.WP7_2012.Datastruct;

/// <summary>
/// 競走馬の母の牝系図を表示するWP7_2012ULV拡張スクリプト
/// </summary>
class WP7_2012ULV_Extension {
	private static bool is_cancel = false;
	
	public static HRaceData CommandMain( WP7 wp, UInt32 horse_num, HRaceData data ) {
		if( is_cancel == true ) {
			return data;
		}
		var dam_data = new HDamData();
		wp.HDamTable.GetData( data.mother_num, ref dam_data );
		
		var form = new DispBloodLineForm( wp, dam_data.blood_num );
		
		if( form.ShowDialog() == DialogResult.No ) {
			is_cancel = true;
		}
		return data;
	}
}

class DispBloodLineForm : Form
{
	private Button button_1;
	private Button button_2;
	private Panel panel_1;
	private TextBox textBox;
	private TreeView treeView;
	private LinkLabel linkLabel;

	private WP7 wp_;
	
	public DispBloodLineForm( WP7 wp, UInt32 blood_num )
	{
		this.wp_ = wp;
		this.Setup_Cotrols();

		var blood_data = new HBloodData();

		this.wp_.HBloodTable.GetData( blood_num, ref blood_data );
		this.Text = String.Format( "{0} の牝系図", get_name_by_data( ref blood_data ) );

		this.DispBloodLine( blood_num );
	}

	private void DispBloodLine( UInt32 blood_num )
	{
		var wp = this.wp_;
		var blood_data = new HBloodData();

		wp.HBloodTable.GetData( blood_num, ref blood_data );

		var current_blood_num = blood_num;
		var target_blood_num = current_blood_num;	

		while( true ) {
			wp.HBloodTable.GetData( target_blood_num, ref blood_data );
			if( blood_data.mother_num == wp.Config.NullBloodNumber ) {
				break;
			}
			target_blood_num = blood_data.mother_num;
		}
		var tree = new BloodLineTree( wp, BloodLineTree.BloodLineType.MARE, target_blood_num );

		var parentNode = new TreeNode(){
			Text = String.Format("{0}", get_name_by_data( ref blood_data ) ),
			Tag = tree.Tree.blood_num,
		};

		if( tree.Tree.childNode == null ) {
			this.treeView.Nodes.Add( parentNode );
		} else {
			this.treeView.Nodes.Add( create_tree_node( parentNode, current_blood_num, tree.Tree.childNode, 0 ) );
		}
		this.treeView.ExpandAll();
		
		this.linkLabel.Click += ( obj, ev )=> {
			if( tree.Tree.childNode == null ) {
				Clipboard.SetText( String.Format( "{0}", get_name_by_data( ref blood_data ) ) );
			} else {
				Clipboard.SetText( String.Format( "{0}\r\n{1}",
					get_name_by_data( ref blood_data ),
					create_tree_text( target_blood_num, tree.Tree.childNode, 0 ) )
				);
			}
			MessageBox.Show( "クリップボードにコピーしました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information );
		};
	}
	
	private string indent( int level )
	{
		var str = "";

		for( var i=0; i<level; ++i ) {
			str += "|    ";
		}
		return str;
	}
	
	private string get_name_by_data( ref HBloodData data )
	{
		var wp = this.wp_;
		var name = "";

		var obj = wp.HNameTable[ (int)data.name_left ];
		name = obj != null ? obj.Kana : String.Format ("(不明{0})", data.name_left );

		if( data.name_right != wp.Config.NullNameNumber ) {
			obj = wp.HNameTable[ (int)data.name_right ];
			name += obj != null ? obj.Kana : String.Format ("(不明{0})", data.name_right );
		}
		return name;
	}
	
	private string create_tree_text( UInt32 current_blood_num, BloodLineTree.BloodNode tree, int level )
	{
		var wp = this.wp_;
		var blood_data = new HBloodData();
		var node = tree;

		using( var sw = new System.IO.StringWriter() ) {
			while( true ) {
				wp.HBloodTable.GetData( node.blood_num, ref blood_data );
				var mark = current_blood_num == node.blood_num ? "※" : "";
				sw.Write( String.Format("{0}|- {1}{2}\r\n", indent(level), mark, get_name_by_data( ref blood_data )  ) );

				if( node.childNode != null ) {
					sw.Write( create_tree_text( current_blood_num, node.childNode, level+1 ) );
				}

				if( node.nextBrother == null ) {
					break;
				}
				node = node.nextBrother;
			}
			return sw.ToString();
		}
	}
	
	private TreeNode create_tree_node( TreeNode treeNode, UInt32 current_blood_num, BloodLineTree.BloodNode tree, int level )
	{
		var wp = this.wp_;
		var blood_data = new HBloodData();
		var bloodNode = tree;

		while( true ) {
			wp.HBloodTable.GetData( bloodNode.blood_num, ref blood_data );
			var newNode = new TreeNode(){
				Text = get_name_by_data( ref blood_data ),
				Tag = bloodNode.blood_num,
				ForeColor = current_blood_num == bloodNode.blood_num ? Color.Red : Color.Black,
			};

			if( bloodNode.childNode == null ) {
				treeNode.Nodes.Add( newNode );
			} else {
				treeNode.Nodes.Add( create_tree_node( newNode, current_blood_num, bloodNode.childNode, level+1 ) );
			}
			if( bloodNode.nextBrother == null ) {
				break;
			}
			bloodNode = bloodNode.nextBrother;
		}
		return treeNode;
	}
	
	private void Setup_Cotrols()
	{
		this.Size = new Size( 700, 800 );
		this.Font = new Font( "メイリオ", 10f, FontStyle.Regular );

		this.treeView = new TreeView() {
			Dock = DockStyle.Fill,
			Font = new Font( "メイリオ", 10f, FontStyle.Regular ),
			PathSeparator = " ⇒ ",
		};

		this.treeView.NodeMouseClick += ( obj, e )=> {
			this.textBox.Text = e.Node.FullPath;
		};

		this.button_2 = new Button() {
			Size = new Size( 120, 28 ),
			Location = new Point( 5, 5 ),
			Text = "これで終わる",
		};

		this.button_1 = new Button() {
			Size = new Size( 120, 28 ),
			Location = new Point( 130, 5 ),
			Text = "次を表示",
		};
	
		this.linkLabel = new LinkLabel() {
			Text = "クリップボードにコピー",
			Location = new Point( 255, 10 ),
			AutoSize = true,
		};

		this.button_1.Click += ( obj, ev )=> {
			this.DialogResult = DialogResult.Yes;
		};
		
		this.button_2.Click += ( obj, ev )=> {
			this.DialogResult = DialogResult.No;
		};
		
		this.panel_1 = new Panel() {
			Size = new Size( 80, 70 ),
			Dock = DockStyle.Top,
		};
		
		this.textBox = new TextBox() {
			Width = this.Width,
			Location = new Point( 0, 50 ),
			Dock = DockStyle.Bottom,
		};
	
		this.panel_1.Controls.AddRange( new Control[]{
			this.textBox,
			this.button_1,
			this.button_2,
			this.linkLabel,
		});
		
		this.Controls.AddRange( new Control[]{
			this.treeView,
			this.panel_1,
		});
		
		this.Shown += ( obj, ev )=> {
			this.Left = 100;
			this.Top = 100;
		};
	}
}


