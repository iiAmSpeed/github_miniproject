using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Cam cam;
    public Transform weaponHolder;
    public Transform BowHolder;
    public GameObject player;
    public bool hasWeapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckWeapon();
    }

    void CheckWeapon()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, 100))
        {               
            if(hitInfo.transform.name == "Sword")
            {
                if(Input.GetKeyDown(KeyCode.E) && !hasWeapon)
                {
                    hasWeapon = true;
                    hitInfo.transform.GetComponent<Sword>().hasSword = true;
                    hitInfo.transform.GetComponent<Animator>().enabled = true;
                    hitInfo.transform.GetComponent<Collider>().isTrigger = true;
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<Rigidbody>().freezeRotation = true;
                    hitInfo.transform.parent = weaponHolder.transform;
                    hitInfo.transform.position = weaponHolder.transform.position;
                }
            }
            else if(hitInfo.transform.name == "Bow")
            {
                if (Input.GetKeyDown(KeyCode.E) && !hasWeapon)
                {
                    hasWeapon = true;
                    hitInfo.transform.GetComponent<Bow>().hasBow = true;
                    hitInfo.transform.GetComponent<Collider>().isTrigger = true;
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<Rigidbody>().freezeRotation = true;
                    hitInfo.transform.position = BowHolder.transform.position;
                    hitInfo.transform.parent = BowHolder.transform;
                    hitInfo.transform.forward = BowHolder.transform.forward;
                    hitInfo.transform.Rotate(new Vector3(-9, 0, 98));
                }
            }
        }
    }
}
