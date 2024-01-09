def filter(str_input, predicate):
    result = []
    for string in str_input:
        if (predicate(string)):
            result.append(string)
    return result

def display(str_input):
    for str in str_input:
        print(str)

def startsWithA(string):
    if (string[0] == "A"):
        return True
    else:
        return False

strings = ["Hello", "World", "Am", "Hi", "a"]
filtered_result = filter(strings, startsWithA)
display(filtered_result)