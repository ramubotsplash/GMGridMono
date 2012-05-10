using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace GMGridTest
{
	public partial class MainViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		UIPopoverController flipsidePopoverController;
		
		public MainViewController ()
			: base (UserInterfaceIdiomIsPhone ? "MainViewController_iPhone" : "MainViewController_iPad" , null)
		{
			// Custom initialization
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			
			LoadGrid ();
			//LoadUITable();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			AddGrid();
			//AddUITable();
			//AddImage();
		}
		
		#region Grid Funtions
		const int spacing = 10;
		GMGridView.GMGridView g;
		public void AddGrid ()
		{
			RectangleF bounds = View.Bounds;
			//bounds.Width = bounds.Width/2;
			bounds.Height= bounds.Height/2;
			
			g = new GMGridView.GMGridView(bounds);
			//g.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			//g.BackgroundColor = UIColor.Clear;
			
			//g.Style = GMGridView.GMGridViewStyle.GMGridViewStyleSwap;
			//g.ItemSpacing = spacing;
			//g.MinEdgeInsets = new UIEdgeInsets(spacing, spacing, spacing, spacing);
			//g.CenterGrid = true;

			View.AddSubview(g);
			g.MainSuperView = View;

			SlidesGridDataSource ds = new SlidesGridDataSource();
			g.DataSource = ds;
			g.ActionDelegate = new SlidesViewActionDelegate();
			g.SortingDelegate = new SlidesSortingDelegate(ds);
			g.TransformDelegate = new SlidesTransformationDelegate();
		}

		void LoadGrid ()
		{
			g.ReloadData();
		}
		
		#endregion
		
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		partial void showInfo (NSObject sender)
		{
			g.ReloadData();
		}
		
		#region Add sample image
		private void AddImage()
		{
			UIImage img;
			UIImageView imgView;
			
			img = UIImage.FromBundle("batman_surfing_on_superman.png");
			imgView = new UIImageView(img);
			imgView.BackgroundColor = UIColor.Clear;
			imgView.Bounds = new System.Drawing.RectangleF(0, 0,
			                                               UIScreen.MainScreen.Bounds.Width,
			                                               200);
			View.AddSubview(imgView);
		}
		#endregion

		#region Test a sample table
		UITableView tblView;
		public void AddUITable ()
		{
			RectangleF bounds = View.Bounds;
			bounds.Width = bounds.Width;
			bounds.Height= bounds.Height/2;
			tblView = new UITableView(bounds);
			View.AddSubview(tblView);
			
			//tblView.Source = new TestTableViewSource();
			tblView.DataSource = new TestTableDataSource();
		}

		public void LoadUITable ()
		{
			tblView.ReloadData();
		}
		#endregion
	}
}

