using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{

    [SerializeField] private GameObject ondaAttack;
    [SerializeField] private bool attackable;
    [SerializeField] private float distanciaMaxima;

    [Header("MeteorSwarm")]
    [SerializeField] private GameObject meteor;
    [SerializeField] private float meteorCD;
    [SerializeField] private bool meteorAvailable = true;

    // Start is called before the first frame update
    void Start()
    {
        ondaAttack.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && attackable)
        {
            StartCoroutine(SpawnAttack());
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            if(meteorAvailable)
            {
                Debug.Log("trying meteor");
                StartCoroutine(MeteorSwarm());
            }
        }
    }

    private IEnumerator SpawnAttack()
    {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector3 direction = (mouseWorldPos - transform.position).normalized;
        Vector3 posicionOnda = transform.position + direction * distanciaMaxima;

        ondaAttack.transform.position = posicionOnda;

        ondaAttack.transform.rotation = Quaternion.LookRotation(-direction);
        attackable = false;
        ondaAttack.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ondaAttack.SetActive(false);
        yield return new WaitForSeconds(0.8f);

        attackable = true;
    }
    Vector3 GetMouseWorldPosition()
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero); // Suponiendo que el juego es en el eje XZ
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }

    private IEnumerator MeteorSwarm()
    {
        meteorAvailable = false;
        Instantiate(meteor, transform.position + new Vector3(0,25,0), Quaternion.identity);
        yield return new WaitForSeconds(meteorCD);
        meteorAvailable = true;

    }
}
