### DOCUMENTATION FOR PROJECT 2

The game is a closed maze which requires for the player to find the key and bring that key to the door to end the game successfully. A successful termination of the game occurs when the door façade slips down.

### Technical details:

The key still is affected by gravity but since I wanted it to be more realistic, I didn't want to make the key massive. But making it too small would create a harder experience to the player while pushing the key to the end of the maze. Thus I added an extra ability to the player, it is able to get hold of the key when collided with it and let it go when it presses _"s"_ key.

The trap I chose is a missile device that throws three missiles each turn. The pattern of attacks doesn't follow an irregular or complex pattern, there are five missile machines and they fire one by one, periodically. The missiles fly for some length and get destroyed before the next firing occurs. I chose to destroy the fired missiles because an accumulation of them inside game would occupy useless CPU although it provides a less realistic experience.

Player can move right, left, forward, backward. It cannot jump. It cannot pass through missile machines and neither can it pass through or climb up the fences. It cannot rotate its face direction. Pressing _"s"_ key will give the player the ability to attach key to itself while walking.


The path between key and the door is as below:

![image](https://user-images.githubusercontent.com/64031659/234134763-05dbc9ef-864f-4d83-8efd-aed4047e2cff.png)


Winning coniditon is making the key collide with the door object without colliding with any missiles thrown by the machines.

The background music can be turned on-off by pressing the _"space"_ key on the keyboard.

