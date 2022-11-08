using UnityEngine;
using Assets.Scripts.Utilities;

public class PlayerCombatController : MonoBehaviour
{
    public Weapon weapon;
    private GameObject weaponGo;

    private Animator _anim;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Transform _backpack;

    private static readonly int animIdle = Animator.StringToHash("Idle");
    private static readonly int animAttack = Animator.StringToHash("Attack");

    float _LockedTill = 0;
    int _CurrentState = 0;

    public void Awake()
    {
        CreateWeapon();
        _anim = weaponGo.AddComponent<Animator>();
        _anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation\\" + weapon.animContName);
    }

    private void Update()
    {
        var state = GetState();

        if (state == _CurrentState) return;
        _anim.CrossFade(state, 0, 0);
        _CurrentState = state;


    }

    private int GetState()
    {
        if (Time.time < _LockedTill) return _CurrentState;

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            return LockState(animAttack, 0.5f);
        }

        int LockState(int s, float t)
        {
            _LockedTill = Time.time + t;
            return s;
        }

        return animIdle;
    }

    private void Attack()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(_attackPoint.position, 1f);
        if (collisions.Length > 0)
        {
            if (collisions[0].CompareTag("Enemy"))
            {
                collisions[0].GetComponent<SpriteRenderer>().color = Color.red;
                collisions[0].attachedRigidbody.AddForce((collisions[0].transform.position - transform.position) * 20, ForceMode2D.Impulse);
                Debug.DrawLine(_attackPoint.position - new Vector3(-1, 0), _attackPoint.position + new Vector3(1, 0));
                Debug.DrawLine(_attackPoint.position - new Vector3(0, -1), _attackPoint.position + new Vector3(0, 1));
            }
        }
    }

    private void CreateWeapon()
    {
        weaponGo = Instantiate(new GameObject());
        AddSpriteRenderer(weaponGo);
        weaponGo.transform.position = new(transform.position.x, transform.position.y + 1f);
        weaponGo.transform.parent = _backpack;
    }

    private void AddSpriteRenderer(GameObject go)
    {
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        SpriteRenderer gosr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = weapon.sprites[0];
        sr.sortingLayerName = gosr.sortingLayerName;
        sr.sortingOrder = gosr.sortingOrder+1;
        
    }

    private void SetupAnimator()
    {

    }
}
