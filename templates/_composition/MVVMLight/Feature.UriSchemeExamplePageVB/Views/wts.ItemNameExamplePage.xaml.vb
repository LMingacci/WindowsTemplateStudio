﻿Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Navigation
Imports Param_ItemNamespace.ViewModels

Namespace Views
    ' TODO WTS: This page exists purely as an example of how to launch a specific page in response to a protocol launch and pass it a value. It is expected that you will delete this page once you have changed the handling of a protocol launch to meet your needs and redirected to another of your pages.
    Partial Public NotInheritable Class wts.ItemNameExamplePage
        Inherits Page
        Private ReadOnly Property ViewModel As wts.ItemNameExampleViewModel
            Get
                Return TryCast(DataContext, wts.ItemNameExampleViewModel)
            End Get
        End Property

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)

            ' Capture the passed in value and assign it to a property that's displayed on the view
            ViewModel.Secret = e.Parameter.ToString
        End Sub
    End Class
End Namespace
