function filter(inputStrings, predicateFn) {
    const result = [];
    inputStrings.forEach(function(item) {
        if (predicateFn(item)) {
            result.push(item);
        }
    });
    return result;
}

function checkStringStartsWithAny(startChar) {
    let predicate = (inputString) => inputString.charAt(0) === startChar;
    return predicate;
}

function printArrayToConsole(inputArray) {
    inputArray.forEach(function(item) {
        console.log(item);
    });
}

let strings = ["Hello", "World", "Hi", "Am", "a"];
let filteredStrings = filter(strings, checkStringStartsWithAny("A"));
printArrayToConsole(filteredStrings);