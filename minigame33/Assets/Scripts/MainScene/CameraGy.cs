using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGy : MonoBehaviour {
    private const float lowPassFilterFactor = 0.2f;
    Gyroscope go;
    bool gyinfo;
    public UILabel gyLabel;
    public GameObject cameraPoint;
    public Vector3 lastGy;
    void Start () {
        gyinfo = SystemInfo.supportsGyroscope;
        go = Input.gyro;
        //设置设备陀螺仪的开启/关闭状态，使用陀螺仪功能必须设置为 true  
        Input.gyro.enabled = true;
        //获取设备重力加速度向量  
        Vector3 deviceGravity = Input.gyro.gravity;
        //设备的旋转速度，返回结果为x，y，z轴的旋转速度，单位为（弧度/秒）  
        Vector3 rotationVelocity = Input.gyro.rotationRate;
        //获取更加精确的旋转  
        Vector3 rotationVelocity2 = Input.gyro.rotationRateUnbiased;
        //设置陀螺仪的更新检索时间，即隔 0.1秒更新一次  
        //Input.gyro.updateInterval = 0.03f;
        //获取移除重力加速度后设备的加速度  
        Vector3 acceleration = Input.gyro.userAcceleration;
        lastGy = Input.gyro.gravity;
    }
	//y+ 上 x+右
	// Update is called once per frame
	void Update () {
        //gyLabel.text = Input.gyro.gravity.ToString();
        //transform.position += new Vector3(10* Input.gyro.gravity.x - lastGy.x,10 * Input.gyro.gravity.y - lastGy.y,0);
        //float _x = transform.position.x;
        //float _y = transform.position.y;
        float _x = Input.gyro.gravity.x * 5;
        float _y = (Input.gyro.gravity.y) * 5;
        if (_y > 1)
        {
            _y = 1;
        }
        else if (_y < -1)
        {
            _y = -1;
        }
        if (_x > 1)
        {
            _x = 1;
        }
        else if (_x < -1)
        {
            _x = -1;
        }
        transform.position = new Vector3(_x, _y, transform.position.z);
        transform.LookAt(cameraPoint.transform);
    }
}
