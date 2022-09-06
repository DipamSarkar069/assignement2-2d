using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float speed = 10f;
    private Vector2 originalPos;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalPos = new Vector2(rb2d.transform.position.x, rb2d.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb2d.velocity = new Vector2(moveX * speed, moveY * speed);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
            {
            rb2d.transform.position = originalPos;
            Wait();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}
