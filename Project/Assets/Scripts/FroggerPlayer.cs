using UnityEngine;
using System.Collections;

public class FroggerPlayer : 
    MonoBehaviour 
{
    public float Speed;
    public float Startpoint;
    public float Checkpoint;
    public float Invincibility;
    public float SpeedBoost;

    public int score;

    Vector3 moveTo;
    float moveDist;
    float startTime;

	// Use this for initialization
	void Start () {
        moveTo = transform.position;
        Startpoint = transform.position.x;
        Checkpoint = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (Invincibility > 0)
        {
            Invincibility -= Time.deltaTime;
        }
        if (SpeedBoost > 0)
        {
            SpeedBoost -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                startTime = Time.time;                
                moveTo = ray.GetPoint(hitdist);
                moveDist = Vector3.Distance(transform.position, moveTo);
                Quaternion targetRotation = Quaternion.LookRotation(moveTo - transform.position);
                transform.rotation = targetRotation;
            }
        }

        if (transform.position != moveTo && GameObject.Find("Floor").GetComponent<FroggerStart>().GameTimer > 0)
        {
            float distCovered = (Time.time - startTime) * Speed;
            if (distCovered / moveDist < 0.9f)
                transform.position = Vector3.Lerp(transform.position, moveTo, distCovered / moveDist);
            else
                transform.position = Vector3.Lerp(transform.position, moveTo, 1);
        }
        GameObject.Find("ScoreDisplay").GetComponent<GUIText>().text = "Score: " + score;
	}

    void OnTriggerEnter(Collider collider)
    {        
        Car car = collider.GetComponent<Car>();
        if (car)
        {
            Debug.Log("HONK");
            if (Invincibility > 0)
            {
                collider.rigidbody.velocity = new Vector3(0, collider.rigidbody.velocity.x, 0);
            }
            else
            {
                score -= 10;
                transform.position = new Vector3(Checkpoint, transform.position.y, transform.position.z);
                moveTo = transform.position;
            }
        }

        Bus bus = collider.GetComponent<Bus>();
        if (bus)
        {
            Debug.Log("BANG");
            if (Invincibility > 0)
            {
                collider.rigidbody.velocity = new Vector3(0, collider.rigidbody.velocity.x, 0);
            }
            else
            {
                score -= 5;
                transform.position = new Vector3(Startpoint, transform.position.y, transform.position.z);
                Checkpoint = Startpoint;
                moveTo = transform.position;
            }
        }

        FroggerCheckpoint check = collider.GetComponent<FroggerCheckpoint>();
        if (check != null)
        {
            if (check.transform.position.x != Checkpoint) 
                score += 20 * check.ScoreMult;
            Checkpoint = collider.transform.position.x;
        }

        if (collider.tag == "Finish")
        {
            score += 100;
            transform.position = new Vector3(Startpoint, transform.position.y, transform.position.z);
            Checkpoint = Startpoint;
            moveTo = transform.position;

        }

        FroggerPlayer player = collider.GetComponent<FroggerPlayer>();
        if (player)
        {
            
        }
    }
}
