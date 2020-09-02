using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : MonoBehaviour
{
    public int enemyHealth = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int health)
    {
        enemyHealth -= health;
        
    }
    
    
}
