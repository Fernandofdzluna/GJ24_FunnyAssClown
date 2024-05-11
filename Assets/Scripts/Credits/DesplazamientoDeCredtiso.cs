using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesplazamientoDeCredtiso : MonoBehaviour
{
    public bool final = false;
    //public float speed = 10f;

    float tiempoDevorar = 4;
    float timeRemaining;
    // Start is called before the first frame update

    float velY = 1;

    private void Start()
    {
        timeRemaining = tiempoDevorar;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.y);
        if (transform.position.y >= 2300)
        {
            final = true;
        }

        if (final == false)
        {
            transform.position += new Vector3(0, velY, 0);
        }
        else if (final == true)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                GoToScene("MenuScene");
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            velY = velY + 3;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            velY = 1;
        }
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
