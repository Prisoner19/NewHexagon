using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	private static CameraShake instance;
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform cam_transform;

	// How long the object should shake for.
	public float small_shake_time;
	public float big_shake_time;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float small_shake_amount;
	public float small_decrease_factor;

	public float big_shake_amount;
	public float big_decrease_factor;

	private float current_shake_time;
	private float current_shake_amount;
	private float current_decrease_factor;

	private bool should_shake;

	Vector3 originalPos;

	void Awake()
	{
		instance = this;

		if (cam_transform == null)
		{
			cam_transform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = cam_transform.localPosition;
	}

	public void Small_Shake()
	{
		current_shake_time = small_shake_time;
		current_shake_amount = small_shake_amount;
		current_decrease_factor = small_decrease_factor;

		cam_transform.localPosition = originalPos;
		should_shake = true;
	}

	public void Big_Shake()
	{
		current_shake_time = big_shake_time;
		current_shake_amount = big_shake_amount;
		current_decrease_factor = big_decrease_factor;

		cam_transform.localPosition = originalPos;
		should_shake = true;
	}

	public void End_Shake()
	{
		should_shake = false;
		cam_transform.localPosition = originalPos;
	}

	void Update()
	{
		if (should_shake == true)
		{
			if (current_shake_time > 0)
			{
				cam_transform.localPosition = originalPos + Random.insideUnitSphere * current_shake_amount;

				current_shake_time -= Time.deltaTime * current_decrease_factor;
			}
			else
			{
				End_Shake ();
			}
		}
	}

	public static CameraShake Instance
	{
		get { return instance; }
	}
}