﻿Imports System.Object
Imports System.Reflection.Assembly
Imports System.Reflection

Public Class about
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://chefranov.name")
    End Sub

    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Eutektika " + Application.ProductVersion
    End Sub
End Class