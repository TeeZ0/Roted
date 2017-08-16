using UnityEngine;

public class MouseLook : MonoBehaviour {


    public float Sensitivity = 6;
    public Camera cam;
    public bool lockCursor = false;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;
    // Use this for initialization
    void Start () {
        lockCursor = true;
        originalRotation = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {

        if (lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        // Read the mouse input axis
        rotationX += Input.GetAxis("Mouse X") * Sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * Sensitivity;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);




        transform.localRotation = Quaternion.Euler(new Vector3(0, cam.transform.rotation.eulerAngles.y, 0));
        cam.transform.position = new Vector3(transform.position.x, transform.position.y +.6f, transform.position.z);
        cam.transform.localRotation = originalRotation * xQuaternion * yQuaternion;



    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
         angle += 360F;
        if (angle > 360F)
         angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
