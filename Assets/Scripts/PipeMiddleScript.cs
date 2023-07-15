using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic; // you can put a script in a script, basically how scripts interact with each other!!
    // Start is called before the first frame update
    public AudioSource pointEffect;
    public AudioSource tenPointEffect;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // this is the equivalent of dragging and dropping the logic script into the pipe middle object, except this is done at run time
        // the reason why we do this is because the pipe middles do not exist before the game is ran, these pipes are spawned which happen AFTER the game is ran, which is why we must only attach the script AT THE MOMENT THEY SPAWN IN!!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            // must increase point before determining sound
            logic.addScore(1);
            if (logic.divisibleByTen())
            {
                tenPointEffect.Play();
            } else
            {
                pointEffect.Play();
            }
        }
    }
}
