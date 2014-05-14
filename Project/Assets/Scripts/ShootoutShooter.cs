using UnityEngine;
using System.Collections;

public class ShootoutShooter :
    MonoBehaviour
{
    public ShootoutCounter clipCounter;

    void Start()
    {
    }

    void Update()
    {
        if (!clipCounter.Reloading)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (clipCounter.Clip < 0)
                {
                    clipCounter.Reload();
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
                    clipCounter.Dec();
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                clipCounter.Reload();
            }
        }
    }
}

