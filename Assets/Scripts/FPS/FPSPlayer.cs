using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [SerializeField] private Transform head;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private FPSUI fpsUI;
    [SerializeField] private int maxHealth;
    private AudioSource[] audioClips;
    public AudioSource gunShot;
    // Start is called before the first frame update
    void Start()
    {
        audioClips = GetComponents<AudioSource>();
        gunShot = audioClips[1];

    }
    public static FPSPlayer instance;

    void Awake()
    {
        instance = this;
        Health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletPrefab = bullets[Random.Range(0, bullets.Length)];
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
            gunShot.Play();
        }

    }
    private float lastHitTime;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy") && (Time.time - lastHitTime > 1f))
        {
            lastHitTime = Time.time;
            Destroy(hit.gameObject);
            if (Health > 0)
            {
                Health--;
            }
        }
    }

    private int health;
    private int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            fpsUI.ShowHealthFraction((float)Health / (float)maxHealth);
            if (health <= 0)
            {     
                LoadingScreen.LoadScene("MainMenu");
            }
        }
    }
    private int enemyDefeatCount;
    public void HandleEnemyDefeat()
    {
        enemyDefeatCount++;
        fpsUI.ShowEnemyDefeatCount(enemyDefeatCount);
    }
    public bool ShouldSpawn(Vector3 pos)
    {
        Vector3 posDiff = pos - transform.position;

        Vector3 faceDirection = head.forward;

        float distanceFromPlayer = posDiff.magnitude;

        return (Vector3.Dot(posDiff.normalized, faceDirection) < 0.5f) && (distanceFromPlayer > 10f);
    }
}
