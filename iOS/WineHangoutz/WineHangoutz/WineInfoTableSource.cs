using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using Foundation;

namespace WineHangoutz
{
	public class WineInfoTableSource : UITableViewSource
	{

		string[,] TableItems;
		string CellIdentifier = "TableCell";

		public WineInfoTableSource(string[,] items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Length/2;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row >= TableItems.Length)
			{
				return null;
			}
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = TableItems[indexPath.Row, 0];
			string val = TableItems[indexPath.Row, 1];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Value2, CellIdentifier); }

			cell.TextLabel.Text = item;
			cell.DetailTextLabel.Text = val;

			return cell;
		}
	}
}
