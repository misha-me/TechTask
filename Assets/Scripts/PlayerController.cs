using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int playerMaterialIndex;
    private int playerScore;
    private float playerSpeed = 0.5f; // const ?
    private int xBorder = 2;

    GameManager gameManager;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerMaterialIndex = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                // Extract calculation to the variable
                transform.Translate(Vector3.right * touch.deltaPosition.x * Time.deltaTime * playerSpeed);

                if (transform.position.x < -xBorder)
                    transform.position = new Vector3(-xBorder, transform.position.y, transform.position.z);
                if (transform.position.x > xBorder)
                    transform.position = new Vector3(xBorder, transform.position.y, transform.position.z);
            }
        }

        scoreText.text = "Score: " + playerScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Color Change"))
        {
            // Code Style
            playerMaterialIndex = other.GetComponent<ColorChange>().materialIndex;
            GetComponent<Renderer>().material = gameManager.materials[playerMaterialIndex];

            Destroy(other.gameObject);
        }
        else
        {
            // Code Style
            int otherMaterialIndex = other.gameObject.GetComponent<MoveToCamera>().materialIndex;

            if (otherMaterialIndex == playerMaterialIndex)
            {
                // Magic numbers
                if (playerScore < 10)
                {
                    //                                make const
                    //                                    \/
                    transform.localScale += Vector3.one / 10;
                    playerScore++;
                }
            }
            else if (otherMaterialIndex != playerMaterialIndex)
            {
                if (playerScore != 0)
                {
                    playerScore--;
                    //                                make const
                    //                                    \/
                    transform.localScale -= Vector3.one / 10;
                }
                else
                    gameManager.GameOver();
            }

            Destroy(other.gameObject);
        }
        
    }


}
