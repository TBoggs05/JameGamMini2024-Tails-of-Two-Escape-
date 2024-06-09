using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool IsBean;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite mommaSprite;
    [SerializeField] private Sprite beanSprite;
    [SerializeField] private Rigidbody2D rb;
    public static GameController instance;
    public short lives;
    public GameObject player;
    public GameObject playerStartPoint;
    public AudioManager audioManager;
    public GameObject controlScreen;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
       
        //initially start as bean.
        lives = 9;
        IsBean = true;
    }

    //BROKEN
    public void swapCat(GameObject p)
    {
        //flag checker
        player = p;
        IsBean = !IsBean;
    }
    public void takeDamage()
    {
        if(lives-1 <= 0)
        {
            //loseCase
        }
        else
        {
            lives--;
        }
    }

    public void CheckCards()
    {
        GameObject[] c = GameObject.FindGameObjectsWithTag("Swap");
        foreach(GameObject g in c)
        {
            g.GetComponent<Swap>().checkCard();
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            int meowNum = Random.Range(1, 5);
            Debug.Log("MEOW" + meowNum.ToString());
            audioManager.Play("Meow" + meowNum.ToString());
        }
        if (Input.GetKey(KeyCode.X))
        {
            //View Controls.
            controlScreen.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            controlScreen.SetActive(false);
        }
    }
}






