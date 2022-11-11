using UnityEngine;
using Assets.Units;

namespace Assets.Combat
{
    public class PlayerCombatController : BaseCombatController
    {
        private GameObject weaponGo;

        private Animator _anim;
        [SerializeField] private Transform _backpack;

        private static readonly int animIdle = Animator.StringToHash("Idle");
        private static readonly int animAttack = Animator.StringToHash("Attack");

        float _LockedTill = 0;
        int _CurrentState = 0;

        public override void Awake()
        {
            CreateWeapon();
            Unit = GetComponent<UnitBase>();
        }

        public override void Update()
        {
            Animate();
            if (_CurrentState == animAttack)
            {
                Attack();
            }
        }

        private void Animate()
        {
            var state = GetState();

            if (state == _CurrentState) return;
            if (_anim != null)
            {
                _anim.CrossFade(state, 0, 0);
            }
            _CurrentState = state;
        }

        private int GetState()
        {
            //if (Time.time < _LockedTill) return _CurrentState;

            if (Input.GetMouseButtonDown(0))
            {
                //Attack();
                return LockState(animAttack, 0.5f);
            }

            if (Time.time < _LockedTill) return _CurrentState;

            int LockState(int s, float t)
            {
                _LockedTill = Time.time + t;
                return s;
            }

            return animIdle;
        }

        private void CreateWeapon()
        {
            if (Weapon.prefab != null)
            {
                weaponGo = Instantiate(Weapon.prefab);
                weaponGo.transform.position = new(transform.position.x, transform.position.y + 0.5f);
                weaponGo.transform.parent = _backpack;
                _anim = weaponGo.GetComponent<Animator>();
            }
        }
    }
}
