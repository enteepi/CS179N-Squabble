using UnityEngine;
using System.Collections;

public class TrafficSpawner : 
    MonoBehaviour 
{
    public float TrafficVelocity;
    public int CarChance;
    public int BusChance;
    public float CooldownMin;
    public float CooldownMax;
    
    float cooldown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            int maxChance = CarChance + BusChance;
            if (Random.Range(1, maxChance + 1) > CarChance)
                SpawnBus();
            else
                SpawnCar();
        }
	}

    void SpawnCar() {
        GameObject car = Instantiate(Resources.Load<GameObject>("Car")) as GameObject;

        car.transform.position = transform.position;
        car.transform.parent = transform;
        car.rigidbody.velocity = new Vector3(0, 0, TrafficVelocity);
        Destroy(car, 10);
        
        cooldown = Random.Range(CooldownMin, CooldownMax);
    }


    void SpawnBus()
    {
        GameObject bus = Instantiate(Resources.Load<GameObject>("Bus")) as GameObject;

        bus.transform.position = transform.position;
        bus.transform.parent = transform;
        bus.rigidbody.velocity = new Vector3(0, 0, TrafficVelocity);
        Destroy(bus, 10);

        cooldown = Random.Range(CooldownMin, CooldownMax);
    }
}
