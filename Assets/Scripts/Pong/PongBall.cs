using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mainRigidbody;
    [SerializeField] private long startSpeed;
    public AudioSource[] sounds;
    public AudioSource audioPaddleHit;
    public AudioSource audioGoalHit;
    public AudioSource audioWallHit;

    void Start()
    {
        sounds = GetComponents<AudioSource>();
        audioPaddleHit = sounds[0];
        audioGoalHit = sounds[1];
        audioWallHit = sounds[2];
    }
    public void Restart()
    {

        mainRigidbody.position = Vector2.zero;
        mainRigidbody.velocity = Vector2.zero;

        StartCoroutine(StartBall());
        IEnumerator StartBall()
        {
            yield return new WaitForSeconds(1);
            int randomOne = Random.Range(0, 2) * 2 - 1;
            int randomOne2 = Random.Range(0, 2) * 2 - 1;

            Vector2 newVelocity = new Vector2(Random.Range(5f, 10f)*randomOne, Random.Range(.5f, 7f)*randomOne2);
            mainRigidbody.velocity = newVelocity.normalized * startSpeed;
        }
        
    }
    public void StopBall()
    {
        mainRigidbody.velocity = new Vector2(0, 0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        if (col.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("Hit paddle");

            audioPaddleHit.volume = Mathf.InverseLerp(0, 10, col.relativeVelocity.magnitude);
            audioPaddleHit.Play();
        }
        if (col.gameObject.CompareTag("Goal"))
        {

            audioGoalHit.volume = Mathf.InverseLerp(0, 10, col.relativeVelocity.magnitude);
            audioGoalHit.Play();
        }
        if (col.gameObject.CompareTag("Wall"))
        {

            audioWallHit.volume = Mathf.InverseLerp(0, 10, col.relativeVelocity.magnitude);
            audioWallHit.Play();
        }
    }
}
