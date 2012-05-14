using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GMGridView
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//

	[BaseType (typeof (UIScrollView))]
	interface GMGridView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

	    //[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
	    //NSObject WeakDelegate { get; set; }
		
		//@property (nonatomic, gm_weak) IBOutlet NSObject<GMGridViewDataSource> *dataSource;                    
		[Export ("dataSource"), NullAllowed, Wrap ("WeakDelegate")]
		NSObject DataSource { get; set;  }
	
		//@property (nonatomic, gm_weak) IBOutlet NSObject<GMGridViewActionDelegate> *actionDelegate;            
		[Export ("actionDelegate"), NullAllowed, Wrap ("WeakDelegate")]
		GMGridViewActionDelegate ActionDelegate { get; set;  }
	
		//@property (nonatomic, gm_weak) IBOutlet NSObject<GMGridViewSortingDelegate> *sortingDelegate;          
		[Export ("sortingDelegate"), NullAllowed, Wrap ("WeakDelegate")]
		GMGridViewSortingDelegate SortingDelegate { get; set;  }
	
		//@prop	erty (nonatomic, gm_weak) IBOutlet NSObject<GMGridViewTransformationDelegate> *transformDelegate; 
		[Export ("transformDelegate"), NullAllowed, Wrap ("WeakDelegate")]
		GMGridViewTransformationDelegate TransformDelegate { get; set;  }
	
		//@property (nonatomic, strong) IBOutlet id<GMGridViewLayoutStrategy> layoutStrategy; 
		[Export ("layoutStrategy"), NullAllowed, Wrap ("WeakDelegate")]
		NSObject LayoutStrategy { get; set;  }
	
		//@property (nonatomic, getter=isEditing) BOOL editing; 
		[Export ("editing")]
		bool Editing { [Bind ("isEditing")] get; set;  }
	
		//@property (nonatomic, gm_weak) IBOutlet UIView *mainSuperView;        
		[Export ("mainSuperView"), NullAllowed]
		UIView MainSuperView { get; set;  }
	
		//@property (nonatomic) GMGridViewStyle style;                          
		[Export ("style")]
		GMGridViewStyle Style { get; set;  }
	
		//@property (nonatomic) NSInteger itemSpacing;                          
		[Export ("itemSpacing")]
		int ItemSpacing { get; set;  }
	
		//@property (nonatomic) BOOL centerGrid;                                
		[Export ("centerGrid")]
		bool CenterGrid { get; set;  }
	
		//@property (nonatomic) UIEdgeInsets minEdgeInsets;                     
		[Export ("minEdgeInsets")]
		UIEdgeInsets MinEdgeInsets { get; set;  }
	
		//@property (nonatomic) CFTimeInterval minimumPressDuration;            
		[Export ("minimumPressDuration")]
		double MinimumPressDuration { get; set;  }
	
		//@property (nonatomic) BOOL showFullSizeViewWithAlphaWhenTransforming; 
		[Export ("showFullSizeViewWithAlphaWhenTransforming")]
		bool ShowFullSizeViewWithAlphaWhenTransforming { get; set;  }

		//- (void)setEditing:(BOOL)editing animated:(BOOL)animated;
		[Export ("setEditing:animated:")]
		void SetEditing (bool editing, bool animated);

		//- (GMGridViewCell *)dequeueReusableCell;                              
		[Export ("dequeueReusableCell")]
		GMGridViewCell DequeueReusableCell { get; }

		//- (GMGridViewCell *)dequeueReusableCellWithIdentifier:(NSString *)identifier;
		[Export ("dequeueReusableCellWithIdentifier:")]
		GMGridViewCell DequeueReusableCellWithIdentifier (string identifier);

		//- (GMGridViewCell *)cellForItemAtIndex:(NSInteger)position;           
		[Export ("cellForItemAtIndex:")]
		GMGridViewCell CellForItemAtIndex (int position);

		//- (void)reloadData;
		[Export ("reloadData")]
		void ReloadData ();

		//- (void)insertObjectAtIndex:(NSInteger)index animated:(BOOL)animated;
		[Export ("insertObjectAtIndex:animated:")]
		void InsertObjectAtIndex (int index, bool animated);

		//- (void)insertObjectAtIndex:(NSInteger)index withAnimation:(GMGridViewItemAnimation)animation;
		[Export ("insertObjectAtIndex:withAnimation:")]
		void InsertObjectAtIndex (int index, GMGridViewItemAnimation animation);

		//- (void)removeObjectAtIndex:(NSInteger)index animated:(BOOL)animated;
		[Export ("removeObjectAtIndex:animated:")]
		void RemoveObjectAtIndex (int index, bool animated);

		//- (void)removeObjectAtIndex:(NSInteger)index withAnimation:(GMGridViewItemAnimation)animation;
		[Export ("removeObjectAtIndex:withAnimation:")]
		void RemoveObjectAtIndex (int index, GMGridViewItemAnimation animation);

		//- (void)reloadObjectAtIndex:(NSInteger)index animated:(BOOL)animated;
		[Export ("reloadObjectAtIndex:animated:")]
		void ReloadObjectAtIndex (int index, bool animated);

		//- (void)reloadObjectAtIndex:(NSInteger)index withAnimation:(GMGridViewItemAnimation)animation;
		[Export ("reloadObjectAtIndex:withAnimation:")]
		void ReloadObjectAtIndex (int index, GMGridViewItemAnimation animation);

		//- (void)swapObjectAtIndex:(NSInteger)index1 withObjectAtIndex:(NSInteger)index2 animated:(BOOL)animated;
		[Export ("swapObjectAtIndex:withObjectAtIndex:animated:")]
		void SwapObjectAtIndex (int index1, int index2, bool animated);

		//- (void)swapObjectAtIndex:(NSInteger)index1 withObjectAtIndex:(NSInteger)index2 withAnimation:(GMGridViewItemAnimation)animation;
		[Export ("swapObjectAtIndex:withObjectAtIndex:withAnimation:")]
		void SwapObjectAtIndex (int index1, int index2, GMGridViewItemAnimation animation);

		//- (void)scrollToObjectAtIndex:(NSInteger)index atScrollPosition:(GMGridViewScrollPosition)scrollPosition animated:(BOOL)animated;
		[Export ("scrollToObjectAtIndex:atScrollPosition:animated:")]
		void ScrollToObjectAtIndex (int index, GMGridViewScrollPosition scrollPosition, bool animated);

		//- (void)layoutSubviewsWithAnimation:(GMGridViewItemAnimation)animation;
		[Export ("layoutSubviewsWithAnimation:")]
		void LayoutSubviewsWithAnimation (GMGridViewItemAnimation animation);

	}

	[Model]
	[BaseType (typeof (NSObject))]
	interface GMGridViewDataSource {

		//@required- (NSInteger)numberOfItemsInGMGridView:(GMGridView *)gridView;
		[Abstract, Export ("numberOfItemsInGMGridView:")]
		int NumberOfItemsInGMGridView (GMGridView gridView);

			//- (CGSize)GMGridView:(GMGridView *)gridView sizeForItemsInInterfaceOrientation:(UIInterfaceOrientation)orientation;
			[Abstract, Export ("GMGridView:sizeForItemsInInterfaceOrientation:")]
			System.Drawing.SizeF SizeForItemsInInterfaceOrientation (GMGridView gridView, UIInterfaceOrientation orientation);

		//- (GMGridViewCell *)GMGridView:(GMGridView *)gridView cellForItemAtIndex:(NSInteger)index;
		[Abstract, Export ("GMGridView:cellForItemAtIndex:")]
		GMGridViewCell CellForItemAtIndex (GMGridView gridView, int index);

		//@optional- (BOOL)GMGridView:(GMGridView *)gridView canDeleteItemAtIndex:(NSInteger)index;
		[Abstract, Export ("GMGridView:canDeleteItemAtIndex:")]
		bool CanDeleteItemAtIndex (GMGridView gridView, int index);

	}
	[Model]

	[BaseType (typeof (NSObject))]
	interface GMGridViewActionDelegate {

		//@required- (void)GMGridView:(GMGridView *)gridView didTapOnItemAtIndex:(NSInteger)position;
		[Abstract, Export ("GMGridView:didTapOnItemAtIndex:")]
		void DidTapOnItemAtIndex (GMGridView gridView, int position);

		//@optional- (void)GMGridViewDidTapOnEmptySpace:(GMGridView *)gridView;
		[Abstract, Export ("GMGridViewDidTapOnEmptySpace:")]
		void DidTapOnEmptySpace (GMGridView gridView);

		//- (void)GMGridView:(GMGridView *)gridView processDeleteActionForItemAtIndex:(NSInteger)index;
		[Abstract, Export ("GMGridView:processDeleteActionForItemAtIndex:")]
		void ProcessDeleteActionForItemAtIndex (GMGridView gridView, int index);

	}
	[Model]

	[BaseType (typeof (NSObject))]
	interface GMGridViewSortingDelegate {

		//@required- (void)GMGridView:(GMGridView *)gridView moveItemAtIndex:(NSInteger)oldIndex toIndex:(NSInteger)newIndex;
		[Abstract, Export ("GMGridView:moveItemAtIndex:toIndex:")]
		void MoveItemAtIndex (GMGridView gridView, int oldIndex, int newIndex);

		//- (void)GMGridView:(GMGridView *)gridView exchangeItemAtIndex:(NSInteger)index1 withItemAtIndex:(NSInteger)index2;
		[Abstract, Export ("GMGridView:exchangeItemAtIndex:withItemAtIndex:")]
		void ExchangeItemAtIndex (GMGridView gridView, int index1, int index2);

		//@optional- (void)GMGridView:(GMGridView *)gridView didStartMovingCell:(GMGridViewCell *)cell;
		[Abstract, Export ("GMGridView:didStartMovingCell:")]
		void DidStartMovingCell (GMGridView gridView, GMGridViewCell cell);

		//- (void)GMGridView:(GMGridView *)gridView didEndMovingCell:(GMGridViewCell *)cell;
		[Abstract, Export ("GMGridView:didEndMovingCell:")]
		void DidEndMovingCell (GMGridView gridView, GMGridViewCell cell);

		//- (BOOL)GMGridView:(GMGridView *)gridView shouldAllowShakingBehaviorWhenMovingCell:(GMGridViewCell *)view atIndex:(NSInteger)index;
		[Abstract, Export ("GMGridView:shouldAllowShakingBehaviorWhenMovingCell:atIndex:")]
		bool ShouldAllowShakingBehaviorWhenMovingCell (GMGridView gridView, GMGridViewCell view, int index);

	}
	[Model]

	[BaseType (typeof (NSObject))]
	interface GMGridViewTransformationDelegate {

		//@required- (CGSize)GMGridView:(GMGridView *)gridView sizeInFullSizeForCell:(GMGridViewCell *)cell atIndex:(NSInteger)index inInterfaceOrientation:(UIInterfaceOrientation)orientation;
		[Abstract, Export ("GMGridView:sizeInFullSizeForCell:atIndex:inInterfaceOrientation:")]
		System.Drawing.SizeF SizeInFullSizeForCell (GMGridView gridView, GMGridViewCell cell, int index, UIInterfaceOrientation orientation);

		//- (UIView *)GMGridView:(GMGridView *)gridView fullSizeViewForCell:(GMGridViewCell *)cell atIndex:(NSInteger)index;
		[Abstract, Export ("GMGridView:fullSizeViewForCell:atIndex:")]
		UIView FullSizeViewForCell (GMGridView gridView, GMGridViewCell cell, int index);

		//@optional- (void)GMGridView:(GMGridView *)gridView didStartTransformingCell:(GMGridViewCell *)cell;
		[Abstract, Export ("GMGridView:didStartTransformingCell:")]
		void DidStartTransformingCell (GMGridView gridView, GMGridViewCell cell);

		//- (void)GMGridView:(GMGridView *)gridView didEnterFullSizeForCell:(GMGridViewCell *)cell;
		[Abstract, Export ("GMGridView:didEnterFullSizeForCell:")]
		void DidEnterFullSizeForCell (GMGridView gridView, GMGridViewCell cell);

		//- (void)GMGridView:(GMGridView *)gridView didEndTransformingCell:(GMGridViewCell *)cell;
		[Abstract, Export ("GMGridView:didEndTransformingCell:")]
		void DidEndTransformingCell (GMGridView gridView, GMGridViewCell cell);

	}

	[BaseType (typeof (UIView))]
	interface GMGridViewCell {

		//@property (nonatomic, strong) UIView *contentView;         
		[Export ("contentView"), NullAllowed]
		UIView ContentView { get; set;  }
	
		//@property (nonatomic, strong) UIImage *deleteButtonIcon;   
		[Export ("deleteButtonIcon"), NullAllowed]
		UIImage DeleteButtonIcon { get; set;  }
	
		//@property (nonatomic) CGPoint deleteButtonOffset;          
		[Export ("deleteButtonOffset")]
		System.Drawing.PointF DeleteButtonOffset { get; set;  }
	
		//@property (nonatomic, strong) NSString *reuseIdentifier;
		[Export ("reuseIdentifier"), NullAllowed]
		string ReuseIdentifier { get; set;  }
			
		//- (void)prepareForReuse;
		[Export ("prepareForReuse")]
		void PrepareForReuse ();

	}

	// Layout strategy
	[BaseType (typeof (NSObject))]
	interface GMGridViewLayoutStrategyFactory {

		//+ (id<GMGridViewLayoutStrategy>)strategyFromType:(GMGridViewLayoutStrategyType)type;
		[Static, Export ("strategyFromType:")]
		NSObject StrategyFromType (GMGridViewLayoutStrategyType type);

	}
	
	[Model]
	[BaseType (typeof (NSObject))]
	interface GMGridViewLayoutStrategy {

		//- (GMGridViewLayoutStrategyType)type;
		[Abstract, Export ("type")]
		GMGridViewLayoutStrategyType Type { get; }

		//+ (BOOL)requiresEnablingPaging;
		//[Static, Abstract, Export ("requiresEnablingPaging")]
		//bool RequiresEnablingPaging { get; }

		//- (void)setupItemSize:(CGSize)itemSize andItemSpacing:(NSInteger)spacing withMinEdgeInsets:(UIEdgeInsets)edgeInsets andCenteredGrid:(BOOL)centered;
		[Abstract, Export ("setupItemSize:andItemSpacing:withMinEdgeInsets:andCenteredGrid:")]
		void SetupItemSize (System.Drawing.SizeF itemSize, int spacing, UIEdgeInsets edgeInsets, bool centered);

		//- (void)rebaseWithItemCount:(NSInteger)count insideOfBounds:(CGRect)bounds;
		[Abstract, Export ("rebaseWithItemCount:insideOfBounds:")]
		void RebaseWithItemCount (int count, System.Drawing.RectangleF bounds);

		//- (CGSize)contentSize;
		[Abstract, Export ("contentSize")]
		System.Drawing.SizeF ContentSize { get; }

		//- (CGPoint)originForItemAtPosition:(NSInteger)position;
		[Abstract, Export ("originForItemAtPosition:")]
		System.Drawing.PointF OriginForItemAtPosition (int position);

		//- (NSInteger)itemPositionFromLocation:(CGPoint)location;
		[Abstract, Export ("itemPositionFromLocation:")]
		int ItemPositionFromLocation (System.Drawing.PointF location);

		//- (NSRange)rangeOfPositionsInBoundsFromOffset:(CGPoint)offset;
		[Abstract, Export ("rangeOfPositionsInBoundsFromOffset:")]
		NSRange RangeOfPositionsInBoundsFromOffset (System.Drawing.PointF offset);

	}

	/*
	[BaseType (typeof (NSObject))]
	interface GMGridViewLayoutStrategyBase {

		//- (void)setupItemSize:(CGSize)itemSize andItemSpacing:(NSInteger)spacing withMinEdgeInsets:(UIEdgeInsets)edgeInsets andCenteredGrid:(BOOL)centered;
		[Export ("setupItemSize:andItemSpacing:withMinEdgeInsets:andCenteredGrid:")]
		void SetupItemSize (System.Drawing.SizeF itemSize, int spacing, UIEdgeInsets edgeInsets, bool centered);

		//- (void)setEdgeAndContentSizeFromAbsoluteContentSize:(CGSize)actualContentSize;
		[Export ("setEdgeAndContentSizeFromAbsoluteContentSize:")]
		void SetEdgeAndContentSizeFromAbsoluteContentSize (System.Drawing.SizeF actualContentSize);

	}

	[BaseType (typeof (GMGridViewLayoutStrategyBase))]
	interface GMGridViewLayoutVerticalStrategy {

	}

	[BaseType (typeof (GMGridViewLayoutStrategyBase))]
	interface GMGridViewLayoutHorizontalStrategy {

	}

	[BaseType (typeof (GMGridViewLayoutHorizontalStrategy))]
	interface GMGridViewLayoutHorizontalPagedStrategy {

		//- (NSInteger)positionForItemAtColumn:(NSInteger)column row:(NSInteger)row page:(NSInteger)page;
		[Export ("positionForItemAtColumn:row:page:")]
		int PositionForItemAtColumn (int column, int row, int page);

		//- (NSInteger)columnForItemAtPosition:(NSInteger)position;
		[Export ("columnForItemAtPosition:")]
		int ColumnForItemAtPosition (int position);

		//- (NSInteger)rowForItemAtPosition:(NSInteger)position;
		[Export ("rowForItemAtPosition:")]
		int RowForItemAtPosition (int position);

	}

	[BaseType (typeof (GMGridViewLayoutHorizontalPagedStrategy))]
	interface GMGridViewLayoutHorizontalPagedLTRStrategy {

	}

	[BaseType (typeof (GMGridViewLayoutHorizontalPagedStrategy))]
	interface GMGridViewLayoutHorizontalPagedTTBStrategy {

	}
	
	// Additional properties not associated with classes
	//@property (nonatomic, readonly) GMGridViewLayoutStrategyType type;
	[Export ("type", ArgumentSemantic.ReadOnly)]
	GMGridViewLayoutStrategyType Type { get;  }

	//@property (nonatomic, readonly) CGSize itemSize;
	[Export ("itemSize", ArgumentSemantic.ReadOnly)]
	System.Drawing.SizeF ItemSize { get;  }

	//@property (nonatomic, readonly) NSInteger itemSpacing;
	[Export ("itemSpacing", ArgumentSemantic.ReadOnly)]
	int ItemSpacing { get;  }

	//@property (nonatomic, readonly) UIEdgeInsets minEdgeInsets;
	[Export ("minEdgeInsets", ArgumentSemantic.ReadOnly)]
	UIEdgeInsets MinEdgeInsets { get;  }

	//@property (nonatomic, readonly) BOOL centeredGrid;
	[Export ("centeredGrid", ArgumentSemantic.ReadOnly)]
	bool CenteredGrid { get;  }

	//@property (nonatomic, readonly) NSInteger itemCount;
	[Export ("itemCount", ArgumentSemantic.ReadOnly)]
	int ItemCount { get;  }

	//@property (nonatomic, readonly) UIEdgeInsets edgeInsets;
	[Export ("edgeInsets", ArgumentSemantic.ReadOnly)]
	UIEdgeInsets EdgeInsets { get;  }

	//@property (nonatomic, readonly) CGRect gridBounds;
	[Export ("gridBounds", ArgumentSemantic.ReadOnly)]
	System.Drawing.RectangleF GridBounds { get;  }

	//@property (nonatomic, readonly) CGSize contentSize;
	[Export ("contentSize", ArgumentSemantic.ReadOnly)]
	System.Drawing.SizeF ContentSize { get;  }

	//@property (nonatomic, readonly) NSInteger numberOfItemsPerRow;
	[Export ("numberOfItemsPerRow", ArgumentSemantic.ReadOnly)]
	int NumberOfItemsPerRow { get;  }

	//@property (nonatomic, readonly) NSInteger numberOfItemsPerColumn;
	[Export ("numberOfItemsPerColumn", ArgumentSemantic.ReadOnly)]
	int NumberOfItemsPerColumn { get;  }

	//@property (nonatomic, readonly) NSInteger numberOfItemsPerRow;
	[Export ("numberOfItemsPerRow", ArgumentSemantic.ReadOnly)]
	int NumberOfItemsPerRow { get;  }

	//@property (nonatomic, readonly) NSInteger numberOfItemsPerPage;
	[Export ("numberOfItemsPerPage", ArgumentSemantic.ReadOnly)]
	int NumberOfItemsPerPage { get;  }

	//@property (nonatomic, readonly) NSInteger numberOfPages;
	[Export ("numberOfPages", ArgumentSemantic.ReadOnly)]
	int NumberOfPages { get;  }
	
	
	*/
}

