
using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Plateform : MonoBehaviour
{
    public float DestroyDelay;
    public float TagDelay;

    public GameObject bullet;
    void Start()
    {
        Invoke(nameof(DestroySelf), DestroyDelay);
        Invoke(nameof(TagSelf), TagDelay);
    }
    private void DestroySelf()
    {
        DestroyImmediate(bullet, true);
    }
    
    private void TagSelf()
    {
        gameObject.layer = LayerMask.NameToLayer("Platform");
        GetComponent<Rigidbody>().isKinematic = true;
    }
    
}
