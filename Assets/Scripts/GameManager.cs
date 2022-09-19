using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Material> materials;
    public SpawnerScript spawner;

    public GameObject gameOverScreen;
    private bool gameOver;

    IEnumerator StartGame()
    {
        int i = 1;
        int materialIndex;

        while (!gameOver)
        {

            // Magic Numbers
            foreach (var row in spawner.rows)
            {
                materialIndex = Random.Range(0, 3);
                spawner.Spawn(0, 5, materialIndex, row);
            }

            // Wtf???
            if (i % 2 == 0)
            {
                materialIndex = Random.Range(0, 3);
                                                  // --- ? What is it? Extract to variable? New?
                // row = spawner.rows[1] + new Vector3(0, 0, -15);
                // spawner.Spawn(1, 1, materialIndex, row);

                spawner.Spawn(1, 1, materialIndex, spawner.rows[1] + new Vector3(0, 0, -15));
            }

            i++;

            // Why do we need this?
            yield return new WaitForSeconds(5);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        StartCoroutine(StartGame());
    }


    

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over!");
    }
}
