using UnityEngine;
using System.Collections;

public class FroggerStart : 
    MonoBehaviour
{
    public float GameTimer = 3000;

    void Start()
    {
        GameObject trafficSpawner = Resources.Load<GameObject>("TrafficSpawner");
        GameObject checkPoint = Resources.Load<GameObject>("Checkpoint");

        int cpWeight = 0;
        int trafficWeight = 0;
        bool cpPrev = false;
        for (int lane = -19; lane < 20; lane += 2)
        {
            GameObject obj;
            int choice = Random.Range(1, 8) + cpWeight;
            if (choice < 7)
            {
                // Place Upward Spawner
                obj = Instantiate(trafficSpawner) as GameObject;
                if (choice <= 3)
                {
                    obj.GetComponent<TrafficSpawner>().TrafficVelocity = 5;
                    obj.transform.position = new Vector3(lane, obj.transform.position.y, -15);
                }
                else
                {                
                    obj.GetComponent<TrafficSpawner>().TrafficVelocity = -5;
                    obj.transform.position = new Vector3(lane, obj.transform.position.y, 15);
                }
                ++cpWeight;
                ++trafficWeight;
                cpPrev = false;
            }
            else if (!cpPrev)
            {
                obj = Instantiate(checkPoint) as GameObject;
                obj.GetComponent<FroggerCheckpoint>().ScoreMult = trafficWeight;
                obj.transform.position = new Vector3(lane, obj.transform.position.y, obj.transform.position.z);
                cpWeight = 0;
                trafficWeight = 0;
                cpPrev = true;
            }
            else
            {
                lane -= 2;
            }
        }
    }

    void Update()
    {
        GameTimer -= Time.deltaTime;
        GameObject.Find("TimeDisplay").GetComponent<GUIText>().text = "Time: " + string.Format("{0:0.0}", (GameTimer));
        if (GameTimer <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
