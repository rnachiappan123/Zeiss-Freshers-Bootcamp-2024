class StartsWithStrategy:
    startChar = None
    
    def setStartChar(self, key):
        self.startChar = key
    
    def invokeStrategy(self, stringItem):
        if (stringItem[0] == self.startChar):
            return True
        else:
            return False

class StringListFilterController:
    strategy = StartsWithStrategy()
    
    def filter(self, stringList):
        result = []
        for stringItem in stringList:
            if(self.strategy.invokeStrategy(stringItem)):
                result.append(stringItem)
        return result

class ConsoleDisplayController:
    content = None
    
    def setContent(self, message):
        self.content = message
    
    def display(self):
        print(self.content)
    
strings = ["Hello", "World", "Hi", "Am", "a"]
displayObject = ConsoleDisplayController()
filterObject = StringListFilterController()
filterObject.strategy.setStartChar("A")
displayObject.setContent(filterObject.filter(strings))
displayObject.display()
