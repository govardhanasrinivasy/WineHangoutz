using System;
using CoreGraphics;
using CoreAnimation;
using Foundation;
using UIKit;
using ObjCRuntime;
using PatridgeDev;

namespace WineHangoutz {

	public class APLCollectionViewCell : UICollectionViewCell {

		public static readonly NSString Key = new NSString ("APLCollectionViewCell");
		public UINavigationController NavigationController;

		[Export ("initWithFrame:")]
		public APLCollectionViewCell (CGRect frame) : base (frame)
		{
            CGRect box = new CGRect(Bounds.Location, Bounds.Size);
			box.X = 0;
			box.Y = 0;
            box.Height = box.Height - 150;
			BackgroundColor = UIColor.DarkGray;
			ImageView = new UIButton(box);
			ImageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			ImageView.Layer.BorderWidth = 3.0f;
			ImageView.ClipsToBounds = true;
			ImageView.Layer.BorderColor = UIColor.White.CGColor;
			ImageView.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.LeftEdge | CAEdgeAntialiasingMask.RightEdge | CAEdgeAntialiasingMask.BottomEdge | CAEdgeAntialiasingMask.TopEdge;
			ImageView.SetBackgroundImage(UIImage.FromFile("placeholder.jpeg"), UIControlState.Normal);

			ImageView.TouchUpInside += (object sender, EventArgs e) =>
			{
				NavigationController.PushViewController(new DetailViewController(), false);
			};


			box.Width = (box.Width/ 240) * 92; //box.Width / 2;
			box.X = (Bounds.Width-box.Width) / 2;
			btlImage = new UIButton(box);
			btlImage.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			btlImage.ContentMode = UIViewContentMode.ScaleToFill;
			//btlImage.Layer.BorderWidth = 3.0f;
			btlImage.ClipsToBounds = true;
			btlImage.Layer.BorderColor = UIColor.White.CGColor;
			btlImage.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.LeftEdge | CAEdgeAntialiasingMask.RightEdge | CAEdgeAntialiasingMask.BottomEdge | CAEdgeAntialiasingMask.TopEdge;
			//btlImage.SetBackgroundImage(UIImage.FromFile("Honoro g.png"), UIControlState.Normal);
			//btlImage.InsertSubviewAbove()
			btlImage.TouchUpInside += (object sender, EventArgs e) =>
			{
				NavigationController.PushViewController(new DetailViewController(), false);
			};

			box.Height = 20;
			box.Width = 20;
			box.X = (Bounds.Width - 25);
			box.Y = 5;
			heartImage = new UIButton(box);
			//heartImage.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			//heartImage.ContentMode = UIViewContentMode.ScaleToFill;
			heartImage.ClipsToBounds = true;
			//heartImage.Layer.BorderWidth = 3.0f;
			heartImage.Layer.BorderColor = UIColor.White.CGColor;
			heartImage.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.LeftEdge | CAEdgeAntialiasingMask.RightEdge | CAEdgeAntialiasingMask.BottomEdge | CAEdgeAntialiasingMask.TopEdge;
			heartImage.SetImage(UIImage.FromFile("heart_empty.png"),UIControlState.Normal);
			heartImage.Tag = 0; // Empty;

			heartImage.TouchUpInside += (object sender, EventArgs e) =>
			{
				//Do some actionn
				UIButton temp = (UIButton)sender;
				if (temp.Tag == 0)
				{
					heartImage.SetImage(UIImage.FromFile("heart_full.png"), UIControlState.Normal);
					temp.Tag = 1;
				}
				else
				{
					heartImage.SetImage(UIImage.FromFile("heart_empty.png"), UIControlState.Normal);
					temp.Tag = 0;
				}
				//NavigationController.PushViewController(new DetailViewController(), false);
			};

			CGRect lower = new CGRect(Bounds.Location, Bounds.Size);
			lower.Y = 35; //lower.Y + (ratio)*(Bounds.Height);
            lblName = new UILabel(lower);
            lblName.Text = "Wine Name";
            lblName.TextAlignment = UITextAlignment.Center;

            lower.Y = 225;
            lower.Height = 1;
            lower.Width = lower.Width - 20;
            lower.X = lower.X + 10;

            Separator = new UIImageView(lower);
            Separator.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            Separator.Image = UIImage.FromFile("separator.png");
            Separator.ContentMode = UIViewContentMode.ScaleAspectFill;
            Separator.ClipsToBounds = true;
            Separator.Layer.BorderColor = UIColor.White.CGColor;
            Separator.BackgroundColor = UIColor.LightGray;

            CGRect year = new CGRect(Bounds.Location, Bounds.Size);
            year.Y = lower.Y - 15;
            year.X = year.Width / 2 - 25; 
            year.Height = 30;
            year.Width = 50;
            lblYear = new UILabel(year);
            lblYear.Text = "2012";
            lblYear.TextAlignment = UITextAlignment.Center;
			lblYear.BackgroundColor = UIColor.DarkGray;


			lblRegPrice = new UILabel(new CGRect(0, Bounds.Height - 60, Bounds.Width, 12f));
			lblRegPrice.Text = "$9.99";
			lblRegPrice.Font = UIFont.FromName("Verdana", 13f);
			lblRegPrice.TextAlignment = UITextAlignment.Center;

			var ratingConfig = new RatingConfig(emptyImage: UIImage.FromBundle("Stars/empty.png"),
						filledImage: UIImage.FromBundle("Stars/filled.png"),
						chosenImage: UIImage.FromBundle("Stars/chosen.png"));

			decimal averageRating = 0;
			ratingView = new PDRatingView(new CGRect(Bounds.Width * 1 / 4, Bounds.Height - 40, Bounds.Width / 2, 14f), ratingConfig, averageRating);
			ratingView.UserInteractionEnabled = false;
			//ratingView.BackgroundColor = UIColor.White;

			ContentView.AddSubview(ImageView);
			ContentView.InsertSubviewAbove(btlImage, ImageView);
			//ContentView.AddSubview(btlImage);
			ContentView.AddSubview(heartImage);
			ContentView.AddSubview(lblName);
            ContentView.AddSubview(Separator);
            ContentView.AddSubview(lblYear);
			ContentView.AddSubview(lblRegPrice);
			ContentView.AddSubview(ratingView);
        }

		public UIButton ImageView { get; private set; }
		public UIButton heartImage { get; private set; }
		public UIButton btlImage { get; private set; }
        public UILabel lblName { get; private set; }
        public UIImageView Separator { get; private set; }
        public UILabel lblYear { get; private set; }
		public UILabel lblRegPrice { get; private set; }
        public PDRatingView ratingView { get; private set; }

		private void NavigateToDetail()
		{
			
		}
    }
}
