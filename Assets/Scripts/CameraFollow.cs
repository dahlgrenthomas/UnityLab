using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform mainTransform;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        Vector3 currentPos = mainTransform.position;
        Vector3 smoothPosition = Vector3.SmoothDamp(mainTransform.position, target.position, ref velocity, 0.15f);
        currentPos.x = smoothPosition.x;
        mainTransform.position = currentPos;
    }
}
