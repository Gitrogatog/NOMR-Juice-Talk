# NOMR Juice Talk
 A sample project used for the NOMR Juice Talk. Feel free to mess around in the EMPTY and COMPLETE scenes!

Instructions for use:
The EMPTY scene represents the project at the beginning of the demo, with no juice, while the COMPLETE scene represents the project at the end, with a lot of juice.
Click and drag the ball around to move it, and press Left Shift to set its velocity to zero. Use the left and right arrow keys or the A and D keys to turn the wand, and Space to fire it.

Instructions for how to tale the EMPTY scene to the COMPLETE scene:
Ball:
1. To make the ball move smoothly: Set Lerp Speed to a high value (such as 100) to make the ball move smoothly towards the mouse, and set Overreach Position to true (check the box) to make it overshoot the mouse slightly. Note that without Overreach Position set to true, the ball's velocity will not work correctly. Please set this to true before experimenting with the other effects.
2. To enable the outline: Enable the Outline object attached to the ball. You can adjust the outlines by setting the values in the ClickOutline script attached to the ball.
3. To enable the particle and sound on collision: Set Enabled to true on the Collision Spawner component. Do this for the VARIABLE I defined in the script, not for the component itself.
4. To enable the trail: Enable the Trail Renderer component.
5. To make the ball stretch in the direction of its velocity: Enable the Stretch Ball script component.
6. To give the ball its eyes: Enable the Ball Eye script component and enable the Eye Holder child GameObject attached to the ball.

Wand:
1. To enable the aim line: Enable the Line Renderer component attached to the wand.
2. To play sounds when the wand is fired and when the projectile hits: Enable the two Audio Source components attached to the wand. The top one plays the fire sound, while the lower one plays the explosion sound.
