using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private SpawnObject objectPrefab;
    [SerializeField] private TMP_Text objectCountText;
    private int objectCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SpawnObject newObject = Instantiate(objectPrefab);
            newObject.transform.position = spawnLocation.position;
            newObject.transform.rotation = Random.rotation;
            newObject.SetColor(Random.ColorHSV(0, 1, 0.75f, 1, 0.5f, 1, 1, 1));
            objectCount++;
            objectCountText.text = "Object Count: " + objectCount;
        }

    }
}
