using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mainRigidbody;
    [SerializeField] private long startSpeed;
    // Start is called before the first frame update

    public void Restart()
    {

        mainRigidbody.position = Vector2.zero;
        mainRigidbody.velocity = Vector2.zero;

        StartCoroutine(StartBall());
        IEnumerator StartBall()
        {
            yield return new WaitForSeconds(1);
            Vector2 newVelocity = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            mainRigidbody.velocity = newVelocity.normalized * startSpeed;
        }
        
    }
    public void StopBall()
    {
        mainRigidbody.velocity = new Vector2(0, 0);
    }
}
