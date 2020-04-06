using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float MaxSpeed = 80;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("RestartGame", 2);
        //this.GoBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = Mathf.Clamp(rb2d.velocity.x * 1.2f, -MaxSpeed, MaxSpeed);
            vel.y = Mathf.Clamp(((rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3)) * 1.2f, -MaxSpeed, MaxSpeed);
            
            rb2d.velocity = vel;
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void GoBall()
    {
        rb2d.AddForce(new Vector2(Random.Range(-20, 20), Random.Range(-20, 20)));
    }
}
