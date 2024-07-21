using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Vector3 _targetPosition;
    private float _explosionRadius;
    private int _damage;
    [SerializeField] private float _speed = 25f;

    public void Launch(Vector3 targetPosition, float explosionRadius, int damage)
    {
        _targetPosition = targetPosition;
        _explosionRadius = explosionRadius;
        _damage = damage;
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, _targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
        Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
           if(nearbyObject.gameObject.GetComponent<Enemy>())
            {
                nearbyObject.gameObject.GetComponent<Enemy>().TakeDamage(ShootController.Instance.GetWeaponDamage());
                Debug.Log($"{nearbyObject.name} получил {_damage} урона от взрыва гранаты");
            }
            
        }
        Destroy(gameObject);
    }
}
