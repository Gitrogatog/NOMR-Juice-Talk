using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private LayerMask _raycastLayers;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private ParticleSystem _impactParticles;
    [SerializeField] private TrailRenderer _bulletTrail;
    [SerializeField] private Color _ballColor;
    [SerializeField] private AudioSource _shootAudio;
    [SerializeField] private AudioSource _hitAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireRaycast();
    }
    void FireRaycast(){
        _line.SetPosition(0, _firePoint.position);
        RaycastHit2D ray = Physics2D.Raycast(_firePoint.position, transform.up, _raycastLayers);
        if(ray){
            _line.SetPosition(1, ray.point);
            if(Input.GetKeyDown(KeyCode.Space)){
                FireParticle(ray);
            }
            
        }
    }
    void FireParticle(RaycastHit2D hit){
        TrailRenderer trail = Instantiate(_bulletTrail, _firePoint.position, Quaternion.identity);
        SetBallColor colorScript = hit.collider.gameObject.GetComponentInParent<SetBallColor>();
        if(_shootAudio != null) _shootAudio.Play();

        StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, true, colorScript));        
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact, SetBallColor colorScript = null)
    {
        // This has been updated from the video implementation to fix a commonly raised issue about the bullet trails
        // moving slowly when hitting something close, and not
        Vector3 startPosition = Trail.transform.position;
        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float remainingDistance = distance;

        while (remainingDistance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (remainingDistance / distance));

            remainingDistance -= _bulletSpeed * Time.deltaTime;

            yield return null;
        }
        //Animator.SetBool("IsShooting", false);
        Trail.transform.position = HitPoint;
        if (MadeImpact)
        {
            Destroy(Instantiate(_impactParticles, HitPoint, Quaternion.LookRotation(HitNormal)).gameObject, 3f);
            _hitAudio?.Play();
            if(colorScript != null){
                colorScript.ChangeColor(_ballColor);
            }
        }

        Destroy(Trail.gameObject, Trail.time);
    }
}
