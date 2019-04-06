'-by Sage Shoemake
'	This console app will create a class With multiple properties, create instances Of that class in a list,
'serialize and Write the list as JSON to a text file, and finally deserialize and read the list before writing 
'it to the console

Imports System.IO
Imports Newtonsoft.Json

Module WriteToJSON

	Sub Main()
		Dim list = GetDogs() 'create a list of dogs
		Dim path As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\dogs.txt"

		WriteToJSON(list) 'pass created list to subroutine to serialize and write JSON to a text file
		ReadFromJson(path) 'pass file path created above to subroutine to deserialize and read JSON we created earlier, and write it to console

		Console.WriteLine("Press any key to close") 'so console doesn't immediately close
		Console.ReadKey()
	End Sub

	'class that we'll be using to create a list of objects to write to JSON 

	Public Class Dog
        Public Property DogName As String
        Public Property Gender As String
        Public Property Breed As String
        Public Property Color As String

        Public Sub New()

        End Sub

		'Constructor

		Public Sub New(ByVal name As String,
					   ByVal gndr As String,
					   ByVal brd As String,
					   ByVal clr As String)
			DogName = name
			Gender = gndr
			Breed = brd
			Color = clr
		End Sub

		'to write the objects and its respective properties to console

		Public Sub Print()
			Console.WriteLine("Dog Name: " & DogName & ", Breed: " & Breed & ", Gender: " & Gender & ", Color: " & Color)
			Console.WriteLine()
		End Sub
	End Class

	'will create new instances of Dog class and add them to a list

	Function GetDogs() As IEnumerable(Of Dog)
        Return New List(Of Dog) From
            {
            New Dog("Hershey", "Male", "Rhodesian Ridgeback", "Brown"),
            New Dog("Chance", "Male", "Rat Terrier", "White"),
            New Dog("Luna", "Female", "Australian Shepherd", "Grey/Brown")
            }
    End Function

	'takes Dog class as arg, creates a writable file path, serializes the collection of Dogs into JSON, and writes a JSON string to text file

	Sub WriteToJSON(ByVal dogs As IEnumerable(Of Dog))

		Dim path As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\dogs.txt"

		File.WriteAllText(path, JsonConvert.SerializeObject(dogs, Newtonsoft.Json.Formatting.Indented))

	End Sub

	'takes a file path as arg, reads the file to a string, deserializes the JSON string into a collection of Dog objects,
	'and prints the objects and their properties to the console using Dog class' Print subroutine

	Sub ReadFromJson(ByVal jsonFile As String)

		Dim readText As String = File.ReadAllText(jsonFile)
		Dim newDogs As List(Of Dog) = JsonConvert.DeserializeObject(Of List(Of Dog))(readText)

		For Each d In newDogs

			d.Print()

		Next

	End Sub

End Module
