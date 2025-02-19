Texture repeating should be set to Mirror instead of Repeat/Tile. In Blender, as of version 3.5.0, this can be done on the image texture node in the shader editor.

Parts of the ship may appear invisible when viewed through the rigging. If this happens, change the alpha blend mode in the material properties from "Alpha Blend" to "Alpha Clip". Alternatively, you can create another material with no alpha for the parts of the ship that do not use transparency; if you do this, note that the rigging on each side of the ship uses TWO overlapping triangles with opposite normals.

Textures for the sail in flag were extracted with the ship, but the objects for them were not. I do not know exactly why. You will have to create these yourself for your project.