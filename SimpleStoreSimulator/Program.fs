module Program

open System.Windows.Forms
open GuiModule
open EventHandlersModule
open ProductModule
open CartModule

// Populate product list
products |> List.iter (fun p -> 
    productList.Items.Add($"{p.Name} - ${p.Price}: {p.Description}") |> ignore
)

// Add controls to the form
form.Controls.AddRange [| productList; cartList; addButton; openCartButton |]

// Add event handlers
addEventHandlers fadeTimer form addButton openCartButton cartList products

// Run the application
[<EntryPoint>]
let main _ =
    fadeTimer.Start()
    Application.Run(form)
    0


