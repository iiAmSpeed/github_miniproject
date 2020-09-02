using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSpiderScript : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(dist <= 3)
        {
            //slow movement code

        }
    }

}
