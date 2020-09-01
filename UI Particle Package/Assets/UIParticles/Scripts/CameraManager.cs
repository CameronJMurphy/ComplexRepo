using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
		camera = GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
		camera.orthographicSize = Screen.height / 2;
		camera.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, -10);
	}
}
