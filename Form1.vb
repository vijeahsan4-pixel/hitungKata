Imports System.IO

Public Class Form1
    ' Procedure (Sub) untuk menghitung jumlah kata dalam sebuah string
    Private Sub HitungKata(ByVal teks As String, ByRef totalKata As Integer, ByRef kataPanjang As Integer)
        ' Split teks menjadi array kata berdasarkan spasi
        Dim kataArray() As String = teks.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

        ' Perulangan: Loop melalui setiap kata
        For Each kata As String In kataArray
            totalKata += 1  ' Hitung total kata

            ' Percabangan: Jika panjang kata > 5, hitung sebagai kata panjang
            If kata.Length > 5 Then
                kataPanjang += 1
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Membuat OpenFileDialog untuk memilih file
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        openFileDialog.Title = "Pilih File Teks"

        If openFileDialog.ShowDialog = DialogResult.OK Then
            ' Tampilkan path file di TextBox1
            TextBox1.Text = openFileDialog.FileName

            ' Membaca file (menggunakan StreamReader)
            Dim totalKata = 0
            Dim kataPanjang = 0

            Try
                Using reader As New StreamReader(openFileDialog.FileName)
                    Dim line As String
                    ' Perulangan: Baca baris per baris
                    Do While reader.Peek >= 0
                        line = reader.ReadLine
                        ' Panggil procedure untuk menghitung kata di setiap baris
                        HitungKata(line, totalKata, kataPanjang)
                    Loop
                End Using

                ' Tampilkan hasil di TextBox2
                TextBox2.Text = $"Total Kata: {totalKata}" & vbCrLf &
                                $"Kata dengan Panjang > 5 Huruf: {kataPanjang}"
            Catch ex As Exception
                MessageBox.Show("Error membaca file: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class