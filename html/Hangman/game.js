const letter0Span = document.getElementById("letter0")
const letter1Span = document.getElementById("letter1")
const letter2Span = document.getElementById("letter2")
const letter3Span = document.getElementById("letter3")
const letter4Span = document.getElementById("letter4")
const letter5Span = document.getElementById("letter5")
const letter6Span = document.getElementById("letter6")
const letter7Span = document.getElementById("letter7")
const letter8Span = document.getElementById("letter8")
const letter9Span = document.getElementById("letter9")
const letter10Span = document.getElementById("letter10")
const letter11Span = document.getElementById("letter11")
const letterSpans = 
[
	letter0Span, letter1Span, letter2Span,
	letter3Span, letter4Span, letter5Span,
	letter6Span, letter7Span, letter8Span,
	letter9Span, letter10Span, letter11Span
];
const dictionary = createDictionary();
var wrongGuesses = 0;

function createDictionary()
{
	
}

function createLetter(theLetter)
{
	var letter = theLetter;	
	var guessed = 0;
	const letterStruct = [letter, guessed];
	
	return letterStruct;
}

function main()
{
	console.log(createLetter('I')[1])
}

main();