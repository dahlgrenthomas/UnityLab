using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mainRigidbody;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private float moveSpeed;
    [SerializeField] public Sprite spriteA;
    [SerializeField] public Sprite spriteB;
    bool isgrounded;
    bool flap = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            mainRigidbody.AddForce(new Vector2(-moveSpeed * Time.deltaTime, 0));
            mainSpriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mainRigidbody.AddForce(new Vector2(moveSpeed * Time.deltaTime, 0));
            mainSpriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            isgrounded = false;
            mainRigidbody.AddForce(new Vector2(0, 200));
            Flap();
        }
        if (isgrounded == true)
        {
            GetComponent<SpriteRenderer>().sprite = spriteA;
        }
    }
    public void Flap()
    {
        if(flap == true)
        {
            GetComponent<SpriteRenderer>().sprite = spriteB;
            flap = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = spriteA;
            flap = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "floor")
        {
            isgrounded = true;
            flap = true;
        }
    }

}
