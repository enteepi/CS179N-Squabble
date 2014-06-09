using UnityEngine;
using System.Collections;


public class ShootoutTarget :
    MonoBehaviour
{
    public float Length;
    public float Speed;
    public bool IsTarget;

    Vector3 origin;

    public float DistanceTravelled
    {
        get { return transform.position.magnitude - origin.magnitude; }
    }

    void Start()
    {
        origin = transform.position;
        GetComponent<Animator>().SetBool("moving", true);
    }

    void Update()
    {
        if (transform.position.magnitude - origin.magnitude >= Length)
            Reset();

        if(Time.timeScale != 0)
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Arrow")
        {
            if (IsTarget)
            {
                GameObject hitPart = Instantiate(Resources.Load<GameObject>("sheephit")) as GameObject;
                hitPart.transform.position = this.transform.position;
                Reset();
                Destroy(hitPart, 1);
                Destroy(collider);
            }
            else
            {
                // GAME OVER
                GameObject hitPart = Instantiate(Resources.Load<GameObject>("squubhit")) as GameObject;
                hitPart.transform.position = this.transform.position;
                Reset();
                Destroy(hitPart, 1);
                Destroy(collider);
                Time.timeScale = 0;
            }
        }
    }
    
    public void Reset()
    {
        Speed = 0f;
        transform.position = origin;
        //cooldown = Random.Range(CooldownMax, CooldownMin);
    }
}

