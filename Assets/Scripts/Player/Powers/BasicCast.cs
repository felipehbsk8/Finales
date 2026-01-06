using System.Collections;
using UnityEngine;

public class BasicCast : Projectile
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] float _lifeTime = 5f;

    float _timer;

    private void OnEnable()
    {
        _timer = 0f;
        active = false;
    }

    public override void Shoot(ShotData shotData)
    {
        transform.position = shotData.position;
        transform.forward = shotData.direction;
        speed = _speed;
        active = true;
    }

    private void Update()
    {
        if (!active) return;
        transform.position += transform.forward * _speed * Time.deltaTime;

        _timer += Time.deltaTime;
        if (_timer >= _lifeTime)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;
        ReturnToPool();
    }
}
