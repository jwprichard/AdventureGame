using UnityEngine;

namespace Assets.Units
{
    public class UnitBase : MonoBehaviour
    {
        public Stats Stats { get; private set; }
        public virtual void SetStats(Stats stats) => Stats = stats;

        public virtual void TakeDamage(int damage)
        {
        }
    }
}
