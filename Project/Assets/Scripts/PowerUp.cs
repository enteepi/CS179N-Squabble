using UnityEngine;
using System.Collections;

public abstract class PowerUp : 
    MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TriggerOnEnter(Collider colldier)
    {
        FroggerPlayer player = collider.GetComponent<FroggerPlayer>();
        if (player)
        {
            PickUp(player);
        }
    }

    protected abstract void PickUp(FroggerPlayer player);
}
