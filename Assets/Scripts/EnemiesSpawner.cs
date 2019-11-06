using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{

    [SerializeField] List<ConfigWave> configwaves;
    [SerializeField] bool loopWaves = false;
    int startwave = 0;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllEnemies());
        } while (loopWaves);
    }
    IEnumerator SpawnAllEnemies()
    {
        for(int i = startwave; i <configwaves.Count; i++)
        {
            yield return StartCoroutine(SpawnEnemies(configwaves[i]));
        }
    }
    IEnumerator SpawnEnemies(ConfigWave cur)
    {
        for(int number = 0; number < cur.GetNumberOfEnemies();number++)
        {
            var newEnemy = Instantiate(
                cur.GetEnemiesPrefab(),
                cur.GetPathPrefab()[0].transform.position,
                Quaternion.identity
                )as GameObject;
            newEnemy.GetComponent<EnemiesPath>().GetConfigWave(cur);
            yield return new WaitForSeconds(cur.GetTimeBetWeenRespawn());
        }
    }
}
