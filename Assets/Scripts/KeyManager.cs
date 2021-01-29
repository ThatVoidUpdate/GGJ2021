using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject Key;
    public KeySpawn[] Keyspawns;
    // Start is called before the first frame update
    void Start()
    {
        Keyspawns = FindObjectsOfType<KeySpawn>();
        Transform KeySpawnLocation = Keyspawns[Random.Range(0, Keyspawns.Length)].transform;
        GameObject key = Instantiate(Key, KeySpawnLocation.position, Quaternion.identity);
        key.GetComponent<Keys>().GameWon.AddListener(FindObjectOfType<GameManager>().WonGame);

        FindObjectOfType<Timer>().GameLost.AddListener(FindObjectOfType<GameManager>().LostGame);
    }
}
