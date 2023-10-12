using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject gunCamera;

    GunBase gunBase;


    private void Awake()
    {
        gunCamera = transform.GetChild(2).gameObject;
        gunBase = gunCamera.GetComponentInChildren<GunBase>();
    }

    /// <summary>
    /// 총 용 카메라 활성화 설정
    /// </summary>
    /// <param name="show">true면 총이 보인다., flase면 총이 안보인다.</param>
    public void ShowGunCamera(bool show = true)
    {
        gunCamera.SetActive(show);
    }

    public void GunFire()
    {
        gunBase.Fire();
    }
}