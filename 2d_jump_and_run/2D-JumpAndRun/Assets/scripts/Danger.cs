using UnityEngine;
using System.Collections;

public class Danger : MonoBehaviour {

    float xStart;
    float xChange;

	// Use this for initialization
	void Start () {
        xStart = transform.position.x;
        xChange = Random.Range(1.0f, 2.0f) * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        float xNew = transform.position.x + xChange;
        transform.position = new Vector3(xNew, transform.position.y, 0);
        if (xNew > xStart + 2 || xNew < xStart -2)
        {
            xChange *= -1;
        }
	}
}
