using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;


public class MaterialManager : MonoBehaviour
{

    public static MaterialManager instance { get; private set; }


    [Header("Material Settings")]
    private const int RarityCount = 7;

    [SerializeField] string filePath;
    /*

            "name": "Material Name",    // STRING
            "tag": "Mineral",           // STRING
            "rarity": 0,                // 0 = common, 1 = uncommon, 2 = rare, 3 = very rare, 4 = exotic  , 5 = ancient, 6 = forgotten
            "icon": "raw_iron.png",     // STRING
            "value": 50,                // INT / FLOAT?
            "weight": 5                 // INT / FLOAT?
            "hasMixture": false         // TRUE / FALSE 

    */

    // Materials organized by tag, then rarity (0-6).
    [SerializeField] Dictionary<string, List<List<MaterialItem>>> MaterialCollection = new();


    void Awake(){
        // Prevent duplicate managers.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Debug.Log("MATERIAL MANAGER STARTING!");
        TextAsset jsonFile = Resources.Load<TextAsset>("MaterialList");


        // Flag if file location or file is missing
        if (jsonFile == null)
        {
            Debug.LogError(
                $"Material file not found: {filePath}",
                this
            );
            return;
        }

        // Load The Materials
        LoadMaterials(jsonFile);
    }

    // Loads all the materials from the json into the game
    void LoadMaterials(TextAsset file){
      
        // Take TXT file
        string json = file.text;
        
        List<MaterialItem> materials = JsonConvert.DeserializeObject<List<MaterialItem>>(json);

        if(materials == null){
            Debug.LogWarning("Materials List is Empty or Null");
            return;
        }

        // Display each material
        foreach (MaterialItem material in materials)
        {
            string tag = material.GetTag();
            int materialRarity = Math.Clamp(material.GetRarity(), 0, RarityCount-1); // Prevents an item from exceeding establish rarity. 

            if (!MaterialCollection.ContainsKey(material.GetTag()))
            {
                
                 MaterialCollection[tag] = new List<List<MaterialItem>>();

                // Create a list for each rarity (0-6). (Assuming there is a total of seven rarities)
                for (int i = 0; i < RarityCount; i++)
                {
                    MaterialCollection[tag].Add(new List<MaterialItem>());
                }
            }

            // Add Material to its category and rarity
            MaterialCollection[tag][materialRarity].Add(material);

        }
        
        Debug.Log($"Processed {materials.Count} materials.");
        
    }



    /// <summary>
    /// Creates a sprite image, using the spritename param to search for the reference image
    /// returns null if image file cannot be found reflecting the spritename parameter
    /// </summary>
    public Sprite GenerateSprite(String spriteName){
        // Creates file Path using sprite name
        String filePath = "Assets/Resources/MaterialIcons/" + spriteName;
        
        if (File.Exists(filePath)){ // Checks if Image Exist

            // Reads the image and converts it into a texture
            byte[] data = File.ReadAllBytes(filePath);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(data);

            // Creatures sprite from texturing, using center as a pivot
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

            // Assign the new generated sprite to object's SpriteRenderer
            GetComponent<SpriteRenderer>().sprite = sprite;
            return sprite;
        }
        else{
            // Incase image file cannot be found
            Debug.LogError("File not found: " + filePath);
            return null;
        }


    }

    /// <summary>
    /// Retrieves a random material matching the specified tag and rarity.
    /// Returns null if no matching materials exist.
    /// </summary>
    public MaterialItem GetRandom(string tag, int rarity = 0)
    {
        var list = MaterialCollection[tag][rarity];
        if (list.Count == 0)
        {
            Debug.LogWarning($"No materials found for tag {tag} and rarity {rarity}");
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, list.Count); // max is exclusive
        return list[randomIndex];
    }



    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}
