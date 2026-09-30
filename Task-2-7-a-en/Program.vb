Option Infer On
Imports System
Imports System.Collections.Generic

Module Program
	Sub Main(args As String())
		Dim a As String ' Current code string
		Dim b As String ' Target code string
		Dim n_len1 As Integer ' Length of the current code string
		Dim n_len2 As Integer ' Length of the target code string
		Dim total_moves As Integer = 0 ' Move counter
		' Read input data
		Console.Write("Enter the current code: ") ' Display a prompt
		a = Console.ReadLine() ' Enter the current code
		Console.Write("Enter the target code: ")
		b = Console.ReadLine() ' Enter the integer code
		a = a.Trim() ' Remove unnecessary spaces
		b = b.Trim() ' Remove unnecessary spaces
		n_len1 = a.Length ' Calculate the length of the 1st string
		n_len2 = b.Length ' Calculate the length of the 2nd string
		' Check if the length of the current and target codes matches
		' If the length of the current code is not equal to the length of the target
		' and both codes are not four-digit, the program terminates.
		If (n_len1 <> 4) OrElse (n_len2 <> 4) OrElse (n_len1 <> n_len2) Then
			Console.WriteLine("The combination lock must be 4 digits.")
			Console.WriteLine("The current and target codes must be the same length.")
			Console.Read() ' Delay output until the Enter key is pressed
			Environment.Exit(0) ' Exit the program
		End If
		' Calculate the minimum number of moves
		' Two character strings are processed in one loop
		Dim c = Enumerable.Zip(a, b)
		For Each p In c
			Dim x = Convert.ToInt32(AscW(p.First) - AscW("0"c)) ' Current code digit
			Dim y = Convert.ToInt32(AscW(p.Second) - AscW("0"c)) ' Target code digit
			Dim diff1 = Math.Abs(x - y) ' difference in digits, forward disk spin
			Dim diff2 = 10 - Math.Abs(x - y) ' difference in digits, reverse disk spin
			' Minimum number of moves - the difference between each digit on the disk
			' in the target code and the current safe lock code
			total_moves += Math.Min(diff1, diff2) ' Total number of moves - answer to the question
		Next p
		' Display information on the screen
		Console.WriteLine($"Current code: {a}")
		Console.WriteLine($"Target code: {b}")
		Console.WriteLine($"Minimum number of moves: {total_moves}")
		Console.Read() ' Delay output until the Enter key is pressed
	End Sub
End Module
