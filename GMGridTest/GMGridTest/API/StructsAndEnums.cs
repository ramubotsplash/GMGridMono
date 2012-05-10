using System;

namespace GMGridView
{
	public enum  GMGridViewStyle
	{
		GMGridViewStylePush = 0,
		GMGridViewStyleSwap
	}
	public enum  GMGridViewScrollPosition
	{
		GMGridViewScrollPositionNone,
		GMGridViewScrollPositionTop,
		GMGridViewScrollPositionMiddle,
		GMGridViewScrollPositionBottom
	}
	public enum  GMGridViewItemAnimation
	{
		GMGridViewItemAnimationNone = 0,
		GMGridViewItemAnimationFade,
		GMGridViewItemAnimationScroll = 1<<7
	}
}
