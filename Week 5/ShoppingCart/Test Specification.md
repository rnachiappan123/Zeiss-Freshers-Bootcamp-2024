# Shopping Cart Test Specification
1. Given empty cart (input = ""), when checkout, then return 0.
"" -> 0
2. Given one item as input, then return price of given item.
"A" -> 50
3. Given two or more items, then return sum of prices.
"ABC" -> 100
4. Given items that are applicable for offer, return discounted price.
"AAA" -> 130
"BAB" -> 95
"AAAA" -> 180
5. Given items that are not in item list, throw exception.
"E" -> (exception)