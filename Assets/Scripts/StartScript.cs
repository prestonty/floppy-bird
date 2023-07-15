using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public PipeSpawnerScript pipeSpawner;
    public BirdScript bird;
    public GameObject startMenu;
    public AudioSource startEffect;
    // Start is called before the first frame update
    void Start()
    {
        pipeSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PipeSpawnerScript>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    public void startGame()
    {
        // bird starts moving
        bird.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        pipeSpawner.spawnPipe(); // spawn first set of pipes immediately
        pipeSpawner.timer = 0; // i need timer to be zero because it cannot be counting in the background while the start menu is up or things will become buggy (either spawn immediately or with a delay)
        pipeSpawner.allowSpawning = true;
        startEffect.Play();

        startMenu.SetActive(false);
    }
}
