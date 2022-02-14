using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey) && transform.position.y <= 5.98)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

        }
        if (Input.GetKey(downKey) && transform.position.y >= -5.98)
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);

        }

    }
}
