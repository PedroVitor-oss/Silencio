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
    
}