platform-performance-c#
=======================

Description will come later. This project is about developing and trying a principle / method, for how to "choose" and use algorithms. The idea is very simple:
 I present you with for example 10 different ways of performing some operation, then  you would (as a human) choose the best / fastest (depening on the goal).
 
For humans that is quite natural, but for a programmer that apprently is not an intuitve thinking (instead we mostly assume that we know how the machine will act and work, and thus that we should use method xyz), but what happens if we let the machine decide ? that is what this project is about. The original idea was to do it in c++, where the benifits are most apprent, due to the larger improvements in performance, but the improvements are also visable in other areas, even in VM's (such as the .net VM, and eventually in the java vm).

To put simple, the very most people uses the inbuilt sort, which is very good (indeed), but it is NOT optimal in most cases. its not due to bad code, its due to the fact that hardware changes, and that change cannot be "precoded", so the inbuilt sorting is based on "older" hardware (this depend on what version ect....), which means that the newer hardware might have a feature xyz, that makes another sort (for this example) much faster than previous hardware did. 
