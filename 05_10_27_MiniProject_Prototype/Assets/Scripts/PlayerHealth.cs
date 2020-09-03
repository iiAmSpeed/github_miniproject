using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Playerhealth = 100;
    private float enemycollidingTime = 0f;
    public GameObject sword;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.UpdateHealth(Playerhealth);
        if(Playerhealth <= 0)
        {
            GameManager.instance.DeadPlayer();
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        sword = GameObject.Find("Sword");
        Sword swordScript = sword.GetComponent<Sword>();
        if (collision.gameObject.tag == "HellHound" && swordScript.blocking == false)
        {
            if (enemycollidingTime < 0.5f)
            {
                enemycollidingTime += Time.deltaTime;

            }

            else
            {
                Playerhealth -= 20;
                enemycollidingTime = 0f;
            }
        }

       else if (collision.gameObject.tag == "Minotaur" && swordScript.blocking == false)
        {
            if (enemycollidingTime < 0.5f)
            {
                enemycollidingTime += Time.deltaTime;

            }

            else
            {
                Playerhealth -= 80;
                enemycollidingTime = 0f;
            }
        }

        else if (collision.gameObject.tag == "GiantSpider" && swordScript.blocking == false)
        {
            if (enemycollidingTime < 0.5f)
            {
                enemycollidingTime += Time.deltaTime;

            }

            else
            {
                Playerhealth -= 30;
                enemycollidingTime = 0f;
            }
        }

        else if (collision.gameObject.tag == "Cyclops" && swordScript.blocking == false)
        {
            if (enemycollidingTime < 0.5f)
            {
                enemycollidingTime += Time.deltaTime;

            }

            else
            {
                Playerhealth -= 80;
                enemycollidingTime = 0f;
            }
        }
    }
}
