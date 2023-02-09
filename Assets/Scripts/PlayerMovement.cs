using System.Collections; 
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6.0f;
	private CharacterController _charController;
	public bool hit = false;
	public float gravity = -9.0f;
	private float jumpMaxVelocity = 9.0f;
	private float currentJumpVelocity = 0f;
	public float velocityModifier;

	//Added bad Rotate - 2/9/23
	public float tiltAngle = 5.0f;
	public float smooth = 60.0f;
	
	void Start()
	{
		_charController = GetComponent<CharacterController>();
	}
	
    // Update is called once per frame
    void Update()
    {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		// Smoothly tilts a transform towards a target rotation.
		float tiltAroundZ = Input.GetAxis("Horizontal"); //This will need a velocity type number. This is too quick
        //float tiltAroundX = Input.GetAxis("Vertical") ;

        float deltaY = 0;
        {/*"simple" jumping, NOTE: This does not prevent player from holding SPACE
			and flying around*/
			if(Input.GetAxis("Jump") > 0)
			{
				currentJumpVelocity = jumpMaxVelocity;
			}
			else
			{
				if(currentJumpVelocity > gravity)
				{
					currentJumpVelocity -= velocityModifier;
				}
			}
			deltaY += currentJumpVelocity;
		}

		Vector3 movement = new Vector3(deltaX, deltaY, deltaZ);
		//if (tiltAroundZ > 360) {
		//	tiltAroundZ = 0;
		//}
		Vector3 transformed = new Vector3(0, tiltAroundZ, 0); // Creates a vector3 to be used for rotating the player

		movement = Vector3.ClampMagnitude(movement, speed);
		
		movement.y += deltaY;
		
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
		//transform.TransformVector(0,3,2);
		transform.localEulerAngles = transformed; // What actually rotates the object
        //transform.rotation = Quaternion.Slerp(transform.rotation,  Time.deltaTime * smooth);
    }
	
	/*private IEnumerator Launch()
	{
		this.transform.Translate(0,(speed * Time.deltaTime), -(speed * Time.deltaTime));
		yield return new WaitForSeconds(2);
		
		hit = false;
	}*/
}
