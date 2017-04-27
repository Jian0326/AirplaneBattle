using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    // Use this for initialization
    public float scrollSpeed;
    public float tileSizeZ;
    private Vector3 startPos;
	void Start () {
        startPos = transform.position;//获取开始坐标
    }
	
	// Update is called once per frame
	void Update () {
        //获取一个从0-tileSizeZ的值
        float newPos = Mathf.Repeat(Time.time * scrollSpeed,tileSizeZ);
        transform.position = startPos + Vector3.forward * newPos;
	}
}
