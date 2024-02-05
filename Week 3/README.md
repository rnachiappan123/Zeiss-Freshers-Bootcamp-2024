# My Experience with the Event Aggregator Design Pattern
During the third week of our freshers' training program at Zeiss, we were given a simple user story and tasked to come up with a suitable design - and its corresponding implementation in code - that satisfies all of the requirements. This article is about the issues in my original system design, how they were addressed with the use of event aggregator design pattern, and my learning outcomes from this assignment.
## The User Story
There are two types of doors: a *simple door* and a *smart door*. A simple door has only two functionalities: *open* and *close*, which open and close the door respectively. A smart door - which can also act as a simple door - has a *door state* (either *opened* or *closed*) and a *timer* that triggers other smart features when the door stays open for too long.

Smart features include:
1. *Buzzer Alert*: generates audible noise when triggered.
2. *Pager Alert*: sends a notification alert via pager.
3. *Auto-Close*: automatically closes the door when triggered.

The smart features must be **configurable** based on the demands of the customer.
## The Original Design
My initial design revolved heavily around the use of the **Observer** pattern, where each component (*subscriber*) observes for state changes in other components (*publishers*), and communication between them took place in the form of *events*.
![alt text](https://raw.githubusercontent.com/rnachiappan123/Zeiss-Freshers-Bootcamp-2024/main/Week%203/Door%20Model/Before/Door%20LLD.svg)