using UnityEngine;
using System.Collections;

public class TrafficSpawner : 
    MonoBehaviour 
{
    public Vector2 TrafficVelocity;
    public int CarChance;
    public int BusChance;
    public int TrafficChance;
    public float CooldownStart;
    
    float Cooldown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Cooldown -= Time.deltaTime;
        if (Cooldown <= 0)
        {
            // Spawning Logic
            SpawnCar();
        }
	}

    void SpawnCar() {
        GameObject car = Instantiate(Resources.Load<GameObject>("Car")) as GameObject;

        car.transform.position = transform.position;
        car.rigidbody.velocity = TrafficVelocity;
        Destroy(car, 10);
        
        Cooldown = CooldownStart;
    }

    void SpawnBus()
    {
        GameObject bus = Instantiate(Resources.Load<GameObject>("Bus")) as GameObject;

        bus.transform.position = transform.position;
        bus.rigidbody.velocity = TrafficVelocity;
        Destroy(bus, 10);

        Cooldown = CooldownStart;
    }
}
