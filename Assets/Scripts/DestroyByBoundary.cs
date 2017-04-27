using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用来删除boundary范围外的子弹
public class DestroyByBoundary : MonoBehaviour {
   	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
