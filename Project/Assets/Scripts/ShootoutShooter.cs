using UnityEngine;
using System.Collections;

public class ShootoutShooter :
    MonoBehaviour
{
    public ShootoutCounter ClipCounter;
    public GameObject Crosshair;
    public float GameTimer = 30;
    
    public int score;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        GameTimer -= Time.deltaTime;
        GameObject.Find("TimeDisplay").GetComponent<GUIText>().text = "Time: " + string.Format("{0:0.0}", (GameTimer));
        if (GameTimer <= 0)
        {
            Time.timeScale = 0;
        }

        Crosshair.transform.position = new Vector3(12 * (Input.mousePosition.x / Screen.width) - 6, Input.mousePosition.y / Screen.height * 5, Input.mousePosition.y / Screen.height * 5  - 4);
        if (!ClipCounter.Reloading)
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
            {
                if (ClipCounter.Clip <= 0)
                {
                    ClipCounter.Reload();
                }
                else
                {
                    Vector3 tomatoPos = new Vector3(12 * (Input.mousePosition.x / Screen.width) - 6, 2, -8);
                    GameObject tomato = Instantiate(Resources.Load<GameObject>("Tomato"), tomatoPos, Quaternion.identity) as GameObject;
                    float pitch = (Input.mousePosition.y / Screen.height) * 10;
                    if (pitch <= 2)
                        pitch = 0;
                    tomato.rigidbody.velocity = new Vector3(0, pitch, 10);
                    Destroy(tomato, 5);
                    ClipCounter.Dec();
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                ClipCounter.Reload();
            }
        }
    }
}

