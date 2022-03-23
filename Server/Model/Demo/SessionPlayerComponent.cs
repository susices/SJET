﻿namespace ET
{
	public class SessionPlayerComponent : Entity, IAwake, IDestroy
	{
		public long PlayerId;

		public long PlayerInstanceId;

		public long AccountId;

		public bool IsNeedKickPlayer = true;
	}
}