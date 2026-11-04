using UnityEngine;

public class DeathPlane : MonoBehaviour
{
	public GameObject scriptManager;
	private Ui Ui;

	// Update is called once per frame
	void Start()
	{
		Ui = scriptManager.GetComponent<Ui>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		var damageable = collision.gameObject.GetComponent<Damageable>();

		if (damageable == null) return;
		damageable.Damage(int.MaxValue, "enviroment");
	}
}
