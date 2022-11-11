using UnityEngine;
using Assets.Units;
using Assets.Combat;

public class BaseMovementController : MonoBehaviour
{
    public int Speed { get; private set; }
    public float LockedTill { get; private set; } = 0;
    public float LockMovement { set { LockedTill = Time.time + value; } }

    [HideInInspector] public Transform Target;
    [HideInInspector] public Rigidbody2D Rigidbody;
    [HideInInspector] public UnitBase Unit;

    private float _oldVelocity;
    private float _crashThreshold = 100f;

    public virtual void Awake()
    {
        Unit = GetComponent<UnitBase>();
        Target = GameObject.FindGameObjectWithTag(Unit.Scriptable.targetUnit.ToString()).transform;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Start()
    {
        _oldVelocity = Rigidbody.velocity.sqrMagnitude;
        _crashThreshold *= _crashThreshold; // So that this works with sqrMagnitude
    }

    public virtual void Update()
    {
        Move();
        Rotate();

    }

    public virtual void FixedUpdate()
    {
        CheckCrash();
    }

    public virtual void CheckCrash()
    {
        float newVel = Rigidbody.velocity.sqrMagnitude;

        if (_oldVelocity - newVel > _crashThreshold)
        {
            Debug.Log((int)(_oldVelocity - newVel) / 1000);
            GetComponent<BaseCombatController>().TakeDamage((int)(_oldVelocity - newVel) / 1000);
        }

        _oldVelocity = newVel;
    }

    public virtual void Move()
    {
        if (Time.time < LockedTill) return;

        float step = Unit.Stats.Speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Target.position, step);
    }

    public virtual void Rotate()
    {

    }
}
