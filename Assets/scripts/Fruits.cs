using UnityEngine;


public class Fruits : MonoBehaviour
{
   
    private GameManager gm;
    public GameObject slicedFruit;
    public GameObject FruitJuice;
    public float rotationForce = 200;
    private Rigidbody rb;
    public int scorePoints;

    public GameObject PopUpPrefab;
    internal static object instance;

    [System.Obsolete]
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }


   

    private void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);

    }
    private void InstantiateSlicedFruit()
    {
       GameObject InstantiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject InstantiatedJuice = Instantiate(FruitJuice, new Vector3(transform.position.x, transform.position.y, 0), FruitJuice.transform.rotation);

       Instantiate(PopUpPrefab, transform.position, Quaternion.identity);


        Rigidbody[] slicedRb = InstantiatedFruit.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody srb in slicedRb)
        {
            srb.AddExplosionForce(150f, transform.position, 10);
        }
        Destroy(InstantiatedFruit, 5);
        Destroy(InstantiatedJuice, 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade")
        {
            Destroy(gameObject);
            InstantiateSlicedFruit();
            gm.AddScore(scorePoints);

            AudioManager.Instance.PlaySfx("sword");
        }



    }
}
