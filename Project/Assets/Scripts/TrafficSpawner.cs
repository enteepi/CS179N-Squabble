using UnityEngine;
using System.Collections;

public class TrafficSpawner : 
    MonoBehaviour 
{
    public GameObject Bus;
    public GameObject Car;

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
        GameObject car = Instantiate(Car) as GameObject;

        car.transform.position = transform.position;
        //car.transform.localPosition = Vector3.zero;
        car.transform.parent = transform;
        if (TrafficVelocity < 0)
            car.transform.eulerAngles = new Vector3(0, 180, 0);
        car.rigidbody.velocity = new Vector3(0, 0, TrafficVelocity);
        Destroy(car, 10);
        
        cooldown = Random.Range(CooldownMin, CooldownMax);
    }


    void SpawnBus()
    {
        GameObject bus = Instantiate(Bus) as GameObject;

        bus.transform.position = transform.position;
        //bus.transform.localPosition = Vector3.zero;
        bus.transform.parent = transform;
        if (TrafficVelocity < 0)
            bus.transform.eulerAngles = new Vector3(0, 180, 0);
        bus.rigidbody.velocity = new Vector3(0, 0, TrafficVelocity);
        Destroy(bus, 10);

        cooldown = Random.Range(CooldownMin, CooldownMax);
    }
}
