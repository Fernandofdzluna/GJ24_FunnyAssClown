using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SueloAsesino : MonoBehaviour
{
    public GameObject fadeEffect; 
    public bool final = false;
    public float timeRemaining;

    private void Start()
    {
        timeRemaining = 4;
    }

    private void Update()
    {
        if (final == true)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                GoToScene("EndingScene");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        fadeEffect.SetActive(true);
        final = true;
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
