using UnityEngine;

public class BombMovementScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        //Bomb position is updated to move left at the specified speed and making sure it is speed per second
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Deletes bomb after it moves off screen
        if (transform.position.x < -25f)
        {
            //Console visual of bomb being deleted
            Debug.Log("Bomb Deleted");
            Destroy(gameObject);
        }
    }
}