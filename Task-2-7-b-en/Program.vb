Option Infer On
Imports System

Module Program
	Sub Main(args As String())
		Dim a As Integer = Nothing ' Current code
		Dim b As Integer = Nothing ' Target code
		Dim m As Integer = 0 ' Number of digits of the target code
		Dim n As Integer = 0 ' Number of digits of the current code
		Dim total_moves As Integer = 0 ' Number of moves of the combination lock discs
		Dim a1, b1 As Integer ' Temporary variables for working with combination lock combinations
		' Data input: target and current codes
		' are entered as four-digit numbers
		Console.Write("Enter the current code: ")
		Integer.TryParse(Console.ReadLine(), a)
		Console.Write("Enter the target code: ")
		Integer.TryParse(Console.ReadLine(), b)
		a1 = a : b1 = b
		' Number of digits of the current code
		Do While a1 > 0 ' Loop execution condition
			m += 1 ' The digit counter has been increased by 1
			a1 \= 10 ' The number has been decreased by a factor of 10
		Loop
		' Number of digits in the target code
		Do While b1 > 0 ' Loop execution condition
			n += 1 ' The digit counter has been increased by 1
			b1 \= 10 ' The number has been decreased by a factor of 10
		Loop
		' Check if the length of the current and target codes matches
		' If the length of the current code is not equal to the length of the target code
		' and both codes are not four-digit, the program terminates.
		If (m <> 4) OrElse (n <> 4) OrElse (m <> n) Then
			Console.WriteLine("The combination lock must be 4 digits.")
			Console.WriteLine("The current and target codes must be the same length.")
			Console.Read() ' Delay output until the Enter key is pressed
			Environment.Exit(0) ' Exit the program
		End If
		a1 = a : b1 = b
		' Loop through the digits of the current and target codes
		Do While (a1 > 0) AndAlso (b1 > 0)
			Dim d1 = a1 Mod 10 ' Current code digit
			Dim d2 = b1 Mod 10 ' Target code digit
			Dim diff1 = Math.Abs(d1 - d2) ' difference in digits, forward disk spin
			Dim diff2 = 10 - Math.Abs(d1 - d2) ' difference in digits, reverse disk spin
			' Minimum number of moves - the difference between each digit on the disk
			' in the target code and the current safe lock code
			total_moves += Math.Min(diff1, diff2)
			a1 \= 10 ' Move to the next digit of the current code
			b1 \= 10 ' Move to the next digit of the target code
		Loop
		' Display information on the screen
		Console.WriteLine($"Current code: {a}")
		Console.WriteLine($"Target code: {b}")
		Console.WriteLine($"Minimum number of moves: {total_moves}")
		Console.Read() ' Delay output until the Enter key is pressed
	End Sub
End Module
