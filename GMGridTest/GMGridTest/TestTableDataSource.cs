using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace GMGridTest
{
	public class TestTableDataSource : UITableViewDataSource
	{
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
				string cellIdentifier = "Cell";
				var cell = tableView.DequeueReusableCell (cellIdentifier);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
					cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				}
				
				if (indexPath.Section == 0) {
					cell.TextLabel.Text = "Section 1";
				} else {
					cell.TextLabel.Text = "Section 2: " + indexPath.Row.ToString();
				}
				
				return cell;
		}
		
		public override int RowsInSection (UITableView tableView, int section)
		{
			return 3;
		}
		
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "SP List";
		}
	}
	
	public class TestTableViewSource : UITableViewSource
	{
		public override int NumberOfSections (UITableView tableView)
		{
			return 2;
		}
		
		public override string TitleForHeader (UITableView tableView, int section)
		{
				if (section == 0) {
					return "Date";
				} else if (section == 1) {
					return "Genre";
				} else {
					return "Main Characters";
				}
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return section + 1;
		}

			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				string cellIdentifier = "Cell";
				var cell = tableView.DequeueReusableCell (cellIdentifier);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
					cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				}
				
				if (indexPath.Section == 0) {
					cell.TextLabel.Text = "Section 1";
				} else {
					cell.TextLabel.Text = "Section 2: " + indexPath.Row.ToString();
				}
				
				return cell;
			}
	}
	
}

