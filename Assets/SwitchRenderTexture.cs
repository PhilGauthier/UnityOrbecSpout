using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRenderTexture : MonoBehaviour
{
    private Camera[] _cams;
    [SerializeField]
    private RenderTexture _texture;
    public int _indexCam = 0;
    // Start is called before the first frame update
    void Start()
    {
        _cams= gameObject.GetComponentsInChildren<Camera>();

        if(_texture == null)
            Debug.LogError("Couldn't find RenderTexture");
        if (_cams.Length==0)
            Debug.LogError("Couldn't find RenderTexture");
        setCam(0);
    }

    public void setCam(int idx)
    {
        int newIdx = idx % _cams.Length;
        
        for (int i = 0; i < _cams.Length; i++)
        {
            if (i != newIdx)
            {
                Camera oldCam = _cams[i];
                oldCam.targetTexture = null;
                oldCam.enabled = false;
            }
        }

        Camera newCam = _cams[newIdx];
        newCam.targetTexture = _texture;
        _indexCam = newIdx;
        newCam.enabled = true;
        Debug.Log("Camera "+newCam.name + " activated");
        
    }

    public void nextCam()
    {
        setCam(_indexCam + 1);
    }
}
