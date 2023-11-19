using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerModel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnObjects;
    [SerializeField] private List<int> _spawnPairs;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Respawn").Count() == 0)
        {
            for (int i = 0; i < _spawnPairs.Count; i++)
            {
                for (int j = 0; j < _spawnPairs[i]; j++)
                {
                    Spawn(i);
                    Spawn(i);
                }
            }
        }
    }

    private void Spawn(int index)
    {
        Instantiate(_spawnObjects[index], new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f)), new Quaternion(0, 0, 0, 0));
    }
}
