##﻿ My solution repository can be found here:https://github.com/Bree245/cinemacapstone/tree/main


# 🎬 Cinema Management System - Capstone Project

## 📌 Overview
This is my final Capstone Project for the University of Hull.  
It is a **Cinema Management System** written in **C#** that demonstrates multiple OOP principles and project structuring.  
The program simulates managing a cinema, including:
- Selling tickets & concessions
- Adding new screenings
- Managing memberships (including Gold members)
- Saving & loading data

---

## 🛠 Features
- **Sell Tickets & Concessions**: Different ticket types and concession sales.
- **Screening Management**: Add and manage movie screenings.
- **Membership System**: Create, view, and upgrade members to Gold.
- **Data Persistence**: Save and load member/screening data using files.
- **OOP Principles**: Inheritance, Polymorphism, Encapsulation, Abstraction.

---

## 📂 Project Structure
CinemaSystem.cs       # Main cinema logic
Concession.cs         # Concession item class
GoldMember.cs         # Gold member subclass
ISellable.cs          # Interface for sellable items
Member.cs             # Base member class
Program.cs            # Main entry point (menu)
screening.cs          # Screening management
staff.cs              # Staff management
Ticket.cs             # Ticket handling
user.cs               # User handling

---

## ▶ How to Run
1. Clone the repository:
   ```bash
   git clone <repository-link>
   2.	Open the solution file (.sln) in Visual Studio.
	3.	Build the project (Ctrl + Shift + B or ⌘ + Shift + B on Mac).
	4.	Run (Ctrl + F5 or ⌘ + F5 on Mac).

	menu example
	=== CINEMA MANAGEMENT SYSTEM ===
1. Sell Ticket & Concessions
2. Add Screening
3. Upgrade Member to Gold
4. View Members
5. Exit
Select an option:
