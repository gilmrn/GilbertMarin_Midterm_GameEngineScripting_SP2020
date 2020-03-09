using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScript : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish Line"))
        {
            playerControllerScript.enabled = false;
            winText.text = "You Win!";
            Debug.Log("You Win!");
        }
    }
}
