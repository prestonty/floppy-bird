using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript bird;
    public AudioSource boundaryDeathEffect;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // i didnt want to duplicate the death sound effect here so i added a unique one :)
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.gameOver();
            bird.birdIsAlive = false;
            boundaryDeathEffect.Play();
        }
    }
}
