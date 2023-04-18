using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float upwardsVelocity = 5;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        animator = GameObject.FindGameObjectWithTag("Wing").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
          myRigidbody.velocity = Vector2.up * upwardsVelocity;
           animator.SetBool("isFlapping", true);
        }

        if(Input.GetKeyUp(KeyCode.Space)) animator.SetBool("isFlapping", false);






        if (transform.position.y < -6.2 || transform.position.y > 6.2 )
        {
            logic.gameOver();
            birdIsAlive = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}