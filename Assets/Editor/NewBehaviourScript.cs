using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(NewBehaviourScript))]
public class NewBehaviourScript : UnityEditor.AssetModificationProcessor {

	// Use this for initialization
	void Start () {
		
	}
    static public void OnWillSaveAssets(string[] names)
    {

        foreach (string name in names)
        {
            if (name.EndsWith(".unity"))
            {
                Scene scene = SceneManager.GetSceneByPath(name);
                Debug.Log("雨松MOMO提醒您保存的场景名称是 ：" + scene.name);
            }

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
