using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackRange = 10;

    private Transform _target;
    //enemy Shooting
    private float _timer;

    private void Awake()
    {
        _target = GameObject.FindWithTag("Player").transform;

    }

    private void Update()
    {
        if (!_target) return;
        float distance = Vector3.Distance(transform.position, _target.position);

        if (distance <= _attackRange)
        {
            LookAtPlayer();
        }
    }

    private void LookAtPlayer()
    {
        Vector3 dir = _target.position - transform.position;
        dir.y = 0f;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
