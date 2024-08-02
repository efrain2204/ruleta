using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteObject : MonoBehaviour
{

    int Degrees = 360;

    public GameObject image;
    public GameObject prefab;
    public Transform parentObject;

    public float rotationSpeed = 100f;
    List<string> items;

    List<GameObject> listChildren = new List<GameObject>{};

    float deltaTimeGlobal;


    // Spinner
    private Rigidbody rb;

    public float duration = 10f; // Duración total en segundos
    private float startTime;

    void Start()
    {
        items = getNames();
        
        int imgPos = (Degrees/items.Count)/2;

        for(int i = 0; i < items.Count; i++){
            int grados = i *(Degrees/items.Count);
            OnDrawGizmoss(grados,imgPos,items[i]);
        }

        // Obtén el componente Rigidbody del objeto.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {        
        deltaTimeGlobal = Time.deltaTime;
        transform.Rotate(new Vector3(0,1,0),  (deltaTimeGlobal* rotationSpeed));
        spinRoulette();
        // startTime = Time.time;
        // rotationSpeed = GetValueBasedOnTime();
    }

    float GetValueBasedOnTime()
    {
        // Calcular el tiempo transcurrido
        float elapsedTime = Time.time - startTime;

        // Normalizar el tiempo en el rango de 0 a 1
        float normalizedTime = Mathf.Clamp01(elapsedTime / duration);

        // Usar una función seno para crear una transición suave
        float sineValue = Mathf.Sin(normalizedTime * Mathf.PI);

        // Convertir el valor del rango de 0 a 1 a un rango de 0 a 100
        float value = sineValue * 100f;

        return value;
    }

    void spinRoulette(){

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Debug.Log("press");
        //     listChildren.ForEach(ele=>{
        //         ele.transform.Rotate(new Vector3(1,0,0),  (deltaTimeGlobal* rotationSpeed));
        //     });
        //     // Vector3 torqueVector = new Vector3(torque,0, 0);
        //     // rb.AddTorque(torqueVector);
        //     rotationSpeed = 50f;
            
        // }
        // if(Input.GetKeyUp(KeyCode.Space)){
        //     Debug.Log("free");
        //     rotationSpeed = 10f;
        // }

    }

    
    List<string> getNames(){
        List<string> names;
        names = new List<string>{
            "aceite",
            "atun",
            "fosforo",
            "leche",
            "mantequilla",
            "vino",
            "yogurt",
        };
        return names;
    }

     
    void OnDrawGizmoss(float Angle, float imgPos, string product)
    {
        Vector3 end = GeneratePosition(Angle,(transform.localScale.x/4));
        Vector3 end_ = GeneratePosition(Angle+imgPos,(transform.localScale.x/3));
        

        GameObject newObject =  Instantiate(prefab, end, Quaternion.identity);
        newObject.transform.parent = parentObject;

        Quaternion additionalRotation = Quaternion.Euler(Angle,0,0);
        newObject.transform.localRotation *= additionalRotation;

        drawProducts(end_, product);
    }


    void drawProducts(Vector3 position, string product){
        string texturePath = $"Assets/static/img/{product}.jpg";
        Texture2D texture = LoadTexture(texturePath);
        Material material = new Material(Shader.Find("Standard"));
        material.mainTexture = texture;

        GameObject newObject =  Instantiate(image, position, Quaternion.identity);
        newObject.transform.parent = parentObject;

        newObject.transform.position = 
        new Vector3(newObject.transform.position.x+0.04f, newObject.transform.position.y, newObject.transform.position.z);

        newObject.GetComponent<Renderer>().material = material;
        listChildren.Add(newObject);

        
    }

    Texture2D LoadTexture(string path)
    {
        // Cargar el archivo de imagen
        byte[] fileData = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData); // Se asigna la imagen a la textura
        return texture;
    }


    Vector3 GeneratePosition(float Angle, float Distance){
        // Convertir el ángulo de grados a radianes
        float angleRadians = Angle * Mathf.Deg2Rad;

        // Calcular la posición del extremo de la línea
        Vector3 direction = new Vector3(0f,Mathf.Cos(angleRadians),Mathf.Sin(angleRadians));
        Vector3 end = transform.position + direction * Distance;

        return end;
    }

}
