class Filter:
    result = []
    predicateFn = None
    
    def __init__(self, predicate):
        self.predicateFn = predicate
    
    def filterInput(self, inputStrings):
        for item in inputStrings:
            if (self.predicateFn(item)):
                self.result.append(item)
    
    def getResult(self):
        return self.result

class IO:
    def printArrayToTerminal(self, array):
        for item in array:
            print(item)

class Predicate:
    def checkStringStartsWithAny(startChar):
        predicate = lambda stringItem : stringItem[0] == startChar
        return predicate
        
strings = ["Hello", "World", "Am", "Hi", "a"]

predicateObject = Predicate()
filterObject = Filter(Predicate.checkStringStartsWithAny("A"))
iObject = IO()

filterObject.filterInput(strings)
filteredResult = filterObject.getResult()
iObject.printArrayToTerminal(filteredResult)