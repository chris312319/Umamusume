using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float rotateSpeed = 180;
    [Range(1, 2)] public float rotateRatio = 1;
    public Transform playerTransform;
    public Transform eyeViewTransform;
    public float MaxViewAngle = 65f;
    private float tmp_viweRotationOffset;

    private void FixedUpdate()
    {
        PlayerRotateControl();
    }

    private void PlayerRotateControl()
    {
        if (playerTransform == null || eyeViewTransform == null)
        {
            return;
        }




        //x控制的是水平方向旋转，也就是控制沿Y轴旋转，控制Player的水平方向转动
        float offset_x = Input.GetAxis("Mouse X");
        //控制垂直方向旋转，也就是沿x轴旋转，这里只控制EYE_VIEW照相机在垂直方向的转动
        float offset_y = Input.GetAxis("Mouse Y");
        playerTransform.Rotate(Vector3.up * (offset_x * rotateSpeed * rotateRatio * Time.fixedDeltaTime));
        //对旋转角进行累加才能够进行对最大角度的限制
        tmp_viweRotationOffset -= offset_y * rotateSpeed * rotateRatio * Time.fixedDeltaTime;
        //限制一下旋转的角度
        tmp_viweRotationOffset = Mathf.Clamp(tmp_viweRotationOffset, -MaxViewAngle, MaxViewAngle);
        Quaternion EyeLocalQuaternion = Quaternion.Euler(new Vector3(tmp_viweRotationOffset,
            eyeViewTransform.localEulerAngles.y,
            eyeViewTransform.localEulerAngles.z));
        //注意旋转角是四元素，需要用四元素处理
        eyeViewTransform.localRotation = EyeLocalQuaternion;
    }
}

