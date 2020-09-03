using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemySpawner;
    public GameObject[] boss;
    public string enemyCategory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if (enemyCategory == "common")
            {
                Instantiate(enemy, enemySpawner.transform.position, Quaternion.identity);
                Instantiate(enemy, enemySpawner.transform.position, Quaternion.identity);
                Instantiate(enemy, enemySpawner.transform.position, Quaternion.identity);
            }

            else if (enemyCategory != "common" && GameManager.instance.level == 2)
            {
                print("spawn cyclops");
                Instantiate(boss[2], enemySpawner.transform.position, Quaternion.identity);
            }

            else if (enemyCategory != "common" && GameManager.instance.level == 1)
            {
                print("spawn giant spider");
                Instantiate(boss[1], enemySpawner.transform.position, Quaternion.identity);
            }

            else if(enemyCategory != "common" && GameManager.instance.level == 0)
            {
                print("spawn minotaur");
                Instantiate(boss[0], enemySpawner.transform.position, Quaternion.identity);
            }

        }
    }
    
}
