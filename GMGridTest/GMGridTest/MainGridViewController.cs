using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace GMGridTest
{
	public partial class MainGridViewController : DialogViewController
	{
		GMGridElement gridElem;
		
		
		public MainGridViewController () : base (UITableViewStyle.Plain, null)
		{
			gridElem = new GMGridElement("Test");	
			Root = new RootElement ("MainGridViewController") {
				new Section ("First Section"){
					new StringElement ("Hello", () => {
				new UIAlertView ("Hola", "Thanks for tapping!", null, "Continue").Show (); 
			}),
					new EntryElement ("Name", "Enter your name", String.Empty)
				},
				new Section ("Second Section"){
					gridElem,
					new TestImageElement("Test Image")
				},
			};
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			//if (gridElem.gv != null && this.NavigationController != null)
			//	gridElem.gv.MainSuperView = this.NavigationController.View;
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			//if (gridElem.gv != null && this.NavigationController != null)
			//	gridElem.gv.MainSuperView = null;
		}
	}
}
