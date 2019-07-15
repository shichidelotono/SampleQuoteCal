# SampleQuoteCal

Example

* URL - https://localhost:5001/api/quote (e.g. running Web App on Kestrel)
* Method - Post
* Body - {
	"amountRequired" : 8000,
	"term" : 24,
	"title": "Mr",
	"firstName" : "Bumble",
	"lastName" : "Bee",
	"mobile" : "0838386289",
	"email": "bumblebee@outlook.com"
}
* Sample response - {
    "url": "https://localhost:5001/home/quote?amountRequired=8000&term=24&title=Mr&firstName=Bumble&lastName=Bee&mobile=0838386289email=bumblebee@outlook.com"
}
* Database name - CalculateQuoteDatabase.db
* Database location - same directory as SampleQuoteApi.csproj
