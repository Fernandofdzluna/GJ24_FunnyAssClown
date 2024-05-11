using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GroundSpawner Spawner;
    private void OnTriggerEnter(Collider other) //Solo hay una cosa que pueda salir del trigger, el jugador por eso no hay "if", al salir llama al metodo del Game Manager , al de GroundSpawner  y destruye la tile 2s despues
    {
        GameManager.inst.ScoreManagement();
        int random = Random.Range(0, 3);
        Spawner.SpawnTile(random);
        Destroy(gameObject, 10f);
    }
}
