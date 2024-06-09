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
        foreach(GameObject c in GameObject.FindGameObjectsWithTag("Swap"))
        {
            c.GetComponent<Swap>().checkCard();
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}






