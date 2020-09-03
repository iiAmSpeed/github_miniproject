using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject cam;
    public Animator swordAnim;
    public GameObject player;
    public Transform weaponHolder;
    private Vector3 defaultScale;

    public bool hasSword;
    public bool blocking, attacking;

    void Start()
    {
        swordAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.Find("Camera");
        defaultScale = transform.localScale;
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
                transform.localScale = defaultScale;
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
        print(other.name);
        if (attacking)
        {
            if (other.gameObject.tag == "HellHound")
            {
                other.GetComponent<HellHound>().TakeDamage(20);
            }
            else if (other.gameObject.tag == "GiantSpider")
            {

                other.GetComponent<GiantSpider>().TakeDamage(20);
            }

            else if (other.gameObject.tag == "Minotaur" )
            {

                other.GetComponent<Minotaur>().TakeDamage(20);
            }

            else if (other.gameObject.tag == "Cyclops")
            {

                other.GetComponent<Cyclops>().TakeDamage(20);
            }
        }

        
    }
}
