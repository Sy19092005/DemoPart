using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 5f;
    public int damage = 1;

    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}