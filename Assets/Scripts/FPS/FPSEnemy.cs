using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSEnemy : MonoBehaviour
{
    [SerializeField] private Transform mainTransform;
    [SerializeField] private int moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = FPSPlayer.instance.transform.position;
        mainTransform.LookAt(playerPos);
        Vector3 currentRotation = mainTransform.rotation.eulerAngles;
        currentRotation.x = 0;
        mainTransform.eulerAngles = currentRotation;
        Vector3 directionToPlayer = (playerPos - mainTransform.position).normalized;
        mainTransform.position += (directionToPlayer * moveSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            FPSPlayer.instance.HandleEnemyDefeat();
        }
    }
}
