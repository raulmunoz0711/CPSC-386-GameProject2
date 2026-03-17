using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float playerSpeed = 5f;
    
    public int totalKeys;               //Key need to pass this level
    private int keysCollected = 0;

    public GameObject finish;
    public TextLogic uiLogic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Changes the total of key required to exit level. Must have key tag.
        totalKeys = GameObject.FindGameObjectsWithTag("key").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Player Input System
        Vector2 move = Vector2.zero;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) move.y = 1;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) move.y = -1;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) move.x = -1;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) move.x = 1;

        transform.Translate(move * playerSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collides with gameObject that has tag key
        if (collision.CompareTag("key"))
        {
            keysCollected++;                //Will increase +1 when key collected
            Destroy(collision.gameObject);  //The key is no longer on screen
            
            //Will log that key that has been collected
            Debug.Log("A key has been collected.");

            //Once keys collected is equal to keys on map, finish is unlocked
            if (keysCollected >= totalKeys)
            {
                UnlockFinish();
            }
        }

        //Destroys player object when finish is touched
        if (collision.gameObject == finish && keysCollected >= totalKeys)
        {
            Debug.Log("Player has reached the finish!");
            
            if (uiLogic != null)
                uiLogic.ShowLevelComplete();

            Destroy(gameObject);
        }
    }

    private void UnlockFinish()
    {   //If finish is open
        if (finish != null)
        {
            //Change Wall Color from red to green
            SpriteRenderer finishBox = finish.GetComponent<SpriteRenderer>();
            if (finishBox != null)
            {
                finishBox.color = Color.green;
            }

            //Player can complete the level by running into box
            Collider2D collide = finish.GetComponent<Collider2D>();
            if (collide != null)
            {
                collide.isTrigger = true;
            }

            Debug.Log("Finish unlocked!");
        }
    }
}
