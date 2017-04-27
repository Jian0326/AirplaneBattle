using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
}
