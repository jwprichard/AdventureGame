using UnityEngine;

namespace Assets.Units
{
    public class UnitBase : MonoBehaviour
    {
        [SerializeField] public virtual UnitStats Stats { get; private set; }
        [SerializeField] public UnitScriptableBase Scriptable;

        // If the scriptable base != null then assign the stats of the scriptable base the the GO
        public virtual void Awake()
        {
            if (Scriptable != null)
            {
                Stats = Scriptable.BaseStats;
            }
        }

        public virtual void SetStats(UnitStats stats) => Stats = stats;
    }
}
