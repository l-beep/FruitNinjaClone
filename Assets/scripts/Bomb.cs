using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float rotationForce = 200;
    private GameManager gm;

    public ParticleSystem explosionSystem;


    public GameObject PopUpPrefab;

    [System.Obsolete]
    private void Start()
    {
        transform.rotation = Random.rotation;
        gm = FindObjectOfType<GameManager>();

        
    }




    private void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
        ;
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade")
        {
            Destroy(gameObject);
            Instantiate(explosionSystem, transform.position, explosionSystem.transform.rotation);
            Instantiate(PopUpPrefab, transform.position, Quaternion.identity);
            gm.LooseLife();
            AudioManager.Instance.PlaySfx("explosion");

        }
    }
}

