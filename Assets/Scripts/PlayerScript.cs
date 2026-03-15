using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    public float playerSpeed = 5f;
    
    public int totalKeys = 1;               //1 Key need to pass this level
    private int keysCollected = 0;

    public GameObject finish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        if (collision.CompareTag("key"))
        {
            keysCollected++;                //Will increase +1 when key collected
            Destroy(collision.gameObject);  //The key is no longer on screen
            Debug.Log("The key has been collected.");

            if (keysCollected >= totalKeys)
            {
                UnlockFinish();
            }
        }

        //Destroys player object when finish is touched
        if (collision.gameObject == finish && keysCollected >= totalKeys)
        {
            Debug.Log("Player has reached the finish!");
            Destroy(gameObject);
        }
    }

    private void UnlockFinish()
    {
        if (finish != null)
        {
            //Change Wall Color from red to green
            SpriteRenderer sprite = finish.GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = Color.green;
            }

            //Ensures that the finish is open when the player makes collisions with all keys.
            Collider2D collide = finish.GetComponent<Collider2D>();
            if (collide != null)
            {
                collide.isTrigger = true;
            }

            Debug.Log("Finish unlocked!");
        }
    }
}
