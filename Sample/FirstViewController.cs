namespace Sample;

using ObjCRuntime;
using System;
using SDWebImage;
using UIKit;
using Foundation;

public partial class FirstViewController : UIViewController {
	protected FirstViewController (NativeHandle handle) : base (handle)
	{
	}

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
        var imageView = new UIImageView(new CGRect(16, 100, 186, 124));
        View.AddSubview(imageView);
        imageView.SetImage(NSUrl.FromString("https://loymax.ru/wp-content/uploads/2022/09/oblozhka-003-2-930x620.png"),
                                         UIImage.FromBundle("placeholder"),
                                         SDWebImageOptions.RefreshCached);
    }
}

