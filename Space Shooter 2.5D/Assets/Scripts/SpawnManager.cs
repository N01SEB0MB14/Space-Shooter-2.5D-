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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
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
}
