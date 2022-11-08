using System.Collections.Generic;
using UnityEngine;
using Assets.Units;
using System.Linq;

public class ResourceSystem : Singleton<ResourceSystem>
{
    public List<ScriptableBase> Units = new();
    private Dictionary<UnitType, ScriptableBase> _units = new();

    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        Units = Resources.LoadAll<ScriptableBase>("Units").ToList();
        _units = Units.ToDictionary(r => r.unitType, r => r);
    }

    public ScriptableBase GetUnit(UnitType t) => _units[t];
}
