using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    public void Shoot()
    {
        ProjectileFactory.Instance.ShootProjectileFromFactory(
            _shootPoint.position,
            _shootPoint.forward,
            gameObject
        );
    }
}

public enum ShotType
{
    Basic,
}
