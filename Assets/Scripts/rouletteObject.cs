using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteObject : MonoBehaviour
{

    int Degrees = 360;

    public GameObject prefab;
    public Transform parentObject;

    public float rotationSpeed = 100f;
    List<string> items;

    void Start()
    {
        items = getNames();
        
        for(int i = 0; i < items.Count; i++){
            int grados = i *(Degrees/items.Count);
            OnDrawGizmoss(grados);
            
        }
    }

    void Update()
    {        
        transform.Rotate(new Vector3(0,1,0),  Time.deltaTime * rotationSpeed);
    }

    List<string> getNames(){
        List<string> names;
        names = new List<string>{
            "leche",
            "chocolate",
            "harina",
            "huevo",
            "gelatina",
            "gelatina",
            "gelatina",
            "gelatina",
            "gelatina",
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
        Vector3 end = transform.position + direction * (transform.localScale.x/4);

        GameObject newObject =  Instantiate(prefab, end, Quaternion.identity);
        newObject.transform.parent = parentObject;

        Quaternion additionalRotation = Quaternion.Euler(Angle,0,0);
        newObject.transform.localRotation *= additionalRotation;
    }
}
