Public Class Eutektika123


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

    Private Function chk(ByVal T As TextBox) As Boolean
        Dim separator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator(0)
        Dim s As String = T.Text.Replace(".", separator) : T.BackColor = Color.White : T.Text = s : chk = True
        If Not IsNumeric(s) Then
            MessageBox.Show("В поле ввода следует вводить числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            T.Clear() : T.Focus() : T.BackColor = Color.Bisque
            Return False
        End If
        If s < 1 Then
            MessageBox.Show("Значение не может быть меньше единицы", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            T.Clear() : T.Focus() : T.BackColor = Color.Bisque
            Return False
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For k As Integer = 1 To 3
            If Not chk(Me.GroupBox1.Controls("temp" & k)) Then Exit Sub
        Next

        For k As Integer = 1 To 3
            If Not chk(Me.GroupBox1.Controls("atoms" & k)) Then Exit Sub
        Next

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

        TextBox10.Text = Format((X112 * 100), "N2")

        TextBox11.Text = Format((X212 * 100), "N2")
        TextBox12.Text = Format(TE12, "N2")

        TextBox13.Text = Format((X113 * 100), "N2")

        TextBox14.Text = Format((X313 * 100), "N2")
        TextBox15.Text = Format(TE13, "N2")

        TextBox16.Text = Format((X223 * 100), "N2")

        TextBox17.Text = Format((X323 * 100), "N2")
        TextBox18.Text = Format(TE23, "N2")

        TextBox19.Text = Format((X1123 * 100), "N2")

        TextBox20.Text = Format((X2123 * 100), "N2")

        TextBox21.Text = Format((X3123 * 100), "N2")

        TextBox22.Text = Format(TE123, "N2")

        draw(X212, X313, X223, X2123, X3123)

        Button2.Enabled = True

        GroupBox2.Enabled = True

    End Sub

    Sub draw(ByVal X212 As Double, ByVal X313 As Double, ByVal X223 As Double, ByVal X2123 As Double, ByVal X3123 As Double)

        Dim BM As New Bitmap(PictureBox1.Width, PictureBox1.Height, Drawing.Imaging.PixelFormat.Format24bppRgb)

        Dim g As System.Drawing.Graphics = Graphics.FromImage(BM)
        g.Clear(PictureBox1.BackColor)      'Очищаем PictureBox от предыдущего рисунка

        'Задаем качество рисунку
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

        'Параметры пера
        Dim pen As New System.Drawing.Pen(System.Drawing.Color.Black, 1)
        Dim pen3 As New System.Drawing.Pen(System.Drawing.Color.Black, 2)

        Dim SS, CC As Double
        Dim X3, Y3, Y1, Y2, X2, X1, XAB, XAC, XBC, XABC, YAB, YAC, YBC, YABC As Single

        'Рассчитываем треугольник
        SS = Math.Sqrt(3) / 2
        CC = 0.5
        X1 = 30 : Y1 = 150
        X2 = 330 : Y2 = 150
        X3 = 180 : Y3 = 150 - 300 * SS / 2.3



        'Расчитываем точки эвтектик на треугольнике
        XAB = 30 + 300 * X212 * CC : YAB = 150 - (300 * X212 * SS) / 2.3
        XAC = 30 + 300 * X313 : YAC = 150
        XBC = 330 - 300 * X223 * CC : YBC = 150 - (300 * X223 * SS) / 2.3
        XABC = 30 + 300 * X2123 * CC + 300 * X3123 : YABC = 150 - (300 * X2123 * SS) / 2.3

        If CheckBox4.Checked Then
            Dim pBrush1 As New SolidBrush(Color.PaleTurquoise)
            Dim pBrush2 As New SolidBrush(Color.LightGreen)
            Dim pBrush3 As New SolidBrush(Color.LightSalmon)

            ' Create points that define polygon.
            Dim pointA1 As New Point(30, 250)
            Dim pointA2 As New Point(XAB, YAB * 2 - 50)
            Dim pointA3 As New Point(XABC, YABC * 2 - 50)
            Dim pointA4 As New Point(XAC, YAC * 2 - 50)
            Dim curvePointsA As Point() = {pointA1, pointA2, pointA3, pointA4}

            Dim pointB1 As New Point(XAB, YAB * 2 - 50)
            Dim pointB2 As New Point(180, 26)
            Dim pointB3 As New Point(XBC, YBC * 2 - 50)
            Dim pointB4 As New Point(XABC, YABC * 2 - 50)
            Dim curvePointsB As Point() = {pointB1, pointB2, pointB3, pointB4}

            Dim pointC1 As New Point(XBC, YBC * 2 - 50)
            Dim pointC2 As New Point(330, Y2 * 2 - 50)
            Dim pointC3 As New Point(XAC, YAC * 2 - 50)
            Dim pointC4 As New Point(XABC, YABC * 2 - 50)
            Dim curvePointsC As Point() = {pointC1, pointC2, pointC3, pointC4}

            ' Draw polygon to screen.
            g.FillPolygon(pBrush1, curvePointsA)
            g.FillPolygon(pBrush2, curvePointsB)
            g.FillPolygon(pBrush3, curvePointsC)
        End If

        'Рисуем треугольник
        g.DrawLine(pen3, X1, Y1 * 2 - 50, X2, Y2 * 2 - 50)
        g.DrawLine(pen3, X1, Y1 * 2 - 50, X3, Y3 * 2 - 50)
        g.DrawLine(pen3, X2, Y2 * 2 - 50, X3, Y3 * 2 - 50)

        'Рисуем центральные линии
        g.DrawLine(pen, XAB, YAB * 2 - 50, XABC, YABC * 2 - 50)
        g.DrawLine(pen, XAC, YAC * 2 - 50, XABC, YABC * 2 - 50)
        g.DrawLine(pen, XBC, YBC * 2 - 50, XABC, YABC * 2 - 50)

        'Текстовые метки
        Dim fnt As New System.Drawing.Font("Tahoma", 6)
        Dim fnt2 As New System.Drawing.Font("Tahoma", 10)

        Dim str1 As String = name1.Text
        Dim strSize1 As SizeF = g.MeasureString(str1, fnt2)
        Dim str2 As String = name2.Text
        Dim strSize2 As SizeF = g.MeasureString(str2, fnt2)
        Dim str3 As String = name3.Text
        Dim strSize3 As SizeF = g.MeasureString(str3, fnt2)




        If CheckBox1.Checked Then
            'Температуры на графике
            g.DrawString(TextBox12.Text + " K", fnt, Brushes.Brown, XAB + 2, YAB * 2 - 50)
            g.DrawString(TextBox15.Text + " K", fnt, Brushes.Brown, XAC + 2, YAC * 2 - 50 + 4)
            g.DrawString(TextBox18.Text + " K", fnt, Brushes.Brown, XBC + 7, YBC * 2 - 50 - 5)
            g.DrawString(TextBox22.Text + " K", fnt, Brushes.Brown, XABC + 5, YABC * 2 - 50)
        End If

        If CheckBox2.Checked Then
            'Точки
            Dim DotBrush As New SolidBrush(Color.Black)
            g.FillEllipse(DotBrush, XAC - 3, YAC * 2 - 50 - 3, 5, 5)
            g.FillEllipse(DotBrush, XAB - 3, YAB * 2 - 50 - 3, 5, 5)
            g.FillEllipse(DotBrush, XBC - 3, YBC * 2 - 50 - 3, 5, 5)
            g.FillEllipse(DotBrush, XABC - 3, YABC * 2 - 50 - 3, 5, 5)
        End If

        If CheckBox3.Checked Then
            'Название соединений
            g.DrawString(str1, fnt2, Brushes.Black, 30 - strSize1.Width / 2, 250 + 5) 'X1
            g.DrawString(str2, fnt2, Brushes.Black, 180 - strSize2.Width / 2, Y3 * 2 - 70) 'X2
            g.DrawString(str3, fnt2, Brushes.Black, 330 - strSize3.Width / 2, 250 + 5) 'X3
        End If


        PictureBox1.Image = BM
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

        Button2.Enabled = False
        GroupBox2.Enabled = False
    End Sub

    Private Sub ВыходИзПрограммыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходИзПрограммыToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub ОПрограммеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОПрограммеToolStripMenuItem.Click
        about.ShowDialog()
        Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "PNG|*.png|JPG|*.jpg|GIF|*.gif"
        If saveFileDialog1.ShowDialog = DialogResult.Cancel Then Exit Sub
        PictureBox1.Image.Save(saveFileDialog1.FileName)
        MessageBox.Show("Изображение успешно сохранено", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ЗагрузитьДанныеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗагрузитьДанныеToolStripMenuItem.Click
        Dim OpenFileDialog1 As New OpenFileDialog()
        OpenFileDialog1.Filter = "Файлы эвтектики (*.edata)|*.edata|Все файлы (*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub

        Dim fileReader() As String
        fileReader = IO.File.ReadAllText(OpenFileDialog1.FileName, System.Text.Encoding.Default).Split("|")
        name1.Text = fileReader(0)
        name2.Text = fileReader(1)
        name3.Text = fileReader(2)
        temp1.Text = fileReader(3)
        temp2.Text = fileReader(4)
        temp3.Text = fileReader(5)
        atoms1.Text = fileReader(6)
        atoms2.Text = fileReader(7)
        atoms3.Text = fileReader(8)
    End Sub

    Private Sub СохранитьДанныеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СохранитьДанныеToolStripMenuItem.Click
        Dim saveFileDialog2 As New SaveFileDialog()
        saveFileDialog2.Filter = "Файл эвтектики (*.edata)|*.edata"
        If saveFileDialog2.ShowDialog = DialogResult.Cancel Then Exit Sub
        IO.File.WriteAllText(saveFileDialog2.FileName, "")
        My.Computer.FileSystem.WriteAllText(saveFileDialog2.FileName, name1.Text + "|" + name2.Text + "|" + name3.Text + "|" + temp1.Text + "|" + temp2.Text + "|" + temp3.Text + "|" + atoms1.Text + "|" + atoms2.Text + "|" + atoms3.Text, True)
        MessageBox.Show("Файл успешно сохранён", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub НовыйФайлToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НовыйФайлToolStripMenuItem.Click
        For Each C As Control In Me.GroupBox2.Controls
            If TypeOf C Is TextBox Then
                C.Text = ""
            End If
        Next
        PictureBox1.Image = Nothing
        Button2.Enabled = False
        GroupBox2.Enabled = False
        temp1.Text = 1000
        temp2.Text = 1000
        temp3.Text = 1000
        atoms1.Text = 10
        atoms2.Text = 10
        atoms3.Text = 10
    End Sub
End Class
