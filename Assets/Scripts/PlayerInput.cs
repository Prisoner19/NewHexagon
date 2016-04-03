using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Check_For_Shooting ();
	}

	private void Check_For_Shooting()
	{
		//if (Controller.Instance.player_inventory.Check_Ammo ())
		if (true)
		{
			if (Input.GetKeyDown (KeyCode.A))
			{
				Rotate_Left ();
				Controller.Instance.player_inventory.Decrease_Ammo ();
			} 
			else if (Input.GetKeyDown (KeyCode.W))
			{
				Rotate_Up ();
				Controller.Instance.player_inventory.Decrease_Ammo ();
			} 
			else if (Input.GetKeyDown (KeyCode.S))
			{
				Rotate_Down ();
				Controller.Instance.player_inventory.Decrease_Ammo ();
			} 
			else if (Input.GetKeyDown (KeyCode.D))
			{
				Rotate_Right ();
				Controller.Instance.player_inventory.Decrease_Ammo ();
			}
		}
	}

	private void Rotate_Left()
	{
		LeanTween.rotateZ (Controller.Instance.playerTransf.gameObject, 90, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Left);
	}

	private void Shoot_Left()
	{
		RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.left, 32f, 1 << LayerMask.NameToLayer("Object"));

		if (hit.collider != null) 
		{
			CameraShake.Instance.Small_Shake ();
			Destroy (hit.collider.gameObject);
		}
	}

	private void Rotate_Up()
	{
		LeanTween.rotateZ (Controller.Instance.playerTransf.gameObject, 0, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Up);
	}

	private void Shoot_Up()
	{
		RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.up, 32f, 1 << LayerMask.NameToLayer("Object"));

		if (hit.collider != null) 
		{
			CameraShake.Instance.Small_Shake ();
			Destroy (hit.collider.gameObject);
		}
	}

	private void Rotate_Down()
	{
		LeanTween.rotateZ (Controller.Instance.playerTransf.gameObject, 180, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Down);
	}

	private void Shoot_Down()
	{
		RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.down, 32f, 1 << LayerMask.NameToLayer("Object"));

		if (hit.collider != null) 
		{
			CameraShake.Instance.Small_Shake ();
			Destroy (hit.collider.gameObject);
		}
	}

	private void Rotate_Right()
	{
		LeanTween.rotateZ (Controller.Instance.playerTransf.gameObject, 270, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Right);
	}

	private void Shoot_Right()
	{
		RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.right, 32f, 1 << LayerMask.NameToLayer("Object"));

		if (hit.collider != null) 
		{
			CameraShake.Instance.Small_Shake ();
			Destroy (hit.collider.gameObject);
		}
	}
}
