using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Camera cam;
    public Animator swordAnim;
    public GameObject player;
    public Transform weaponHolder;

    public bool hasSword;
    private bool blocking, attacking;

    void Start()
    {
        swordAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.FindObjectOfType<Camera>();

    }
    void Update()
    {
        AttackAnimation();


    }

    private void AttackAnimation()
    {
        if (hasSword)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                cam.GetComponent<WeaponPickUp>().hasWeapon = false;

                hasSword = false;
                transform.GetComponent<Animator>().enabled = false;
                transform.GetComponent<Collider>().isTrigger = false;
                transform.GetComponent<Rigidbody>().useGravity = true;
                transform.GetComponent<Rigidbody>().freezeRotation = false;
                transform.parent = null;
            }
            if (Input.GetMouseButtonDown(0) && !blocking)
            {
                swordAnim.SetBool("isAttack", true);
                attacking = true;
                player.GetComponent<PlayerMovement>().attacking = true;
            }
            else if (Input.GetMouseButtonDown(1) && !attacking)
            {
                swordAnim.SetBool("isBlock", true);
                blocking = true;
                player.GetComponent<PlayerMovement>().blocking = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                swordAnim.SetBool("isBlock", false);
                blocking = false;
                player.GetComponent<PlayerMovement>().blocking = false;
            }
            if (attacking)
            {
                if (swordAnim.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack"))
                {
                    swordAnim.SetBool("isAttack", false);
                    attacking = false;
                    player.GetComponent<PlayerMovement>().attacking = false;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HellHound" && attacking)
        {

            other.GetComponent<HellHound>().TakeDamage(60);
        }
    }
}
