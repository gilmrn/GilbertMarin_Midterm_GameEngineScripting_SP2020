using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public TextMeshProUGUI countdownText;

    private int timerCountdown = 3;

    IEnumerator CountdownToStart()
    {
        playerControllerScript.enabled = false;
        while (timerCountdown > 0)
        {
            countdownText.text = timerCountdown.ToString();
            yield return new WaitForSeconds(1f);
            timerCountdown--;
            playerControllerScript.enabled = false;
        }

        countdownText.text = "Go!";
        playerControllerScript.enabled = true;

        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GetComponent<PlayerController>();
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
