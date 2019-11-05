using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRenderTexture : MonoBehaviour
{
    private Camera[] cams;
    public int indexCam = 0;
    // Start is called before the first frame update
    void Start()
    {
        cams=GetComponentsInChildren<Camera>();
    }

    public void nextCam()
    {
        Camera oldCam = cams[indexCam];
        int newIdx = (indexCam + 1) % cams.Length;
        Camera newCam = cams[newIdx];
        RenderTexture t = oldCam.targetTexture;
        oldCam.targetTexture = null;
        newCam.targetTexture = t;
        indexCam = newIdx;
    }
}
