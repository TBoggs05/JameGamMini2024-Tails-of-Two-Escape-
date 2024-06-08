using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

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


    public void swapCat(GameObject p)
    {
        GetComponent<CameraController>().ChangeTarget(p);
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
}






