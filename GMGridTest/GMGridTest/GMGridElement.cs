using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using GMGridView;
using System.Drawing;

namespace GMGridTest
{
	public partial class GMGridElement : UIViewElement, IElementSizing
	{
		public SlidesGridView gv;
		
		public GMGridElement (string caption) : base (caption, new UIView(), false)
		{
			gv = new SlidesGridView(new RectangleF(0,0,UIScreen.MainScreen.Bounds.Width, 200));
			gv.Setup();
			View.AddSubview(gv);
		}
		
		
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = base.GetCell (tv);
			gv.Bounds = new System.Drawing.RectangleF(
				cell.Bounds.Location.X,
				cell.Bounds.Location.Y,
			    UIScreen.MainScreen.Bounds.Width,
			    GetHeight(null, null));
			return cell;
		}
		
		#region IElementSizing implementation
		public float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return 400;
		}
		#endregion
	}
}
