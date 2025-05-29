using System;
using System.Collections.Generic;
using System.Threading;

class LiftSystem
{
    // List of floors in the building
    private static List<string> floors = new List<string> { "GROUND", "FLOOR1", "FLOOR2", "LIBRARY" };

    // Current floor of the lift
    private static int currentFloor = 0;

    // Door state (true = open, false = closed)
    private static bool isDoorOpen = false;

    static void Main(string[] args)
    {
        Console.WriteLine("Lift System Simulation");
        Console.WriteLine("----------------------");

        // Start the lift from the ground floor
        StartLift();

        // Continuously accept user input for destination floor
        while (true)
        {
            Console.WriteLine("\nEnter the floor you want to go to (GROUND, FLOOR1, FLOOR2, LIBRARY) or type 'EXIT' to quit:");
            string input = Console.ReadLine().ToUpper();

            if (input == "EXIT")
            {
                Console.WriteLine("Exiting lift simulation...");
                break;
            }

            // Validate the input and move to the specified floor
            if (floors.Contains(input))
            {
                MoveToFloor(input);
            }
            else
            {
                Console.WriteLine("Invalid floor. Please try again.");
            }
        }
    }

    // Start the lift from the ground floor
    static void StartLift()
    {
        currentFloor = 0; // GROUND floor
        Console.WriteLine("Lift started at: " + floors[currentFloor]);

        // Open the door at the ground floor for 30 seconds
        OpenDoor();
        Thread.Sleep(30000); // Wait for 30 seconds
        CloseDoor();
    }

    // Move the lift to the specified floor
    static void MoveToFloor(string targetFloor)
    {
        int targetIndex = floors.IndexOf(targetFloor);

        if (targetIndex == currentFloor)
        {
            Console.WriteLine("Lift is already at " + targetFloor);
            return;
        }

        Console.WriteLine("Moving to: " + targetFloor);

        // Determine direction (UP or DOWN)
        string direction = targetIndex > currentFloor ? "UP" : "DOWN";

        while (currentFloor != targetIndex)
        {
            MoveLift(direction); // Move one floor at a time
            StopLift();          // Stop at the current floor
            OpenDoor();          // Open the door
            Thread.Sleep(30000); // Wait for 30 seconds
            CloseDoor();         // Close the door
        }

        Console.WriteLine("Reached destination: " + targetFloor);
    }

    // Move the lift up or down
    static void MoveLift(string direction)
    {
        if (direction == "UP" && currentFloor < floors.Count - 1)
        {
            currentFloor++;
            Console.WriteLine("Lift moving UP to: " + floors[currentFloor]);
        }
        else if (direction == "DOWN" && currentFloor > 0)
        {
            currentFloor--;
            Console.WriteLine("Lift moving DOWN to: " + floors[currentFloor]);
        }
        else
        {
            Console.WriteLine("Invalid direction or lift cannot move further.");
        }
    }

    // Stop the lift at the current floor
    static void StopLift()
    {
        Console.WriteLine("Lift stopped at: " + floors[currentFloor]);
    }

    // Open the lift door
    static void OpenDoor()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            Console.WriteLine("Door opened at: " + floors[currentFloor]);
        }
        else
        {
            Console.WriteLine("Door is already open.");
        }
    }

    // Close the lift door
    static void CloseDoor()
    {
        if (isDoorOpen)
        {
            isDoorOpen = false;
            Console.WriteLine("Door closed at: " + floors[currentFloor]);
        }
        else
        {
            Console.WriteLine("Door is already closed.");
        }
    }
}