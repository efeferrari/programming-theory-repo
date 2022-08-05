# Programming theory repo
Unity Junior Programmer final project

# Description
This project was created to accomplish the Unity course [Programming theory in action](https://learn.unity.com/tutorial/submission-programming-theory-in-action).

# General requirements.
* Create any kind of Video Game
* Implement the Four Pillars of OOP.
* Use git as VCS creating different commits and branches.
* Implement all the acquired knowledge during the course.

### Requirement accomplishments.
* OOP Pillars:
  * Abstraction.
    * Use of Unity as GameEngine avoiding to write a new one by myself.
    * Use of functionality like Colliders, GameObject.Find and User Input reads.
  * Inheritance.
    * My scripts are all based on the MonoBehaviour class.
  * Polymorphism.
    * Obstacles over the board has all the same functionality but different type of PhysicMaterial and Score.
  * Encapsulation.
    * The Cannon class have mostly private attributes, encapsulating the own functionality.

### Another functionality.
* User score and name are persistent, so even if the game is closed the user's score is saved.
* An event is triggered when the User throws the ball and start playing to stop reading User input for the spacebar key.