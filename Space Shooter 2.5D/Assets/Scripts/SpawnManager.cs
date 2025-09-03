using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject TSPowerUpPrefab;
    [SerializeField]
    private GameObject PowerUpContainer;
    [SerializeField]
    private GameObject SpeedPowerUpPrefab;
    [SerializeField]
    private GameObject ShieldPowerUpPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(TSPowerUpSpawnRoutine());
        StartCoroutine(SpeedPowerUpSpawnRoutine());
        StartCoroutine(ShieldPowerUpSpawnRoutine());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpawnRoutine()
    {
        bool spawn=true;
        while (spawn)
        {   
            if(player ==null)
            {
               spawn = false; // Stop spawning if player is dead
                yield break;
            }
            else
            {
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-10f, 10f), 6, 0), Quaternion.identity);
                enemy.transform.parent = enemyContainer.transform; // Set the parent of the enemy to the enemyContainer
            }
            yield return new WaitForSeconds(3f); // Wait for 5 seconds before spawning the next enemy
        }
    }
    IEnumerator TSPowerUpSpawnRoutine()
    {
        bool spawn = true;
        while (spawn)
        {
            if (player == null)
            {
                spawn = false; //
            }
            else
            {
                GameObject powerUp = Instantiate(TSPowerUpPrefab, new Vector3(Random.Range(-10f, 10f), 6, 0), Quaternion.identity);
                powerUp.transform.parent = PowerUpContainer.transform; // Set the parent of the power-up to the enemyContainer
              
            }

            yield return new WaitForSeconds(Random.Range(3f, 8f)); // Wait for a random time between 3 and 8 seconds
        }
    }
    IEnumerator SpeedPowerUpSpawnRoutine()
    {
        bool spawn = true;
        while (spawn)
        {
            if (player == null)
            {
                spawn = false; //
            }
            else
            {
                GameObject powerUp = Instantiate(SpeedPowerUpPrefab, new Vector3(Random.Range(-10f, 10f), 6, 0), Quaternion.identity);
                powerUp.transform.parent = PowerUpContainer.transform; // Set the parent of the power-up to the enemyContainer

            }

            yield return new WaitForSeconds(Random.Range(3f, 8f)); // Wait for a random time between 3 and 8 seconds
        }
    }
    IEnumerator ShieldPowerUpSpawnRoutine()
    {
        bool spawn = true;
        while (spawn)
        {
            if (player == null)
            {
                spawn = false; // Stop spawning if player is dead
                yield break;
            }
            else
            {
                GameObject powerUp = Instantiate(ShieldPowerUpPrefab, new Vector3(Random.Range(-10f, 10f), 6, 0), Quaternion.identity);
                powerUp.transform.parent = PowerUpContainer.transform; // Set the parent of the power-up to the enemyContainer
            }
            yield return new WaitForSeconds(Random.Range(3f, 8f)); // Wait for a random time between 3 and 8 seconds
        }
    }
    
}
