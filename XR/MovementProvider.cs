using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
/*using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : LocomotionProvider
{
     public List<XRController> controllers = null;
     public float gravityMultiplier = 1.0f;
     public float speed = 1.0f;

     private CharacterController characterController = null;
     private GameObject head = null;



     // Start is called before the first frame update
     new void Awake()
     {
          characterController = GetComponent<CharacterController>();
          head = GetComponent<XRRig>().cameraGameObject;
     }

     private void Start()
     {
          PositionController();
     }

     // Update is called once per frame
     void Update()
     {
          PositionController();
          ChechForInput();
          ApplyGravity();

     }

     private void PositionController()
     {
          float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);

          characterController.height = headHeight;

          Vector3 newCenter = Vector3.zero;
          newCenter.y = headHeight / 2;
          newCenter.y += characterController.skinWidth;
          newCenter.x = head.transform.localPosition.x;
          newCenter.z = head.transform.localPosition.z;

          characterController.center = newCenter;
     }

     void ChechForInput()
     {
          foreach (XRController controller in controllers)
          {
               if (controller.enableInputActions)
               {
                    CheckForMovement(controller.inputDevice);
               }
          }
     }

     void CheckForMovement(InputDevice device)
     {
          if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
          {
               StartMove(position);
          }
     }

     void StartMove(Vector2 position)
     {
          Vector3 direction = new Vector3(position.x, 0, position.y);
          Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

          direction = Quaternion.Euler(headRotation) * direction;

          Vector3 movement = direction * speed;
          characterController.Move(movement * Time.deltaTime);

     }

     void ApplyGravity()
     {
          Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
          gravity.y *= Time.deltaTime;

          characterController.Move(gravity * Time.deltaTime);
     }
}*/
