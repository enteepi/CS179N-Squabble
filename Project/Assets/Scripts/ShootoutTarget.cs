using UnityEngine;
using System.Collections;


public class ShootoutTarget :
    MonoBehaviour
{
    public ShootoutTarget Partner;
    public float CooldownMin;
    public float CooldownMax;
    public float SpeedMin;
    public float SpeedMax;
    public float Length;

    float cooldown;
    float speed;
    Vector3 origin;

    void Start()
    {
        origin = transform.position;
        GetComponent<Animator>().SetBool("moving", true);
    }

    void Update()
    {
        if (cooldown <= 0)
        {
            if (speed == 0 && Partner.speed == 0)
            {
                speed = Random.Range(SpeedMin, SpeedMax);
            }
            else if (transform.position.magnitude - origin.magnitude >= Length)
            {
                Reset();
            }
            else
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            }
        }
        else
        {
            cooldown -= Time.fixedDeltaTime;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Arrow")
        {
            GameObject hitPart = Instantiate(Resources.Load<GameObject>("squubhit")) as GameObject;
            hitPart.transform.position = this.transform.position;
            Reset();
            Destroy(hitPart, 1);
            Destroy(collider);
        }
    }
    
    public void Reset()
    {
        speed = 0f;
        transform.position = origin;
        cooldown = Random.Range(CooldownMax, CooldownMin);
    }
}

