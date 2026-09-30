Option Infer On
Imports System
Imports System.Collections.Generic


Module Program
	Sub Main(args As String())
		Dim a As String ' строка текущего кода
		Dim b As String ' строка целового кода
		Dim n_len1 As Integer ' Длина строки текущего кода
		Dim n_len2 As Integer ' Длина строки целевого кода
		Dim total_moves As Integer = 0 ' Счётчик ходов
		' Чтение входных данных
		Console.Write("Введите текущий код: ") ' Вывод подсказки
		a = Console.ReadLine() ' Ввод текущего кода
		Console.Write("Введите целевой код: ")
		b = Console.ReadLine() ' Ввод целового кода
		a = a.Trim() ' Удаление ненужных пробелов
		b = b.Trim() ' Удаление ненужных пробелов
		n_len1 = a.Length ' Вычислить длину 1-ой строки
		n_len2 = b.Length ' Вычислить длину 2-ой строки
		' Проверка на совпадение длины текущего и целевого кода
		' Если длина текущего кода не равна длине целевого
		' и оба кода не четырёхзначные, программа завершает работу.
		If (n_len1 <> 4) OrElse (n_len2 <> 4) OrElse (n_len1 <> n_len2) Then
			Console.WriteLine("Комбинация кодового замка должна быть 4 цифры.")
			Console.WriteLine("Текущий и целевой код должны быть одинаковой длины.")
			Console.Read() ' Задержка вывода до нажатия клавиши "Ввод"
			Environment.Exit(0) ' Выход из программы
		End If
		' Подсчет минимального количества ходов
		' Две строки символов обрабатываются в одном цикле
		Dim c = Enumerable.Zip(a, b)
		For Each p In c
			Dim x = Convert.ToInt32(AscW(p.First) - AscW("0"c)) ' Цифра текущего кода
			Dim y = Convert.ToInt32(AscW(p.Second) - AscW("0"c)) ' Цифра целевого кода
			Dim diff1 = Math.Abs(x - y) ' разность цифр, прямой ход диска
			Dim diff2 = 10 - Math.Abs(x - y) ' разность цифр, обратный ход диска
			' Мнинимальное число ходов - разность между каждой цифрой диска
			' в целевом коде и текущем коде замка сейфа
			total_moves += Math.Min(diff1, diff2) ' Общее число ходов - ответ на вопрос
		Next p
		' Вывод информации на экран
		Console.WriteLine($"Текущий код:{a}")
		Console.WriteLine($"Целевой код:{b}")
		Console.WriteLine($"Мнинимальное число ходов:{total_moves}")
		Console.Read() ' Задержка вывода до нажатия клавиши "Ввод"
	End Sub
End Module
