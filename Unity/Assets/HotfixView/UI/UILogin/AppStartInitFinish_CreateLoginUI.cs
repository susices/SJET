﻿

namespace ET
{
	public class AppStartInitFinish_RemoveLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventType.AppStartInitFinish args)
		{
			await args.ZoneScene.ShowUIPanel(UIPanelType.UILogin);
		}
	}
}
