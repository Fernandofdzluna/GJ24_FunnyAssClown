using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner groundSpawner;
    public GameObject[] surfaceTile;

    private Transform lastBlock;
    public bool generatingTiles;

    bool primerosSuelos = false;
    private int m_Count = 0;

    // Start is called before the first frame update

    private void Start() // al comienzo crea 14 tiles, las 2 primeras sin obstaculos ni monedas
    {
        lastBlock = transform;
        if (this.gameObject.CompareTag("SueloPadre") && primerosSuelos == false)
        {
            for (int i = 0; i < 6; i++)
            {
                int random = Random.Range(0, 3);
                SpawnTile(random);
            }

            primerosSuelos = true;
        }
    }
    public void SpawnTile(int tileType) // metodo que crea las tiles, crea cada tile justo despues de la otra , echar ojo al prefab, tiene un hijo que es directamente el punto de spawn de la siguiente tile
    {
        m_Count++;
        GameObject temp = Instantiate(surfaceTile[tileType], lastBlock.GetChild(0).transform.position, lastBlock.GetChild(0).transform.rotation);
        temp.name = m_Count.ToString();
        temp.GetComponent<GroundTile>().Spawner = this;
        lastBlock = temp.transform;
    }

}