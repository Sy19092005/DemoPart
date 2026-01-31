using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;

    [Header("Weapon")]
    public GameObject bulletPrefabs;
    public float shootingInterval = 0.2f;
    public Vector3 bulletOffset = new Vector3(0, 0.6f, 0);

    [Header("Weapon Power")]
    public int weaponPower = 1;          // ⭐ BONUS DÙNG
    public int maxweaponPower = 5;       // ⭐ BONUS DÙNG

    private float lastBulletTime;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }

    void UpdateFiring()
    {
        if (Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }

    public void ShootBullet()
    {
        for (int i = 0; i < weaponPower; i++)
        {
            Vector3 offset = bulletOffset;

            // bắn nhiều đạn khi weaponPower tăng
            offset.x += (i - weaponPower / 2f) * 0.2f;

            Instantiate(
                bulletPrefabs,
                transform.position + offset,
                Quaternion.identity
            );
        }
    }

    // ⭐ BONUS GỌI HÀM NÀY
    public void IncreaseWeaponPower()
    {
        if (weaponPower < maxweaponPower)
        {
            weaponPower++;
        }
    }
}