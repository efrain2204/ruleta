using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteObject : MonoBehaviour
{

    int Degrees = 360;
    bool B_isFinished = false;

    private LineRenderer lineRenderer;

    public GameObject prefab;
    public Transform parentObject;

    public float angleDegrees = 0f; // Ángulo en grados
    public float lineLength = 1f;   // Longitud de la línea
    public Color lineColor = Color.red; // Color de la línea



    public float rotationSpeed = 100f;
    public int maxItems = 8;
    List<string> items;
    List<Transform> Positions;
    // Start is called before the first frame update

    void Start()
    {
        items = getNames();
        

        int I_size = items.Count;
        int I_spaceBtw = Degrees/I_size;
        
        for(int i = 0; i < items.Count; i++){
            angleDegrees += I_spaceBtw;
            OnDrawGizmoss(angleDegrees);
            
        }
        angleDegrees = 0f;



    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        
        transform.Rotate(new Vector3(0,1,0),  Time.deltaTime * rotationSpeed);


        // if (Input.GetKeyDown("space")){
        //     Debug.Log($"{Time.deltaTime * rotationSpeed}"+"<----------");
        //     OnDrawGizmoss();
        // }
        

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

     
    void OnDrawGizmoss(float Angle)
    {
        // Convertir el ángulo de grados a radianes
        float angleRadians = Angle * Mathf.Deg2Rad;

        // Calcular la posición del extremo de la línea
        Vector3 direction = new Vector3(0f,Mathf.Cos(angleRadians),Mathf.Sin(angleRadians));
        Vector3 end = transform.position + direction * lineLength;

        GameObject newObject =  Instantiate(prefab, end, Quaternion.identity);
        newObject.transform.parent = parentObject;
        // Positions.Add(newObject.transform);

        DrawLine(transform.position,end,Color.red);

        // Establecer el color de la línea
        Gizmos.color = lineColor;

        // Dibujar la línea en la escena
        // Gizmos.DrawLine(transform.position, end);
    }

    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor  = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        myLine.transform.parent = parentObject;
    }
}
