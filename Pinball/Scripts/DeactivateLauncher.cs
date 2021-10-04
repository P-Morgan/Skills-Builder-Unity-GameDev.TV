using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateLauncher : MonoBehaviour
{
    [SerializeField] GameObject launcherGroup;
    [SerializeField] GameObject ballLauncher;
    AreaEffector2D areaEffector2D;

    private void Start()
    {
         areaEffector2D = ballLauncher.GetComponent<AreaEffector2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        launcherGroup.SetActive(false);
        areaEffector2D.enabled = false;
    }
    
}
