using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    // Use this for initialization
    public GameObject explosion;
    public GameObject playExplosion;
    public int scoreValue;
    private GameController gc;
	void Start () {
        GameObject gameControl = GameObject.FindGameObjectWithTag("GameController");
        if (null != gameControl)
        {
            gc = gameControl.GetComponent<GameController>();
        }
        if(null == gc)
        {
            Debug.LogError("cannot find ‘game controller’ script");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //刚体发生碰撞后
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        
        if ( null != explosion)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playExplosion, other.transform.position, other.transform.rotation);
            gc.GameOver();
        }
        Debug.LogFormat("by contact trigger exit tag = {0}",other.tag);
        Destroy(other.gameObject);
        Destroy(gameObject);
        gc.AddScore(scoreValue);
    }
}
