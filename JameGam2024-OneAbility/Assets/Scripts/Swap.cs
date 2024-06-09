using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public GameObject beanPrefab;
    public GameObject mommaPrefab;
    public Sprite mommaCard;
    public Sprite beanCard;
    private SpriteRenderer cardRenderer;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cardRenderer = GetComponent<SpriteRenderer>();
        checkCard();
    }

    private void OnTriggerEnter2D(Collider2D collider)
        {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Swapped!");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(SwapCoolDown());
            StartCoroutine(swapSequence());
        }
       
        }
    IEnumerator swapSequence()
    {
        float originalSpeed = player.GetComponent<MovePlayer>().speed;// store OG movement speed
        player.GetComponent<MovePlayer>().speed = 0; // stop movement
        //Start animation(maybe yield waitforseconds to ensure animation starts) TODO

        //Instantiate Cat that doesnt exist
        if(player.name == "BeanPlayer" || player.name == "BeanPlayer(Clone)")
        {
            
            //store players position
            Vector3 tempPos = player.transform.position;
            Destroy(player);
            //make new cat as p
            player = Instantiate(mommaPrefab, tempPos, Quaternion.identity);
            //   camera.GetComponent<GameController>().swapCat(player);//tell camera who to focus on + switch flag.

            //set card to Bean Card
            cardRenderer.sprite = beanCard;

        }
        else
        {
            //store players position
            Vector3 tempPos = player.transform.position;
            Destroy(player);
            //make new cat as p
            //public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
            player = Instantiate(beanPrefab, tempPos, Quaternion.identity);
            //camera.GetComponent<GameController>().swapCat(player);//tell camera who to focus on + switch flag.

            //set card to Momma Card
            cardRenderer.sprite = mommaCard;

        }
        
        /*
         * while(animation != finished){
         * yield return null
         * }
         */
        // end animation

        player.GetComponent<MovePlayer>().speed = originalSpeed;// return moving
        yield return null; //TEMP TO STOP ERROR!
    }
    IEnumerator SwapCoolDown()
    {
        int timer = 3;
        while(timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    void checkCard()
    {
        if (player.name == "BeanPlayer" || player.name == "BeanPlayer(Clone)")
        {

            cardRenderer.sprite = mommaCard;
        }
        else
        {
            cardRenderer.sprite = beanCard;
        }
    }
}
