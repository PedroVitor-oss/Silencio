using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour {
    public List<string> inventarioNames;

    public void addItem(string itemName) {
        inventarioNames.Add(itemName);
    }
    public int QuantItem(){
        return inventarioNames.Count;
    }
    public int removeItens(string name){
        int quantItenRemovidos = 0;
       for (int i = inventarioNames.Count - 1; i >= 0; i--)
        {
            if (inventarioNames[i].Contains(name))
            {   
                quantItenRemovidos++;
                inventarioNames.RemoveAt(i);
            }
        }
        return quantItenRemovidos;
    }
    public bool ImHasImte(string name){
        for (int i = inventarioNames.Count - 1; i >= 0; i--)
        {
            if (inventarioNames[i].Contains(name))
            {
                return true;
            }
        }
        return false;
    }
    
}