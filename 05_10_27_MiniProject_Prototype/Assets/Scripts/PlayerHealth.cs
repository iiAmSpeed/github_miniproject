using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Playerhealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.UpdateHealth(Playerhealth);
    }
        
    public void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "HellHound")
        {
            Playerhealth -= 20;

        }
    }

    IEnumerator Wait()
    {
        Playerhealth -= 20;
        yield return new WaitForSeconds(2);
        
    }
}
