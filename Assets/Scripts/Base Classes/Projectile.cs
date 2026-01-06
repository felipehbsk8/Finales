using UnityEngine;

public abstract class Projectile : MonoBehaviour, IShootable
{
    protected float speed;
    protected Pool<Projectile> pool;

    protected bool active;
    public void SetPool(Pool<Projectile> pool)
    {
        this.pool = pool;
    }
    protected virtual void OnEnable()
    {
        active = false;
    }
    public abstract void Shoot(ShotData shotData);
    protected void ReturnToPool()
    {
        active = false;
        pool.ReturnToPool(this);
    }
}
