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
    public void removeItens(string name){
       for (int i = inventarioNames.Count - 1; i >= 0; i--)
        {
            if (inventarioNames[i].Contains(name))
            {
                inventarioNames.RemoveAt(i);
            }
        }
    }
    
}