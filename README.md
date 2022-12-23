# Procedural Map Generator
 
Procedural Map Generator Prototype, mainly made to use as forest map creator in a strategy game with Unity Game Engine.

## Setup

The folder "3D - 09.01.2022" is the main Unity Project. After you clone or dowload the repository, you can select that folder in Unity Hub and open the project.
Beware that used Unity Editor version of this project is [2020.3.22f1](https://unity.com/releases/editor/whats-new/2020.3.22).

## It Consists...

### Mesh Generator

A basic Mesh Generator made by using Perlin Noise, to be able to create a smooth and continues land shape. 

<p align="center">
  <img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/mesh_generator_1.JPG" width=50% height=50%>
  <img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/mesh_generator_2.JPG" width=50% height=50%>
</p>

The built-in function that has been used for perlin noise

```c#
UnityEngine.Mathf.PerlinNoise
```

### Map Generator

After the land has been generated, comes the part where we locate the chosen amount of objects on the land. In this case, since it was a map for camp sides in the forest, our surroundings will be camps and trees. To inpersonate them in the prototype, there are simple wide and long rectangles.

We can adjust the offset between the entities. You can see the difference in the images below, with the Editor values of offsets(radius) and amounts.

<p align="center">
  <img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/map_generator_1.JPG" width=50% height=50%>
  <img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/map_generator_2.JPG" width=50% height=50%>
  <img src="https://github.com/ErtyumPX/ProceduralMapGenerator/blob/main/Images/map_generator_3.JPG" width=50% height=50%>
</p>
