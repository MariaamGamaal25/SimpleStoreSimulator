module GuiModule

open System.Windows.Forms
open System.Drawing

// Create the main form
let form = new Form(Text = "Simple Store Simulator", Width = 800, Height = 400)
form.BackColor <- Color.LightGray
form.Opacity <- 0.0

// Timer for the fade-in effect
let fadeTimer = new Timer(Interval = 50)

// Create the product list
let productList = new ListBox(Top = 20, Left = 20, Width = 300, Height = 150)
productList.BackColor <- Color.White
productList.BorderStyle <- BorderStyle.Fixed3D

// Create the cart list
let cartList = new ListBox(Top = 20, Left = 350, Width = 300, Height = 150)
cartList.BackColor <- Color.White
cartList.BorderStyle <- BorderStyle.Fixed3D

// Create the buttons
let addButton = new Button(Text = "Add to Cart", Top = 200, Left = 300, Width = 100)
let openCartButton = new Button(Text = "Open Cart", Top = 240, Left = 300, Width = 100)



// Helper function to style buttons
let styleButton (button: Button) (color: Color) =
    button.BackColor <- color
    button.ForeColor <- Color.White
    button.FlatStyle <- FlatStyle.Popup
    button.FlatAppearance.BorderSize <- 0
    button.Font <- new Font("Arial", 12.0f, FontStyle.Regular)
    button

// Style the buttons
styleButton addButton Color.DeepPink |> ignore
styleButton openCartButton Color.DeepPink |> ignore

// Add the buttons to the form's controls

form.Controls.AddRange([| productList; cartList; addButton; openCartButton;|])


// Expose these elements to other modules


