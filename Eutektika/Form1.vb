Public Class Form1


    Private Function sub1010(ByVal TT1 As Integer, ByVal NN1 As Integer, ByVal TT2 As Integer, ByVal NN2 As Integer, ByRef X1 As Double, ByRef X2 As Double) As Double
        Dim eee As Double = 0.0001
        Dim PP, Y As Double
        X2 = 0 : PP = 1
        While True
            PP = PP / 10
            Do
                X2 = X2 + PP
                X1 = Math.Exp(NN1 * (1 - TT1 * (1 - Math.Log(X2) / NN2) / TT2))
                Y = X1 + X2 - 1
                If Math.Abs(Y) < eee Then Exit While
            Loop While Y < 0
            X2 = X2 - PP
        End While
        sub1010 = TT1 / (1 - Math.Log(X1) / NN1)
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s1 As String = name1.Text
        Dim s2 As String = name2.Text
        Dim s3 As String = name3.Text
        Dim t1, t2, t3, n1, n2, n3 As Integer
        Try
            t1 = Int32.Parse(temp1.Text)
            t2 = Int32.Parse(temp2.Text)
            t3 = Int32.Parse(temp3.Text)
            n1 = Int32.Parse(atoms1.Text)
            n2 = Int32.Parse(atoms2.Text)
            n3 = Int32.Parse(atoms3.Text)
        Catch ex As Exception
            MsgBox("Введите корректные данные")
        End Try
        Dim eee As Double = 0.0001
        Dim PP, X2, X1, X3, Y, TE123, X1123, X2123, X3123, X112, X212, X113, X313, X223, X323 As Double
        Dim TE12 As Double = sub1010(t1, n1, t2, n2, X112, X212)
        Dim TE13 As Double = sub1010(t1, n1, t3, n3, X113, X313)
        Dim TE23 As Double = sub1010(t2, n2, t3, n3, X223, X323)
        'Опред. состaвa и темп. плaвления эвтектики в 3-х комп.сист.

        X2 = 0 : PP = 1 : eee = 0.0001

        While True
            PP = PP / 10
            Do
                X2 = X2 + PP
                X1 = Math.Exp(n1 * (1 - t1 * (1 - Math.Log(X2) / n2) / t2))
                X3 = Math.Exp(n3 * (1 - t3 * (1 - Math.Log(X2) / n2) / t2))
                Y = X1 + X2 + X3 - 1
                If Math.Abs(Y) < eee Then Exit While
            Loop While Y < 0
            X2 = X2 - PP
        End While
        TE123 = t1 / (1 - Math.Log(X1) / n1)
        X1123 = X1 : X2123 = X2 : X3123 = X3

        '3300 LOCATE 4, 40: PRINT S1$; "-"; S2$
        '3305 LOCATE 4, 55: PRINT "X("; S1$; ")=";
        '3306 PRINT USING "###.#"; X112 * 100; : PRINT " мол.%"

        TextBox10.Text = Format((X112 * 100), "N2")

        '3310 LOCATE 5, 55: PRINT "X("; S2$; ")=";
        '3315 PRINT USING "###.#"; X212 * 100; : PRINT " мол.%"
        '3316 LOCATE 6, 55: PRINT "Te2="; : PRINT USING "####"; TE12; : PRINT " K"

        TextBox11.Text = Format((X212 * 100), "N2")
        TextBox12.Text = Format(TE12, "N2")
        '3320 LOCATE 7, 40: PRINT S1$; "-"; S3$


        '3325 LOCATE 7, 55: PRINT "X("; S1$; ")=";
        '3326 PRINT USING "###.#"; X113 * 100; : PRINT " мол.%"
        TextBox13.Text = Format((X113 * 100), "N2")

        '3330 LOCATE 8, 55: PRINT "X("; S3$; ")=";
        '3335 PRINT USING "###.#"; X313 * 100; : PRINT " мол.%"
        '3336 LOCATE 9, 55: PRINT "Te2="; : PRINT USING "####"; TE13; : PRINT " K"
        TextBox14.Text = Format((X313 * 100), "N2")
        TextBox15.Text = Format(TE13, "N2")

        '3340 LOCATE 10, 40: PRINT S2$; "-"; S3$

        '3345 LOCATE 10, 55: PRINT "X("; S2$; ")=";
        '3346 PRINT USING "###.#"; X223 * 100; : PRINT " мол.%"
        TextBox16.Text = Format((X223 * 100), "N2")
        '3350 LOCATE 11, 55: PRINT "X("; S3$; ")=";
        '3355 PRINT USING "###.#"; X323 * 100;
        '3356 PRINT " мол.%": LOCATE 12, 55: PRINT "Te2=";
        '3357 PRINT USING "####"; TE23; : PRINT " K"
        TextBox17.Text = Format((X323 * 100), "N2")
        TextBox18.Text = Format(TE23, "N2")

        '3370 LOCATE 14, 55: PRINT S1$; "-"; S2$; "-"; S3$

        '3380 LOCATE 15, 55: PRINT "X("; S1$; ")=";
        '3385 PRINT USING "###.#"; X1123 * 100; : PRINT " мол.%"
        TextBox19.Text = Format((X1123 * 100), "N2")

        '3386 LOCATE 16, 55: PRINT "X("; S2$; ")="; : PRINT USING "###.#"; X2123 * 100; : PRINT " мол.%"
        TextBox20.Text = Format((X2123 * 100), "N2")
        '3390 LOCATE 17, 55: PRINT "X("; S3$; ")=";

        '3395 PRINT USING "###.#"; X3123 * 100; : PRINT " мол.%"
        TextBox21.Text = Format((X3123 * 100), "N2")

        '3400 LOCATE 18, 55: PRINT "Te3="; : PRINT USING "####"; TE123; : PRINT " K"
        TextBox22.Text = Format(TE123, "N2")

        '3420:   LOCATE(5, 30) : Print(s2$)
        '3425:   LOCATE(22, 12) : Print(s1$) : LOCATE(22, 50) : Print(s3$)



        Dim Triangle, pText As Graphics
        Triangle = PictureBox1.CreateGraphics
        pText = PictureBox1.CreateGraphics
        Triangle.Clear(PictureBox1.BackColor)

        Triangle.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim font As New System.Drawing.Font("Tahoma", 10)
        Dim font2 As New System.Drawing.Font("Tahoma", 7)
        Dim tA, tB, tC As String
        tA = name1.Text
        tB = name2.Text
        tC = name3.Text
        pText.DrawString(tA, font, Brushes.Red, 10, PictureBox1.Height - 20)
        pText.DrawString(tB, font, Brushes.Red, PictureBox1.Width / 2 - 15, 5)
        pText.DrawString(tC, font, Brushes.Red, PictureBox1.Width - 40, PictureBox1.Width - 20)


        Dim pSS, pCC, pX1, pX2, pX3, pY1, pY2, pY3, pBh, pBw, pXAB, pYAB, pXABC, pYABC, pXAC, pYAC, pXBC, pYBC, tX112, tX113, tX223, tX212, tX313, tX323 As Single

        'Размеры треугольника
        pSS = Math.Sqrt(3) / 2
        pCC = 0.5

        pX1 = 0
        pX2 = 320
        pX3 = 160
        pY1 = 277.13
        pY2 = 277.13
        pY3 = 0

        X112 = X1 : X212 = X2
        X113 = X1 : X313 = X2
        X223 = X1 : X323 = X2

        'Рисуем треугольник
        Triangle.DrawLine(Pens.Black, pX1, pY1, pX2, pY2)
        Triangle.DrawLine(Pens.Black, pX1, pY1, pX3, pY3)
        Triangle.DrawLine(Pens.Black, pX2, pY2, pX3, pY3)


        pXAB = 0 + 320 * X2123 * pCC
        pYAB = 277.13 - (320 * X212 * pSS)

        pXAC = 0 + 320 * X313
        pYAC = 277.13

        pXBC = 320 - 320 * X223 * pCC
        pYBC = 277.13 - (320 * X223 * pSS)

        pXABC = 0 + 320 * X2123 * pCC + 320 * X3123
        pYABC = 277.13 - (320 * X2123 * pSS)









        Triangle.DrawLine(Pens.Black, pXAB, pYAB, pXABC, pYABC)
        Triangle.DrawLine(Pens.Black, pXAC, pYAC, pXABC, pYABC)
        Triangle.DrawLine(Pens.Black, pXBC, pYBC, pXABC, pYABC)
        Dim redBrush As New SolidBrush(Color.Black)

        Triangle.FillEllipse(redBrush, pXABC - 2, pYABC - 2, 6, 6)
        pText.DrawString("TE123 = " & Format(TE123, "#.##") & " K", font2, Brushes.Green, pXABC, pYABC - 17)

        Triangle.FillEllipse(redBrush, pXAB - 2, pYAB - 2, 6, 6)
        pText.DrawString("TE1 = " & Format(TE12, "#.##") & " K", font2, Brushes.Green, pXAB - 48, pYAB - 17)
        pText.Dispose()


    End Sub

    Private Sub name1_TextChanged(sender As Object, e As EventArgs) Handles name1.TextChanged
        name1_answer.Text = name1.Text + " - " + name2.Text
        name2_answer.Text = name1.Text + " - " + name3.Text
        name3_answer.Text = name2.Text + " - " + name3.Text
        name123_answer.Text = name1.Text + " - " + name2.Text + " - " + name3.Text
        X12_1.Text = name1.Text
        X12_2.Text = name2.Text
        X13_1.Text = name1.Text
        X13_2.Text = name3.Text
        X23_1.Text = name2.Text
        X23_2.Text = name3.Text
        X123_1.Text = name1.Text
        X123_2.Text = name2.Text
        X123_3.Text = name3.Text
    End Sub

    Private Sub name2_TextChanged(sender As Object, e As EventArgs) Handles name2.TextChanged
        name1_answer.Text = name1.Text + " - " + name2.Text
        name2_answer.Text = name1.Text + " - " + name3.Text
        name3_answer.Text = name2.Text + " - " + name3.Text
        name123_answer.Text = name1.Text + " - " + name2.Text + " - " + name3.Text
        X12_1.Text = name1.Text
        X12_2.Text = name2.Text
        X13_1.Text = name1.Text
        X13_2.Text = name3.Text
        X23_1.Text = name2.Text
        X23_2.Text = name3.Text
        X123_1.Text = name1.Text
        X123_2.Text = name2.Text
        X123_3.Text = name3.Text
    End Sub

    Private Sub name3_TextChanged(sender As Object, e As EventArgs) Handles name3.TextChanged
        name1_answer.Text = name1.Text + " - " + name2.Text
        name2_answer.Text = name1.Text + " - " + name3.Text
        name3_answer.Text = name2.Text + " - " + name3.Text
        name123_answer.Text = name1.Text + " - " + name2.Text + " - " + name3.Text
        X12_1.Text = name1.Text
        X12_2.Text = name2.Text
        X13_1.Text = name1.Text
        X13_2.Text = name3.Text
        X23_1.Text = name2.Text
        X23_2.Text = name3.Text
        X123_1.Text = name1.Text
        X123_2.Text = name2.Text
        X123_3.Text = name3.Text
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        name1_answer.Text = name1.Text + " - " + name2.Text
        name2_answer.Text = name1.Text + " - " + name3.Text
        name3_answer.Text = name2.Text + " - " + name3.Text
        name123_answer.Text = name1.Text + " - " + name2.Text + " - " + name3.Text
        X12_1.Text = name1.Text
        X12_2.Text = name2.Text
        X13_1.Text = name1.Text
        X13_2.Text = name3.Text
        X23_1.Text = name2.Text
        X23_2.Text = name3.Text
        X123_1.Text = name1.Text
        X123_2.Text = name2.Text
        X123_3.Text = name3.Text
    End Sub

    Private Sub ВыходИзПрограммыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходИзПрограммыToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        name1.Text = "A"
        name2.Text = "B"
        name3.Text = "C"

        temp1.Text = "0"
        temp2.Text = "0"
        temp3.Text = "0"

        atoms1.Text = "0"
        atoms2.Text = "0"
        atoms3.Text = "0"

        For Each C As Control In GroupBox2.Controls
            If TypeOf C Is TextBox Then
                C.Text = ""
            End If
        Next

        PictureBox1.Image = Nothing
    End Sub

    Private Sub ОПрограммеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОПрограммеToolStripMenuItem.Click
        about.ShowDialog()
        Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
