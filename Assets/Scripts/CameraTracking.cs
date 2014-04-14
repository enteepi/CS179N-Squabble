using UnityEngine;
using System.Collections;

public class CameraTracking : 
    MonoBehaviour 
{

    public Transform Focus;
    public float TrackingDelay = 0f;
    Vector3 velocity = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
        if (Focus)
        {
            Vector3 delta = Focus.position - camera.ViewportToWorldPoint(new Vector3(camera.rect.width / 2,
                                                                                             camera.rect.height / 2,
                    Focus.position.z - transform.position.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, TrackingDelay);
        }
	}
}
