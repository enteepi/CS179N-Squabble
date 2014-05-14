using UnityEngine;
using System.Collections;

public class ShootoutCounter :
    MonoBehaviour
{
    public int ClipPool;
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
            ClipPool -= ClipSize;
            if (ClipPool < 0)
                clip += ClipPool;
        }

        for (int i = 0; i < ClipSize; ++i)
        {
            if (i <= clip)
                transform.FindChild("t" + i).renderer.enabled = true;
            else
                transform.FindChild("t" + i).renderer.enabled = false;
        }
    }

    public void Dec()
    {
        --clip;
    }

    public void Reload()
    {
        if (!reloading)
        {
            reloading = true;
            reloadTime = ReloadLength;
        }
    }
}
