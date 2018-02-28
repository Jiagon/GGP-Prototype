using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Camera cam;
    CursorLockMode cursor;

    // Use this for initialization
    void Start() {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cursor = CursorLockMode.Confined;
        Cursor.lockState = cursor;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        float speed = 2;
        Vector3 pos = transform.position;

        float sensitivity = 0.05f;
        Vector3 vTV = cam.ViewportToScreenPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        Vector3 vTS = cam.ViewportToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        Vector3 vTW = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        transform.LookAt(vTV, Vector3.up);
        /*Vector3 vp = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;

        Vector3 sp = cam.ViewportToScreenPoint(vp);

        Vector3 v = cam.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);*/

        //transform.LookAt(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane)), Vector3.up);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed *= 2f;
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            speed *= .5f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
        if (Input.GetKey(KeyCode.Q))
        {

        }
        if (Input.GetKey(KeyCode.E))
        {

        }
        transform.position = pos;
	}
}
