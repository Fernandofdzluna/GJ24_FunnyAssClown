using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject payaso;
    public GameObject spawnPayaso;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null) //If there is no other instance
        {
            Instance = this; //if not, set instance to this
        }
        else if (Instance != this) //If instance already exist and it's not this:
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); //Sets this to not be destroyed when reloding scene

        inst = this;
    }

    public static GameManager inst;  // Un objeto del mismo tipo que este script, accesible desde cualquier otro lado
    public int tilesCrossed;

    [Header("Set in Inspector")] //Referencias al GameObject Player (jugador) y  cuadros de texto 
    public GameObject player;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start() //Actualizamos desde el comienzo los textos (Para que no aparezcan a solo cuando obtienes puntos)
    {
        scoreText.text = "Score: " + tilesCrossed;
    }

    public void ScoreManagement() // Aumenta la puntuacion, actualiza el texto y aumenta la velocidad con cada casilla avanzada (Es llamado desde GroundTile_Script)
    {
        tilesCrossed += 1;
        scoreText.text = "Score: " + tilesCrossed;
    }

    bool tocandoSuelo = true;

    public bool IsGrounded()
    {
        tocandoSuelo = true;

        if (payaso.transform.position.y > 0.7)
        {
            tocandoSuelo = false;
        }
        return tocandoSuelo;
    }

    bool enSuelo = true;
    private void Update()
    {
        enSuelo = IsGrounded();

        if (enSuelo == false)
        {
            payaso.transform.position = spawnPayaso.transform.position;
        }
    }
}
