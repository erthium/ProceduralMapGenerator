# ProceduralMapGenerator
 
Procedural Map Generator Prototype, mainly made to use as forest map creator in a strategy game.

Unity Editor Version: [2020.3.22f1](https://unity.com/releases/editor/whats-new/2020.3.22)

## It Consist...

### Mesh Generator

A basic Mesh Generator made by using Perlin Noise, to be able to create a smooth and continues land shape. 

<img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/mesh_generator_1.JPG" width=50% height=50%>
<img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/mesh_generator_2.JPG" width=50% height=50%>


The built-in function that has been used for perlin noise

```c#
UnityEngine.Mathf.PerlinNoise
```

### Map Generator

After the land has been generated, comes the part where we locate the chosen amount of objects on the land. In this case, since it was a map for camp sides in the forest, our surroundings will be camps and trees. To inpersonate them in the prototype, there are simple wide and long rectangles.

<img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/map_generator_1.JPG" width=50% height=50%>
<img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/map_generator_2.JPG" width=50% height=50%>
<img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/map_generator_3.JPG" width=50% height=50%>

