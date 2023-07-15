using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to import the Text object type
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    // Start is called before the first frame update

    // Add this to run the function from unity itself
    [ContextMenu("Increase Score")] // NOW YOU CAN MANUALLY RUN FUNCTIONS BY HAND FOR TESTING, VERY USEFUL WHEN DEVELOPING
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString(); // scoreText is a Text object, but has a string property .text
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // the input is literally the file name for a scene
        // we are using the current scene so that is why we use SceneManager.GetActiveScene, we simply want to use the initial scene when we press the Run Code button
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public int calculateDifficulty()
    {
        return playerScore / 10;
    }

    public bool divisibleByTen()
    {
        if(playerScore%10.0 == 0)
        {
            return true;
        }
        return false;
    }
}


// Basically everything miscellanious is written in the logic script, all the other scripts are very small and only do one task.
