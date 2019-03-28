using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Vector3 start;
    public GameObject platform;
    public GameObject point;

    Vector3 lastPos, platformSize;

    void Start()
    {
        lastPos = start;
        platformSize = platform.transform.localScale;
        
        for (var i = 0; i < 20; i++)
        {
            Spawn();
        }

        //Interval is set to 0.4f because that's gonna keep
        //the same amount of platforms all the time
        InvokeRepeating("AutoSpawnIfGameStarted", 0f, 0.40f);
    }

    void Update()
    {
        if (GameManager.instance.gameOver) CancelInvoke("Spawn");
    }

    void Spawn()
    {
        Vector3 pos = lastPos;

        //Randomly select x or z axis to spawn platform
        int xOrZ = Random.Range(0, 2);
        if (xOrZ == 0)
        {
            pos.x += platformSize.x;
        }
        else
        {
            pos.z += platformSize.z;
        }
        
        //Spawn a platform
        Instantiate(platform, pos, Quaternion.identity);

        //Will the platform have a collectible on it?
        int willCollectibleSpawn = Random.Range(0, 5);
        if (willCollectibleSpawn == 0)
        {
            Instantiate(point, new Vector3(pos.x, pos.y + 1.2f, pos.z), Quaternion.identity);
        }

        //Store the position
        lastPos = pos;
    }

    void AutoSpawnIfGameStarted()
    {
        if (GameManager.instance.started && !GameManager.instance.gameOver) Spawn();
    }
}
