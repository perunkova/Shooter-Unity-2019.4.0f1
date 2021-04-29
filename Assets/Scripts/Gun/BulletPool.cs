using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private Queue<Bullet> _queueBullet = new Queue<Bullet>();

    [SerializeField] Bullet _bulletPrefab;

    public Bullet CreateBullet(Transform spawnPoint)
    {
        Bullet bullet;

        if (_queueBullet.Count == 0)
            bullet = Instantiate(_bulletPrefab, transform);
        else
            bullet = _queueBullet.Dequeue();

        bullet.transform.parent = null;
        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = spawnPoint.rotation;
        bullet.transform.localScale = Vector3.one;
        bullet.gameObject.SetActive(true);
        bullet.BulletMissionCompleted += DestroyBullet;

        return bullet;
    }

    public void DestroyBullet(Bullet bullet)
    {
        bullet.BulletMissionCompleted -= DestroyBullet;
        bullet.gameObject.SetActive(false);
        bullet.transform.parent = transform;
        _queueBullet.Enqueue(bullet);
    }
}
