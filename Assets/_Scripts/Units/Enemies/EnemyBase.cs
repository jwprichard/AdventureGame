using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Units;

public class EnemyBase : UnitBase
{
    [SerializeField] private Transform _target;

    float speed = 1;

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _target.position, step);
    }
}
