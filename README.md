# RPI Hackathon 2014
Flocking simulation

## Theory

Boids stay together to save themselves from predators, creating swarming effect that can be used to visualize other complex systems (e.g. stock markets).

### Three principles (by Craig Reynolds)

* Cohesion (flock centering)
* Flocking (velocity matching)
* Separation (collision avoidance)

### Cohesion

The boids which are far from the center of the flock are more likely to be caught by predators.

Model: the acceleration of each boid points to the center of mass of the nearby boids.

### Flocking

The boids travel in the same direction and speed as nearby boids do.

Model: the acceleration of each boid points to the sum of velocities of nearby boids.

### Separation

The boids try to avoid running into each other.

Model: the acceleration of each boid points away from the sum of distances of nearby boids.

### Vision

Each entity, whether it is a prey or predator, has vision, within which it perceives food or danger. Therefore our model

Model: interaction considered only within a certain radius.

## References

### Flocking

- swarm behavior: http://en.wikipedia.org/wiki/Swarm_behaviour
- Craig Reynolds Flocking: http://www.kfish.org/boids/pseudocode.html
- predator antiflocking behavior: http://www.youtube.com/watch?v=rN8DzlgMt3M

### The Reactive Swarm

- sound reactive swarm: https://www.youtube.com/watch?v=JF24IWou8u0
- sound visualization in unity: http://answers.unity3d.com/questions/35380/music-visualizer.html
- sound tutorial: http://www.creativeapplications.net/mac/visuals-for-sonar-festival-vdmx-to-unity3d-tutorials/

