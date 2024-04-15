using UnityEngine;
using System.Collections;
/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public GameObject PlayerBody;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    bool lockstate;

    float rotationY = 0F;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.visible = !Cursor.visible;
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (Cursor.lockState == CursorLockMode.None || Cursor.lockState == CursorLockMode.Confined)
        {
            return;
        }
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * PlayerPrefs.GetInt("Sensitivity");

        rotationY += Input.GetAxisRaw("Mouse Y") * PlayerPrefs.GetInt("Sensitivity");
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, transform.localEulerAngles.z);
        PlayerBody.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * PlayerPrefs.GetInt("Sensitivity"), 0);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.GetInt("Sensitivity") == 0)
        {
            PlayerPrefs.SetInt("Sensitivity", 5);
        }
    }
}