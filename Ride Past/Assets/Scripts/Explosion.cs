using UnityEngine;

/// ------------------------------
/// Creating instance of particles
/// ------------------------------
public class Explosion: MonoBehaviour
{
	/// ------------------------------
	/// Singleton
	/// ------------------------------
	public static Explosion Instance;

	public ParticleSystem effectA;
	public ParticleSystem effectB;
    public GameObject enemy;
	void Awake()
	{
		/// ---------------------
		// Register the singleton
		/// ---------------------
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of InstanceExample script!");
		}

		Instance = this;
	}

	void Update(){
        /// -----------------------------------------
        /// Instanciate into a box of 5 x 5 x 5 (xyz)
        /// -----------------------------------------
        if (Input.GetKeyDown("Space"))
        {
            Explosion.Instance.Explosions(new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z));
        }
       }

	/// -----------------------------------------
	/// Create an explosion at the given location
	/// -----------------------------------------
	public void Explosions(Vector3 position)
	{
		instantiate(effectA, position);
		instantiate(effectB, position);
	}

	/// -----------------------------------------
	/// Instantiate a Particle system from prefab
	/// -----------------------------------------
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(prefab,position,Quaternion.identity) as ParticleSystem;

		/// -----------------------------
		// Make sure it will be destroyed
		/// -----------------------------
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);

		return newParticleSystem;
	}



}