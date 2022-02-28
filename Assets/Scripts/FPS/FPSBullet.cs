using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSBullet : MonoBehaviour
{
    [SerializeField] private Transform mainTransform;
    [SerializeField] private float moveTime;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRoutine());
        IEnumerator FireRoutine()
        {
            float elapsedTime = 0;
            while (elapsedTime <= moveTime)
            {
                elapsedTime += Time.deltaTime;
                mainTransform.position += mainTransform.forward * moveSpeed * Time.deltaTime;
                yield return null;
            }
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
