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

    void Start()
    {
        items = getNames();
        
        int imgPos = (Degrees/items.Count)/2;

        for(int i = 0; i < items.Count; i++){
            int grados = i *(Degrees/items.Count);
            OnDrawGizmoss(grados,imgPos);
            
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

     
    void OnDrawGizmoss(float Angle, float imgPos)
    {
        // Convertir el ángulo de grados a radianes
        
        Vector3 end = GeneratePosition(Angle,(transform.localScale.x/4));
        Vector3 end_ = GeneratePosition(Angle+imgPos,(transform.localScale.x/3));
        

        GameObject newObject =  Instantiate(prefab, end, Quaternion.identity);
        newObject.transform.parent = parentObject;

        Quaternion additionalRotation = Quaternion.Euler(Angle,0,0);
        newObject.transform.localRotation *= additionalRotation;

        drawProducts(end_);
    }


    void drawProducts(Vector3 position){
        GameObject newObject =  Instantiate(image, position, Quaternion.identity);
        newObject.transform.parent = parentObject;
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
