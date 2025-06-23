# PW1

## Student ID
9406701

## Table of Contents
1. Introduction
2. Description
3. Problems
4. Conclusions

## Introduction
This document describes the design and implementation of a train simulation system developed as an individual practical assignment. The project was developed in C# using .NET Core 8.0 and incorporates key object-oriented principles such as abstraction, encapsulation, inheritance, and polymorphism.

## Description

### Objective
To simulate the arrival and docking of passenger and freight trains at a station, managing platform allocation over discrete time steps of 15 minutes.

### Main Features
- Load train data from a CSV file
- Advance time in 15-minute ticks
- Assign arriving trains to free platforms
- Handle docking delays and waiting status
- Display train and platform status at every step

### Class Overview

1. BaseTrain (abstract class)
   - Identifier: unique train ID
   - MinutesUntilArrival: arrival countdown
   - CurrentStatus: EnRoute, Waiting, Docking, Docked
   - Category: "passenger" or "freight"

2. PassengerTrain (inherits BaseTrain)
   - NumberOfCarriages
   - Capacity

3. FreightTrain (inherits BaseTrain)
   - MaxWeight
   - FreightType

4. Platform
   - ID, Status (Free/Occupied), CurrentTrain, RemainingDockingTicks

5. Station
   - List of Platforms
   - List of all Trains
   - Methods: AddTrain(), AdvanceTick(), DisplayStatus()

6. Program
   - CLI menu: load file, run simulation, view status, exit
   - CSV parsing and error handling
   - Simulation loop until all trains are docked

### Class Diagram (textual)
BaseTrain (abstract)
-- PassengerTrain
-- FreightTrain

Station
-- List<Platform>
-- List<BaseTrain>

Platform
-- BaseTrain (if occupied)

## Problems
- File format validation required try-catch
- Visual Studio sometimes didn’t recognize new files (solved by recreating them)
- Handling docking tick countdown and transitions between states took debugging

## Conclusions
- Reinforced the use of abstract classes and polymorphism
- Improved understanding of simulation logic and time-stepped modeling
- Learned how to structure and isolate logic across multiple classes
- Managed clean file input and error handling practices
