using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteObject : MonoBehaviour
{
    
    // public float lineLength = 5f;
    // public Vector3 direction = Vector3.up;
    // public Color lineColor = Color.white;

    public GameObject prefab;
    public Transform parentObject;

    public float angleDegrees = 0f; // Ángulo en grados
    public float lineLength = 1f;   // Longitud de la línea
    public Color lineColor = Color.red; // Color de la línea



    public float rotationSpeed = 100f;
    public int maxItems = 8;
    List<string> items;
    // Start is called before the first frame update

    void Start()
    {
        items = getNames();
        





    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        
        transform.Rotate(new Vector3(0,1,0),  Time.deltaTime * rotationSpeed);

        if (Input.GetKeyDown("space"))
            OnDrawGizmoss();
        

    }

    List<string> getNames(){
        List<string> names;
        names = new List<string>{
            "leche",
            "chocolate",
            "harina",
            "huevo",
            "gelatina",
        };
        return names;
    }

    // void OnDrawGizmos()
    // {

    //     Vector3 centerPosition = new Vector3(0,transform.position.y-transform.localScale.y,0);

    //     Debug.Log(transform.localScale);
    //     Debug.Log(transform.localScale);


    //     Vector3 center = new Vector3(0,transform.position.y,0);
    //     Vector3 end = centerPosition + direction.normalized * lineLength;
    //     Gizmos.color = lineColor;
    //     // Gizmos.DrawLine(centerPosition, end);
    // }

     
    void OnDrawGizmoss()
    {
        // Convertir el ángulo de grados a radianes
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        // Calcular la posición del extremo de la línea
        Vector3 direction = new Vector3(0f,Mathf.Cos(angleRadians),Mathf.Sin(angleRadians));
        Vector3 end = transform.position + direction * lineLength;

        GameObject newObject =  Instantiate(prefab, end, Quaternion.identity);
        newObject.transform.parent = parentObject;
        

        // Establecer el color de la línea
        Gizmos.color = lineColor;

        // Dibujar la línea en la escena
        Gizmos.DrawLine(transform.position, end);
    }
}
