using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private bool _enabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(!_enabled) return;
        Debug.Log(collision.contactCount);
        ContactPoint2D contact = collision.GetContact(0);
        ParticleSystem p = Instantiate(_particles, transform.position, Quaternion.LookRotation(contact.normal));
        Destroy(p.gameObject, 3f);
        if(_audio != null) _audio.Play();
    }
}
