using UnityEngine;
using System.Collections;

public class FroggerStart : 
    MonoBehaviour
{
    public float GameTimer = 3000;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject trafficSpawner = Resources.Load<GameObject>("TrafficSpawner");
        GameObject checkPoint = Resources.Load<GameObject>("Checkpoint");

        int cpWeight = 0;
        int trafficWeight = 0;
        int checkPoints = 4;
        bool cpPrev = false;
        for (int lane = -19; lane < 20; lane += 2)
        {
            GameObject obj;
            int choice = Random.Range(1, 8) + cpWeight;
            if (choice < 7 || checkPoints == 0 || trafficWeight <= 2)
            {
                int speed = Random.Range(1, 10);
                // Place Upward Spawner

                float cooldown = 1.25f;
                switch (speed)
                {
                    case 10:
                    case 9:
                    case 8:
                        cooldown = 0.75f;
                        break;
                    case 7:
                    case 6:
                    case 5:
                    case 4:
                        cooldown = 1;
                        break;
                    case 3:
                    case 2:
                    default:
                        break;
                }
                
                obj = Instantiate(trafficSpawner) as GameObject;
                if (choice <= 3 || ((checkPoints == 0 || trafficWeight <= 2) && choice / 4 < 1))
                {
                    obj.GetComponent<TrafficSpawner>().TrafficVelocity = 5 * speed;
                    obj.GetComponent<TrafficSpawner>().CooldownMin = cooldown;
                    obj.GetComponent<TrafficSpawner>().CooldownMax = cooldown + 1;
                    obj.transform.position = new Vector3(lane, obj.transform.position.y, -15);
                }
                else
                {
                    obj.GetComponent<TrafficSpawner>().TrafficVelocity = -5 * speed;
                    obj.GetComponent<TrafficSpawner>().CooldownMin = cooldown;
                    obj.GetComponent<TrafficSpawner>().CooldownMax = cooldown + 1;
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
                --checkPoints;
            }
            else
            {
                lane -= 2;
            }
        }
    }

    void Update()
    {
        //GameTimer -= Time.deltaTime;
        //GameObject.Find("TimeDisplay").GetComponent<GUIText>().text = "Time: " + string.Format("{0:0.0}", (GameTimer));
        //if (GameTimer <= 0)
        //{
        //    Time.timeScale = 0;
        //}
    }
}
