using UnityEngine;

public class BombSpawnerScript : MonoBehaviour
{
    public GameObject bomb;
    public float spawnRate = 2f;
    private float timer = 0f;

    public float heightOffset = 3.5f;

    void Update()
    {
        //Has enough time passed to spawn a new bomb
        if (timer < spawnRate)
        {
            //Increases the timer
            timer += Time.deltaTime;
        }
        else
        {
            //spawn a new bomb and reset the timer.
            SpawnBomb();
            timer = 0f;
        }
    }

    void SpawnBomb()
    {
        //Provides a maximum and minimum height in which bombs will spawn
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(
            bomb, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}