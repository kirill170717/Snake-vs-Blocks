using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private float defaultWidth;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        defaultWidth = _camera.orthographicSize * _camera.aspect;
    }

    private void Update()
    {
        _camera.orthographicSize = defaultWidth / _camera.aspect;
    }
}