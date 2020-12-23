using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 move;
    public float speed = 1;
    [FormerlySerializedAs("headset")] public Transform bodyCollider;
    public new CapsuleCollider collider;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.height = collider.height;

        var localPosition = bodyCollider.localPosition;
        var newPos = new Vector3(localPosition.x, characterController.height / 2, localPosition.z);
        characterController.center = newPos;

        var direction = Player.instance.hmdTransform.TransformDirection(new Vector3(move.axis.x, 0, move.axis.y)); // Get direction relative to headset rotation and joystick position.

        // Move player using CharacterController to handle collisions. Also ProjectOnPlane to prevent player from flying. Also subtract by gravity.
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) -
                                 new Vector3(0, 9.81f, 0) * Time.deltaTime);
    }
}