using System;
using UnityEngine;

namespace Assets.Units
{
    [Serializable]
    public class UnitScriptableBase : ScriptableObject
    {
        [SerializeField]
        new string name;
        public UnitType unitType;
        public UnitType targetUnit;

        [SerializeField] private UnitStats _stats;
        public UnitStats BaseStats => _stats;

        public UnitBase prefab;
        //public Sprite sprite;
    }

    [Serializable]
    public struct UnitStats
    {
        public int Health;
        public int Speed;
    }
    [Serializable]
    public enum UnitType
    {
        Player = 0,
        Enemy = 1,
        friendly = 2,
    }
}
