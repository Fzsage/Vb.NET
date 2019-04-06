'-by Sage Shoemake
'This is my implementation of the popular coding challenge "FizzBuzz". 
'It will loop through integers 1 through 100
'If the number is divisible by 3, it will output "Fizz" to the console
'If the number is divisible by 5, it will output "Buzz" to the console
'If the number is divisible by 3 and 5 (or 15), it will output "FizzBuzz" to the console
'If a number doesn't match any of these scenarios, it alone will be output to the console

Module FizzBuzz

	Sub Main()

		For i As Integer = 1 To 100
			fizzBuzzIt(i) 'pass iterations of integer loop to subroutine to keep Main clean
		Next

		Console.WriteLine("Press any key to close") 'so console doesn't close immediately
		Console.ReadKey()

	End Sub

	Sub fizzBuzzIt(ByVal i As Integer)

		If (i Mod 15) = 0 Then  'if divisible by 3 and 5, FizzBuzz. Must be first, or else you'll never see a FizzBuzz
			Console.WriteLine("FizzBuzz!")

		ElseIf (i Mod 3) = 0 Then 'if divisible by 3, then Fizz
			Console.WriteLine("Fizz!")

		ElseIf (i Mod 5) = 0 Then 'if divisble by 5, then Buzz
			Console.WriteLine("Buzz!")

		Else
			Console.WriteLine(i) 'for all other cases when number is not divisible by 3 or 5 (or both)
		End If

	End Sub

End Module
