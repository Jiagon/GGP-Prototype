using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public Transform[] pointList;

    public float timeBetweenPoints = 2.0f;
    float currentTime = 0.0f;

    int index;

	// Use this for initialization
	void Start () {
        if (pointList == null)
            throw new UnassignedReferenceException("Point list not defined!");
        timeBetweenPoints = Mathf.Max(0.5f, timeBetweenPoints);
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (pointList.Length < 2)
            return;
        currentTime += Time.deltaTime;
        if(currentTime >= timeBetweenPoints)
        {
            index++;
            currentTime -= timeBetweenPoints;
        }
        if (index >= pointList.Length)
            index = 0;

        Transform next = index + 1 >= pointList.Length ? pointList[0] : pointList[index + 1];
        Vector3 dist = next.position - pointList[index].position;

        transform.LookAt(next);
        transform.position = Vector3.MoveTowards(transform.position, next.position, dist.magnitude / timeBetweenPoints * Time.deltaTime);
    }
}
