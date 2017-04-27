using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    // Use this for initialization
    public float lifetime;

    void Start()
    {
        //等待lifetime时间销毁
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
