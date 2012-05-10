using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace GMGridTest
{
	public partial class TestImageElement : UIViewElement, IElementSizing
	{
		UIImage img;
		UIImageView imgView;
		
		public TestImageElement (string caption) : base (caption, new UIView(), false)
		{
			//GMGridView.GMGridView gv = new GMGridView.GMGridView();
			//View.AddSubview(gv);
			img = UIImage.FromBundle("batman_surfing_on_superman.png");
			imgView = new UIImageView(img);
			imgView.BackgroundColor = UIColor.Clear;
			View.AddSubview(imgView);
		}
		
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = base.GetCell (tv);
			imgView.Bounds = new System.Drawing.RectangleF(0, 0,
			                                               UIScreen.MainScreen.Bounds.Width,
			                                               GetHeight(null, null));
			return cell;
		}
		
		#region IElementSizing implementation
		public float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return 200;
		}
		#endregion
	}
}
