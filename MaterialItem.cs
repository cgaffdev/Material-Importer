using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;


[CreateAssetMenu(fileName = "New Material Item", menuName = "Item/Create New Material Item")]
public class MaterialItem : Item
{

    /*
    HAS BASE:

    [SerializeField] protected int id;
    [SerializeField] protected string itemName;
    [SerializeField] public string tag;
    [SerializeField] public int value;
    [SerializeField] protected float weight;
    [SerializeField] public Sprite icon;
    [SerializeField] protected List<GameEffects> effects;
    [SerializeField] public bool hasMixture;
*/

    private int rarity;

    public int GetRarity(){
        return rarity;
    }

    public string GetTag(){
        return base.tag;
    }

    Sprite sprite;

    /// <summary>
    /// Creates a Material item with assigned paramaters
    /// Attempts to give it a model path and icon
    /// </summary>
    public MaterialItem(string name, string tag, int rarity, string icon, string model, int value, float weight){

        base.itemName = name;
        base.tag = tag;
        this.rarity=rarity;
        
        base.icon=MaterialManager.instance.GenerateSprite(icon);
        //base.model=model;
        base.value=value;
        base.weight=weight;
        base.hasMixture=hasMixture;

        // Construct model path
        string modelPath = "Assets/GameData/materials/models/" + name.Replace(" ", "_") + ".obj";
        // Now you can use iconPath and modelPath wherever you need
        
    }

    
    
}
