using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovementScript : MonoBehaviour
{
    private NavMeshAgent nav;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player =  GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);
    }

}
