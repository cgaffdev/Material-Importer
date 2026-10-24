using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Item/Create New Item")]
public class Item : ScriptableObject
{
    [SerializeField] protected int id;
    [SerializeField] protected string itemName;
    [SerializeField] public string tag;
    [SerializeField] public int value;
    [SerializeField] protected float weight;
    [SerializeField] public Sprite icon;
    [SerializeField] public GameObject model;
    [SerializeField] protected List<GameEffects> effects;
    [SerializeField] public bool hasMixture;



    public Item()
    {
        // Initialize the effects list to an empty list
        effects = new List<GameEffects>();
    }
    
    public string GetItemName(){
        return itemName;
    }

    public void SetItemName(string itemName){
        this.itemName = itemName;
    }

    public Sprite GetIcon(){
        return icon;
    }

    public float GetWeight(){
        return weight;
    }

    public GameObject GetModel(){
        return model;
    }

    public int GetValue(){
        return value;
    }


    #region Effect Functions

    public bool HasEffects(){
        if(effects.Count == 0){
            return false;
        } else{
            return true;
        }
    }

    public List<GameEffects> GetEffectsList(){
        return effects;
    }

    public void ApplyEffects(){
        foreach(GameEffects effect in effects){
            effect.RunEffect();
        }
    }

    public void ApplyEffects(GameObject obj){
        foreach(GameEffects effect in effects){
            effect.SetTargetObject(obj);
            effect.RunEffect();
        }
    }

    public List<GameEffects> GetEffects(){
        return effects;
    }
    public void AddEffect(GameEffects newEffect){   
        if (newEffect == null){
            Debug.LogWarning("AddedEffect was given null");
        } else{

            effects.Add(newEffect);        
        }
    }
    public void AddEffects(List<GameEffects> newEffects){
        foreach(GameEffects effect in newEffects){
            effects.Add(effect);
        }
    }
    
    #endregion
}
