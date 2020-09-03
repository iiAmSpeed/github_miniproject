using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int level = 0;
    public Text healthtxt;
    public static GameManager instance = null;
    public GameObject[] Spawn;
    private GameObject player;
    private bool pauseOn = false;

    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;


        }
        pauseUI.SetActive(false);
        int RandomSpawn = Random.Range(0, 3);
        player = GameObject.Find("Player");
        player.transform.position = Spawn[RandomSpawn].transform.position;
        player.transform.position = new Vector3(Spawn[RandomSpawn].transform.position.x, Spawn[RandomSpawn].transform.position.y + 2, Spawn[RandomSpawn].transform.position.z);
        level = PlayerPrefs.GetInt("MyValue");
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Input.GetKeyDown(KeyCode.Escape ) && pauseOn == false)
        {
            pauseUI.SetActive(true);
            pauseOn = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseOn == true)
        {
            pauseUI.SetActive(false);
            pauseOn = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            Time.timeScale = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("GameScene");
        }
        

    }

    public void UpdateHealth(int health)
    {
        healthtxt.text = "Health: " + health;
        
    }

    public void DeadPlayer()
    {
        SceneManager.LoadScene("Lose");
    }

    public void NextLevel()
    {
        Debug.Log(level);
        level++;
        PlayerPrefs.SetInt("MyValue", level);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("MyValue"));

        if (level == 3)
        {
            SceneManager.LoadScene("Win");
        }

        else if (level < 3)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
