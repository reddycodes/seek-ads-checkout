# Seek Ads Checkout Rebuild
Seek Coding Assessment

[![Build Status](https://snehitv.visualstudio.com/Seek%20Ads/_apis/build/status/Seek%20Ads-ASP.NET%20Core-CI)](https://snehitv.visualstudio.com/Seek%20Ads/_build/latest?definitionId=2)

The problem at hand is to rewrite its job ads checkout system to enable the pricing rules to be as flexible as possible to enable easy changes.

The solution is built on .net core and contains two projects:
* Business/Domain Entities
* Tests

The solution utilised some of the design patterns such as Factory Pattern to help in object creation and Strategy Pattern to help with object's behaviour at run time along with SOLID principles.

The solution is built following TDD techniques.

***Current Code Coverage: 100% (TBD: Direct integration from CI pipelines to here)***

Below is the solution design diagram:
![alt text](https://raw.githubusercontent.com/reddycodes/seek-ads-checkout/master/Design%20Diagram.png)
