# Material Importer for Untitled: "Searfarers"
A Material Importer created for the development of Untitled: "Seafarers". 

This Material Importer was made to be dynamic and flexible. Whether it's me, the developer, adding new materials, fish, resources, etc, to the loot table, or players potentially wishing to add their own content, the Material Importer was the first step towards achiving that goal. 

The importer is responsible to bringing the item into existence within the scope of the game. If an item needs to be pulled from the loot table or called for a item needed in a recipe, the Material Importer is likely what made it available to be discovered, collected, or gathered in the first place.

## Json File Formatting


Here is an example of what an item within the MaterialList.JSON might look like:

    "name": "Iron Ore",
    "tag": "Resource",
    "rarity": 0,
    "icon": "iron_ore.png",
    "value": 50,
    "weight": 5,
    "hasMixture": false

Properties such as the item's weight, value, rarity, are all predetermined. The tag helps categorize materials such as "Fish," or "Resource," for sorting and various other purposes. While the icon name could be inferred, the JSON file ask for a direct name to reference. Finally, the hasMixture property was originally intended for the game's brewing system before the project was redefined. 

### Improvements and Future?
The future of this script would involve incorporating object models and a direct tie-in to recipes. Accomplishing this would probably be fairly simple, using FBX models, as they're quite compatible with Unity. As for a recipe tie-in, I would imagine a script that runs after this one, checking to see if the material is in the game before adding the item.


## About Searfarer
"Searfarers" was originally envisioned as an open-world, top-down isometric RPG. However, after returning from other projects, the game's scope narrowed to focus on sailing where the player travels from dock to dock, shore to shore, and eventually across the grand sea of the world. Players would begin as humble rowboat fishermen as they eventually worked their way up to become merchants ferrying goods between distant ports.

