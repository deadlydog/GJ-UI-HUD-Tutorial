using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public float healthRatio;
    public float coinRatio;

    public Vector2 spawnTimeRange;

    public Vector2 spawnYRange;
    public Vector2 spawnXRange;

    private Coroutine spawnItemsHandler;

    public GameObject fireball;
    public GameObject heart;
    public GameObject coin;

    private void OnEnable()
    {
        spawnItemsHandler = StartCoroutine(SpawnItemsRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnItemsHandler);
    }

    private IEnumerator SpawnItemsRoutine()
    {
        while (true)
        {
            float timer = Random.Range(spawnTimeRange.x, spawnTimeRange.y);

            yield return new WaitForSeconds(timer);

            SpawnItem();
        }
    }
    
    
    private void SpawnItem()
    {
        float rand = Random.value;
        
        if (rand <= healthRatio)
        {
            Instantiate(heart, new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), Random.Range(spawnYRange.x, spawnYRange.y), 0), quaternion.identity);
        } else if (rand > healthRatio && rand <= healthRatio + coinRatio)
        {
            Instantiate(coin, new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), Random.Range(spawnYRange.x, spawnYRange.y), 0), quaternion.identity);
        }
        else
        {
            Instantiate(fireball, new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), Random.Range(spawnYRange.x, spawnYRange.y), 0), quaternion.identity);
        }
    }
}
