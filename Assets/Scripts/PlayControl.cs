using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    //角色行动范围
    public float xMin, zMin, xMax, zMax;
}
public class PlayControl : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //放子弹
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //初始化一个预设object
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    public void FixedUpdate()
    {
        //移動飛機
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = movement * speed;
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
            );
        rigidbody.rotation = Quaternion.Euler(0.0f,0.0f, rigidbody.velocity.x * -tilt);
    }
}
