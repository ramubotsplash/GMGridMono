using System;
using System.Drawing;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace GMGridTest
{
	public class SlidesGridDataSource : GMGridView.GMGridViewDataSource
	{
		public SlidesGridDataSource(){
			Console.WriteLine("SlideDS");
		}
		
		public override int NumberOfItemsInGMGridView (GMGridView.GMGridView gridView)
		{
			Console.WriteLine("NumberOfItemsInGMGridView");
			return 30;
		}
		
		public override bool CanDeleteItemAtIndex (GMGridView.GMGridView gridView, int index)
		{
			Console.WriteLine("CanDeleteItemAtIndex");
			return false;
		}
		
		public override GMGridView.GMGridViewCell CellForItemAtIndex (GMGridView.GMGridView gridView, int index)
		{
			Console.WriteLine("{1:yyyy-MM-dd HH:mm:ss FFF} CellForItemAtIndex: {0}", index, DateTime.Now);
			SizeF size = this.SizeForItemsInInterfaceOrientation(gridView, UIApplication.SharedApplication.StatusBarOrientation);
			
			GMGridView.GMGridViewCell cell = gridView.DequeueReusableCell;
			if (cell == null)
			{
				cell = new GMGridView.GMGridViewCell();
				//cell.DeleteButtonIcon = UIImage.FromBundle("close_x.png");
				//cell.DeleteButtonOffset = new PointF(-15, -15);

				//UIView view = new UIView(new RectangleF(0, 0, size.Width, size.Height));
		        //view.BackgroundColor = UIColor.Blue;
		        //view.Layer.MasksToBounds = false;
				//view.Layer.CornerRadius = 8;
		        
		        //cell.ContentView = view;

			    //UIImageView testView = new UIImageView();
			    //testView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			    //testView.Frame = cell.ContentView.Bounds;
			    //testView.BackgroundColor = UIColor.Yellow;
			    //cell.ContentView.AddSubview(testView);

		    	UIImage testImg = UIImage.FromBundle(@"batman_surfing_on_superman.png");
			    UIImageView testView = new UIImageView(testImg);
				testView.ClipsToBounds = false;
			    //testView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			    //testView.Frame = new RectangleF(0, 0, size.Width, size.Height);
			   // testView.BackgroundColor = UIColor.Yellow;
				cell.ContentView = testView;
			}
		    
		    //cell.ContentView.Subviews.R .subviews] makeObjectsPerformSelector:@selector(removeFromSuperview)];
		    
		    //UIImage testImg = UIImage.FromBundle(@"batman_surfing_on_superman.png");
		    //((UIImageView)cell.ContentView.Subviews[0]).Image = testImg;
		    return cell;
		}
		
		public override System.Drawing.SizeF SizeForItemsInInterfaceOrientation (GMGridView.GMGridView gridView, UIInterfaceOrientation orientation)
		{
			SizeF size;
			//Console.WriteLine("SizeForItemsInInterfaceOrientation");
			if (MainViewController.UserInterfaceIdiomIsPhone) {
				if (orientation == UIInterfaceOrientation.LandscapeLeft || orientation == UIInterfaceOrientation.LandscapeRight)
		        {
		            size = new SizeF(170.0f, 135.0f);
		        }
		        else
		        {
		            size = new SizeF(140f, 110f);
		        }
		    }
		    else
		    {
				if (orientation == UIInterfaceOrientation.LandscapeLeft || orientation == UIInterfaceOrientation.LandscapeRight)
		        {
		            size = new SizeF(285.0f, 205.0f);
		        }
		        else
		        {
		            size = new SizeF(230.0f, 175.0f);
		        }
			}
			Console.WriteLine("Size: {0}; {1}", size.Width, size.Height);
			return size;
		}
	}

	public class SlidesViewActionDelegate : GMGridView.GMGridViewActionDelegate
	{
		#region implemented abstract members of GMGridView.GMGridViewActionDelegate
		public override void DidTapOnItemAtIndex (GMGridView.GMGridView gridView, int position)
		{
			Console.WriteLine("DidTapOnItemAtIndex");
		}

		public override void DidTapOnEmptySpace (GMGridView.GMGridView gridView)
		{
			Console.WriteLine("DidTapOnEmptySpace");
		}

		public override void ProcessDeleteActionForItemAtIndex (GMGridView.GMGridView gridView, int index)
		{
			Console.WriteLine("ProcessDeleteActionForItemAtIndex");
		}
		#endregion
	}
	
	public class SlidesSortingDelegate : GMGridView.GMGridViewSortingDelegate
	{
		public SlidesGridDataSource DS {
			get;
			set;
		}

		public SlidesSortingDelegate(SlidesGridDataSource ds) {
			DS = ds;
		}
		
		#region implemented abstract members of GMGridView.GMGridViewSortingDelegate
		public override void MoveItemAtIndex (GMGridView.GMGridView gridView, int oldIndex, int newIndex)
		{
			Console.WriteLine("MoveItemAtIndex");
		}

		public override void ExchangeItemAtIndex (GMGridView.GMGridView gridView, int index1, int index2)
		{
			Console.WriteLine("ExchangeItemAtIndex");
		}

		public override void DidStartMovingCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell cell)
		{
			Console.WriteLine("DidStartMovingCell");
		}

		public override void DidEndMovingCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell cell)
		{
			Console.WriteLine("DidEndMovingCell");
		}

		public override bool ShouldAllowShakingBehaviorWhenMovingCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell view, int index)
		{
			Console.WriteLine("ShouldAllowShakingBehaviorWhenMovingCell");
			return false;
		}
		#endregion
	}
	
	public class SlidesTransformationDelegate : GMGridView.GMGridViewTransformationDelegate
	{
		#region implemented abstract members of GMGridView.GMGridViewTransformationDelegate
		public override System.Drawing.SizeF SizeInFullSizeForCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell cell, int index, UIInterfaceOrientation orientation)
		{
			Console.WriteLine("SizeInFullSizeForCell");
            return new System.Drawing.SizeF(300, 310);
		}

		public override UIView FullSizeViewForCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell cell, int index)
		{
			Console.WriteLine("FullSizeViewForCell");

		    UIView fullView = new UIView();
		    fullView.BackgroundColor = UIColor.Yellow;
		    fullView.Layer.MasksToBounds = false;
		    fullView.Layer.CornerRadius = 8;
		    
		    SizeF size = this.SizeInFullSizeForCell(gridView, cell, index, UIApplication.SharedApplication.StatusBarOrientation);
		    fullView.Bounds = new RectangleF(0, 0, size.Width, size.Height);
		    
		    UILabel label = new UILabel(fullView.Bounds);
		    label.Text = string.Format(@"Fullscreen View for cell at index {0}", index);
		    label.TextAlignment = UITextAlignment.Center;
		    label.BackgroundColor = UIColor.Clear;
		    label.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
		    
	        label.Font = UIFont.BoldSystemFontOfSize(15);
		    fullView.AddSubview(label);
		    
		    
		    return fullView;
		}

		public override void DidStartTransformingCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell cell)
		{
			Console.WriteLine("DidStartTransformingCell");
		}

		public override void DidEnterFullSizeForCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell cell)
		{
			Console.WriteLine("DidEnterFullSizeForCell");
		}

		public override void DidEndTransformingCell (GMGridView.GMGridView gridView, GMGridView.GMGridViewCell cell)
		{
			Console.WriteLine("DidEndTransformingCell");
		}
		#endregion
	}	
}

