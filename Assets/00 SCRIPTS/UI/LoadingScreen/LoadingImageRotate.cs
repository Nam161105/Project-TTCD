using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LoadingImageRotate : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        this.RotateImage();
    }

    protected void RotateImage()
    {
        this.transform.eulerAngles += new Vector3(0, 0, Time.deltaTime * _speed);
    }
}
