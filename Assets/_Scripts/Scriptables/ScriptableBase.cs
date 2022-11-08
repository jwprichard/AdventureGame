using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Units
{
    public class ScriptableBase : ScriptableObject
    {
        [SerializeField]
        new string name;
        public UnitType unitType;

        [SerializeField] private Stats _stats;
        public Stats BaseStats => _stats;

        public UnitBase prefab;
        public Sprite sprite;
    }

    [Serializable]
    public struct Stats
    {
        public int Health;
        public int Damage;
    }
    [Serializable]
    public enum UnitType
    {
        player = 0,
        enemy = 1,
        friendly = 2,
    }
}
