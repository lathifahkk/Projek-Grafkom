using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance);
        if(hitInfo.collider != null){
            if(hitInfo.collider.CompareTag("enemy")){
                hitInfo.collider.GetComponent<Enemy>().TakeDamage();
            }
            DestroyProjectile();
        }

        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }

    void DestroyProjectile(){
        SoundManager.PlaySound("destroy");
        Instantiate(destroyEffect.gameObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
