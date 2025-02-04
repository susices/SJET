using System;


namespace ET
{
    public static class MapHelper
    {
        public static async ETVoid EnterMapAsync(Scene zoneScene, string sceneName)
        {
            try
            {
                G2C_EnterMap g2CEnterMap = await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2G_EnterMap()) as G2C_EnterMap;
                
                UnitComponent unitComponent = zoneScene.GetComponent<UnitComponent>();
                unitComponent.MyUnit = unitComponent.Get(g2CEnterMap.UnitId);
                var bagComponent =  unitComponent.MyUnit.AddComponent<BagComponent>();
                await bagComponent.GetAllBagItem();
                unitComponent.MyUnit.AddComponent<BuffContainerComponent>();
                Game.EventSystem.Publish(new EventType.EnterMapFinish() {ZoneScene = zoneScene}).Coroutine();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}