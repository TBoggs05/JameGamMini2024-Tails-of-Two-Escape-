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

    public static GameController instance;
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
        IsBean = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Momma>().enabled = false;
        GetComponent<Bean>().enabled = true;
    }


    public void swapCat()
    {
        //flag checker
        IsBean = !IsBean;
        if (IsBean)
        {
            //change sprite
            spriteRenderer.sprite = beanSprite;
            //set bean script to active and momma script to not active.
            GetComponent<Momma>().enabled = false;
            GetComponent<Bean>().enabled = true;
        }
        else
        {
            //change sprite
            spriteRenderer.sprite = mommaSprite;
            //set momma script to active and bean script to not active.
            GetComponent<Momma>().enabled = true;
            GetComponent<Bean>().enabled = false;
        }
    }
}






