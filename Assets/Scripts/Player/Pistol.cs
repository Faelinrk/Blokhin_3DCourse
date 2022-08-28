using System.Collections;
using System.Collections.Generic;
using Quest.Player;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private GameObject localShootLight;
    [SerializeField] private GameObject lightPrefab;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private float shootDist = 1000f;
    private GameObject distShotLighgt;
    private Animator animator;

    private const string Shot = "Shot";
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayShot()
    {
        animator.SetTrigger(Shot);
    }

    public void ShootLight()
    {
        localShootLight.SetActive(true);
        Vector3 targetDirection = transform.right*shootDist;
        Ray ray = new Ray(bulletPoint.transform.position,targetDirection);
        Debug.DrawRay(bulletPoint.transform.position,targetDirection, Color.red,1000f);
        if (Physics.Raycast(ray, out RaycastHit hit,1000f))
        {
            distShotLighgt = Instantiate(lightPrefab, hit.point, Quaternion.identity);
        }
    }
    
    public void StopShootLightning()
    {
        localShootLight.SetActive(false);
        Destroy(distShotLighgt);
    }
    
}
