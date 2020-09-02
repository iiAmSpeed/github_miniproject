using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject cam;
    public GameObject playerArm;
    public GameObject arrow;
    public Animator bowAnim;

    public bool hasBow;
    bool shot;

    float _charge;

    public float chargeMax;
    public float chargeRate;

    public Transform shootPoint;
    public Rigidbody arrowObj;

    private Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        ShootBow();
    }

    private void ShootBow()
    {
        if (hasBow)
        {
            arrow.SetActive(true);
            playerArm.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                cam.GetComponent<WeaponPickUp>().hasWeapon = false;

                hasBow = false;
                transform.GetComponent<Collider>().isTrigger = false;
                transform.GetComponent<Rigidbody>().useGravity = true;
                transform.GetComponent<Rigidbody>().freezeRotation = false;
                transform.parent = null;
                transform.localScale = defaultScale;
            }

            if(Input.GetMouseButton(0) && !shot)
            {
                if(_charge < chargeMax)
                {
                    bowAnim.SetBool("Pull", true);
                    _charge += Time.deltaTime * chargeRate;
                }
                else if(_charge >= chargeMax)
                {
                }

                if(Input.GetMouseButton(1))
                {
                    bowAnim.SetBool("Cancel", true);
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                StartCoroutine(ShootAnimation());
                Rigidbody arrow = Instantiate(arrowObj, shootPoint.position, Quaternion.LookRotation(shootPoint.forward)) as Rigidbody;
                arrow.AddForce(shootPoint.forward * _charge, ForceMode.Impulse);
                _charge = 0;

            }
        }
        else
        {
            arrow.SetActive(false);
            playerArm.SetActive(false);
        }
    }

    IEnumerator ShootAnimation()
    {
        shot = true;
        bowAnim.SetBool("Shoot", true);
        bowAnim.SetBool("Pull", false);
        bowAnim.SetBool("Cancel", false);

        yield return new WaitForSeconds(0.5f);

        bowAnim.SetBool("Shoot", false);
        shot = false;
    }
}
