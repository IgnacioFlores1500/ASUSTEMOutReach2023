using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6.0f;
	private CharacterController _charController;
	public bool hit = false;
	public float gravity = -9.0f;
	private float jumpMaxVelocity = 9.0f;
	private float currentJumpVelocity = 0f;
	public float velocityModifier;
	
	void Start()
	{
		_charController = GetComponent<CharacterController>();
	}
	
    // Update is called once per frame
    void Update()
    {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaY = 0;
		float deltaZ = Input.GetAxis("Vertical") * speed;
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

		movement = Vector3.ClampMagnitude(movement, speed);
		
		movement.y += deltaY;
		
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		
		_charController.Move(movement);
    }
	
	/*private IEnumerator Launch()
	{
		this.transform.Translate(0,(speed * Time.deltaTime), -(speed * Time.deltaTime));
		yield return new WaitForSeconds(2);
		
		hit = false;
	}*/
}
