using UnityEngine;
using Assets.Units;

public class UnitManager : Singleton<UnitManager>
{
    public void SpawnUnit(UnitType t, Vector2 pos)
    {
        ResourceSystem.Instance.GetUnit(UnitType.enemy);
    }
}

