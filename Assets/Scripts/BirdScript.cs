using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody; // we create a public variable to store the rigidBody object (can access outside the script). NOW YOU CAN LITERALLY DRAG THE RIGIDBODY
    // COMPONENT INTO THE BIRDSCRIPT!!!
    public LogicScript logic;
    public AudioSource jumpEffect;
    public AudioSource deadEffect;
    public AudioSource music;

    public float flapStrength = 10;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Bird"; // changes the name of the bird game object to Flappy
        // This bird script is a component that we added to the bird game object. By default it can only communicate with the transform component and name component, not
        // any components that we manually added
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; // bird starts off as static (NOT MOVING)
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            jumpEffect.Play();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        // need this code so you cannot play while game over screen is up
        birdIsAlive = false;
        deadEffect.Play();
    }
}
