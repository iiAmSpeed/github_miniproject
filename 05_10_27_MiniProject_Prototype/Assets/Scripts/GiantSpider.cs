using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSpider : MonoBehaviour
{
    public int enemyHealth = 80;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            GameManager.instance.NextLevel();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int health)
    {
        enemyHealth -= health;

    }
}
