using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

    public GameObject[] chunkPrefabs;

    private Transform playerTransform;
    private float spawnZ = 20.0f;
    private float chunkLenght = 24.0f;
    private float saveZone = 70.0f;
    private int amnChunksOnScreen = 6;
    private int lastPrefabIndex = 0;


    private List<GameObject> activeChunks;

    // Use this for initialization
    private void Start () {
        activeChunks = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnChunksOnScreen; i++)
        {
            if( i < 2)
            {
                SpawnChunk(0);
            }
            SpawnChunk ();    
        }
    }

    // Update is called once per frame
    private void Update ()
    {
		if (playerTransform.position.z - saveZone > (spawnZ - amnChunksOnScreen * chunkLenght))
        {
            SpawnChunk ();
            DeleteChunk();
        }
	}

    private void SpawnChunk (int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(chunkPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(chunkPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += chunkLenght;
        activeChunks.Add (go);
    }
    
    private void DeleteChunk()
    {
        Destroy(activeChunks [0]);
        activeChunks.RemoveAt (0);
    }

    private int RandomPrefabIndex()
    {
        if (chunkPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, chunkPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    
}
