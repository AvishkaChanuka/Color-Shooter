using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3[] rotateDirection;
    [SerializeField] Transform bulletSpawnPosition;
    [SerializeField] GameObject[] bullets;
    [SerializeField] Slider playerHealthSlider;
    private int playerHealth = 5;
    void Start()
    {
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotatePlayer(rotateDirection[0]);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotatePlayer(rotateDirection[1]);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotatePlayer(rotateDirection[2]);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotatePlayer(rotateDirection[3]);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(bullets[0], bulletSpawnPosition.position, transform.rotation);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(bullets[1], bulletSpawnPosition.position, transform.rotation);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(bullets[2], bulletSpawnPosition.position, transform.rotation);
        }

        if (playerHealth <= 0)
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.GameOver();
        }
    }

    void rotatePlayer(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(direction);
    }

    public void Health(int health)
    {
        playerHealth += health;
        playerHealthSlider.value = playerHealth;
        //Debug.Log(playerHealth);
    }

}
