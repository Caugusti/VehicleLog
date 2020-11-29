VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} newVehicle 
   Caption         =   "New Vehicle"
   ClientHeight    =   8544.001
   ClientLeft      =   108
   ClientTop       =   456
   ClientWidth     =   10116
   OleObjectBlob   =   "newVehicle.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "newVehicle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub clearButton_Click()

LocationsInit.Text = ""
VehTypeInit.Text = ""
ModelInit.Text = ""
TAGInit.Text = ""
YearInit.Text = ""
    
gasolineFuel.Value = False
ethanolFuel.Value = False
flexFuel.Value = False
dieselFuel.Value = False
    
EngineInit.Text = ""
PowerInit.Text = ""
WeightInit.Text = ""
ColorInit.Text = ""
responsibleInit.Text = ""
commentsInit.Text = ""

End Sub

Private Sub saveButton_Click()

With Sheets("Active DB")

    .Rows(5).Insert

    .Cells(5, 1).Value = Date                               ' Registration Date
    .Cells(5, 2).Value = Time()                             ' Registration Time
    .Cells(5, 3).Value = LocationsInit.Text      ' FORD Locations
    .Cells(5, 4).Value = VehTypeInit.Text        ' Vehicle Type
    .Cells(5, 5).Value = ModelInit.Text          ' Vehicle Model
    .Cells(5, 6).Value = TAGInit.Text            ' Vehicle TAG
    .Cells(5, 7).Value = YearInit.Text           ' Year
    
    If gasolineFuel.Value = True Then            ' Fuel Type
        .Cells(5, 8).Value = "Gasoline"
    
    ElseIf ethanolFuel.Value = True Then
        .Cells(5, 8).Value = "Ethanol"
    
    ElseIf flexFuel.Value = True Then
        .Cells(5, 8).Value = "Flex"
    
    ElseIf dieselFuel.Value = True Then
        .Cells(5, 8).Value = "Diesel"
    
    End If
    
    .Cells(5, 9).Value = EngineInit.Text         ' Vehicle Engine
    .Cells(5, 10).Value = PowerInit.Text         ' Vehicle Power
    .Cells(5, 11).Value = WeightInit.Text        ' Vehicle Weight
    .Cells(5, 12).Value = ColorInit.Text         ' Vehicle Color
    .Cells(5, 13).Value = responsibleInit.Text   ' Responsible
    .Cells(5, 14).Value = Date                              ' Last Update Date
    .Cells(5, 15).Value = Time()                            ' Last Update Time
    .Cells(5, 16).Value = "Active"                          ' Status
    .Cells(5, 17).Value = commentsInit.Text      ' Comments

End With

With Sheets("Full DB")

    .Rows(5).Insert

    .Cells(5, 1).Value = Date                               ' Registration Date
    .Cells(5, 2).Value = Time()                             ' Registration Time
    .Cells(5, 3).Value = LocationsInit.Text      ' FORD Locations
    .Cells(5, 4).Value = VehTypeInit.Text        ' Vehicle Type
    .Cells(5, 5).Value = ModelInit.Text          ' Vehicle Model
    .Cells(5, 6).Value = TAGInit.Text            ' Vehicle TAG
    .Cells(5, 7).Value = YearInit.Text           ' Year
    
    If gasolineFuel.Value = True Then            ' Fuel Type
        .Cells(5, 8).Value = "Gasoline"
    
    ElseIf ethanolFuel.Value = True Then
        .Cells(5, 8).Value = "Ethanol"
    
    ElseIf flexFuel.Value = True Then
        .Cells(5, 8).Value = "Flex"
    
    ElseIf dieselFuel.Value = True Then
        .Cells(5, 8).Value = "Diesel"
    
    End If
    
    .Cells(5, 9).Value = EngineInit.Text         ' Vehicle Engine
    .Cells(5, 10).Value = PowerInit.Text         ' Vehicle Power
    .Cells(5, 11).Value = WeightInit.Text        ' Vehicle Weight
    .Cells(5, 12).Value = ColorInit.Text         ' Vehicle Color
    .Cells(5, 13).Value = responsibleInit.Text   ' Responsible
    .Cells(5, 14).Value = Date                              ' Last Update Date
    .Cells(5, 15).Value = Time()                            ' Last Update Time
    .Cells(5, 16).Value = "Active"                          ' Status
    .Cells(5, 17).Value = commentsInit.Text      ' Comments

End With

LocationsInit.Text = ""
VehTypeInit.Text = ""
ModelInit.Text = ""
TAGInit.Text = ""
YearInit.Text = ""
    
gasolineFuel.Value = False
ethanolFuel.Value = False
flexFuel.Value = False
dieselFuel.Value = False
    
EngineInit.Text = ""
PowerInit.Text = ""
WeightInit.Text = ""
ColorInit.Text = ""
responsibleInit.Text = ""
commentsInit.Text = ""

MsgBox "Registration complete."

End Sub

Private Sub UserForm_Activate()

lin1 = 2
lin2 = 2

Do While Sheets("Configuration").Cells(lin1, 1) <> ""

    LocationsInit.AddItem Sheets("Configuration").Cells(lin1, 1).Value
    
    lin1 = lin1 + 1

Loop

Do While Sheets("Configuration").Cells(lin2, 2) <> ""

    VehTypeInit.AddItem Sheets("Configuration").Cells(lin2, 2).Value
    
    lin2 = lin2 + 1

Loop

End Sub

