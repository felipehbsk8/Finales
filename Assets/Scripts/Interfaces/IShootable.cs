using UnityEngine;

public interface IShootable 
{
    void Shoot(ShotData shotData);
}

public struct ShotData
{
    public Vector3 position;
    public Vector3 direction;
    public GameObject shooter;
}
