def filter(str_inputs, predicateFn):
    result = []
    for item in str_inputs:
        if (predicateFn(item)):
            result.append(item)
    return result

def printToTerminal(array):
    for item in array:
        print(item)

def checkStringStartsWithA(string):
    if (string[0] == "A"):
        return True
    else:
        return False

strings = ["Hello", "World", "Am", "Hi", "a"]
filtered_result = filter(strings, checkStringStartsWithA)
printToTerminal(filtered_result)