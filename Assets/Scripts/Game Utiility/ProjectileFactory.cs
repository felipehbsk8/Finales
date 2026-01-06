using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory: MonoBehaviour
{
    public Projectile model;
    Pool<Projectile> _pool = new Pool<Projectile>();
    [SerializeField] int _projectileQuantity;

    public static ProjectileFactory Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _pool.Initalize(model, _projectileQuantity ,p =>
        {
            p.SetPool(_pool);
            return p;
        });
    }

    public void ShootProjectileFromFactory(Vector3 postion, Vector3 direction, GameObject shooter)
    {
        Projectile projectile = _pool.GetObject();
        projectile.Shoot(new ShotData
        {
            position = postion,
            direction = direction,
            shooter = shooter
        });
    }
}
