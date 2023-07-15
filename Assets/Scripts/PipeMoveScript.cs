using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float initSpeed = 10;
    public float moveSpeed;
    public float deadZone = -45;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = calculateMoveSpeed();
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; // by multiplying by delta time, runs at same speed on different computers, does not rely on fps
        if(transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }

    public float calculateMoveSpeed()
    {
        return 10 + logic.calculateDifficulty();
    }
}
