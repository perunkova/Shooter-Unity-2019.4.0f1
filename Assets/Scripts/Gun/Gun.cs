using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireParticleSystem;
    [SerializeField] private Transform _spawnPoint;

    public BulletPool BulletPool;

    public void StartShooting()
    {
        var bullet = BulletPool.CreateBullet(_spawnPoint);
        bullet.Move();
        _fireParticleSystem.Play();
    }
}
