using UnityEngine;
using System.Collections;

public class ShootoutCounter :
    MonoBehaviour
{
    public int ClipSize;
    public float ReloadLength;

    int clip;
    float reloadTime;
    bool reloading;

    public bool Reloading
    {
        get { return reloading; }
    }

    public int Clip
    {
        get { return clip; }
    }

    void Start()
    {
        clip = ClipSize;
    }

    void Update()
    {
        if (reloadTime > 0)
        {
            reloadTime -= Time.fixedDeltaTime;
        }
        else if (reloading)
        {
            reloading = false;
            clip = ClipSize;
        }

        for (int i = 0; i < ClipSize; ++i)
        {
            if (i + 1 <= clip)
                transform.FindChild("t" + i).transform.localScale = new Vector3(70, 70, 70);
            else
                transform.FindChild("t" + i).transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void Dec()
    {
        --clip;
    }

    public void Reload()
    {
        if (!reloading && clip < 10)
        {
            reloading = true;
            reloadTime = ReloadLength;
        }
    }
}
