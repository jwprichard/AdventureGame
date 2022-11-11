using UnityEngine;
using Assets.Units;
using Assets.Items;

namespace Assets.Combat
{
    public class BaseCombatController : MonoBehaviour
    {
        [HideInInspector] public UnitBase Unit;
        public WeaponScriptable Weapon;
        public Transform AttackPoint;

        public float InvincibilityFrames { get; private set; } = 0;
        public float SetInvincible { set { InvincibilityFrames = Time.time + value; } }
        private bool Invincible { get { return InvincibilityFrames > Time.time; } }


        public virtual void Awake()
        {
            Unit = GetComponent<UnitBase>();
            if (AttackPoint == null) AttackPoint = transform;
        }

        public virtual void Update()
        {
            Attack();
        }

        public virtual void TakeDamage(int damage) 
        {
            //Can't be dealt damage for a specific amount of time
            if (Invincible) return;
            if (damage < 1) return; //Don't grant invincibility for 0 damage
            UnitStats stats = Unit.Stats;
            stats.Health -= damage;
            Unit.SetStats(stats);
            if (stats.Health <= 0)
            {
                Destroy(gameObject);
            }

            SetInvincible = .5f;
        }

        public virtual void KnockBack(Vector2 dir)
        {
            if (Invincible) return;
            GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        }

        public virtual void Attack() 
        {
            //This may be computationally intensive but will use for now.
            Collider2D[] collisions = Physics2D.OverlapCircleAll(AttackPoint.position, Weapon.BaseStats.Range);
            if (collisions.Length > 0)
            {
                foreach(Collider2D c in collisions)
                {
                    if (c.CompareTag(Unit.Scriptable.targetUnit.ToString()))
                    {
                        DealDamage(c.GetComponent<BaseCombatController>());
                        c.GetComponent<BaseMovementController>().LockMovement = 0.5f;
                    }
                }
            }
        }

        public virtual void DealDamage(BaseCombatController bcc)
        {
            bcc.KnockBack((bcc.transform.position - transform.position).normalized * Weapon.BaseStats.KnockBack);
            bcc.TakeDamage(Weapon.BaseStats.Damage);
        }
    }
}
