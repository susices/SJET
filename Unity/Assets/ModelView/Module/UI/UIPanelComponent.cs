﻿using System.Collections.Generic;

namespace ET
{
	/// <summary>
	/// 管理Scene上的UI
	/// </summary>
	public class UIPanelComponent: Entity
	{
		public Dictionary<int, UIPanel> UIPanels = new Dictionary<int, UIPanel>();
	}
}