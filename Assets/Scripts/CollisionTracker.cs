using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollisionTracker : MonoBehaviour
{
    private PlayerController playerControllerScript;

    private int playerHealth;
    public TextMeshProUGUI damageText;

    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GetComponent<PlayerController>();
        playerHealth = 3;
        damageText.text = "Health: " + playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHealth(int damage)
    {
        playerHealth -= damage;
        damageText.text = "Health: " + playerHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //update health
            UpdateHealth(1);
            Debug.Log("You took damage");
        }
        if (collision.gameObject.CompareTag("Kill Zone"))
        {
            playerControllerScript.enabled = false;
            gameOverText.text = "You Fell Off!";
            Debug.Log("Game Over");
        }
    }
}
