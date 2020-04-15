using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public Camera Camera;

    public float weaponDamage = 10f;
    public float weaponRange = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out RaycastHit hit, weaponRange))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
