using System;
using System.Collections.Generic;
using System.Text;

namespace SpoilerLikeControls
{
	public class ListBoxItem
	{
		public String Text = String.Empty;
		public Object Tag  = null;

		public ListBoxItem()
		{}

		public ListBoxItem( String text, Object tag )
		{
			this.Text = text;
			this.Tag = tag;
		}

		public override string ToString()
		{
			return this.Text;
		}
	}
}
