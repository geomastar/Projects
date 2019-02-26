const QButton = document.getElementById("QButton");
const WButton = document.getElementById("WButton");
const EButton = document.getElementById("EButton");
const RButton = document.getElementById("RButton");
const TButton = document.getElementById("TButton");
const YButton = document.getElementById("YButton");
const UButton = document.getElementById("UButton");
const IButton = document.getElementById("IButton");
const OButton = document.getElementById("OButton");
const PButton = document.getElementById("PButton");
const AButton = document.getElementById("AButton");
const SButton = document.getElementById("SButton");
const DButton = document.getElementById("DButton");
const FButton = document.getElementById("FButton");
const GButton = document.getElementById("GButton");
const HButton = document.getElementById("HButton");
const JButton = document.getElementById("JButton");
const KButton = document.getElementById("KButton");
const LButton = document.getElementById("LButton");
const ZButton = document.getElementById("ZButton");
const XButton = document.getElementById("XButton");
const CButton = document.getElementById("CButton");
const VButton = document.getElementById("VButton");
const BButton = document.getElementById("BButton");
const NButton = document.getElementById("NButton");
const MButton = document.getElementById("MButton");
const letter0Span = document.getElementById("letter0");
const letter1Span = document.getElementById("letter1");
const letter2Span = document.getElementById("letter2");
const letter3Span = document.getElementById("letter3");
const letter4Span = document.getElementById("letter4");
const letter5Span = document.getElementById("letter5");
const letter6Span = document.getElementById("letter6");
const letter7Span = document.getElementById("letter7");
const letter8Span = document.getElementById("letter8");
const letter9Span = document.getElementById("letter9");
const letter10Span = document.getElementById("letter10");
const letter11Span = document.getElementById("letter11");
const image = document.getElementById("image");
const buttons = 
[
	AButton, BButton, CButton, DButton, EButton, FButton,
    GButton, HButton, IButton, JButton, KButton, LButton,
	MButton, NButton, OButton, PButton, QButton, RButton,
    SButton, TButton, UButton, VButton, WButton, XButton,
	YButton, ZButton
];
const letterSpans = 
[
	letter0Span, letter1Span, letter2Span,
	letter3Span, letter4Span, letter5Span,
	letter6Span, letter7Span, letter8Span,
	letter9Span, letter10Span, letter11Span
];
const imagePaths = 
[
	"Resources/0.png", "Resources/1.png",
	"Resources/2.png", "Resources/3.png",
	"Resources/4.png", "Resources/5.png",
	"Resources/6.png", "Resources/7.png",
	"Resources/8.png", "Resources/9.png",
	"Resources/10.png", "Resources/11.png",
	"Resources/12.png", "Resources/13.png"
	
];
const outcome = document.getElementById("outcome");
const outcomeText = ["You Win !!!", "You Lose. the word was: "];                                                                                                     ;

QButton.onclick = function(){ buttonPress('Q', QButton); }
WButton.onclick = function(){ buttonPress('W', WButton); }
EButton.onclick = function(){ buttonPress('E', EButton); }
RButton.onclick = function(){ buttonPress('R', RButton); }
TButton.onclick = function(){ buttonPress('T', TButton); }
YButton.onclick = function(){ buttonPress('Y', YButton); }
UButton.onclick = function(){ buttonPress('U', UButton); }
IButton.onclick = function(){ buttonPress('I', IButton); }
OButton.onclick = function(){ buttonPress('O', OButton); }
PButton.onclick = function(){ buttonPress('P', PButton); }
AButton.onclick = function(){ buttonPress('A', AButton); }
SButton.onclick = function(){ buttonPress('S', SButton); }
DButton.onclick = function(){ buttonPress('D', DButton); }
FButton.onclick = function(){ buttonPress('F', FButton); }
GButton.onclick = function(){ buttonPress('G', GButton); }
HButton.onclick = function(){ buttonPress('H', HButton); }
JButton.onclick = function(){ buttonPress('J', JButton); }
KButton.onclick = function(){ buttonPress('K', KButton); }
LButton.onclick = function(){ buttonPress('L', LButton); }
ZButton.onclick = function(){ buttonPress('Z', ZButton); }
XButton.onclick = function(){ buttonPress('X', XButton); }
CButton.onclick = function(){ buttonPress('C', CButton); }
VButton.onclick = function(){ buttonPress('V', VButton); }
BButton.onclick = function(){ buttonPress('B', BButton); }
NButton.onclick = function(){ buttonPress('N', NButton); }
MButton.onclick = function(){ buttonPress('M', MButton); }

var dictionary = [];
var wrongGuesses = 0;
var wordString = "";
var word = [];




function playGame(file)
{
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function()
	{
		if (this.readyState == 4 && this.status == 200)
		{
			setup(this.responseText.split(","));
		}
	};
	xhttp.open("GET", file, true);
	xhttp.send();
}



function setup(array)
{	
	dictionary = array;
	createWord(generateRandomWord());
	for (var i = word.length; i < 12; i++)
	{
		letterSpans[i].textContent = "";
	}
}

function generateRandomWord()
{
	while(true)
	{
		var temp = dictionary[Math.floor(Math.random() * dictionary.length)];
		if (temp.length <= 12)
		{
			wordString = temp;
			return temp;
		}
	}
}
function createWord(theWord)
{
	for (let i = 0; i < theWord.length; i++)
	{
		word.push(createLetter(theWord[i]));
	}
	
	console.log("The Word is: " + theWord);
}
function createLetter(theLetter)
{
	var letter = theLetter.toUpperCase();	
	var guessed = false;
	const letterStruct = [letter, guessed];
	
	return letterStruct;
}



function buttonPress(theLetter, theButton)
{
	theButton.disabled = true;
	var indexes = checkGuess(theLetter);
	indexes.forEach(function(element)
	{
		letterSpans[element].textContent = theLetter;
	});
	if (checkWin())
	{
		fin(true);
	}
	if (indexes.length == 0)
	{
		wrongGuesses++;
		image.src = imagePaths[wrongGuesses];
		if (wrongGuesses == 12)
		{
			fin(false);
		}
	}
}

function checkGuess(theLetter)
{
	var returnValue = [];
	
	word.forEach(
		function(element)
		{
			if (theLetter == element[0])
			{				
				returnValue.push(word.indexOf(element));
				element[1] = true;
			}
		});
	
	return returnValue;
}
function checkWin()
{
	var returnValue = true;
	
	word.forEach(function(element)
	{
		if (element[1] == false)
		{
			returnValue = false;
		}
	});
	
	return returnValue;
}
function fin(resultBool)
{
	if (resultBool) 
	{ 
		console.log("win"); 
		outcome.textContent = outcomeText[0]; 
	}
	else 
	{ 
		console.log("lose"); 
		outcome.textContent = outcomeText[1] + wordString; 
	}
	
	buttons.forEach(function(element)
	{
		element.disabled = true;
	});
}




playGame("Resources/dictionary.txt")