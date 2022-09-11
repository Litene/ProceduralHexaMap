using System;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private float _CameraSensitivity;
    private float _CameraSmoothing;
    private float _ScrollSensitivity = 10;
    private Vector3 _moveDir;
    private Vector3 _pivotPoint;

    private void Start() {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider != null) {
            _pivotPoint = hit.point;
            Debug.Log("hit");
        }

        if (_pivotPoint != null) {
            _moveDir = _pivotPoint - transform.position;
            Debug.DrawRay(transform.position, _moveDir, Color.red, 10.0f);
        }
        
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_pivotPoint, 1.0f);
    }

    private void Update() {
        // transform.position +=  Input.mouseScrollDelta.y * _ScrollSensitivity * Time.deltaTime;
    }
}