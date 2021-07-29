using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
        
    [SerializeField]
    private GameObject point;

    
    private void Start()
    {
        if (!this.gameObject.CompareTag("Enemy"))
        {
            CreatePoints();
        }
        
    }
    private void CreatePoints()
    {
        // nerede olışacağını belirledik.
        float radius_cyl = transform.localScale.x/2; // yarıçapını aldık yükseklik gibi değil.
        float radius_cube = point.transform.localScale.x / 2;

        float minRange = transform.position.z - transform.localScale.y; // Silindirin en başı
        float maxRange = transform.position.z + transform.localScale.y; // Silindirin en sonu
        Vector3 pos = new Vector3(transform.position.x, transform.position.y+radius_cyl+radius_cube , Random.Range(minRange,maxRange));
        Instantiate(point, pos, Quaternion.identity);

    }
    
}
