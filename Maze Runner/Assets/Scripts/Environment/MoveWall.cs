using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public Vector3 openPosition, closedPosition;
    public float closeTime, openTime;
    public Material openMaterial, closedMaterial;
    private float currentTime;
    private MeshRenderer renderer;
    public LightingManager lightingManager;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        currentTime = lightingManager.TimeOfDay;
        //Debug.Log(currentTime);
        if(currentTime > closeTime || currentTime < openTime)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, closedPosition, .5f);
            renderer.material = closedMaterial;
            Debug.Log("close");
        }
            
        if(currentTime < closeTime && currentTime > openTime)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, openPosition, .5f);
            renderer.material = openMaterial;
            Debug.Log("open");
        }

    }
}
