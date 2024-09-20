# Space Shooter Game - DOTS Assignment #

Most of this assignment has been based upon the lectures that we had where we coded along.
The player is able to move with the WASD keys and shoot with Space Bar. I have however added enemy movement and altered the spawner.

I added a simple movement to the enemy with an Enemy Authoring and Enemy Move System:
The enemy moves slowly downward, similar to an old arcade game. It is made very similar to how the player moves as it transforms the local position,
however here it only moves in the y axis. The movement is using burst compile which reduces the performance of the movement on the system.

I modified the spawner to create waves of enemies at an area around the spawners location. They are set to spawn within a random range by using 
Unity.Mathematics Random to make sure the calculation is efficient.